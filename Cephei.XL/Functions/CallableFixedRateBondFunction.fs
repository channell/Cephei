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
module CallableFixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableFixedRateBond", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_create
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
        ([<ExcelArgument(Name="putCallSchedule",Description = "Reference to putCallSchedule")>] 
         putCallSchedule : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _putCallSchedule = Helper.toCell<CallabilitySchedule> putCallSchedule "putCallSchedule" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.CallableFixedRateBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _putCallSchedule.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableFixedRateBond>) l

                let source = Helper.sourceFold "Fun.CallableFixedRateBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _putCallSchedule.source
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
                                ;  _putCallSchedule.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableFixedRateBond_callability", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Callability") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_cleanPriceOAS", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_cleanPriceOAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).CleanPriceOAS
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".CleanPriceOAS") 
                                               [| _CallableFixedRateBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_effectiveConvexity", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_effectiveConvexity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).EffectiveConvexity
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".EffectiveConvexity") 
                                               [| _CallableFixedRateBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_effectiveDuration", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_effectiveDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).EffectiveDuration
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".EffectiveDuration") 
                                               [| _CallableFixedRateBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_impliedVolatility", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Reference to minVol")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Reference to maxVol")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".ImpliedVolatility") 
                                               [| _CallableFixedRateBond.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_OAS", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_OAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let _guess = Helper.toCell<double> guess "guess" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).OAS
                                                            _cleanPrice.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                            _guess.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".OAS") 
                                               [| _CallableFixedRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxIterations.source
                                               ;  _guess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                ;  _cleanPrice.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxIterations.cell
                                ;  _guess.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_accruedAmount", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".AccruedAmount") 
                                               [| _CallableFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_calendar", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Calendar") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableFixedRateBond> format
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
    [<ExcelFunction(Name="_CallableFixedRateBond_cashflows", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Cashflows") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_cleanPrice", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".CleanPrice") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_cleanPrice1", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
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

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".CleanPrice1") 
                                               [| _CallableFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_dirtyPrice1", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
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

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".DirtyPrice1") 
                                               [| _CallableFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_dirtyPrice", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".DirtyPrice") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_isExpired", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".IsExpired") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_issueDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".IssueDate") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_isTradable", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".IsTradable") 
                                               [| _CallableFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_maturityDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".MaturityDate") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_nextCashFlowDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".NextCashFlowDate") 
                                               [| _CallableFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_nextCouponRate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".NextCouponRate") 
                                               [| _CallableFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_notional", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Notional") 
                                               [| _CallableFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_notionals", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Notionals") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_previousCashFlowDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".PreviousCashFlowDate") 
                                               [| _CallableFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_previousCouponRate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".PreviousCouponRate") 
                                               [| _CallableFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_redemption", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Redemption") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableFixedRateBond> format
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
    [<ExcelFunction(Name="_CallableFixedRateBond_redemptions", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Redemptions") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_settlementDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".SettlementDate") 
                                               [| _CallableFixedRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_settlementDays", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".SettlementDays") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_settlementValue", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".SettlementValue") 
                                               [| _CallableFixedRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_settlementValue1", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".SettlementValue1") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_startDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".StartDate") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_yield1", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
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

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Yield1") 
                                               [| _CallableFixedRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_yield", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
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

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Yield") 
                                               [| _CallableFixedRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_CASH", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".CASH") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_errorEstimate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".ErrorEstimate") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_NPV", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".NPV") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_result", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".Result") 
                                               [| _CallableFixedRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_setPricingEngine", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CallableFixedRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".SetPricingEngine") 
                                               [| _CallableFixedRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_valuationDate", Description="Create a CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableFixedRateBond",Description = "Reference to CallableFixedRateBond")>] 
         callablefixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableFixedRateBond = Helper.toCell<CallableFixedRateBond> callablefixedratebond "CallableFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_CallableFixedRateBond.cell :?> CallableFixedRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableFixedRateBond.source + ".ValuationDate") 
                                               [| _CallableFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableFixedRateBond.cell
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
    [<ExcelFunction(Name="_CallableFixedRateBond_Range", Description="Create a range of CallableFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableFixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CallableFixedRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableFixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableFixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableFixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CallableFixedRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
