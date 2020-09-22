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
    [<ExcelFunction(Name="_FixedRateBond_dayCounter", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FixedRateBond.source + ".DayCounter") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Reference to exCouponPeriod")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Reference to exCouponCalendar")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "Reference to exCouponConvention")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "Reference to exCouponEndOfMonth")>] 
         exCouponEndOfMonth : obj)
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
                let _coupons = Helper.toCell<Generic.List<InterestRate>> coupons "coupons" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" true
                let _exCouponPeriod = Helper.toCell<Period> exCouponPeriod "exCouponPeriod" true
                let _exCouponCalendar = Helper.toCell<Calendar> exCouponCalendar "exCouponCalendar" true
                let _exCouponConvention = Helper.toCell<BusinessDayConvention> exCouponConvention "exCouponConvention" true
                let _exCouponEndOfMonth = Helper.toCell<bool> exCouponEndOfMonth "exCouponEndOfMonth" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FixedRateBond 
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

                let source = Helper.sourceFold "Fun.FixedRateBond" 
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
        ! simple annual compounding coupon rates with internal schedule calculation
    *)
    [<ExcelFunction(Name="_FixedRateBond1", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "Reference to accrualConvention")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
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
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Reference to exCouponPeriod")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Reference to exCouponCalendar")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "Reference to exCouponConvention")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "Reference to exCouponEndOfMonth")>] 
         exCouponEndOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" true
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" true
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" true
                let _accrualConvention = Helper.toCell<BusinessDayConvention> accrualConvention "accrualConvention" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _stubDate = Helper.toCell<Date> stubDate "stubDate" true
                let _rule = Helper.toCell<DateGeneration.Rule> rule "rule" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" true
                let _exCouponPeriod = Helper.toCell<Period> exCouponPeriod "exCouponPeriod" true
                let _exCouponCalendar = Helper.toCell<Calendar> exCouponCalendar "exCouponCalendar" true
                let _exCouponConvention = Helper.toCell<BusinessDayConvention> exCouponConvention "exCouponConvention" true
                let _exCouponEndOfMonth = Helper.toCell<bool> exCouponEndOfMonth "exCouponEndOfMonth" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FixedRateBond1 
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

                let source = Helper.sourceFold "Fun.FixedRateBond1" 
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
        ! simple annual compounding coupon rates
    *)
    [<ExcelFunction(Name="_FixedRateBond2", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Reference to exCouponPeriod")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Reference to exCouponCalendar")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "Reference to exCouponConvention")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "Reference to exCouponEndOfMonth")>] 
         exCouponEndOfMonth : obj)
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
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" true
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _redemption = Helper.toCell<double> redemption "redemption" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" true
                let _exCouponPeriod = Helper.toCell<Period> exCouponPeriod "exCouponPeriod" true
                let _exCouponCalendar = Helper.toCell<Calendar> exCouponCalendar "exCouponCalendar" true
                let _exCouponConvention = Helper.toCell<BusinessDayConvention> exCouponConvention "exCouponConvention" true
                let _exCouponEndOfMonth = Helper.toCell<bool> exCouponEndOfMonth "exCouponEndOfMonth" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.FixedRateBond2 
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

                let source = Helper.sourceFold "Fun.FixedRateBond2" 
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
    [<ExcelFunction(Name="_FixedRateBond_frequency", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".Frequency") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_accruedAmount", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".AccruedAmount") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_calendar", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FixedRateBond.source + ".Calendar") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_cashflows", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FixedRateBond.source + ".Cashflows") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_cleanPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".CleanPrice") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_cleanPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".CleanPrice1") 
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
    [<ExcelFunction(Name="_FixedRateBond_dirtyPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _Yield = Helper.toCell<double> Yield "Yield" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".DirtyPrice") 
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
    [<ExcelFunction(Name="_FixedRateBond_dirtyPrice", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".DirtyPrice1") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_isExpired", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".IsExpired") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_issueDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".IssueDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_isTradable", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".IsTradable") 
                                               [| _FixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_maturityDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".MaturityDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_nextCashFlowDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".NextCashFlowDate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_nextCouponRate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".NextCouponRate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_notional", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".Notional") 
                                               [| _FixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_notionals", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FixedRateBond.source + ".Notionals") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_previousCashFlowDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".PreviousCashFlowDate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_previousCouponRate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".PreviousCouponRate") 
                                               [| _FixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_redemption", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_FixedRateBond.source + ".Redemption") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_redemptions", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FixedRateBond.source + ".Redemptions") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _date = Helper.toCell<Date> date "date" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".SettlementDate") 
                                               [| _FixedRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementDays", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".SettlementDays") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementValue", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".SettlementValue") 
                                               [| _FixedRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_settlementValue", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".SettlementValue1") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_startDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".StartDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_yield", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" true
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".YIELD") 
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
    [<ExcelFunction(Name="_FixedRateBond_yield", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
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

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _dc = Helper.toCell<DayCounter> dc "dc" true
                let _comp = Helper.toCell<Compounding> comp "comp" true
                let _freq = Helper.toCell<Frequency> freq "freq" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".YIELD") 
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
    [<ExcelFunction(Name="_FixedRateBond_CASH", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".CASH") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_errorEstimate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".ErrorEstimate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_NPV", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".NPV") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_result", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".Result") 
                                               [| _FixedRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_setPricingEngine", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FixedRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".SetPricingEngine") 
                                               [| _FixedRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_valuationDate", Description="Create a FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "Reference to FixedRateBond")>] 
         fixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toCell<FixedRateBond> fixedratebond "FixedRateBond" true 
                let builder () = withMnemonic mnemonic ((_FixedRateBond.cell :?> FixedRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBond.source + ".ValuationDate") 
                                               [| _FixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBond.cell
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
    [<ExcelFunction(Name="_FixedRateBond_Range", Description="Create a range of FixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FixedRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateBond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FixedRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
