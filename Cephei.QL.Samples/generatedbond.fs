
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type BondSimple 
    ( coupons : ICell<System.Collections.Generic.List<System.Double>>
    , Yield1 : ICell<QLNet.SimpleQuote>
    , Yield2 : ICell<QLNet.SimpleQuote>
    , Yield4 : ICell<QLNet.SimpleQuote>
    , Yield3 : ICell<QLNet.SimpleQuote>
    ) as this =
    inherit Model ()

(* functions *)
    let _calendar = Fun.TARGET()
    let _Today = (value DateTime.Today)
    let _clock = Fun.Date1 (triv (fun () -> int (_Today.Value.ToOADate())))
    let _priceday = _calendar.Adjust _clock (value BusinessDayConvention.Following)
    let _dayCount = Fun.ActualActual1 (value ActualActual.Convention.ISMA) (value (null :> Schedule))
    let _FreqS = Fun.Period2 (value Frequency.Semiannual)
    let _exCoupon = Fun.Period1()
    let _coupons = coupons
    let _settlement = (value 3)
    let _Yield1 = Yield1
    let _FlatYield1 = Fun.FlatForward _priceday (triv (fun () -> _Yield1.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _EngineFlatYield1 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (_FlatYield1.Value))) (triv (fun () -> toNullable (True))
    let _Mat3 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(10))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Yield2 = Yield2
    let _Mat1 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(3))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Mat2 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(5))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _FlatYield2 = Fun.FlatForward _priceday (triv (fun () -> _Yield2.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _Fac2 = (value 101)
    let _Mat1FreqS = Fun.Schedule _priceday _Mat1 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _EngineFlatYield2 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield2))) (triv (fun () -> toNullable (True))
    let _Mat3FreqS = Fun.Schedule _priceday _Mat3 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Fac1 = (value 100)
    let _Mat2FreqS = Fun.Schedule _priceday _Mat2 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _FreqA = Fun.Period2 (value Frequency.Annual)
    let _Fac3 = (value 500)
    let _Bond1 = Fun.FixedRateBond _settlement _Fac1 _Mat1FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac1 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Bond2 = Fun.FixedRateBond _settlement _Fac2 _Mat2FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac2 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield2.Value :> IPricingEngine)) _priceday
    let _Bond3 = Fun.FixedRateBond _settlement _Fac3 _Mat3FreqS _coupons (triv (fun () -> _dayCount.Value :> DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Fac3 _priceday (triv (fun () -> _calendar.Value :> Calendar)) _exCoupon (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Following) (value false) (triv (fun () -> _EngineFlatYield1.Value :> IPricingEngine)) _priceday
    let _Mat4 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(15))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _Yield4 = Yield4
    let _Yield3 = Yield3
    let _Mat5 = _calendar.Advance1 _priceday (triv (fun () -> Convert.ToInt32(20))) (value TimeUnit.Years) (value BusinessDayConvention.ModifiedFollowing) (value false)
    let _FlatYield3 = Fun.FlatForward _priceday (triv (fun () -> _Yield3.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _FlatYield4 = Fun.FlatForward _priceday (triv (fun () -> _Yield4.Value :> Quote)) (triv (fun () -> _dayCount.Value :> DayCounter))
    let _clean1 = _Bond1.CleanPrice()
    let _EngineFlatYield4 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield4))) (triv (fun () -> toNullable (True))
    let _Mat4FreqS = Fun.Schedule _priceday _Mat4 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat5FreqS = Fun.Schedule _priceday _Mat5 _FreqS (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat2FreqA = Fun.Schedule _priceday _Mat2 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat3FreqA = Fun.Schedule _priceday _Mat3 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat5FreqA = Fun.Schedule _priceday _Mat5 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _clean3 = _Bond3.CleanPrice()
    let _Mat1FreqA = Fun.Schedule _priceday _Mat1 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _Mat4FreqA = Fun.Schedule _priceday _Mat4 _FreqA (triv (fun () -> _calendar.Value :> Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> Date)) (value (null :> Date))
    let _EngineFlatYield3 = Fun.DiscountingBondEngine (triv (fun () -> toHandle<YieldTermStructure> (FlatYield3))) (triv (fun () -> toNullable (True))
    let _clean2 = _Bond2.CleanPrice()

    do this.Bind ()

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.Today = _Today
    member this.clock = _clock
    member this.priceday = _priceday
    member this.dayCount = _dayCount
    member this.FreqS = _FreqS
    member this.exCoupon = _exCoupon
    member this.coupons = _coupons
    member this.settlement = _settlement
    member this.Yield1 = _Yield1
    member this.FlatYield1 = _FlatYield1
    member this.EngineFlatYield1 = _EngineFlatYield1
    member this.Mat3 = _Mat3
    member this.Yield2 = _Yield2
    member this.Mat1 = _Mat1
    member this.Mat2 = _Mat2
    member this.FlatYield2 = _FlatYield2
    member this.Fac2 = _Fac2
    member this.Mat1FreqS = _Mat1FreqS
    member this.EngineFlatYield2 = _EngineFlatYield2
    member this.Mat3FreqS = _Mat3FreqS
    member this.Fac1 = _Fac1
    member this.Mat2FreqS = _Mat2FreqS
    member this.FreqA = _FreqA
    member this.Fac3 = _Fac3
    member this.Mat4 = _Mat4
    member this.Yield4 = _Yield4
    member this.Yield3 = _Yield3
    member this.Mat5 = _Mat5
    member this.FlatYield3 = _FlatYield3
    member this.FlatYield4 = _FlatYield4
    member this.clean1 = _clean1
    member this.EngineFlatYield4 = _EngineFlatYield4
    member this.Mat4FreqS = _Mat4FreqS
    member this.Mat5FreqS = _Mat5FreqS
    member this.Mat2FreqA = _Mat2FreqA
    member this.Mat3FreqA = _Mat3FreqA
    member this.Mat5FreqA = _Mat5FreqA
    member this.clean3 = _clean3
    member this.Mat1FreqA = _Mat1FreqA
    member this.Mat4FreqA = _Mat4FreqA
    member this.EngineFlatYield3 = _EngineFlatYield3
    member this.clean2 = _clean2


#if EXCEL
module BondSimpleFunction =

    [<ExcelFunction(Name="__BondSimple", Description="Create a BondSimple",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BondSimple_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__coupons",Description = "reference to coupons")>]
        coupons : obj)
        ([<ExcelArgument(Name="__Yield1",Description = "reference to Yield1")>]
        Yield1 : obj)
        ([<ExcelArgument(Name="__Yield2",Description = "reference to Yield2")>]
        Yield2 : obj)
        ([<ExcelArgument(Name="__Yield4",Description = "reference to Yield4")>]
        Yield4 : obj)
        ([<ExcelArgument(Name="__Yield3",Description = "reference to Yield3")>]
        Yield3 : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _coupons = Helper.toCell<System.Collections.Generic.List<System.Double>> coupons "coupons"
                let _Yield1 = Helper.toCell<QLNet.SimpleQuote> Yield1 "Yield1"
                let _Yield2 = Helper.toCell<QLNet.SimpleQuote> Yield2 "Yield2"
                let _Yield4 = Helper.toCell<QLNet.SimpleQuote> Yield4 "Yield4"
                let _Yield3 = Helper.toCell<QLNet.SimpleQuote> Yield3 "Yield3"

                let builder (current : ICell) = withMnemonic mnemonic (new BondSimple
                                                            _coupons.cell
                                                            _Yield1.cell
                                                            _Yield2.cell
                                                            _Yield4.cell
                                                            _Yield3.cell

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> BondSimple) l
                let source () = Helper.sourceFold "new BondSimple"
                                               [| _coupons.source
                                               ;  _Yield1.source
                                               ;  _Yield2.source
                                               ;  _Yield4.source
                                               ;  _Yield3.source
                                               |]

                let hash = Helper.hashFold
                                [| _coupons.cell
                                ;  _Yield1.cell
                                ;  _Yield2.cell
                                ;  _Yield4.cell
                                ;  _Yield3.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BondSimple> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__BondSimple_calendar", Description="Create a QLNet.TARGET",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).calendar) :> ICell
            let format (o : QLNet.TARGET) (l:string) = o.Helper.Range.fromModel (i :?> calendar) l
            let source () = (_BondSimple.source + ".calendar")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Today", Description="Create a System.DateTime",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Today : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Today) :> ICell
            let format (o : System.DateTime) (l:string) = o.Helper.Range.fromModel (i :?> Today) l
            let source () = (_BondSimple.source + ".Today")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clock", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clock) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> clock) l
            let source () = (_BondSimple.source + ".clock")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_priceday", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         priceday : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).priceday) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> priceday) l
            let source () = (_BondSimple.source + ".priceday")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_dayCount", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         dayCount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).dayCount) :> ICell
            let format (o : QLNet.ActualActual) (l:string) = o.Helper.Range.fromModel (i :?> dayCount) l
            let source () = (_BondSimple.source + ".dayCount")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FreqS", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FreqS) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> FreqS) l
            let source () = (_BondSimple.source + ".FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_exCoupon", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         exCoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).exCoupon) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> exCoupon) l
            let source () = (_BondSimple.source + ".exCoupon")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_+coupons", Description="Create a System.Collections.Generic.List`1[System.Double]",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +coupons : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+coupons) :> ICell
            let format (o : System.Collections.Generic.List`1[System.Double]) (l:string) = o.Helper.Range.fromModel (i :?> +coupons) l
            let source () = (_BondSimple.source + ".+coupons")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_settlement", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).settlement) :> ICell
            let format (o : System.Int32) (l:string) = o.Helper.Range.fromModel (i :?> settlement) l
            let source () = (_BondSimple.source + ".settlement")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_+Yield1", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield1) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield1) l
            let source () = (_BondSimple.source + ".+Yield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield1", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield1) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield1) l
            let source () = (_BondSimple.source + ".FlatYield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield1", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield1) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield1) l
            let source () = (_BondSimple.source + ".EngineFlatYield1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat3", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat3) l
            let source () = (_BondSimple.source + ".Mat3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_+Yield2", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield2) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield2) l
            let source () = (_BondSimple.source + ".+Yield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat1", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat1) l
            let source () = (_BondSimple.source + ".Mat1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat2", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat2) l
            let source () = (_BondSimple.source + ".Mat2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield2", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield2) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield2) l
            let source () = (_BondSimple.source + ".FlatYield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac2) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac2) l
            let source () = (_BondSimple.source + ".Fac2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat1FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat1FreqS) l
            let source () = (_BondSimple.source + ".Mat1FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield2", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield2) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield2) l
            let source () = (_BondSimple.source + ".EngineFlatYield2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat3FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat3FreqS) l
            let source () = (_BondSimple.source + ".Mat3FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac1) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac1) l
            let source () = (_BondSimple.source + ".Fac1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat2FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat2FreqS) l
            let source () = (_BondSimple.source + ".Mat2FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FreqA", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FreqA) :> ICell
            let format (o : QLNet.Period) (l:string) = o.Helper.Range.fromModel (i :?> FreqA) l
            let source () = (_BondSimple.source + ".FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Fac3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Fac3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Fac3) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> Fac3) l
            let source () = (_BondSimple.source + ".Fac3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat4", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat4) l
            let source () = (_BondSimple.source + ".Mat4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_+Yield4", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield4) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield4) l
            let source () = (_BondSimple.source + ".+Yield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_+Yield3", Description="Create a QLNet.SimpleQuote",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         +Yield3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).+Yield3) :> ICell
            let format (o : QLNet.SimpleQuote) (l:string) = o.Helper.Range.fromModel (i :?> +Yield3) l
            let source () = (_BondSimple.source + ".+Yield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat5", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5) :> ICell
            let format (o : QLNet.Date) (l:string) = o.Helper.Range.fromModel (i :?> Mat5) l
            let source () = (_BondSimple.source + ".Mat5")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield3", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield3) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield3) l
            let source () = (_BondSimple.source + ".FlatYield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_FlatYield4", Description="Create a QLNet.FlatForward",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         FlatYield4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).FlatYield4) :> ICell
            let format (o : QLNet.FlatForward) (l:string) = o.Helper.Range.fromModel (i :?> FlatYield4) l
            let source () = (_BondSimple.source + ".FlatYield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean1", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean1 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean1) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean1) l
            let source () = (_BondSimple.source + ".clean1")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield4", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield4) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield4) l
            let source () = (_BondSimple.source + ".EngineFlatYield4")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat4FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat4FreqS) l
            let source () = (_BondSimple.source + ".Mat4FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat5FreqS", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5FreqS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5FreqS) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat5FreqS) l
            let source () = (_BondSimple.source + ".Mat5FreqS")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat2FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat2FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat2FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat2FreqA) l
            let source () = (_BondSimple.source + ".Mat2FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat3FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat3FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat3FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat3FreqA) l
            let source () = (_BondSimple.source + ".Mat3FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat5FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat5FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat5FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat5FreqA) l
            let source () = (_BondSimple.source + ".Mat5FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean3", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean3) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean3) l
            let source () = (_BondSimple.source + ".clean3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat1FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat1FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat1FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat1FreqA) l
            let source () = (_BondSimple.source + ".Mat1FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_Mat4FreqA", Description="Create a QLNet.Schedule",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         Mat4FreqA : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).Mat4FreqA) :> ICell
            let format (o : QLNet.Schedule) (l:string) = o.Helper.Range.fromModel (i :?> Mat4FreqA) l
            let source () = (_BondSimple.source + ".Mat4FreqA")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_EngineFlatYield3", Description="Create a QLNet.DiscountingBondEngine",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         EngineFlatYield3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).EngineFlatYield3) :> ICell
            let format (o : QLNet.DiscountingBondEngine) (l:string) = o.Helper.Range.fromModel (i :?> EngineFlatYield3) l
            let source () = (_BondSimple.source + ".EngineFlatYield3")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
                            
    [<ExcelFunction(Name="__BondSimple_clean2", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BondSimple",Description = "Reference to BondSimple")>] 
         clean2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _BondSimple = Helper.toCell<BondSimple> BondSimple "BondSimple"  
            let builder (current : ICell) = withMnemonic mnemonic (_BondSimple.cell :> BondSimple).clean2) :> ICell
            let format (o : System.Double) (l:string) = o.Helper.Range.fromModel (i :?> clean2) l
            let source () = (_BondSimple.source + ".clean2")
            let hash = Helper.hashFold [| _BondSimple.cell |]
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
