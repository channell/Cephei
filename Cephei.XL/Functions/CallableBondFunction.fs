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
(*!!
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module CallableBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableBond_callability", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".Callability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPriceOAS", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_cleanPriceOAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
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
        ([<ExcelArgument(Name="settlement",Description = "Calendar")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).CleanPriceOAS
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".CleanPriceOAS") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_effectiveConvexity", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_effectiveConvexity
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
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
        ([<ExcelArgument(Name="bump",Description = "Calendar")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toDefault<double> bump "bump" 2e-4
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).EffectiveConvexity
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".EffectiveConvexity") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_effectiveDuration", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_effectiveDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
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
        ([<ExcelArgument(Name="bump",Description = "Calendar")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toDefault<double> bump "bump" 2e-4
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).EffectiveDuration
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".EffectiveDuration") 

                                               [| _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_impliedVolatility", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Calendar")>] 
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

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_OAS", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_OAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
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
        ([<ExcelArgument(Name="settlement",Description = "Calendar")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Calendar")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "Calendar")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="guess",Description = "Calendar")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxIterations = Helper.toDefault<int> maxIterations "maxIterations" 100
                let _guess = Helper.toDefault<double> guess "guess" 0.0
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).OAS
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

                let source () = Helper.sourceFold (_CallableBond.source + ".OAS") 

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
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_accruedAmount", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Calendar")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".AccruedAmount") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_calendar", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_CallableBond.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBond> format
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
    [<ExcelFunction(Name="_CallableBond_cashflows", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CallableBond.source + ".Cashflows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".CleanPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".CleanPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_dirtyPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="Yield",Description = "double")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".DirtyPrice") 

                                               [| _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_dirtyPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".DirtyPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_isExpired", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_issueDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".IssueDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_isTradable", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".IsTradable") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_maturityDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_nextCashFlowDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".NextCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_nextCouponRate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".NextCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_notional", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".Notional") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_notionals", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_CallableBond.source + ".Notionals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_previousCashFlowDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".PreviousCashFlowDate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_previousCouponRate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "CashFlow")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".PreviousCouponRate") 

                                               [| _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_redemption", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "CashFlow")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CallableBond.source + ".Redemption") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBond> format
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
    [<ExcelFunction(Name="_CallableBond_redemptions", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_CallableBond.source + ".Redemptions") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".SettlementDate") 

                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementDays", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".SettlementDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementValue", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".SettlementValue") 

                                               [| _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementValue", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".SettlementValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_startDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_yield", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "double")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Helper.Range.fromModelList")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Helper.Range.fromModelList")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toDefault<Date> settlement "settlement" null
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".Yield") 

                                               [| _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_yield", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="dc",Description = "DayCounter")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Compounding: Simple, Compounded, Continuous, SimpleThenCompounded")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Helper.Range.fromModelList")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-10
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".Yield") 

                                               [| _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_CASH", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_errorEstimate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_NPV", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_result", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_setPricingEngine", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CallableBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_valuationDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((CallableBondModel.Cast _CallableBond.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CallableBond.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_Range", Description="Create a range of CallableBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CallableBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CallableBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
