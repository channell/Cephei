(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  floating-rate bond (possibly capped and/or floored)   calculations are tested by checking results against cached values.
  </summary> *)
[<AutoSerializable(true)>]
module FloatingRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatingRateBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _paymentDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateBond>) l

                let source = Helper.sourceFold "Fun.FloatingRateBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _index.source
                                               ;  _paymentDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _index.cell
                                ;  _paymentDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatingRateBond1 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _paymentDayCounter.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateBond>) l

                let source = Helper.sourceFold "Fun.FloatingRateBond1" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _index.source
                                               ;  _paymentDayCounter.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _index.cell
                                ;  _paymentDayCounter.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond2", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "Reference to inArrears")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let _caps = Helper.toCell<List<Nullable<double>>> caps "caps" true
                let _floors = Helper.toCell<List<Nullable<double>>> floors "floors" true
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatingRateBond2 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _paymentDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateBond>) l

                let source = Helper.sourceFold "Fun.FloatingRateBond2" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _index.source
                                               ;  _paymentDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _index.cell
                                ;  _paymentDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        public FloatingRateBond(int settlementDays, double faceAmount, Date startDate, Date maturityDate, Frequency couponFrequency, Calendar calendar, IborIndex index, DayCounter accrualDayCounter, BusinessDayConvention accrualConvention = Following, BusinessDayConvention paymentConvention = Following, int fixingDays = Null<Natural>(), List<double> gearings = std::vector<Real>(1, 1.0), List<double> spreads = std::vector<Spread>(1, 0.0), List<double> caps = std::vector<Rate>(), List<double> floors = std::vector<Rate>(), bool inArrears = false, double redemption = 100.0, Date issueDate = Date(), Date stubDate = Date(), DateGeneration.Rule rule = DateGeneration::Backward, bool endOfMonth = false)
    *)
    [<ExcelFunction(Name="_FloatingRateBond3", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="couponFrequency",Description = "Reference to couponFrequency")>] 
         couponFrequency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "Reference to accrualConvention")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "Reference to inArrears")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="stubDate",Description = "Reference to stubDate")>] 
         stubDate : obj)
        ([<ExcelArgument(Name="rule",Description = "Reference to rule")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" true
                let _couponFrequency = Helper.toCell<Frequency> couponFrequency "couponFrequency" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" true
                let _accrualConvention = Helper.toCell<BusinessDayConvention> accrualConvention "accrualConvention" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" true
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" true
                let _caps = Helper.toCell<List<Nullable<double>>> caps "caps" true
                let _floors = Helper.toCell<List<Nullable<double>>> floors "floors" true
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _stubDate = Helper.toCell<Date> stubDate "stubDate" true
                let _rule = Helper.toCell<DateGeneration.Rule> rule "rule" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FloatingRateBond3 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _maturityDate.cell 
                                                            _couponFrequency.cell 
                                                            _calendar.cell 
                                                            _index.cell 
                                                            _accrualDayCounter.cell 
                                                            _accrualConvention.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _stubDate.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateBond>) l

                let source = Helper.sourceFold "Fun.FloatingRateBond3" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _maturityDate.source
                                               ;  _couponFrequency.source
                                               ;  _calendar.source
                                               ;  _index.source
                                               ;  _accrualDayCounter.source
                                               ;  _accrualConvention.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _stubDate.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _maturityDate.cell
                                ;  _couponFrequency.cell
                                ;  _calendar.cell
                                ;  _index.cell
                                ;  _accrualDayCounter.cell
                                ;  _accrualConvention.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _stubDate.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_accruedAmount", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".AccruedAmount") 
                                               [| _FloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_calendar", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Calendar") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_cashflows", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Cashflows") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_cleanPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".CleanPrice") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_cleanPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".CleanPrice1") 
                                               [| _FloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_dirtyPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".DirtyPrice") 
                                               [| _FloatingRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_dirtyPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".DirtyPrice1") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_isExpired", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".IsExpired") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_issueDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".IssueDate") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_isTradable", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".IsTradable") 
                                               [| _FloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_maturityDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".MaturityDate") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_nextCashFlowDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".NextCashFlowDate") 
                                               [| _FloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_nextCouponRate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".NextCouponRate") 
                                               [| _FloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_notional", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Notional") 
                                               [| _FloatingRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_notionals", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Notionals") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_previousCashFlowDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".PreviousCashFlowDate") 
                                               [| _FloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_previousCouponRate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".PreviousCouponRate") 
                                               [| _FloatingRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_FloatingRateBond_redemption", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Redemption") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_FloatingRateBond_redemptions", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Redemptions") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".SettlementDate") 
                                               [| _FloatingRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _date.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementDays", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".SettlementDays") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementValue", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".SettlementValue") 
                                               [| _FloatingRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _cleanPrice.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementValue", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".SettlementValue1") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_startDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".StartDate") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_yield", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".YIELD") 
                                               [| _FloatingRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_yield", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".YIELD") 
                                               [| _FloatingRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_CASH", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".CASH") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_errorEstimate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".ErrorEstimate") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_NPV", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".NPV") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_result", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".Result") 
                                               [| _FloatingRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _tag.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_setPricingEngine", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatingRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".SetPricingEngine") 
                                               [| _FloatingRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _e.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_valuationDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "Reference to FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateBond.cell :?> FloatingRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateBond.source + ".ValuationDate") 
                                               [| _FloatingRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FloatingRateBond_Range", Description="Create a range of FloatingRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloatingRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingRateBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatingRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatingRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FloatingRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
