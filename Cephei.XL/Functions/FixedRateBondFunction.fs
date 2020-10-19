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

  </summary> *)
[<AutoSerializable(true)>]
module FixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBond_dayCounter", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FixedRateBond.source + ".DayCounter") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBond2", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedRateBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "InterestRate")>] 
         coupons : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "FixedRateBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "FixedRateBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "FixedRateBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "FixedRateBond")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "FixedRateBond")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "FixedRateBond")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "FixedRateBond")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "FixedRateBond")>] 
         exCouponEndOfMonth : obj)
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
                let _coupons = Helper.toCell<Generic.List<InterestRate>> coupons "coupons" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateBond2 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBond>) l

                let source () = Helper.sourceFold "Fun.FixedRateBond2" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _coupons.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! simple annual compounding coupon rates with internal schedule calculation
    *)
    [<ExcelFunction(Name="_FixedRateBond1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedRateBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="coupons",Description = "double")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "FixedRateBond")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "FixedRateBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "FixedRateBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "FixedRateBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="stubDate",Description = "FixedRateBond")>] 
         stubDate : obj)
        ([<ExcelArgument(Name="rule",Description = "FixedRateBond")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "FixedRateBond")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "FixedRateBond")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "FixedRateBond")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "FixedRateBond")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "FixedRateBond")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "FixedRateBond")>] 
         exCouponEndOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _accrualConvention = Helper.toDefault<BusinessDayConvention> accrualConvention "accrualConvention" BusinessDayConvention.Following
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _stubDate = Helper.toDefault<Date> stubDate "stubDate" null
                let _rule = Helper.toDefault<DateGeneration.Rule> rule "rule" DateGeneration.Rule.Backward
                let _endOfMonth = Helper.toDefault<bool> endOfMonth "endOfMonth" false
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateBond1 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _maturityDate.cell 
                                                            _tenor.cell 
                                                            _coupons.cell 
                                                            _accrualDayCounter.cell 
                                                            _accrualConvention.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _stubDate.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBond>) l

                let source () = Helper.sourceFold "Fun.FixedRateBond1" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _maturityDate.source
                                               ;  _tenor.source
                                               ;  _coupons.source
                                               ;  _accrualDayCounter.source
                                               ;  _accrualConvention.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _stubDate.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _maturityDate.cell
                                ;  _tenor.cell
                                ;  _coupons.cell
                                ;  _accrualDayCounter.cell
                                ;  _accrualConvention.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _stubDate.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! simple annual compounding coupon rates
    *)
    [<ExcelFunction(Name="_FixedRateBond", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FixedRateBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "double")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "DayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "FixedRateBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "FixedRateBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "FixedRateBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "FixedRateBond")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "FixedRateBond")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "FixedRateBond")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "FixedRateBond")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "FixedRateBond")>] 
         exCouponEndOfMonth : obj)
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
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateBond
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBond>) l

                let source () = Helper.sourceFold "Fun.FixedRateBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _coupons.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBond_frequency", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Frequency") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_accruedAmount", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".AccruedAmount") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_calendar", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Calendar") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
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
    [<ExcelFunction(Name="_FixedRateBond_cashflows", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Cashflows") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_cleanPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".CleanPrice") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_cleanPrice1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".CleanPrice1") 
                                               [| _FixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_dirtyPrice1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".DirtyPrice1") 
                                               [| _FixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_dirtyPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".DirtyPrice") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_isExpired", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".IsExpired") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_issueDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".IssueDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_isTradable", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".IsTradable") 
                                               [| _FixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_maturityDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".MaturityDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_nextCashFlowDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".NextCashFlowDate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_nextCouponRate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".NextCouponRate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_notional", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Notional") 
                                               [| _FixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_notionals", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Notionals") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_previousCashFlowDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".PreviousCashFlowDate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_previousCouponRate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".PreviousCouponRate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_redemption", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Redemption") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
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
    [<ExcelFunction(Name="_FixedRateBond_redemptions", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Redemptions") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".SettlementDate") 
                                               [| _FixedRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementDays", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".SettlementDays") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementValue", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".SettlementValue") 
                                               [| _FixedRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementValue1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".SettlementValue1") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_startDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".StartDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_yield1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Yield1") 
                                               [| _FixedRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_yield", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Yield") 
                                               [| _FixedRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_CASH", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".CASH") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_errorEstimate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".ErrorEstimate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_NPV", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".NPV") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_result", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".Result") 
                                               [| _FixedRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_setPricingEngine", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FixedRateBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".SetPricingEngine") 
                                               [| _FixedRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_valuationDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateBondModel.Cast _FixedRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateBond.source + ".ValuationDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_Range", Description="Create a range of FixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FixedRateBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
