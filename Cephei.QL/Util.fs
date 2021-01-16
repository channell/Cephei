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
open System.Runtime.CompilerServices
open System.Threading

// Summary : Date dependant models need to have the evaluation date injected
type IDateDependant =

    abstract EvaluationDate : Cephei.Cell.Generic.ICell<QLNet.Date> with get, set

type DateDependantTrivial<'T> (f : unit -> 'T, d : ICell<Date>) =

    inherit CellTrivial<'T> (f)

    let mutable _evaluationDate = d

    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d        

module Util = 
    // Summary: create a value that notifies other cells when the value changes
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let value v = Cell.CreateFastValue (v)

    // Summary: run calcualtions within in the background
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let make (f : unit -> 'f) = Cell.CreateFast (f) 

    // Summary: run calcualtions within in the background
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let cell (mutex : ICell) (f : unit -> 'f) = Cell.CreateFast (f, null) 

    // Summary: run calcualtions within in the background with a mutex
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let celm (mutex : ICell) (f : unit -> 'f) = Cell.CreateFast (f, mutex) 

    // cretate a trivial cell
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let triv (mutex : ICell) (f : unit -> 'f) = Cell.CreateTrivial (f, null)

    // cretate a trivial cell using mutex lock
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let trvm (mutex : ICell) (f : unit -> 'f) = Cell.CreateTrivial (f, mutex)

    // cretate a lazy cell
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let lcel (mutex : ICell) (f : unit -> 'f) = Cell.CreateLazy (f, null)

    // cretate a lazy cell using mutex lock
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
    let lclm (mutex : ICell) (f : unit -> 'f) = Cell.CreateLazy (f, mutex)

    let trivDate (f : unit -> 'f) (d : IDateDependant) = 
        new DateDependantTrivial<'f> (f, d.EvaluationDate) :> ICell<'f>

    // Summary: variant of lazy evaluation where the value is claculated on a background thread
    let future (f : unit -> 'f) = 
        let r = lazy f
        async { r.Value |> ignore } |> Async.StartAsTask |> ignore
        r

    let withEngine (e : ICell<IPricingEngine>) (d : ICell<Date>) (priced : 'priced when 'priced :> LazyObject) = 
        let lo = priced :> LazyObject
        if not (d = null) then Settings.setEvaluationDate (d.Value)
        if not (e = null) then 
            match lo with 
            | :? Instrument as i         -> i.setPricingEngine e.Value
//                                            i.recalculate()
            | :? CalibrationHelper  as c -> c.setPricingEngine e.Value
            | _                          -> e |> ignore
        priced

    let withEvaluationDate<'i when 'i :> LazyObject> (d : ICell<Date>) (i : ICell<'i>) = 
        if not (d = null) then 
            Settings.setEvaluationDate (d.Value)
        i.Value.update()
        i.Value

    let curryEvaluationDate (d : ICell<Date>) i = 
        if not (d = null) then 
            Settings.setEvaluationDate (d.Value)
        i

#if !DEBUG
    [<MethodImpl(MethodImplOptions.AggressiveInlining)>]
#endif
    let createEvaluationDate (d: ICell<Date>) (f : unit -> 'f) = 
        if not (d = null) then
            Settings.setEvaluationDate (d.Value)
        f ()

    let toGeneric (l : 'i list) : Generic.List<'i> =
        new Generic.List<'i> (l)

    let toCellList (l : ICell<'c> seq) =
        new Cephei.Cell.List<'c> (l)

    let toHandle<'T when 'T :> IObservable> (v : 'T) =
        let h = new RelinkableHandle<'T> (v)
        h.linkTo (v)    
        h :> Handle<'T>

    let toNullable<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> (v : 'T) = 
        Nullable<'T> (v)

    let nullableNull<'T when 'T :struct and 'T :> ValueType and 'T : (new : unit -> 'T)> () = 
        Nullable<'T> ()

// Summary: Time lapse value
type Delay<'t> (reference : ICell<'t>, lapse : ICell<double>) as this = 
    inherit Model<'t> ()

    let _queue  = new Generic.Queue<Generic.KeyValuePair<DateTime,'t>> ()

    let mutable _reference = reference
    let mutable _lapse = lapse
    let mutable _span = Util.cell null (fun () -> TimeSpan.FromSeconds(_lapse.Value))

    let at (span : TimeSpan) (now : DateTime) (current : 't) = 
        System.Threading.Monitor.Enter _queue
        try
            try
                _queue.Enqueue (new Generic.KeyValuePair<DateTime,'t> (now, current))
                let peek = _queue.Peek()
                if peek.Key.Add(span) >= now then 
                    peek.Value
                else
                    while (_queue.Peek().Key.Add(span) < now) do ignore (_queue.Dequeue())
                    _queue.Peek().Value
            with
            | e -> current

        finally
            System.Threading.Monitor.Exit _queue

    let _value = Util.cell null (fun () -> at _span.Value DateTime.Now _reference.Value)


    do this.Bind(_value)

    member this.Value = _value
    member this.Reference with get () = _reference and set v = _reference <- v
    member this.Lapse with get () = _lapse and set v = _lapse <- v
    member this.Span with get () = _span and set v = _span <- v
