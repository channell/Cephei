
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System

type Clock (tick : float) as this = 
    inherit CellFast<DateTime> (DateTime.Now)

    let _timer = new System.Timers.Timer (tick);

    let tick (e : System.Timers.ElapsedEventArgs) : unit = 
        this.Value <- DateTime.Now 

    do  _timer.Elapsed.Add tick
        _timer.AutoReset <- true
        _timer.Enabled <- true
        _timer.Start ()

type Today () as this = 
    inherit CellFast<DateTime> (DateTime.Today)

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

    [<ExcelFunction(Name="_Clock", Description="Get the current date ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let clock () =
        let format (i:DateTime) (l:string) = i.ToOADate() :> obj
        Model.specify 
            { mnemonic = "Clock"
            ; creator = fun (current : ICell) -> new Clock(1000.0) :> ICell
            ; subscriber = Helper.subscriber format
            ; source =  (fun () -> "cell " + value.ToString())
            ; hash = 0
            } |> ignore 
        Model.add "Clock"            
        Model.value "Clock"

    [<ExcelFunction(Name="_Today", Description="Get the current date ",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let today () =
        let format (i:DateTime) (l:string) = i.ToOADate() :> obj
        Model.specify 
            { mnemonic = "Today"
            ; creator = fun (current : ICell) -> new Today() :> ICell
            ; subscriber = Helper.subscriber format
            ; source =  (fun () -> "(value DateTime.Today)")
            ; hash = 0
            } 

