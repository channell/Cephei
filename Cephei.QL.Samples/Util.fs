namespace Cephei

open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open QLNet

module Util = 
    // Summary: create a value that notifies other cells when the value changes
    let value v = Cell.CreateValue (v)

    // Summary: run calcualtions within in the background
    let cell (f : unit -> 'f) = Cell.Create (f)

    let trivial (f : unit -> 'f) = Cell.CreateTrivial (f)

    // Summary: variant of lazy evaluation where the value is claculated on a background thread
    let future (f : unit -> 'f) = 
        let r = lazy f
        async { r.Value |> ignore } |> Async.StartAsTask |> ignore
        r

    let withEngine (e : IPricingEngine) (i : 'i)   = 
        (i :> Instrument).setPricingEngine (e)
        i
    let withEvaluationDate (d : ICell<Date>) (i : ICell<'i>) = 
        Settings.setEvaluationDate (d.Value)
        i.Value

    let toGeneric (l : 'i list) : Generic.List<'i> =
        new Generic.List<'i> (l)
