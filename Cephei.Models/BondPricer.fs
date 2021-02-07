
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type BondPricerModel
    ( settlementDate : ICell<QLNet.Date>
    ) as this =
    inherit Model<IPricingEngine> ()

(* functions *)
    let _settlementDate = settlementDate
    let _Globals = new GlobalsModel (_settlementDate)
    let _redemption = (value (Convert.ToDouble(100)))
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _calendar = _Globals.calendar
    let _USGovi = _Globals.USgovi
    let _zcBondsDayCounter = _Globals.zcBondsDayCounter
    let _fixingDaysNeg = _Globals.fixingDaysNeg
    let _todaysDate = _Globals.todaysDate
    let _zc3mRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0096)))
    let _zc1yRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0194)))
    let _zc6mRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0145)))
    let _tolerance = (value (Convert.ToDouble(1E-15)))
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _settlementDays = _Globals.settlementDays
    let _ActualActualBond = Fun.ActualActual1 (value ActualActual.Convention.Bond) (value (null :> QLNet.Schedule))
    let _fixingDays = _Globals.fixingDays
    let _zc6mPeriod = Fun.Period (value (Convert.ToInt32(6))) (value TimeUnit.Months)
    let _zc1yPeriod = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Years)
    let _zc6m = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc6mRate.Box :?> QLNet.Quote))) _zc6mPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _Adjusted = _Globals.Adjusted
    let _couponRate0 = (new Cephei.Cell.List<double>([| Convert.ToDouble(0.02375)|]))
    let _depositDayCounter = Fun.Actual360 (value false)
    let _marketQuotes0 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (100.390625)))
    let _marketQuotes4 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (102.140625)))
    let _marketQuotes1 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (106.21875)))
    let _marketQuotes3 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (101.6875)))
    let _marketQuotes2 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (100.59375)))
    let _actual360 = Fun.Actual360 (value false)
    let _couponRate2 = (new Cephei.Cell.List<double>([| Convert.ToDouble(0.03125)|]))
    let _couponRate1 = (new Cephei.Cell.List<double>([| Convert.ToDouble(0.04625)|]))
    let _couponRate4 = (new Cephei.Cell.List<double>([| Convert.ToDouble(0.045)|]))
    let _couponRate3 = (new Cephei.Cell.List<double>([| Convert.ToDouble(0.04)|]))
    let _zc1y = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc1yRate.Box :?> QLNet.Quote))) _zc1yPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _schedule4 = Fun.Schedule (value (new Date(int (31912)))) (value (new Date(int (50540)))) _Semiannual (triv null (fun () -> _USGovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule2 = Fun.Schedule (value (new Date(int (38898)))) (value (new Date(int (41517)))) _Semiannual (triv null (fun () -> _USGovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule0 = Fun.Schedule (value (new Date(int (38426)))) (value (new Date(int (40421)))) _Semiannual (triv null (fun () -> _USGovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule3 = Fun.Schedule (value (new Date(int (37575)))) (value (new Date(int (43327)))) _Semiannual (triv null (fun () -> _USGovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule1 = Fun.Schedule (value (new Date(int (38518)))) (value (new Date(int (40786)))) _Semiannual (triv null (fun () -> _USGovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _bondhelper2 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes2.Subject.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule2 _couponRate2  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38898)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper1 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes1.Subject.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule1 _couponRate1  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38518)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper4 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes4.Subject.Box :?> QLNet.Quote))) _settlementDays (value (100.0)) _schedule4 _couponRate4  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (31912)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper3 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes3.Subject.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule3 _couponRate3  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (37575)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper0 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes0.Subject.Box :?> QLNet.Quote))) _settlementDays (value (100.0)) _schedule0 _couponRate0  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38426)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _zc3mPeriod = Fun.Period (value (Convert.ToInt32(3))) (value TimeUnit.Months)
    let _termStructureDayCounter = Fun.ActualActual1 (value ActualActual.Convention.ISDA) (value (null :> QLNet.Schedule))
    let _discount = Fun.Discount ()
    let _loglinier = Fun.LogLinear ()
    let _zc3m = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc3mRate.Box :?> QLNet.Quote))) _zc3mPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _bondInstruments = (new Cephei.Cell.List<RateHelper>([|(trivDate (fun () -> _zc3m.Value :> QLNet.RateHelper) (_zc3m :> IDateDependant));(trivDate (fun () -> _zc6m.Value :> QLNet.RateHelper) (_zc6m :> IDateDependant));(trivDate (fun () -> _zc1y.Value :> QLNet.RateHelper) (_zc1y :> IDateDependant));(triv null (fun () -> _bondhelper0.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper1.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper2.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper3.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper4.Value :> QLNet.RateHelper))|]))
    let _bondDiscountingTermStructure = Fun.PiecewiseYieldCurve (triv null (fun () -> _discount.Value :> QLNet.ITraits<QLNet.YieldTermStructure>)) _Adjusted _bondInstruments (triv null (fun () -> _termStructureDayCounter.Value :> QLNet.DayCounter)) (value (new System.Collections.Generic.List<QLNet.Handle<QLNet.Quote>>())) (value (new System.Collections.Generic.List<QLNet.Date>())) _tolerance (triv null (fun () -> _loglinier.Value :> QLNet.IInterpolationFactory)) _todaysDate
    let _Quarterly = Fun.Period2 (value Frequency.Quarterly)
    let _instruments = (new Cephei.Cell.List<RateHelper>([|(trivDate (fun () -> _zc3m.Value :> QLNet.RateHelper) (_zc3m :> IDateDependant));(trivDate (fun () -> _zc6m.Value :> QLNet.RateHelper) (_zc6m :> IDateDependant));(trivDate (fun () -> _zc1y.Value :> QLNet.RateHelper) (_zc1y :> IDateDependant));(triv null (fun () -> _bondhelper0.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper1.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper2.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper3.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper4.Value :> QLNet.RateHelper))|]))
    let _swFloatingLegIndex = Fun.Euribor6M1()
    let _swFixedLegDayCounter = Fun.Thirty360 (value Thirty360.Thirty360Convention.European)
    let _bondEngine = Fun.DiscountingBondEngine (triv null (fun () -> toHandle (_bondDiscountingTermStructure.Value :> QLNet.YieldTermStructure))) (triv null (fun () -> toNullable (true))) _Adjusted
    let _forwardStart = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Days)
    let _Actual365Fixed = Fun.Actual365Fixed()

    do this.Bind (triv null (fun () -> _bondEngine.Value :> IPricingEngine))

