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
module EuropeanOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuropeanOption", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
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

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.EuropeanOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuropeanOption>) l

                let source = Helper.sourceFold "Fun.EuropeanOption" 
                                               [| _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
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
        ! \warning currently, this method returns the Black-Scholes implied volatility using analytic formulas for European options and a finite-difference method for American and Bermudan options. It will give unconsistent results if the pricing was performed with any other methods (such as jump-diffusion models.)  \warning options with a gamma that changes sign (e.g., binary options) have values that are <b>not</b> monotonic in the volatility. In these cases, the calculation can fail and the result (if any) is almost meaningless.  Another possible source of failure is to have a target value that is not attainable with any volatility, e.g., a target value lower than the intrinsic value in the case of American options.
    *)
    [<ExcelFunction(Name="_EuropeanOption_impliedVolatility", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
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

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let _targetValue = Helper.toCell<double> targetValue "targetValue" true
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _accuracy = Helper.toCell<double> accuracy "accuracy" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let _minVol = Helper.toCell<double> minVol "minVol" true
                let _maxVol = Helper.toCell<double> maxVol "maxVol" true
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".ImpliedVolatility") 
                                               [| _EuropeanOption.source
                                               ;  _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_delta", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Delta") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_deltaForward", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".DeltaForward") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_dividendRho", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".DividendRho") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_elasticity", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Elasticity") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_gamma", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Gamma") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_isExpired", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".IsExpired") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_itmCashProbability", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".ItmCashProbability") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_rho", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Rho") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_strikeSensitivity", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".StrikeSensitivity") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_theta", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Theta") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_thetaPerDay", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".ThetaPerDay") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_vega", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Vega") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_exercise", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_EuropeanOption.source + ".Exercise") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_payoff", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_EuropeanOption.source + ".Payoff") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_CASH", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".CASH") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_errorEstimate", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".ErrorEstimate") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_NPV", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".NPV") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_result", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : object) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".Result") 
                                               [| _EuropeanOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_setPricingEngine", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : EuropeanOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".SetPricingEngine") 
                                               [| _EuropeanOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_valuationDate", Description="Create a EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuropeanOption",Description = "Reference to EuropeanOption")>] 
         europeanoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuropeanOption = Helper.toCell<EuropeanOption> europeanoption "EuropeanOption" true 
                let builder () = withMnemonic mnemonic ((_EuropeanOption.cell :?> EuropeanOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuropeanOption.source + ".ValuationDate") 
                                               [| _EuropeanOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuropeanOption.cell
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
    [<ExcelFunction(Name="_EuropeanOption_Range", Description="Create a range of EuropeanOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuropeanOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EuropeanOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuropeanOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuropeanOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuropeanOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EuropeanOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
