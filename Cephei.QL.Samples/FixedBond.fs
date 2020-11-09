
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type FixedBond 
    ( Tenor : ICell<Int32>
    , Maturity : ICell<Date>
    , FixedAmount : ICell<Double>
    ) as this =
    inherit Model ()

(* functions *)
    let _Calendar = Fun.TARGET()
    let _Today = (value DateTime.Today)
    let _clock = Fun.Date1 (triv (fun () -> int (_Today.Value.ToOADate())))
    let _PriceDay = _Calendar.Adjust _clock (value BusinessDayConvention.Following)
    let _DayCount = Fun.ActualActual1 (value ActualActual.Convention.ISMA) (value (null :> Schedule))
    let _Quote = Fun.SimpleQuote1 (triv (fun () -> toNullable (0.03)))
    let _Tenor = Tenor
    let _Frequency = Fun.Period2 (value Frequency.Annual)
    let _FlatForward = Fun.FlatForward _PriceDay (triv (fun () -> (_Quote :> ICell<SimpleQuote>).Value :> Quote)) (triv (fun () -> _DayCount.Value :> DayCounter))
    let _Maturity = Maturity
    let _Coupon = value (new Generic.List<double>([| Convert.ToDouble(0.02); Convert.ToDouble(0.05); Convert.ToDouble(0.08)|]))
    let _ExCoupon = Fun.Period1()
    let _Settlement = (value (Convert.ToInt32(0)))
    let _FixedAmount = FixedAmount
    let _Engine = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatForward.Value))) (triv (fun () -> toNullable (true)))
    let _Schedule = Fun.Schedule _PriceDay _Maturity _Frequency (triv (fun () -> _Calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Bond = Fun.FixedRateBond _Settlement _FixedAmount _Schedule _Coupon (triv (fun () -> _DayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _FixedAmount _PriceDay (triv (fun () -> _Calendar.Value :> Calendar)) _ExCoupon (triv (fun () -> _Calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _Engine.Value :> IPricingEngine)) _PriceDay
    let _clock = Fun.Date1 (triv (fun () -> int (_Today.Value.ToOADate())))
    let _CleanPrice = _Bond.CleanPrice
    let _DirtyPrice = _Bond.DirtyPrice
    let _NPV = _Bond.NPV
    let _Cash = _Bond.CASH

    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.Today = _Today
    member this.Quote = _Quote
    member this.Tenor = _Tenor
    member this.Frequency = _Frequency
    member this.Maturity = _Maturity
    member this.FixedAmount = _FixedAmount
    member this.clock = _clock
    member this.CleanPrice = _CleanPrice
    member this.DirtyPrice = _DirtyPrice
    member this.NPV = _NPV
    member this.Cash = _Cash


#if EXCEL
module FixedBondFunction =

    [<ExcelFunction(Name="__FixedBond", Description="Create a FixedBond",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__Tenor",Description = "reference to Int32")>]
        Tenor : obj)
        ([<ExcelArgument(Name="__Maturity",Description = "reference to Date")>]
        Maturity : obj)
        ([<ExcelArgument(Name="__FixedAmount",Description = "reference to Double")>]
        FixedAmount : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _Tenor = Helper.toCell<Int32> Tenor "Tenor"
                let _Maturity = Helper.toCell<Date> Maturity "Maturity"
                let _FixedAmount = Helper.toCell<Double> FixedAmount "FixedAmount"

                let builder (current : ICell) = withMnemonic mnemonic (new FixedBond
                                                            _Tenor.cell
                                                            _Maturity.cell
                                                            _FixedAmount.cell

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> FixedBond) l
                let source () = Helper.sourceFold "new FixedBond"
                                               [| _Tenor.source
                                               ;  _Maturity.source
                                               ;  _FixedAmount.source
                                               |]

                let hash = Helper.hashFold
                                [| _Tenor.cell
                                ;  _Maturity.cell
                                ;  _FixedAmount.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__FixedBond_Today", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_Today
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).Today) :> ICell
            let format (o : System.DateTime) (l:string) = o.Helper.Range.fromModel (i :?> Today) l
            let source () = (_FixedBond.source + ".Today")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_Quote", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_Quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).Quote) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> Quote) l
            let source () = (_FixedBond.source + ".Quote")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_Frequency", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_Frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).Frequency) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> Frequency) l
            let source () = (_FixedBond.source + ".Frequency")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_clock", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_clock
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).clock) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> clock) l
            let source () = (_FixedBond.source + ".clock")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_CleanPrice", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_CleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).CleanPrice) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> CleanPrice) l
            let source () = (_FixedBond.source + ".CleanPrice")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_Clock", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_Clock
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).Clock) :> ICell
            let format (o : System.DateTime) (l:string) = o.Helper.Range.fromModel (i :?> Clock) l
            let source () = (_FixedBond.source + ".Clock")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_DirtyPrice", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_DirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).DirtyPrice) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> DirtyPrice) l
            let source () = (_FixedBond.source + ".DirtyPrice")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_NPV", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).NPV) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> NPV) l
            let source () = (_FixedBond.source + ".NPV")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__FixedBond_Cash", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedBond_Cash
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedBond",Description = "FixedBond")>] 
         FixedBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedBond = Helper.toCell<FixedBond> FixedBond "FixedBond"  
            let builder (current : ICell) = withMnemonic mnemonic (_FixedBond.cell :> FixedBond).Cash) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Cash) l
            let source () = (_FixedBond.source + ".Cash")
            let hash = Helper.hashFold [| _FixedBond.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
#endif
