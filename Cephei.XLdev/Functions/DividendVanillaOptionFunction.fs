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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module DividendVanillaOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DividendVanillaOption", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Reference to exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="dividendDates",Description = "Reference to dividendDates")>] 
         dividendDates : obj)
        ([<ExcelArgument(Name="dividends",Description = "Reference to dividends")>] 
         dividends : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _dividendDates = Helper.toCell<Generic.List<Date>> dividendDates "dividendDates" true
                let _dividends = Helper.toCell<Generic.List<double>> dividends "dividends" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.DividendVanillaOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _dividendDates.cell 
                                                            _dividends.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DividendVanillaOption>) l

                let source = Helper.sourceFold "Fun.DividendVanillaOption" 
                                               [| _payoff.source
                                               ;  _exercise.source
                                               ;  _dividendDates.source
                                               ;  _dividends.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _exercise.cell
                                ;  _dividendDates.cell
                                ;  _dividends.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_impliedVolatility", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
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

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".ImpliedVolatility") 
                                               [| _DividendVanillaOption.source
                                               ;  _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_delta", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Delta") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_deltaForward", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".DeltaForward") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_dividendRho", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".DividendRho") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_elasticity", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Elasticity") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_gamma", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Gamma") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_isExpired", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".IsExpired") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_itmCashProbability", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".ItmCashProbability") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_rho", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Rho") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_strikeSensitivity", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".StrikeSensitivity") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_theta", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Theta") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_thetaPerDay", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".ThetaPerDay") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_vega", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Vega") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_exercise", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Exercise") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_payoff", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Payoff") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_CASH", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".CASH") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_errorEstimate", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".ErrorEstimate") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_NPV", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".NPV") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_result", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".Result") 
                                               [| _DividendVanillaOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_setPricingEngine", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : DividendVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".SetPricingEngine") 
                                               [| _DividendVanillaOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_valuationDate", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "Reference to DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption" true 
                let builder () = withMnemonic mnemonic ((_DividendVanillaOption.cell :?> DividendVanillaOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DividendVanillaOption.source + ".ValuationDate") 
                                               [| _DividendVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_Range", Description="Create a range of DividendVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DividendVanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DividendVanillaOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DividendVanillaOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DividendVanillaOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DividendVanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DividendVanillaOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
