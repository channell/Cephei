
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type Sheet1 
    () as this =
    inherit Model ()

(* functions *)
    let True = true
    let False = false
    let _calendar = Fun.TARGET()
    let _settlementDate = Fun.Date1 (value (Convert.ToInt32(39709)))
    let _fixingDaysNeg = (value (Convert.ToInt32(-3)))
    let _todaysDate = _calendar.Advance1 _settlementDate _fixingDaysNeg (value TimeUnit.Days) (value BusinessDayConvention.Following) (value false)
    let _USgovi = Fun.UnitedStates (value UnitedStates.Market.GovernmentBond)
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _settlementDays = (value (Convert.ToInt32(3)))
    let _redemption = (value (Convert.ToDouble(100)))
    let _ActualActualBond = Fun.ActualActual1 (value ActualActual.Convention.Bond) (value (null :> QLNet.Schedule))
    let _zcBondsDayCounter = Fun.Actual365Fixed()
    let _fixingDays = (value (Convert.ToInt32(3)))
    let _couponRates4 = (new List<double>([| Convert.ToDouble(0.04500)|]))
    let _zc6mRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0145)))
    let _couponRates1 = (new List<double>([| Convert.ToDouble(0.04625)|]))
    let _zc3mRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0096)))
    let _couponRates2 = (new List<double>([| Convert.ToDouble(0.03125)|]))
    let _couponRates0 = (new List<double>([| Convert.ToDouble(0.02375)|]))
    let _settlementDateAdjusted = _calendar.Adjust _settlementDate (value BusinessDayConvention.Following)
    let _zc1yRate = Fun.SimpleQuote1 (triv null (fun () -> toNullable (0.0194)))
    let _zc6mPeriod = Fun.Period (value (Convert.ToInt32(6))) (value TimeUnit.Months)
    let _marketQuotes0 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (100.390625)))
    let _marketQuotes4 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (102.140625)))
    let _schedule4 = Fun.Schedule (value (new Date(int (31912)))) (value (new Date(int (50540)))) _Semiannual (triv null (fun () -> _USgovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _marketQuotes2 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (100.59375)))
    let _marketQuotes3 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (101.6875)))
    let _zc3mPeriod = Fun.Period (value (Convert.ToInt32(3))) (value TimeUnit.Months)
    let _schedule2 = Fun.Schedule (value (new Date(int (38898)))) (value (new Date(int (41517)))) _Semiannual (triv null (fun () -> _USgovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule1 = Fun.Schedule (value (new Date(int (38518)))) (value (new Date(int (40786)))) _Semiannual (triv null (fun () -> _USgovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _zc1yPeriod = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Years)
    let _marketQuotes1 = Fun.SimpleQuote1 (triv null (fun () -> toNullable (106.21875)))
    let _couponRates3 = (new List<double>([| Convert.ToDouble(0.04000)|]))
    let _schedule3 = Fun.Schedule (value (new Date(int (37575)))) (value (new Date(int (43327)))) _Semiannual (triv null (fun () -> _USgovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _schedule0 = Fun.Schedule (value (new Date(int (38426)))) (value (new Date(int (40421)))) _Semiannual (triv null (fun () -> _USgovi.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _todaysDate
    let _zc3m = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc3mRate.Cell.Box :?> QLNet.Quote))) _zc3mPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _zc6m = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc6mRate.Cell.Box :?> QLNet.Quote))) _zc6mPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _bondhelper2 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes2.Cell.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule2 _couponRates2  (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38898)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper1 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes1.Cell.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule1 (_couponRates1 :> ICell<Generic.List<double>>) (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38518)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper4 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes4.Cell.Box :?> QLNet.Quote))) _settlementDays (value (100.0)) _schedule4 (_couponRates4 :> ICell<Generic.List<double>>) (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (31912)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper3 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes3.Cell.Box :?>  QLNet.Quote))) _settlementDays (value (100.0)) _schedule3 (_couponRates3 :> ICell<Generic.List<double>>) (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (37575)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _bondhelper0 = Fun.FixedRateBondHelper (triv null (fun () -> toHandle (_marketQuotes0.Cell.Box :?> QLNet.Quote))) _settlementDays (value (100.0)) _schedule0 (_couponRates0 :> ICell<Generic.List<double>>) (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.Unadjusted) _redemption (value (new Date(int (38426)))) (value (null :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) (value true)
    let _zc1y = Fun.DepositRateHelper (triv null (fun () -> toHandle (_zc1yRate.Cell.Box :?> QLNet.Quote))) _zc1yPeriod _fixingDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.ModifiedFollowing) (value true) (triv null (fun () -> _zcBondsDayCounter.Value :> QLNet.DayCounter)) _todaysDate
    let _termStructureDayCounter = Fun.ActualActual1 (value ActualActual.Convention.ISDA) (value (null :> QLNet.Schedule))
    let _discount = Fun.Discount ()
    let _tolerance = (value (Convert.ToDouble(1E-15)))
    let _bondInstruments1 = (new List<RateHelper>([|(trivDate (fun () -> _zc3m.Value :> QLNet.RateHelper) (_zc3m :> IDateDependant));(trivDate (fun () -> _zc6m.Value :> QLNet.RateHelper) (_zc6m :> IDateDependant));(trivDate (fun () -> _zc1y.Value :> QLNet.RateHelper) (_zc1y :> IDateDependant));(triv null (fun () -> _bondhelper0.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper1.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper2.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper3.Value :> QLNet.RateHelper));(triv null (fun () -> _bondhelper4.Value :> QLNet.RateHelper))|]))
    let _loglinier = Fun.LogLinear ()
    let _bondDiscountingTermStructure = Fun.PiecewiseYieldCurve (triv null (fun () -> _discount.Value :> QLNet.ITraits<QLNet.YieldTermStructure>)) _settlementDateAdjusted _bondInstruments1  (triv null (fun () -> _termStructureDayCounter.Value :> QLNet.DayCounter)) (value (new System.Collections.Generic.List<QLNet.Handle<QLNet.Quote>>())) (value (new System.Collections.Generic.List<QLNet.Date>())) _tolerance (triv null (fun () -> _loglinier.Value :> QLNet.IInterpolationFactory)) _todaysDate
    let _ZeroSettlementDate = Fun.Date1 (value (Convert.ToInt32(41501)))
    let _ZeroIssueDate = Fun.Date1 (value (Convert.ToInt32(37848)))
    let _faceAmount = (value (Convert.ToDouble(100)))
    let _RemptionAmount = (value (Convert.ToDouble(116.62)))
    let _bondEngine = Fun.DiscountingBondEngine (triv null (fun () -> toHandle (_bondDiscountingTermStructure.Value :> QLNet.YieldTermStructure))) (triv null (fun () -> toNullable (True))) _todaysDate //  _settlementDateAdjusted
    let _swFloatingLegIndex = Fun.Euribor6M1()
    
    let _zeroCouponBond = Fun.ZeroCouponBond _settlementDays (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) _faceAmount _ZeroSettlementDate (value BusinessDayConvention.Following) _RemptionAmount _ZeroIssueDate  (triv null (fun () -> _bondEngine .Value :> QLNet.IPricingEngine)) _todaysDate   
    let _zeroNPV = _zeroCouponBond.NPV

    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.settlementDate = _settlementDate
    member this.fixingDaysNeg = _fixingDaysNeg
    member this.todaysDate = _todaysDate
    member this.USgovi = _USgovi
    member this.Semiannual = _Semiannual
    member this.settlementDays = _settlementDays
    member this.redemption = _redemption
    member this.ActualActualBond = _ActualActualBond
    member this.zcBondsDayCounter = _zcBondsDayCounter
    member this.fixingDays = _fixingDays
    member this.couponRates4 = _couponRates4
    member this.zc6mRate = _zc6mRate
    member this.couponRates1 = _couponRates1
    member this.zc3mRate = _zc3mRate
    member this.couponRates2 = _couponRates2
    member this.couponRates0 = _couponRates0
    member this.settlementDateAdjusted = _settlementDateAdjusted
    member this.zc1yRate = _zc1yRate
    member this.zc6mPeriod = _zc6mPeriod
    member this.marketQuotes0 = _marketQuotes0
    member this.marketQuotes4 = _marketQuotes4
    member this.schedule4 = _schedule4
    member this.marketQuotes2 = _marketQuotes2
    member this.marketQuotes3 = _marketQuotes3
    member this.zc3mPeriod = _zc3mPeriod
    member this.schedule2 = _schedule2
    member this.schedule1 = _schedule1
    member this.zc1yPeriod = _zc1yPeriod
    member this.marketQuotes1 = _marketQuotes1
    member this.couponRates3 = _couponRates3
    member this.schedule3 = _schedule3
    member this.schedule0 = _schedule0
    member this.zc3m = _zc3m
    member this.zc6m = _zc6m
    member this.bondhelper2 = _bondhelper2
    member this.bondhelper1 = _bondhelper1
    member this.bondhelper4 = _bondhelper4
    member this.bondhelper3 = _bondhelper3
    member this.bondhelper0 = _bondhelper0
    member this.zc1y = _zc1y
    member this.termStructureDayCounter = _termStructureDayCounter
    member this.discount = _discount
    member this.tolerance = _tolerance
    member this.bondInstruments1 = _bondInstruments1
    member this.loglinier = _loglinier
    member this.bondDiscountingTermStructure = _bondDiscountingTermStructure
    member this.ZeroSettlementDate = _ZeroSettlementDate
    member this.ZeroIssueDate = _ZeroIssueDate
    member this.faceAmount = _faceAmount
    member this.RemptionAmount = _RemptionAmount
    member this.bondEngine = _bondEngine
    member this.swFloatingLegIndex = _swFloatingLegIndex

    member this.zeroCouponBond = _zeroCouponBond
    member this.zeroNPV = _zeroNPV

#if EXCEL
module Sheet1Function =

    [<ExcelFunction(Name="__Sheet1", Description="Create a Sheet1",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)

        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (new Sheet1

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> Sheet1) l
                let source () = Helper.sourceFold "new Sheet1"
                                               [|                                               |]

                let hash = Helper.hashFold
                                [|                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sheet1> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__Sheet1_calendar", Description="Create a QLNet.TARGET",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).calendar) :> ICell
            let format (o : QLNet.TARGET) (l:string) = o.Helper.Range.fromModel (i :?> calendar) l
            let source () = (_Sheet1.source + ".calendar")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_settlementDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).settlementDate) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> settlementDate) l
            let source () = (_Sheet1.source + ".settlementDate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_fixingDaysNeg", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_fixingDaysNeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).fixingDaysNeg) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> fixingDaysNeg) l
            let source () = (_Sheet1.source + ".fixingDaysNeg")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_todaysDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_todaysDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).todaysDate) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> todaysDate) l
            let source () = (_Sheet1.source + ".todaysDate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_USgovi", Description="Create a QLNet.UnitedStates",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_USgovi
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).USgovi) :> ICell
            let format (o : QLNet.UnitedStates) (l:string) = o.Helper.Range.fromModel (i :?> USgovi) l
            let source () = (_Sheet1.source + ".USgovi")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_Semiannual", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_Semiannual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).Semiannual) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> Semiannual) l
            let source () = (_Sheet1.source + ".Semiannual")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_settlementDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).settlementDays) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> settlementDays) l
            let source () = (_Sheet1.source + ".settlementDays")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_redemption", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).redemption) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> redemption) l
            let source () = (_Sheet1.source + ".redemption")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_ActualActualBond", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_ActualActualBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).ActualActualBond) :> ICell
            let format (o : QLNet.ActualActual) (l:string) = o.Helper.Range.fromModel (i :?> ActualActualBond) l
            let source () = (_Sheet1.source + ".ActualActualBond")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zcBondsDayCounter", Description="Create a QLNet.Actual365Fixed",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zcBondsDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zcBondsDayCounter) :> ICell
            let format (o : QLNet.Actual365Fixed) (l:string) = o.Helper.Range.fromModel (i :?> zcBondsDayCounter) l
            let source () = (_Sheet1.source + ".zcBondsDayCounter")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_fixingDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).fixingDays) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> fixingDays) l
            let source () = (_Sheet1.source + ".fixingDays")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_couponRates4", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_couponRates4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).couponRates4) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> couponRates4) l
            let source () = (_Sheet1.source + ".couponRates4")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc6mRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc6mRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc6mRate) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> zc6mRate) l
            let source () = (_Sheet1.source + ".zc6mRate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_couponRates1", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_couponRates1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).couponRates1) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> couponRates1) l
            let source () = (_Sheet1.source + ".couponRates1")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc3mRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc3mRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc3mRate) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> zc3mRate) l
            let source () = (_Sheet1.source + ".zc3mRate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_couponRates2", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_couponRates2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).couponRates2) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> couponRates2) l
            let source () = (_Sheet1.source + ".couponRates2")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_couponRates0", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_couponRates0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).couponRates0) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> couponRates0) l
            let source () = (_Sheet1.source + ".couponRates0")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_settlementDateAdjusted", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_settlementDateAdjusted
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).settlementDateAdjusted) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> settlementDateAdjusted) l
            let source () = (_Sheet1.source + ".settlementDateAdjusted")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc1yRate", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc1yRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc1yRate) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> zc1yRate) l
            let source () = (_Sheet1.source + ".zc1yRate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc6mPeriod", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc6mPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc6mPeriod) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> zc6mPeriod) l
            let source () = (_Sheet1.source + ".zc6mPeriod")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_marketQuotes0", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_marketQuotes0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).marketQuotes0) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> marketQuotes0) l
            let source () = (_Sheet1.source + ".marketQuotes0")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_marketQuotes4", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_marketQuotes4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).marketQuotes4) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> marketQuotes4) l
            let source () = (_Sheet1.source + ".marketQuotes4")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_schedule4", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_schedule4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).schedule4) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> schedule4) l
            let source () = (_Sheet1.source + ".schedule4")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_marketQuotes2", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_marketQuotes2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).marketQuotes2) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> marketQuotes2) l
            let source () = (_Sheet1.source + ".marketQuotes2")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_marketQuotes3", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_marketQuotes3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).marketQuotes3) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> marketQuotes3) l
            let source () = (_Sheet1.source + ".marketQuotes3")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc3mPeriod", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc3mPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc3mPeriod) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> zc3mPeriod) l
            let source () = (_Sheet1.source + ".zc3mPeriod")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_schedule2", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_schedule2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).schedule2) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> schedule2) l
            let source () = (_Sheet1.source + ".schedule2")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_schedule1", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_schedule1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).schedule1) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> schedule1) l
            let source () = (_Sheet1.source + ".schedule1")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc1yPeriod", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc1yPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc1yPeriod) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> zc1yPeriod) l
            let source () = (_Sheet1.source + ".zc1yPeriod")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_marketQuotes1", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_marketQuotes1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).marketQuotes1) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> marketQuotes1) l
            let source () = (_Sheet1.source + ".marketQuotes1")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_couponRates3", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_couponRates3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).couponRates3) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> couponRates3) l
            let source () = (_Sheet1.source + ".couponRates3")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_schedule3", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_schedule3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).schedule3) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> schedule3) l
            let source () = (_Sheet1.source + ".schedule3")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_schedule0", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_schedule0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).schedule0) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> schedule0) l
            let source () = (_Sheet1.source + ".schedule0")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc3m", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc3m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc3m) :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = o.Helper.Range.fromModel (i :?> zc3m) l
            let source () = (_Sheet1.source + ".zc3m")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc6m", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc6m
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc6m) :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = o.Helper.Range.fromModel (i :?> zc6m) l
            let source () = (_Sheet1.source + ".zc6m")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper2", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper2) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper2) l
            let source () = (_Sheet1.source + ".bondhelper2")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper1", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper1) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper1) l
            let source () = (_Sheet1.source + ".bondhelper1")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper4", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper4) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper4) l
            let source () = (_Sheet1.source + ".bondhelper4")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper3", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper3) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper3) l
            let source () = (_Sheet1.source + ".bondhelper3")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper0", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper0) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper0) l
            let source () = (_Sheet1.source + ".bondhelper0")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc1y", Description="Create a QLNet.DepositRateHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc1y
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc1y) :> ICell
            let format (o : QLNet.DepositRateHelper) (l:string) = o.Helper.Range.fromModel (i :?> zc1y) l
            let source () = (_Sheet1.source + ".zc1y")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_termStructureDayCounter", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_termStructureDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).termStructureDayCounter) :> ICell
            let format (o : QLNet.ActualActual) (l:string) = o.Helper.Range.fromModel (i :?> termStructureDayCounter) l
            let source () = (_Sheet1.source + ".termStructureDayCounter")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_discount", Description="Create a QLNet.Discount",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).discount) :> ICell
            let format (o : QLNet.Discount) (l:string) = o.Helper.Range.fromModel (i :?> discount) l
            let source () = (_Sheet1.source + ".discount")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_tolerance", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_tolerance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).tolerance) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> tolerance) l
            let source () = (_Sheet1.source + ".tolerance")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondInstruments1", Description="Create a System.Collections.Generic.List`1[QLNet.RateHelper]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondInstruments1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondInstruments1) :> ICell
            let format (o : System.Collections.Generic.List`1[QLNet.RateHelper]) (l:string) = o.Helper.Range.fromModel (i :?> bondInstruments1) l
            let source () = (_Sheet1.source + ".bondInstruments1")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_loglinier", Description="Create a QLNet.LogLinear",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_loglinier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).loglinier) :> ICell
            let format (o : QLNet.LogLinear) (l:string) = o.Helper.Range.fromModel (i :?> loglinier) l
            let source () = (_Sheet1.source + ".loglinier")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondDiscountingTermStructure", Description="Create a Cephei.QLNetHelper.PiecewiseYieldCurve",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondDiscountingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondDiscountingTermStructure) :> ICell
            let format (o : Cephei.QLNetHelper.PiecewiseYieldCurve) (l:string) = o.Helper.Range.fromModel (i :?> bondDiscountingTermStructure) l
            let source () = (_Sheet1.source + ".bondDiscountingTermStructure")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_ZeroSettlementDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_ZeroSettlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).ZeroSettlementDate) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> ZeroSettlementDate) l
            let source () = (_Sheet1.source + ".ZeroSettlementDate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_ZeroIssueDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_ZeroIssueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).ZeroIssueDate) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> ZeroIssueDate) l
            let source () = (_Sheet1.source + ".ZeroIssueDate")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_faceAmount", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_faceAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).faceAmount) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> faceAmount) l
            let source () = (_Sheet1.source + ".faceAmount")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_RemptionAmount", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_RemptionAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).RemptionAmount) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> RemptionAmount) l
            let source () = (_Sheet1.source + ".RemptionAmount")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondEngine", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondEngine) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> bondEngine) l
            let source () = (_Sheet1.source + ".bondEngine")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_swFloatingLegIndex", Description="Create a QLNet.Euribor6M",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_swFloatingLegIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).swFloatingLegIndex) :> ICell
            let format (o : QLNet.Euribor6M) (l:string) = o.Helper.Range.fromModel (i :?> swFloatingLegIndex) l
            let source () = (_Sheet1.source + ".swFloatingLegIndex")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper4ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper4ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper4ld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper4ld) l
            let source () = (_Sheet1.source + ".bondhelper4ld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc3mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc3mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc3mld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> zc3mld) l
            let source () = (_Sheet1.source + ".zc3mld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_todaysDateSer", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_todaysDateSer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).todaysDateSer) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> todaysDateSer) l
            let source () = (_Sheet1.source + ".todaysDateSer")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_swFixedLegDayCounter", Description="Create a QLNet.Thirty360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_swFixedLegDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).swFixedLegDayCounter) :> ICell
            let format (o : QLNet.Thirty360) (l:string) = o.Helper.Range.fromModel (i :?> swFixedLegDayCounter) l
            let source () = (_Sheet1.source + ".swFixedLegDayCounter")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_Actual365Fixed", Description="Create a QLNet.Actual365Fixed",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_Actual365Fixed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).Actual365Fixed) :> ICell
            let format (o : QLNet.Actual365Fixed) (l:string) = o.Helper.Range.fromModel (i :?> Actual365Fixed) l
            let source () = (_Sheet1.source + ".Actual365Fixed")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper2u", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper2u
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper2u) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper2u) l
            let source () = (_Sheet1.source + ".bondhelper2u")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper3u", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper3u
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper3u) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper3u) l
            let source () = (_Sheet1.source + ".bondhelper3u")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper4u", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper4u
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper4u) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper4u) l
            let source () = (_Sheet1.source + ".bondhelper4u")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper0u", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper0u
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper0u) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper0u) l
            let source () = (_Sheet1.source + ".bondhelper0u")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc1yld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc1yld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc1yld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> zc1yld) l
            let source () = (_Sheet1.source + ".zc1yld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper1u", Description="Create a QLNet.FixedRateBondHelper",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper1u
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper1u) :> ICell
            let format (o : QLNet.FixedRateBondHelper) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper1u) l
            let source () = (_Sheet1.source + ".bondhelper1u")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc3mq", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc3mq
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc3mq) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> zc3mq) l
            let source () = (_Sheet1.source + ".zc3mq")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_settlementDateAdjustedSer", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_settlementDateAdjustedSer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).settlementDateAdjustedSer) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> settlementDateAdjustedSer) l
            let source () = (_Sheet1.source + ".settlementDateAdjustedSer")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc1yq", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc1yq
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc1yq) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> zc1yq) l
            let source () = (_Sheet1.source + ".zc1yq")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_depositDayCounter", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_depositDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).depositDayCounter) :> ICell
            let format (o : QLNet.Actual360) (l:string) = o.Helper.Range.fromModel (i :?> depositDayCounter) l
            let source () = (_Sheet1.source + ".depositDayCounter")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper2ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper2ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper2ld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper2ld) l
            let source () = (_Sheet1.source + ".bondhelper2ld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_actual360", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_actual360
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).actual360) :> ICell
            let format (o : QLNet.Actual360) (l:string) = o.Helper.Range.fromModel (i :?> actual360) l
            let source () = (_Sheet1.source + ".actual360")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_Quarterly", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_Quarterly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).Quarterly) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> Quarterly) l
            let source () = (_Sheet1.source + ".Quarterly")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc6mld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc6mld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc6mld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> zc6mld) l
            let source () = (_Sheet1.source + ".zc6mld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_zc6mq", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_zc6mq
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).zc6mq) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> zc6mq) l
            let source () = (_Sheet1.source + ".zc6mq")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper0ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper0ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper0ld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper0ld) l
            let source () = (_Sheet1.source + ".bondhelper0ld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper1ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper1ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper1ld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper1ld) l
            let source () = (_Sheet1.source + ".bondhelper1ld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_forwardStart", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_forwardStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).forwardStart) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> forwardStart) l
            let source () = (_Sheet1.source + ".forwardStart")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
                            
    [<ExcelFunction(Name="__Sheet1_bondhelper3ld", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Sheet1_bondhelper3ld
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sheet1",Description = "Sheet1")>] 
         Sheet1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Sheet1 = Helper.toCell<Sheet1> Sheet1 "Sheet1"  
            let builder (current : ICell) = withMnemonic mnemonic (_Sheet1.cell :> Sheet1).bondhelper3ld) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> bondhelper3ld) l
            let source () = (_Sheet1.source + ".bondhelper3ld")
            let hash = Helper.hashFold [| _Sheet1.cell |]
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
