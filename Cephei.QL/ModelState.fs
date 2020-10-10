namespace Cephei.QL

open System.Collections.Generic
open System.Collections.Concurrent
open Cephei.Cell
open Cephei.Cell.Generic
open System

// Summary:  interface that functions will use to foreard events to Excel
type IValueRTD = 
    abstract UpdateValue : string -> string -> obj -> unit
    abstract UpdateRange : string -> string -> obj[,] -> unit


// Summary: Specification for an  RTD obj subscription
type spec = { mnemonic : string; creator : (ICell ->ICell); subscriber : (IValueRTD -> ICell -> string -> IDisposable) ; source : unit -> string; hash : int}

// Summary: Model state for Excel addin
type ModelState () = 

    let _model                  = new Model ()
    let _source                 = new ConcurrentDictionary<string, string> ()
    let _subscriber             = new ConcurrentDictionary<string, (IValueRTD -> ICell -> string -> IDisposable)> ()
    let _ranges                 = new ConcurrentDictionary<KeyValuePair<string, string>, obj[,]> ()

    let  _rtd                   = new ConcurrentDictionary<string, spec> ()
    let mutable _version        = 0

    member this.Model = _model
    member this.Source = _source
    member this.Subscriber = _subscriber
    member this.Ranges = _ranges
    member this.Rtd = _rtd
    member this.Version with  get () = _version and set(v) = _version <- v

type CellSource<'t> = {cell : ICell<'t>; source : string}

