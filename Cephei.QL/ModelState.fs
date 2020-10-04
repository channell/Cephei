namespace Cephei.QL

open System.Collections.Generic 
open Cephei.Cell
open Cephei.Cell.Generic
open System

// Summary:  interface that functions will use to foreard events to Excel
type IValueRTD = 
    abstract UpdateValue : string -> string -> obj -> unit
    abstract UpdateRange : string -> string -> obj[,] -> unit


// Summary: Specification for an  RTD obj subscription
type spec = { mnemonic : string; creator : (unit ->ICell); subscriber : (IValueRTD -> ICell -> string -> IDisposable) ; source : string; hash : int}

// Summary: Model state for Excel addin
type ModelState () = 

    let _model                  = new Model ()
    let _source                 = new Dictionary<string, string> ()
    let _subscriber             = new Dictionary<string, (IValueRTD -> ICell -> string -> IDisposable)> ()
    let  _ranges                = new Dictionary<KeyValuePair<string, string>, obj[,]> ()

    let  _rtd                   = new Dictionary<string, spec> ()

    member this.Model = _model
    member this.Source = _source
    member this.Subscriber = _subscriber
    member this.Ranges = _ranges
    member this.Rtd = _rtd

type CellSource<'t> = {cell : ICell<'t>; source : string}

