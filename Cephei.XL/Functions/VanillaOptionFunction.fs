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
  Vanilla option (no discrete dividends, no barriers) on a single asset
  </summary> *)
[<AutoSerializable(true)>]
module VanillaOptionFunction =

    (*
        ! \warning currently, this method returns the Black-Scholes implied volatility using analytic formulas for European options and a finite-difference method for American and Bermudan options. It will give unconsistent results if the pricing was performed with any other methods (such as jump-diffusion models.)  \warning options with a gamma that changes sign (e.g., binary options) have values that are <b>not</b> monotonic in the volatility. In these cases, the calculation can fail and the result (if any) is almost meaningless.  Another possible source of failure is to have a target value that is not attainable with any volatility, e.g., a target value lower than the intrinsic value in the case of American options.
    *)
    [<ExcelFunction(Name="_VanillaOption_impliedVolatility", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
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

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".ImpliedVolatility") 
                                               [| _VanillaOption.source
                                               ;  _targetValue.source
                                               ;  _Process.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_create
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

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.VanillaOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaOption>) l

                let source = Helper.sourceFold "Fun.VanillaOption" 
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
                    ; subscriber = Helper.subscriberModel<VanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaOption_delta", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Delta") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_deltaForward", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".DeltaForward") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_dividendRho", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".DividendRho") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_elasticity", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Elasticity") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_gamma", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Gamma") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_isExpired", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".IsExpired") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_itmCashProbability", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".ItmCashProbability") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_rho", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Rho") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_strikeSensitivity", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".StrikeSensitivity") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_theta", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Theta") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_thetaPerDay", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".ThetaPerDay") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_vega", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Vega") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_exercise", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_VanillaOption.source + ".Exercise") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaOption_payoff", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_VanillaOption.source + ".Payoff") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VanillaOption_CASH", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".CASH") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_errorEstimate", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".ErrorEstimate") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_NPV", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".NPV") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_result", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".Result") 
                                               [| _VanillaOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_setPricingEngine", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : VanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".SetPricingEngine") 
                                               [| _VanillaOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_valuationDate", Description="Create a VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VanillaOption",Description = "Reference to VanillaOption")>] 
         vanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VanillaOption = Helper.toCell<VanillaOption> vanillaoption "VanillaOption"  
                let builder () = withMnemonic mnemonic ((VanillaOptionModel.Cast _VanillaOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_VanillaOption.source + ".ValuationDate") 
                                               [| _VanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VanillaOption.cell
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
    [<ExcelFunction(Name="_VanillaOption_Range", Description="Create a range of VanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the VanillaOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VanillaOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VanillaOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<VanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<VanillaOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
