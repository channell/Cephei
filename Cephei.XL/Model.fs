namespace Cephei.XL

//open ExcelDna.Integration
//open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections.Generic
open System.Collections
open System
open System.Threading

module public  Model =

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)

    let getState () = 
        let modelName = "ModelState"
        let mutable state = AppDomain.CurrentDomain.GetData(modelName)
        if state = null then
            state <- new ModelState ()
            AppDomain.CurrentDomain.SetData(modelName, state)
        state :?> ModelState

    let _state = lazy getState()

    let setRange m l o =
        lock _state (fun () ->
            _state.Value.Ranges.[kv m l] <- o
            )
    let hasRange m l =
        lock _state (fun () ->
            _state.Value.Ranges.ContainsKey (kv m l))

    let clearRange s =
        lock _state (fun () ->
            _state.Value.Ranges |> 
            Seq.filter (fun i -> i.Key.Key = s) |>
            Seq.toList |>
            List.iter (fun i -> _state.Value.Ranges.Remove( i.Key) |> ignore))

    let mutable xlInterface             = (new ExcelInterface (setRange) ) :> IExcelInterace

    let IsInFunctionWizard () = 
        xlInterface.IsInFunctionWizard ()

    // Subscribe to the objct 
    let subscribe (rtd : IValueRTD) (mnemonic : string) (layout : string) = 
        lock _state (fun () ->
            if _state.Value.Subscriber.ContainsKey (mnemonic) then 

                let f = _state.Value.Subscriber.[mnemonic]
                let c = _state.Value.Model.[mnemonic]
                let d = f rtd c layout
                d
            else
                null :> IDisposable)

    let add (s: string) = 
        lock _state (fun () ->
            if _state.Value.Rtd.ContainsKey(s) then
                let sub = _state.Value.Rtd.[s]
                let c = sub.creator()
                c.Mnemonic <- sub.mnemonic
                _state.Value.Model.[sub.mnemonic] <- c
                _state.Value.Source.[sub.mnemonic] <- sub.source
                _state.Value.Subscriber.[sub.mnemonic] <- sub.subscriber)

    // Register a functor to create a cell if requried
    let specify (spec : spec) : obj =
        lock _state (fun () ->
            _state.Value.Rtd.[spec.mnemonic] <- spec
            let xlv = xlInterface.ModelRTD spec.mnemonic (spec.hash.ToString())
            if xlv = null then 
                add spec.mnemonic
                _state.Value.Rtd.Remove spec.mnemonic |> ignore
                spec.mnemonic :> obj
            else
                _state.Value.Rtd.Remove spec.mnemonic |> ignore
                xlv)
    // Register and get the value of a single obj
    let value (mnemonic : string) : obj =
        lock _state (fun () ->
            let xlv = xlInterface.ValueRTD mnemonic ""
            if xlv = null then 
                add mnemonic
                mnemonic :> obj
            else
                xlv)

    // Register and get the value from a range
    let range (mnemonic : string) (layout : string) : obj[,] =
        lock _state (fun () ->
            let k = kv mnemonic layout
            let xlv = xlInterface.ValueRTD mnemonic layout 
            if _state.Value.Ranges.ContainsKey(k) then
                    _state.Value.Ranges.[k]
            else 
                Array2D.create<obj> 1 1 "#NoValue")

    let remove s = 
        lock _state (fun () ->
            if _state.Value.Model.ContainsKey(s) then
                let cell = _state.Value.Model.[s]
                let mutable cell2 = cell
                if _state.Value.Model.TryRemove (s, ref cell2) then
                    if not (cell = null) then
                        cell.Dependants|> Seq.iter (fun d -> if not (d = null) then d.OnChange (CellEvent.Link, cell, DateTime.Now, null ))
                    _state.Value.Source.Remove s |> ignore
                    _state.Value.Subscriber.Remove s |> ignore)

    let cell mnemonic : ICell option = 
        let m = _state.Value.Model
        lock m (fun () ->
            if m.ContainsKey(mnemonic) then 
                Some m.[mnemonic]
            else 
                None)

    let contains mnemonic = 
        lock _state (fun () ->
            _state.Value.Model.ContainsKey mnemonic)

    (*
    // Summary : Add a cansting cell
    let addCast (c : ICell<'t>) (source : string) =
        _state.Value.Model.[c.Mnemonic] <- c
        _state.Value.Source.[c.Mnemonic] <- source
        c
    *)

    let sourcecode (name : string) = 
        lock _state (fun () ->
            let tieredCells (model : Model) =

                let rec depth (cell : ICell) = 
                    let max a b = if a > b then a else b
                    cell.Dependants |> 
                    Seq.filter (fun i -> i :? ICell) |>
                    Seq.map (fun i -> i :?> ICell) |>
                    Seq.fold (fun a y -> max a (depth y)) 0

                model |>
                Seq.map (fun i -> (i.Value, depth i.Value)) |>
                Seq.toArray |>
                Array.sortBy (fun (c,d) -> d * -1)

            let tiers = 
                tieredCells _state.Value.Model

            let cells = 
                tiers |>
                Array.filter (fun (c,d) -> _state.Value.Source.ContainsKey c.Mnemonic) |>
                Array.map (fun (c,d) -> (c.Mnemonic, _state.Value.Source.[c.Mnemonic]))

            let functions =
                cells |> 
                Array.map (fun (n,s) -> sprintf "    let _%s = %s\n" n s) |>
                Array.fold (fun a y -> a + y) "\n(* functions *)\n"

            let members = 
                cells |> 
                Array.map (fun (n,s) -> sprintf "    member this.%s = _%s\n" n n) |>
                Array.fold (fun a y -> a + y) "\n(* Externally visible/bindable properties *)\n"

            String.Format ("
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type {0} () as this =
    inherit Model ()
{1}
    do this.Bind ()
{2}
", name, functions, members))
        
