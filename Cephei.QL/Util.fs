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
open System

module Util = 
    // Summary: create a value that notifies other cells when the value changes
    let value v = Cell.CreateFastValue (v)

    // Summary: run calcualtions within in the background
    let cell (f : unit -> 'f) = Cell.CreateFast (f)

    // cretate a trivial cell
    let triv (f : unit -> 'f) = Cell.CreateTrivial (f)

    // Summary: variant of lazy evaluation where the value is claculated on a background thread
    let future (f : unit -> 'f) = 
        let r = lazy f
        async { r.Value |> ignore } |> Async.StartAsTask |> ignore
        r

    let withEngine (e : ICell<IPricingEngine>) (priced : 'priced when 'priced :> LazyObject) = 
        let lo = priced :> LazyObject
        match lo with 
        | :? Instrument as i         -> i.setPricingEngine e.Value
        | :? CalibrationHelper  as c -> c.setPricingEngine e.Value
        | _                          -> e |> ignore
        priced

    let withEvaluationDate<'i when 'i :> LazyObject> (d : ICell<Date>) (i : ICell<'i>) = 
        Settings.setEvaluationDate (d.Value)
        i.Value.update()
        i.Value

    let toGeneric (l : 'i list) : Generic.List<'i> =
        new Generic.List<'i> (l)

    let toCellList (l : ICell<'c> seq) =
        new Cephei.Cell.List<'c> (l)

    let toHandle<'T when 'T :> IObservable> (v : 'T) =
        new Handle<'T> (v)

    let toNullable<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> (v : 'T) = 
        Nullable<'T> (v)

    let nullableNull<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> () = 
        Nullable<'T> ()

// Summary: Time lapse value
type TimeLapse<'t> (reference : ICell<'t>, lapse : ICell<double>) as this = 
    inherit Model<'t> ()

    let _queue  = new Generic.Queue<Generic.KeyValuePair<DateTime,'t>> ()

    let mutable _reference = reference
    let mutable _lapse = lapse
    let mutable _span = Util.cell (fun () -> TimeSpan.FromSeconds(_lapse.Value))

    let at (span : TimeSpan) (now : DateTime) (current : 't) = 
        System.Threading.Monitor.Enter _queue
        try
            _queue.Enqueue (new Generic.KeyValuePair<DateTime,'t> (now, current))
            let peek = _queue.Peek()
            if peek.Key.Add(span) >= now then 
                peek.Value
            else
                while (_queue.Peek().Key.Add(span) < now) do ignore (_queue.Dequeue())
                _queue.Peek().Value
        finally
            System.Threading.Monitor.Exit _queue

    let _value = Util.cell (fun () -> at _span.Value DateTime.Now _reference.Value)

    do this.Bind(_value)

    member this.Value = _value
    member this.Reference = _reference 
    member this.Lapse = _lapse
    member this.Span = _span


