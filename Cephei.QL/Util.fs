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

    let withEngine (e : IPricingEngine) (priced : 'priced when 'priced :> LazyObject) = 
        let lo = priced :> LazyObject
        match lo with 
        | :? Instrument as i         -> i.setPricingEngine e
        | :? CalibrationHelper  as c -> c.setPricingEngine e
        | _                          -> e |> ignore
        priced

    let withEvaluationDate (d : ICell<Date>) (i : ICell<'i>) = 
        Settings.setEvaluationDate (d.Value)
        i.Value

    let toGeneric (l : 'i list) : Generic.List<'i> =
        new Generic.List<'i> (l)

