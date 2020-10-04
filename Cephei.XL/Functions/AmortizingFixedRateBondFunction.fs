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
module AmortizingFixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFixedRateBond", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_create
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
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="sinkingFrequency",Description = "Reference to sinkingFrequency")>] 
         sinkingFrequency : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _sinkingFrequency = Helper.toCell<Frequency> sinkingFrequency "sinkingFrequency" 
                let _coupon = Helper.toCell<double> coupon "coupon" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.AmortizingFixedRateBond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _bondTenor.cell 
                                                            _sinkingFrequency.cell 
                                                            _coupon.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingFixedRateBond>) l

                let source = Helper.sourceFold "Fun.AmortizingFixedRateBond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _bondTenor.source
                                               ;  _sinkingFrequency.source
                                               ;  _coupon.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _bondTenor.cell
                                ;  _sinkingFrequency.cell
                                ;  _coupon.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFixedRateBond1", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _coupons = Helper.toCell<Generic.List<InterestRate>> coupons "coupons" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.AmortizingFixedRateBond1 
                                                            _settlementDays.cell 
                                                            _notionals.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingFixedRateBond>) l

                let source = Helper.sourceFold "Fun.AmortizingFixedRateBond1" 
                                               [| _settlementDays.source
                                               ;  _notionals.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _notionals.cell
                                ;  _schedule.cell
                                ;  _coupons.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFixedRateBond2", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="notionals",Description = "Reference to notionals")>] 
         notionals : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _notionals = Helper.toCell<Generic.List<double>> notionals "notionals" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.AmortizingFixedRateBond2 
                                                            _settlementDays.cell 
                                                            _notionals.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AmortizingFixedRateBond>) l

                let source = Helper.sourceFold "Fun.AmortizingFixedRateBond2" 
                                               [| _settlementDays.source
                                               ;  _notionals.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _notionals.cell
                                ;  _schedule.cell
                                ;  _coupons.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFixedRateBond_dayCounter", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".DayCounter") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AmortizingFixedRateBond_frequency", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Frequency") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_accruedAmount", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".AccruedAmount") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_calendar", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Calendar") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_cashflows", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Cashflows") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_cleanPrice", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".CleanPrice") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_cleanPrice1", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
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

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".CleanPrice1") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_dirtyPrice1", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
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

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".DirtyPrice") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_dirtyPrice", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".DirtyPrice1") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_isExpired", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".IsExpired") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_issueDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".IssueDate") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_isTradable", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".IsTradable") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_maturityDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".MaturityDate") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_nextCashFlowDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".NextCashFlowDate") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_nextCouponRate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".NextCouponRate") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_notional", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Notional") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_notionals", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Notionals") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_previousCashFlowDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".PreviousCashFlowDate") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_previousCouponRate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".PreviousCouponRate") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_redemption", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Redemption") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AmortizingFixedRateBond> format
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_redemptions", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Redemptions") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_settlementDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".SettlementDate") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_settlementDays", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".SettlementDays") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_settlementValue", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".SettlementValue") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_settlementValue1", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".SettlementValue1") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_startDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".StartDate") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_yield1", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
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

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Yield") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_yield", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
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

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Yield") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_CASH", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".CASH") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_errorEstimate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".ErrorEstimate") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_NPV", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".NPV") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_result", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".Result") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_setPricingEngine", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : AmortizingFixedRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".SetPricingEngine") 
                                               [| _AmortizingFixedRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_valuationDate", Description="Create a AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AmortizingFixedRateBond",Description = "Reference to AmortizingFixedRateBond")>] 
         amortizingfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AmortizingFixedRateBond = Helper.toCell<AmortizingFixedRateBond> amortizingfixedratebond "AmortizingFixedRateBond"  
                let builder () = withMnemonic mnemonic ((AmortizingFixedRateBondModel.Cast _AmortizingFixedRateBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AmortizingFixedRateBond.source + ".ValuationDate") 
                                               [| _AmortizingFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AmortizingFixedRateBond.cell
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
    [<ExcelFunction(Name="_AmortizingFixedRateBond_Range", Description="Create a range of AmortizingFixedRateBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AmortizingFixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AmortizingFixedRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AmortizingFixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AmortizingFixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AmortizingFixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AmortizingFixedRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
