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
    [<ExcelFunction(Name="_CreditDefaultSwap_accrualRebateNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_accrualRebateNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).AccrualRebateNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".AccrualRebateNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_conventionalSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_conventionalSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="conventionalRecovery",Description = "double")>] 
         conventionalRecovery : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="model",Description = "Helper.Range.fromModelList")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let _conventionalRecovery = Helper.toCell<double> conventionalRecovery "conventionalRecovery" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _model = Helper.toDefault<PricingModel> model "model" PricingModel.Midpoint
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ConventionalSpread
                                                            _conventionalRecovery.cell 
                                                            _discountCurve.cell 
                                                            _dayCounter.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ConventionalSpread") 
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
        ! Returns the variation of the fixed-leg value given a one-basis-point change in the running spread.
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_couponLegBPS", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_couponLegBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).CouponLegBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".CouponLegBPS") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_couponLegNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_couponLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).CouponLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".CouponLegNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_coupons", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_coupons
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).Coupons
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".Coupons") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap1", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "CreditDefaultSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="side",Description = "Protection.Side")>] 
         side : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        ([<ExcelArgument(Name="upfront",Description = "double")>] 
         upfront : obj)
        ([<ExcelArgument(Name="runningSpread",Description = "double")>] 
         runningSpread : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention")>] 
         convention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="settlesAccrual",Description = "CreditDefaultSwap")>] 
         settlesAccrual : obj)
        ([<ExcelArgument(Name="paysAtDefaultTime",Description = "CreditDefaultSwap")>] 
         paysAtDefaultTime : obj)
        ([<ExcelArgument(Name="protectionStart",Description = "CreditDefaultSwap")>] 
         protectionStart : obj)
        ([<ExcelArgument(Name="upfrontDate",Description = "CreditDefaultSwap")>] 
         upfrontDate : obj)
        ([<ExcelArgument(Name="claim",Description = "CreditDefaultSwap")>] 
         claim : obj)
        ([<ExcelArgument(Name="lastPeriodDayCounter",Description = "CreditDefaultSwap")>] 
         lastPeriodDayCounter : obj)
        ([<ExcelArgument(Name="rebatesAccrual",Description = "CreditDefaultSwap")>] 
         rebatesAccrual : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _side = Helper.toCell<Protection.Side> side "side" 
                let _notional = Helper.toCell<double> notional "notional" 
                let _upfront = Helper.toCell<double> upfront "upfront" 
                let _runningSpread = Helper.toCell<double> runningSpread "runningSpread" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _settlesAccrual = Helper.toDefault<bool> settlesAccrual "settlesAccrual" true
                let _paysAtDefaultTime = Helper.toDefault<bool> paysAtDefaultTime "paysAtDefaultTime" true
                let _protectionStart = Helper.toDefault<Date> protectionStart "protectionStart" null
                let _upfrontDate = Helper.toDefault<Date> upfrontDate "upfrontDate" null
                let _claim = Helper.toDefault<Claim> claim "claim" null
                let _lastPeriodDayCounter = Helper.toDefault<DayCounter> lastPeriodDayCounter "lastPeriodDayCounter" null
                let _rebatesAccrual = Helper.toDefault<bool> rebatesAccrual "rebatesAccrual" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CreditDefaultSwap1 
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

                let source () = Helper.sourceFold "Fun.CreditDefaultSwap1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CreditDefaultSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CreditDefaultSwap")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="side",Description = "Protection.Side")>] 
         side : obj)
        ([<ExcelArgument(Name="notional",Description = "double")>] 
         notional : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention")>] 
         convention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="settlesAccrual",Description = "CreditDefaultSwap")>] 
         settlesAccrual : obj)
        ([<ExcelArgument(Name="paysAtDefaultTime",Description = "CreditDefaultSwap")>] 
         paysAtDefaultTime : obj)
        ([<ExcelArgument(Name="protectionStart",Description = "CreditDefaultSwap")>] 
         protectionStart : obj)
        ([<ExcelArgument(Name="claim",Description = "CreditDefaultSwap")>] 
         claim : obj)
        ([<ExcelArgument(Name="lastPeriodDayCounter",Description = "CreditDefaultSwap")>] 
         lastPeriodDayCounter : obj)
        ([<ExcelArgument(Name="rebatesAccrual",Description = "CreditDefaultSwap")>] 
         rebatesAccrual : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _side = Helper.toCell<Protection.Side> side "side" 
                let _notional = Helper.toCell<double> notional "notional" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _settlesAccrual = Helper.toDefault<bool> settlesAccrual "settlesAccrual" true
                let _paysAtDefaultTime = Helper.toDefault<bool> paysAtDefaultTime "paysAtDefaultTime" true
                let _protectionStart = Helper.toDefault<Date> protectionStart "protectionStart" null
                let _claim = Helper.toDefault<Claim> claim "claim" null
                let _lastPeriodDayCounter = Helper.toDefault<DayCounter> lastPeriodDayCounter "lastPeriodDayCounter" null
                let _rebatesAccrual = Helper.toDefault<bool> rebatesAccrual "rebatesAccrual" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CreditDefaultSwap
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

                let source () = Helper.sourceFold "Fun.CreditDefaultSwap" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CreditDefaultSwap> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_defaultLegNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_defaultLegNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).DefaultLegNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".DefaultLegNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_fairSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_fairSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).FairSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".FairSpread") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
        Returns the upfront spread that, given the running spread and the quoted recovery rate, will make the instrument have an NPV of 0.

