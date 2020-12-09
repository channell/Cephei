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
    [<ExcelFunction(Name="_DividendVanillaOption", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "StrikedTypePayoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="exercise",Description = "Exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="dividendDate ranges",Description = "Date range")>] 
         dividendDates : obj)
        ([<ExcelArgument(Name="dividends",Description = "double range")>] 
         dividends : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _dividendDates = Helper.toCell<Generic.List<Date>> dividendDates "dividendDates" 
                let _dividends = Helper.toCell<Generic.List<double>> dividends "dividends" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DividendVanillaOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _dividendDates.cell 
                                                            _dividends.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DividendVanillaOption>) l

                let source () = Helper.sourceFold "Fun.DividendVanillaOption" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DividendVanillaOption> format
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
    [<ExcelFunction(Name="_DividendVanillaOption_impliedVolatility", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
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

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".ImpliedVolatility") 

                                               [| _targetValue.source
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
    [<ExcelFunction(Name="_DividendVanillaOption_delta", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_deltaForward", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".DeltaForward") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_dividendRho", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_elasticity", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Elasticity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_gamma", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_isExpired", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_itmCashProbability", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".ItmCashProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_rho", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_strikeSensitivity", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".StrikeSensitivity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_theta", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_thetaPerDay", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".ThetaPerDay") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_vega", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_exercise", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DividendVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DividendVanillaOption_payoff", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DividendVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DividendVanillaOption_CASH", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_errorEstimate", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_NPV", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_result", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_setPricingEngine", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : DividendVanillaOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_valuationDate", Description="Create a DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DividendVanillaOption",Description = "DividendVanillaOption")>] 
         dividendvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DividendVanillaOption = Helper.toCell<DividendVanillaOption> dividendvanillaoption "DividendVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((DividendVanillaOptionModel.Cast _DividendVanillaOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DividendVanillaOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DividendVanillaOption.cell
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
    [<ExcelFunction(Name="_DividendVanillaOption_Range", Description="Create a range of DividendVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DividendVanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DividendVanillaOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DividendVanillaOption> (c)) :> ICell
                let format (i : Generic.List<ICell<DividendVanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DividendVanillaOption>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
