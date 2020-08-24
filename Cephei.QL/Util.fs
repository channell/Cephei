(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.QL

open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open QLNet

module Util = 
    // Summary: create a value that notifies other cells when the value changes
    let value v = Cell.CreateValue (v)

    // Summary: run calcualtions within in the background
    let cell (f : unit -> 'f) = Cell.Create (f)

    // cretate a trivial cell
    let triv (f : unit -> 'f) = Cell.CreateTrivial (f);

    // Summary: variant of lazy evaluation where the value is claculated on a background thread
    let future (f : unit -> 'f) = 
        let r = lazy f
        async { r.Value |> ignore } |> Async.StartAsTask |> ignore
        r

    let withEngine (d : ICell<Date>) (e : ICell<IPricingEngine>) (priced : 'priced when 'priced :> LazyObject) = 
        let aref = d.Value;
        let lo = priced :> LazyObject
        match lo with 
        | :? Instrument as i         -> i.setPricingEngine e.Value
        | :? CalibrationHelper  as c -> c.setPricingEngine e.Value
        | _                          -> e |> ignore
        priced
(*
    let withEvaluationDate<'i when 'i :> LazyObject> (d : ICell<Date>) (i : ICell<'i>) = 
        let lo = i.Value :> LazyObject
        lock i (fun () -> Settings.setEvaluationDate (d.Value)
                          lo.update ())
        i.Value
*)
    let withEvaluationDate<'i when 'i :> LazyObject> (d : ICell<Date>) (i : ICell<'i>) = 
        if not (Settings.evaluationDate() = d.Value) then
            Settings.setEvaluationDate (d.Value)
        i.Value

    let toGeneric (l : 'i list) : Generic.List<'i> =
        new Generic.List<'i> (l)

    let toCellList (l : ICell<'c> seq) =
        new Cephei.Cell.List<'c> (l)

