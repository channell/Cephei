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
module CreditDefaultSwapFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_accrualRebateNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_accrualRebateNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).AccrualRebateNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".AccrualRebateNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_conventionalSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_conventionalSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="conventionalRecovery",Description = "Reference to conventionalRecovery")>] 
         conventionalRecovery : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let _conventionalRecovery = Helper.toCell<double> conventionalRecovery "conventionalRecovery" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _model = Helper.toCell<PricingModel> model "model" true
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ConventionalSpread
                                                            _conventionalRecovery.cell 
                                                            _discountCurve.cell 
                                                            _dayCounter.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ConventionalSpread") 
                                               [| _CreditDefaultSwap.source
                                               ;  _conventionalRecovery.source
                                               ;  _discountCurve.source
                                               ;  _dayCounter.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
                                ;  _conventionalRecovery.cell
                                ;  _discountCurve.cell
                                ;  _dayCounter.cell
                                ;  _model.cell
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
        ! Returns the variation of the fixed-leg value given a one-basis-point change in the running spread.
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_couponLegBPS", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_couponLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).CouponLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".CouponLegBPS") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_couponLegNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_couponLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).CouponLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".CouponLegNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_coupons", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_coupons
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).Coupons
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".Coupons") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap1", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="side",Description = "Reference to side")>] 
         side : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        ([<ExcelArgument(Name="upfront",Description = "Reference to upfront")>] 
         upfront : obj)
        ([<ExcelArgument(Name="runningSpread",Description = "Reference to runningSpread")>] 
         runningSpread : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="settlesAccrual",Description = "Reference to settlesAccrual")>] 
         settlesAccrual : obj)
        ([<ExcelArgument(Name="paysAtDefaultTime",Description = "Reference to paysAtDefaultTime")>] 
         paysAtDefaultTime : obj)
        ([<ExcelArgument(Name="protectionStart",Description = "Reference to protectionStart")>] 
         protectionStart : obj)
        ([<ExcelArgument(Name="upfrontDate",Description = "Reference to upfrontDate")>] 
         upfrontDate : obj)
        ([<ExcelArgument(Name="claim",Description = "Reference to claim")>] 
         claim : obj)
        ([<ExcelArgument(Name="lastPeriodDayCounter",Description = "Reference to lastPeriodDayCounter")>] 
         lastPeriodDayCounter : obj)
        ([<ExcelArgument(Name="rebatesAccrual",Description = "Reference to rebatesAccrual")>] 
         rebatesAccrual : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _side = Helper.toCell<Protection.Side> side "side" true
                let _notional = Helper.toCell<double> notional "notional" true
                let _upfront = Helper.toCell<double> upfront "upfront" true
                let _runningSpread = Helper.toCell<double> runningSpread "runningSpread" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _settlesAccrual = Helper.toCell<bool> settlesAccrual "settlesAccrual" true
                let _paysAtDefaultTime = Helper.toCell<bool> paysAtDefaultTime "paysAtDefaultTime" true
                let _protectionStart = Helper.toCell<Date> protectionStart "protectionStart" true
                let _upfrontDate = Helper.toCell<Date> upfrontDate "upfrontDate" true
                let _claim = Helper.toCell<Claim> claim "claim" true
                let _lastPeriodDayCounter = Helper.toCell<DayCounter> lastPeriodDayCounter "lastPeriodDayCounter" true
                let _rebatesAccrual = Helper.toCell<bool> rebatesAccrual "rebatesAccrual" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CreditDefaultSwap1 
                                                            _side.cell 
                                                            _notional.cell 
                                                            _upfront.cell 
                                                            _runningSpread.cell 
                                                            _schedule.cell 
                                                            _convention.cell 
                                                            _dayCounter.cell 
                                                            _settlesAccrual.cell 
                                                            _paysAtDefaultTime.cell 
                                                            _protectionStart.cell 
                                                            _upfrontDate.cell 
                                                            _claim.cell 
                                                            _lastPeriodDayCounter.cell 
                                                            _rebatesAccrual.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CreditDefaultSwap>) l

                let source = Helper.sourceFold "Fun.CreditDefaultSwap1" 
                                               [| _side.source
                                               ;  _notional.source
                                               ;  _upfront.source
                                               ;  _runningSpread.source
                                               ;  _schedule.source
                                               ;  _convention.source
                                               ;  _dayCounter.source
                                               ;  _settlesAccrual.source
                                               ;  _paysAtDefaultTime.source
                                               ;  _protectionStart.source
                                               ;  _upfrontDate.source
                                               ;  _claim.source
                                               ;  _lastPeriodDayCounter.source
                                               ;  _rebatesAccrual.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _side.cell
                                ;  _notional.cell
                                ;  _upfront.cell
                                ;  _runningSpread.cell
                                ;  _schedule.cell
                                ;  _convention.cell
                                ;  _dayCounter.cell
                                ;  _settlesAccrual.cell
                                ;  _paysAtDefaultTime.cell
                                ;  _protectionStart.cell
                                ;  _upfrontDate.cell
                                ;  _claim.cell
                                ;  _lastPeriodDayCounter.cell
                                ;  _rebatesAccrual.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="side",Description = "Reference to side")>] 
         side : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="settlesAccrual",Description = "Reference to settlesAccrual")>] 
         settlesAccrual : obj)
        ([<ExcelArgument(Name="paysAtDefaultTime",Description = "Reference to paysAtDefaultTime")>] 
         paysAtDefaultTime : obj)
        ([<ExcelArgument(Name="protectionStart",Description = "Reference to protectionStart")>] 
         protectionStart : obj)
        ([<ExcelArgument(Name="claim",Description = "Reference to claim")>] 
         claim : obj)
        ([<ExcelArgument(Name="lastPeriodDayCounter",Description = "Reference to lastPeriodDayCounter")>] 
         lastPeriodDayCounter : obj)
        ([<ExcelArgument(Name="rebatesAccrual",Description = "Reference to rebatesAccrual")>] 
         rebatesAccrual : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _side = Helper.toCell<Protection.Side> side "side" true
                let _notional = Helper.toCell<double> notional "notional" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _settlesAccrual = Helper.toCell<bool> settlesAccrual "settlesAccrual" true
                let _paysAtDefaultTime = Helper.toCell<bool> paysAtDefaultTime "paysAtDefaultTime" true
                let _protectionStart = Helper.toCell<Date> protectionStart "protectionStart" true
                let _claim = Helper.toCell<Claim> claim "claim" true
                let _lastPeriodDayCounter = Helper.toCell<DayCounter> lastPeriodDayCounter "lastPeriodDayCounter" true
                let _rebatesAccrual = Helper.toCell<bool> rebatesAccrual "rebatesAccrual" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.CreditDefaultSwap
                                                            _side.cell 
                                                            _notional.cell 
                                                            _spread.cell 
                                                            _schedule.cell 
                                                            _convention.cell 
                                                            _dayCounter.cell 
                                                            _settlesAccrual.cell 
                                                            _paysAtDefaultTime.cell 
                                                            _protectionStart.cell 
                                                            _claim.cell 
                                                            _lastPeriodDayCounter.cell 
                                                            _rebatesAccrual.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CreditDefaultSwap>) l

                let source = Helper.sourceFold "Fun.CreditDefaultSwap" 
                                               [| _side.source
                                               ;  _notional.source
                                               ;  _spread.source
                                               ;  _schedule.source
                                               ;  _convention.source
                                               ;  _dayCounter.source
                                               ;  _settlesAccrual.source
                                               ;  _paysAtDefaultTime.source
                                               ;  _protectionStart.source
                                               ;  _claim.source
                                               ;  _lastPeriodDayCounter.source
                                               ;  _rebatesAccrual.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _side.cell
                                ;  _notional.cell
                                ;  _spread.cell
                                ;  _schedule.cell
                                ;  _convention.cell
                                ;  _dayCounter.cell
                                ;  _settlesAccrual.cell
                                ;  _paysAtDefaultTime.cell
                                ;  _protectionStart.cell
                                ;  _claim.cell
                                ;  _lastPeriodDayCounter.cell
                                ;  _rebatesAccrual.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_defaultLegNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_defaultLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).DefaultLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".DefaultLegNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_fairSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".FairSpread") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
        Returns the upfront spread that, given the running spread and the quoted recovery rate, will make the instrument have an NPV of 0.