(* Externally visible/bindable properties *)
    member this.Globals = _Globals
    member this.redemption = _redemption
    member this.Semiannual = _Semiannual
    member this.settlementDate = _settlementDate
    member this.zc3mRate = _zc3mRate
    member this.zc1yRate = _zc1yRate
    member this.zc6mRate = _zc6mRate
    member this.tolerance = _tolerance
    member this.zc6m = _zc6m
    member this.zc1y = _zc1y
    member this.zc3m = _zc3m
    member this.couponRate3 = _couponRate3
    member this.couponRate1 = _couponRate1
    member this.couponRate4 = _couponRate4
    member this.couponRate0 = _couponRate0
    member this.marketQuotes0 = _marketQuotes0
    member this.marketQuotes4 = _marketQuotes4
    member this.marketQuotes1 = _marketQuotes1
    member this.marketQuotes3 = _marketQuotes3
    member this.marketQuotes2 = _marketQuotes2
    member this.couponRate2 = _couponRate2
    member this.bondEngine = _bondEngine


#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module BondPricerModelFunction =

    [<ExcelFunction(Name="__BondPricer", Description="Create a BondPricer",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__settlementDate",Description = "reference to QLNet.Date")>]
        settlementDate : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _settlementDate = Helper.toCell<QLNet.Date> settlementDate "settlementDate"

                let builder (current : ICell) = (new BondPricerModel
                                                                        ( _settlementDate.cell)

                                                                      ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> BondPricerModel) l
                let source () = Helper.sourceFold "new BondPricer"
                                               [| _settlementDate.source
                                               |]

                let hash = Helper.hashFold
                                [| _settlementDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BondPricerModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__BondPricer_Globals", Description="Create a Cephei.Models.GlobalsModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_Globals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).Globals :> ICell
            let format (o : Cephei.Models.GlobalsModel) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".Globals")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_redemption", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).redemption :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".redemption")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_Semiannual", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_Semiannual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).Semiannual :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".Semiannual")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc3mRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc3mRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc3mRate :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc3mRate")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc1yRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc1yRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc1yRate :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc1yRate")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc6mRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc6mRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc6mRate :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc6mRate")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_tolerance", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_tolerance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).tolerance :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".tolerance")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc6m", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc6m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc6m :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc6m")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc1y", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc1y
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc1y :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc1y")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_zc3m", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_zc3m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).zc3m :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".zc3m")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_couponRate3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_couponRate3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).couponRate3 :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".couponRate3")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_couponRate1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_couponRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).couponRate1 :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".couponRate1")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_couponRate4", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_couponRate4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).couponRate4 :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".couponRate4")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                                                       
    [<ExcelFunction(Name="__BondPricer_couponRate0", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_couponRate0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).couponRate0 :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".couponRate0")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_marketQuotes0", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_marketQuotes0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).marketQuotes0 :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".marketQuotes0")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_marketQuotes4", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_marketQuotes4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).marketQuotes4 :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".marketQuotes4")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_marketQuotes1", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_marketQuotes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).marketQuotes1 :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".marketQuotes1")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_marketQuotes3", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_marketQuotes3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).marketQuotes3 :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".marketQuotes3")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_marketQuotes2", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_marketQuotes2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).marketQuotes2 :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".marketQuotes2")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_couponRate2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_couponRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).couponRate2 :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".couponRate2")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
                            
    [<ExcelFunction(Name="__BondPricer_bondEngine", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondPricer_bondEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondPricer",Description = "BondPricer")>] 
         BondPricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondPricer = Helper.toModel<BondPricerModel,  IPricingEngine> BondPricer "BondPricer"  
            let builder (current : ICell) = (_BondPricer.cell :?> BondPricerModel).bondEngine :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = Model.genericFormat o
            let source () = (_BondPricer.source + ".bondEngine")
            let hash = Helper.hashFold [| _BondPricer.cell |]
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
