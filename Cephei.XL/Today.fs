
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System
open System.Threading
open Cephei.XL.Helper

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

    [<ExcelFunction(Name="_Delay_Double", Description="Delay a price for # seconds",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let delay
        ([<ExcelArgument(Name="Mnemonic",Description = "Mnemonic for this lapse")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Reference",Description = "Mnemonic of Cell with the Value")>] 
         reference : string)
        ([<ExcelArgument(Name="time lapse",Description = "number of seconds to delay")>] 
        lapse : obj)
        = 

        if not (Model.IsInFunctionWizard()) then

            try

                let mnemonic = Model.formatMnemonic mnemonic
                let _reference = Helper.toCell<double> reference "reference" 
                let _lapse = Helper.toCell<double> lapse "lapse" 

                let builder (current : ICell) = 
                    if current = null then 
                        withMnemonic mnemonic (new Delay<double> (_reference.cell, _lapse.cell)) :> ICell
                    else
                        let source = current :?> Delay<double>
                        source.Reference.Value  <- _reference.cell.Value
                        source.Lapse.Value <- _lapse.cell.Value
                        current

                let format (i : double) (l:string) = i :> obj

                let source () = Helper.sourceFold "Fun.Delay" 
                                               [| _reference.source
                                               ;  _lapse.source
                                               |]
                let hash = Helper.hashFold 
                                [| _reference.cell
                                ;  _lapse.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } 

            with
            | _ as e ->  "#" + e.Message :> obj
        else
            "<WIZ>" :> obj
