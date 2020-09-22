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
  %Barrier option on a single asset.   The analytic pricing Engine will be used if none if passed.  instruments
  </summary> *)
[<AutoSerializable(true)>]
module BarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BarrierOption", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "Reference to barrierType")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier",Description = "Reference to barrier")>] 
         barrier : obj)
        ([<ExcelArgument(Name="rebate",Description = "Reference to rebate")>] 
         rebate : obj)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _barrierType = Helper.toCell<Barrier.Type> barrierType "barrierType" true
                let _barrier = Helper.toCell<double> barrier "barrier" true
                let _rebate = Helper.toCell<double> rebate "rebate" true
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.BarrierOption 
                                                            _barrierType.cell 
                                                            _barrier.cell 
                                                            _rebate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BarrierOption>) l

                let source = Helper.sourceFold "Fun.BarrierOption" 
                                               [| _barrierType.source
                                               ;  _barrier.source
                                               ;  _rebate.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _barrierType.cell
                                ;  _barrier.cell
                                ;  _rebate.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
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
        ! \warning see VanillaOption for notes on implied-volatility calculation.
    *)
    [<ExcelFunction(Name="_BarrierOption_impliedVolatility", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
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

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".ImpliedVolatility") 
                                               [| _BarrierOption.source
                                               ;  _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
                                ;  _targetValue.cell
                                ;  _Process.cell
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
    [<ExcelFunction(Name="_BarrierOption_delta", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Delta") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_deltaForward", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".DeltaForward") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_dividendRho", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".DividendRho") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_elasticity", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Elasticity") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_gamma", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Gamma") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_isExpired", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".IsExpired") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_itmCashProbability", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".ItmCashProbability") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_rho", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Rho") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_strikeSensitivity", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".StrikeSensitivity") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_theta", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Theta") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_thetaPerDay", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".ThetaPerDay") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_vega", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Vega") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_exercise", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_BarrierOption.source + ".Exercise") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_payoff", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_BarrierOption.source + ".Payoff") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_CASH", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".CASH") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_errorEstimate", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".ErrorEstimate") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_NPV", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".NPV") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_result", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".Result") 
                                               [| _BarrierOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_setPricingEngine", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".SetPricingEngine") 
                                               [| _BarrierOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_valuationDate", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "Reference to BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption" true 
                let builder () = withMnemonic mnemonic ((_BarrierOption.cell :?> BarrierOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BarrierOption.source + ".ValuationDate") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_Range", Description="Create a range of BarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BarrierOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BarrierOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BarrierOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