@returns 
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_fairUpfront", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_fairUpfront
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).FairUpfront
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".FairUpfront") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_impliedHazardRate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_impliedHazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="targetNPV",Description = "Reference to targetNPV")>] 
         targetNPV : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "Reference to recoveryRate")>] 
         recoveryRate : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let _targetNPV = Helper.toCell<double> targetNPV "targetNPV" true
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _model = Helper.toCell<PricingModel> model "model" true
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ImpliedHazardRate
                                                            _targetNPV.cell 
                                                            _discountCurve.cell 
                                                            _dayCounter.cell 
                                                            _recoveryRate.cell 
                                                            _accuracy.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ImpliedHazardRate") 
                                               [| _CreditDefaultSwap.source
                                               ;  _targetNPV.source
                                               ;  _discountCurve.source
                                               ;  _dayCounter.source
                                               ;  _recoveryRate.source
                                               ;  _accuracy.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
                                ;  _targetNPV.cell
                                ;  _discountCurve.cell
                                ;  _dayCounter.cell
                                ;  _recoveryRate.cell
                                ;  _accuracy.cell
                                ;  _model.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_isExpired", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".IsExpired") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_notional", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).Notional
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".Notional") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_paysAtDefaultTime", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_paysAtDefaultTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).PaysAtDefaultTime
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".PaysAtDefaultTime") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_protectionEndDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_protectionEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ProtectionEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ProtectionEndDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_protectionStartDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_protectionStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ProtectionStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ProtectionStartDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_rebatesAccrual", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_rebatesAccrual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).RebatesAccrual
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".RebatesAccrual") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_runningSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_runningSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).RunningSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".RunningSpread") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_settlesAccrual", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_settlesAccrual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).SettlesAccrual
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".SettlesAccrual") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_side", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_side
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).Side
                                                       ) :> ICell
                let format (o : Protection.Side) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".Side") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfront", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfront
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).Upfront
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".Upfront") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfrontBPS", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfrontBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).UpfrontBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".UpfrontBPS") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfrontNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfrontNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).UpfrontNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".UpfrontNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_CASH", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".CASH") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_errorEstimate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ErrorEstimate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_NPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".NPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_result", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".Result") 
                                               [| _CreditDefaultSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_setPricingEngine", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CreditDefaultSwap) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".SetPricingEngine") 
                                               [| _CreditDefaultSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_valuationDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "Reference to CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap" true 
                let builder () = withMnemonic mnemonic ((_CreditDefaultSwap.cell :?> CreditDefaultSwapModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CreditDefaultSwap.source + ".ValuationDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_Range", Description="Create a range of CreditDefaultSwap",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CreditDefaultSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CreditDefaultSwap")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CreditDefaultSwap> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CreditDefaultSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CreditDefaultSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CreditDefaultSwap>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
