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
  The analytic pricing engine will be used if none if passed.  instruments
  </summary> *)
[<AutoSerializable(true)>]
module DoubleBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DoubleBarrierOption", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "DoubleBarrier.Type")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier_lo",Description = "double")>] 
         barrier_lo : obj)
        ([<ExcelArgument(Name="barrier_hi",Description = "double")>] 
         barrier_hi : obj)
        ([<ExcelArgument(Name="rebate",Description = "double")>] 
         rebate : obj)
        ([<ExcelArgument(Name="payoff",Description = "StrikedTypePayoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _barrierType = Helper.toCell<DoubleBarrier.Type> barrierType "barrierType" 
                let _barrier_lo = Helper.toCell<double> barrier_lo "barrier_lo" 
                let _barrier_hi = Helper.toCell<double> barrier_hi "barrier_hi" 
                let _rebate = Helper.toCell<double> rebate "rebate" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DoubleBarrierOption 
                                                            _barrierType.cell 
                                                            _barrier_lo.cell 
                                                            _barrier_hi.cell 
                                                            _rebate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DoubleBarrierOption>) l

                let source () = Helper.sourceFold "Fun.DoubleBarrierOption" 
                                               [| _barrierType.source
                                               ;  _barrier_lo.source
                                               ;  _barrier_hi.source
                                               ;  _rebate.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _barrierType.cell
                                ;  _barrier_lo.cell
                                ;  _barrier_hi.cell
                                ;  _rebate.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning see VanillaOption for notes on implied-volatility calculation.
    *)
    [<ExcelFunction(Name="_DoubleBarrierOption_impliedVolatility", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="accuracy",Description = "double or empty")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "int or empty")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "double or empty")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "double or empty")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
                                ;  _targetValue.cell
                                ;  _Process.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_delta", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_deltaForward", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".DeltaForward") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_dividendRho", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_elasticity", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Elasticity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_gamma", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_isExpired", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_itmCashProbability", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".ItmCashProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_rho", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_strikeSensitivity", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".StrikeSensitivity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_theta", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_thetaPerDay", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".ThetaPerDay") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_vega", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_exercise", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DoubleBarrierOption_payoff", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DoubleBarrierOption_CASH", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_errorEstimate", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_NPV", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_result", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_setPricingEngine", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : DoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_valuationDate", Description="Create a DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoubleBarrierOption",Description = "DoubleBarrierOption")>] 
         doublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoubleBarrierOption = Helper.toCell<DoubleBarrierOption> doublebarrieroption "DoubleBarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DoubleBarrierOptionModel.Cast _DoubleBarrierOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DoubleBarrierOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DoubleBarrierOption_Range", Description="Create a range of DoubleBarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DoubleBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DoubleBarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DoubleBarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DoubleBarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DoubleBarrierOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
