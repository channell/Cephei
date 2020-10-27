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
module CallableZeroCouponBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableZeroCouponBond", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CallableZeroCouponBond")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "double")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Date")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "CallableZeroCouponBond")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "CallableZeroCouponBond")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "CallableZeroCouponBond")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="putCallSchedule",Description = "CallableZeroCouponBond")>] 
         putCallSchedule : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _putCallSchedule = Helper.toDefault<CallabilitySchedule> putCallSchedule "putCallSchedule" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CallableZeroCouponBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _calendar.cell 
                                                            _maturityDate.cell 
                                                            _dayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _putCallSchedule.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CallableZeroCouponBond>) l

                let source () = Helper.sourceFold "Fun.CallableZeroCouponBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _calendar.source
                                               ;  _maturityDate.source
                                               ;  _dayCounter.source
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
                                ;  _calendar.cell
                                ;  _maturityDate.cell
                                ;  _dayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _putCallSchedule.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableZeroCouponBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CallableZeroCouponBond_callability", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Callability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPriceOAS", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPriceOAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "double")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "YieldTermStructure")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).CleanPriceOAS
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPriceOAS") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_effectiveConvexity", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_effectiveConvexity
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "double")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "YieldTermStructure")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "double")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).EffectiveConvexity
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".EffectiveConvexity") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_effectiveDuration", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_effectiveDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="oas",Description = "double")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "YieldTermStructure")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "double")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).EffectiveDuration
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".EffectiveDuration") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_impliedVolatility", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "double")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "double")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_OAS", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_OAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="engineTS",Description = "YieldTermStructure")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "int")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="guess",Description = "double")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let _guess = Helper.toCell<double> guess "guess" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).OAS
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

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".OAS") 

                                               [| _cleanPrice.source
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
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_accruedAmount", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_calendar", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableZeroCouponBond> format
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cashflows", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPrice", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_cleanPrice1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
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

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".CleanPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_dirtyPrice1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
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

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".DirtyPrice1") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_dirtyPrice", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_isExpired", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_issueDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_isTradable", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_maturityDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_nextCashFlowDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_nextCouponRate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_notional", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_notionals", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_previousCashFlowDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_previousCouponRate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Date")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_redemption", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableZeroCouponBond> format
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_redemptions", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementDays", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementValue", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_settlementValue1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".SettlementValue1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_startDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_yield1", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
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

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Yield1") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_yield", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
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

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_CASH", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_errorEstimate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_NPV", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_result", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_setPricingEngine", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CallableZeroCouponBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_valuationDate", Description="Create a CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableZeroCouponBond",Description = "CallableZeroCouponBond")>] 
         callablezerocouponbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableZeroCouponBond = Helper.toCell<CallableZeroCouponBond> callablezerocouponbond "CallableZeroCouponBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableZeroCouponBondModel.Cast _CallableZeroCouponBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableZeroCouponBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableZeroCouponBond.cell
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
    [<ExcelFunction(Name="_CallableZeroCouponBond_Range", Description="Create a range of CallableZeroCouponBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableZeroCouponBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableZeroCouponBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableZeroCouponBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableZeroCouponBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CallableZeroCouponBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
