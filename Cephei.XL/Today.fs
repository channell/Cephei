
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System

type Clock () as this = 
    inherit Cell<DateTime> (DateTime.Now)

    let _timer = new System.Timers.Timer (1000.0);

    let tick (e : System.Timers.ElapsedEventArgs) : unit = 
        this.Value <- DateTime.Now 

    do  _timer.Elapsed.Add tick
        _timer.AutoReset <- true
        _timer.Enabled <- true
        _timer.Start ()

type Today () as this = 
    inherit Cell<DateTime> (DateTime.Today)

    let _timer = new System.Timers.Timer (60000.0);
    let mutable _date = DateTime.Today;

    let tick (e : System.Timers.ElapsedEventArgs) : unit = 
        if DateTime.Today > _date then
            _date <- DateTime.Today
            this.Value <- DateTime.Now 

    do  _timer.Elapsed.Add tick
        _timer.AutoReset <- true
        _timer.Enabled <- true
        _timer.Start ()


module Today =

    [<ExcelFunction(Name="_Clock", Description="Get the current date ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let clock () =
        let format (i:DateTime) (l:string) = i.ToOADate() :> obj
        Model.specify 
            { mnemonic = "Clock"
            ; creator = fun () -> new Clock() :> ICell
            ; subscriber = Helper.subscriber format
            ; source = "cell " + value.ToString()
            ; hash = 0
            } |> ignore 
        Model.value "Clock"

    [<ExcelFunction(Name="_Today", Description="Get the current date ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=false)>]
    let today () =
        let format (i:DateTime) (l:string) = i.ToOADate() :> obj
        Model.specify 
            { mnemonic = "Today"
            ; creator = fun () -> new Today() :> ICell
            ; subscriber = Helper.subscriber format
            ; source = "(value DateTime.Today)"
            ; hash = 0 
            } 
