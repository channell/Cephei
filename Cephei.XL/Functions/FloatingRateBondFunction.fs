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
    [<ExcelFunction(Name="_FloatingRateBond1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "DayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateBond1 
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

                let source () = Helper.sourceFold "Fun.FloatingRateBond1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "DayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateBond
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _index.cell 
                                                            _paymentDayCounter.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateBond>) l

                let source () = Helper.sourceFold "Fun.FloatingRateBond" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond2", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "DayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "bool")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "double")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateBond2 
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

                let source () = Helper.sourceFold "Fun.FloatingRateBond2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
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
    [<ExcelFunction(Name="_FloatingRateBond3", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="couponFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         couponFrequency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="index",Description = "IborIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "double range")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "double range")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "double range or empty")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "double range or empty")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "bool")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "double")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Date")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="stubDate",Description = "Date")>] 
         stubDate : obj)
        ([<ExcelArgument(Name="rule",Description = "DateGeneration.Rule: Backward, Forward, Zero, ThirdWednesday, Twentieth, TwentiethIMM, OldCDS, CDS, CDS2015")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _couponFrequency = Helper.toCell<Frequency> couponFrequency "couponFrequency" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _accrualConvention = Helper.toCell<BusinessDayConvention> accrualConvention "accrualConvention" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _caps = Helper.toNullabletList<double> caps "caps" 
                let _floors = Helper.toNullabletList<double> floors "floors" 
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _stubDate = Helper.toCell<Date> stubDate "stubDate" 
                let _rule = Helper.toCell<DateGeneration.Rule> rule "rule" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateBond3 
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

                let source () = Helper.sourceFold "Fun.FloatingRateBond3" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
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
    [<ExcelFunction(Name="_FloatingRateBond_accruedAmount", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_calendar", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
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
    [<ExcelFunction(Name="_FloatingRateBond_cashflows", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatingRateBond_cleanPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_cleanPrice1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".CleanPrice1") 

                                               [| _Yield.source
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
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_dirtyPrice1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
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
    (*
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_dirtyPrice", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_isExpired", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_issueDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_isTradable", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _d.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_maturityDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_nextCashFlowDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
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
    (*
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_nextCouponRate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_notional", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _d.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_notionals", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatingRateBond_previousCashFlowDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
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
    (*
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_previousCouponRate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _settlement.cell
                                |]
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
    (*
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_FloatingRateBond_redemption", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateBond> format
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
    [<ExcelFunction(Name="_FloatingRateBond_redemptions", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_FloatingRateBond_settlementDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _date.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementDays", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementValue", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _cleanPrice.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_settlementValue1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_startDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_yield1", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Yield1") 

                                               [| _cleanPrice.source
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
    (*
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_yield", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Yield") 

                                               [| _dc.source
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_CASH", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_errorEstimate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateBond_NPV", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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
    (*
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_result", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _tag.cell
                                |]
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
    (*
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_setPricingEngine", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatingRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _e.cell
                                |]
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
    (*
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_valuationDate", Description="Create a FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                |]
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

    (*
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_FloatingRateBond_SetCouponPricer", Description="Set a coupon pricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_SetCouponPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateBond",Description = "FloatingRateBond")>] 
         floatingratebond : obj)
        ([<ExcelArgument(Name="Pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateBond = Helper.toCell<FloatingRateBond> floatingratebond "FloatingRateBond"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "FloatingRateCouponPricer"
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateBondModel.Cast _FloatingRateBond.cell).SetCouponPricer
                                                                        _pricer.cell
                                                                      ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateBond.source + ".SetCouponPricer") 
                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateBond.cell
                                ;  _pricer.cell
                                |]
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


    [<ExcelFunction(Name="_FloatingRateBond_Range", Description="Create a range of FloatingRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FloatingRateBond> (c)) :> ICell
                let format (i : Generic.List<ICell<FloatingRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FloatingRateBond>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
