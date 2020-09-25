namespace Cephei.XL

//open ExcelDna.Integration
//open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections.Generic
open System.Collections
open System

// Summary: Specification for an  RTD obj subscription
type spec = { mnemonic : string; creator : (unit ->ICell); subscriber : (IValueRTD -> ICell -> string -> IDisposable) ; source : string; hash : int}

module public  Model =

    let kv (k:'k) (v:'v) = new System.Collections.Generic.KeyValuePair<'k,'v>(k,v)

    let private _model                  = new Model ()
//    let private _hash                   = new Dictionary<string, string> ()
    let private _source                 = new Dictionary<string, string> ()
    let private _subscriber             = new Dictionary<string, (IValueRTD -> ICell -> string -> IDisposable)> ()
    let private _ranges                 = new Dictionary<Generic.KeyValuePair<string, string>, obj[,]> ()

    let private _rtd                    = new Dictionary<string, spec> ()

    (*
        Handle array subscriptions
    *)
    let setRange m l o =
        _ranges.[kv m l] <- o

    let clearRange s =
        _ranges |> 
        Seq.filter (fun i -> i.Key.Key = s) |>
        Seq.toList |>
        List.iter (fun i -> _ranges.Remove( i.Key) |> ignore) 


    let mutable xlInterface             = (new ExcelStub (setRange) ) :> IExcelInterace

    let IsInFunctionWizard () = 
        xlInterface.IsInFunctionWizard ()

    // Subscrive to the objct 
    let subscribe (rtd : IValueRTD) (mnemonic : string) (layout : string) = 

        if _subscriber.ContainsKey (mnemonic) then 

            let f = _subscriber.[mnemonic]
            let c = _model.[mnemonic]
            let d = f rtd c layout
            d
        else
            null :> IDisposable

    let add (s: string) = 
    
        if _rtd.ContainsKey(s) then
            let sub = _rtd.[s]
            let c = sub.creator()
            c.Mnemonic <- sub.mnemonic
            _model.[sub.mnemonic] <- c
            _source.[sub.mnemonic] <- sub.source
            _subscriber.[sub.mnemonic] <- sub.subscriber
            _rtd.Remove s |> ignore

    // Register a functor to create a cell if requried
    let specify (spec : spec) : obj =

        _rtd.[spec.mnemonic] <- spec
        let xlv = xlInterface.ModelRTD spec.mnemonic (spec.hash.ToString())
        if xlv = null then 
            add spec.mnemonic
            spec.mnemonic :> obj
        else
            xlv

    // Register and get the value of a single obj
    let value (mnemonic : string) : obj =

        let xlv = xlInterface.ValueRTD mnemonic ""
        if xlv = null then 
            add mnemonic
            mnemonic :> obj
        else
            xlv

    // Register and get the value from a range
    let range (mnemonic : string) (layout : string) : obj[,] =
        let k = kv mnemonic layout
        let xlv = xlInterface.ValueRTD mnemonic layout 
        if _ranges.ContainsKey(k) then
            _ranges.[k]
        else 
            Array2D.create<obj> 1 1 "#NoValue"

    let remove s = 
    
        if _model.ContainsKey(s) then
            let cell = _model.[s]
            let mutable cell2 = cell
            if _model.TryRemove (s, ref cell2) then
                if not (cell = null) then
                    cell.Dependants|> Seq.iter (fun d -> d.OnChange (CellEvent.Link, cell, DateTime.Now, null ))
                _source.Remove s |> ignore
                _subscriber.Remove s |> ignore

    let cell mnemonic = 
        _model.[mnemonic]

    let contains mnemonic = 
        _model.ContainsKey mnemonic

    // Summary : Add a cansting cell
    let addCast (c : ICell<'t>) (source : string) =
        _model.[c.Mnemonic] <- c
        _source.[c.Mnemonic] <- source
        c

    let sourcecode (name : string)  = 
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
            Array.sortBy (fun (c,d) -> d)
        
        let cells = 
            (tieredCells _model) |>
            Array.filter (fun (c,d) -> _source.ContainsKey c.Mnemonic) |>
            Array.map (fun (c,d) -> (c.Mnemonic, _source.[c.Mnemonic]))

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
            ", name, functions, members)
        