@returns 
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_fairUpfront", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_fairUpfront
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).FairUpfront
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".FairUpfront") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_impliedHazardRate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_impliedHazardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="targetNPV",Description = "double")>] 
         targetNPV : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "Helper.Range.fromModelList")>] 
         recoveryRate : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Helper.Range.fromModelList")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="model",Description = "Helper.Range.fromModelList")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let _targetNPV = Helper.toCell<double> targetNPV "targetNPV" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _recoveryRate = Helper.toDefault<double> recoveryRate "recoveryRate" 0.4
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-6
                let _model = Helper.toDefault<PricingModel> model "model" PricingModel.Midpoint
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ImpliedHazardRate
                                                            _targetNPV.cell 
                                                            _discountCurve.cell 
                                                            _dayCounter.cell 
                                                            _recoveryRate.cell 
                                                            _accuracy.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ImpliedHazardRate") 
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
    [<ExcelFunction(Name="_CreditDefaultSwap_isExpired", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".IsExpired") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_notional", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).Notional
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".Notional") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_paysAtDefaultTime", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_paysAtDefaultTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).PaysAtDefaultTime
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".PaysAtDefaultTime") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_protectionEndDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_protectionEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ProtectionEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ProtectionEndDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_protectionStartDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_protectionStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ProtectionStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ProtectionStartDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_rebatesAccrual", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_rebatesAccrual
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).RebatesAccrual
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".RebatesAccrual") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_runningSpread", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_runningSpread
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).RunningSpread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".RunningSpread") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_settlesAccrual", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_settlesAccrual
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).SettlesAccrual
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".SettlesAccrual") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CreditDefaultSwap_side", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_side
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).Side
                                                       ) :> ICell
                let format (o : Protection.Side) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".Side") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfront", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfront
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).Upfront
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".Upfront") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfrontBPS", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfrontBPS
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).UpfrontBPS
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".UpfrontBPS") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_upfrontNPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_upfrontNPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).UpfrontNPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".UpfrontNPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_CASH", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".CASH") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_errorEstimate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ErrorEstimate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_NPV", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".NPV") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_result", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".Result") 
                                               [| _CreditDefaultSwap.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_setPricingEngine", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CreditDefaultSwap) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".SetPricingEngine") 
                                               [| _CreditDefaultSwap.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_valuationDate", Description="Create a CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CreditDefaultSwap",Description = "CreditDefaultSwap")>] 
         creditdefaultswap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CreditDefaultSwap = Helper.toCell<CreditDefaultSwap> creditdefaultswap "CreditDefaultSwap"  
                let builder (current : ICell) = withMnemonic mnemonic ((CreditDefaultSwapModel.Cast _CreditDefaultSwap.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CreditDefaultSwap.source + ".ValuationDate") 
                                               [| _CreditDefaultSwap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CreditDefaultSwap.cell
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
    [<ExcelFunction(Name="_CreditDefaultSwap_Range", Description="Create a range of CreditDefaultSwap",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CreditDefaultSwap_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CreditDefaultSwap> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CreditDefaultSwap>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CreditDefaultSwap>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CreditDefaultSwap>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
