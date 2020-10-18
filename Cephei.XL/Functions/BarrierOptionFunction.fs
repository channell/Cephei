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
    [<ExcelFunction(Name="_BarrierOption", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "BarrierOption")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="barrierType",Description = "Barrier.Type")>] 
         barrierType : obj)
        ([<ExcelArgument(Name="barrier",Description = "double")>] 
         barrier : obj)
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

                let _barrierType = Helper.toCell<Barrier.Type> barrierType "barrierType" 
                let _barrier = Helper.toCell<double> barrier "barrier" 
                let _rebate = Helper.toCell<double> rebate "rebate" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BarrierOption 
                                                            _barrierType.cell 
                                                            _barrier.cell 
                                                            _rebate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BarrierOption>) l

                let source () = Helper.sourceFold "Fun.BarrierOption" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BarrierOption> format
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
    [<ExcelFunction(Name="_BarrierOption_impliedVolatility", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="targetValue",Description = "double")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Exercise")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Exercise")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Exercise")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Exercise")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _accuracy = Helper.toDefault<double> accuracy "accuracy" 1.0e-4
                let _maxEvaluations = Helper.toDefault<int> maxEvaluations "maxEvaluations" 100
                let _minVol = Helper.toDefault<double> minVol "minVol" 1.0e-7
                let _maxVol = Helper.toDefault<double> maxVol "maxVol" 4.0
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _Process.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".ImpliedVolatility") 
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
    [<ExcelFunction(Name="_BarrierOption_delta", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Delta") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_deltaForward", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".DeltaForward") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_dividendRho", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".DividendRho") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_elasticity", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Elasticity") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_gamma", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Gamma") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_isExpired", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".IsExpired") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_itmCashProbability", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".ItmCashProbability") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_rho", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Rho") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_strikeSensitivity", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".StrikeSensitivity") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_theta", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Theta") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_thetaPerDay", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".ThetaPerDay") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_vega", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Vega") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_exercise", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_BarrierOption.source + ".Exercise") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BarrierOption_payoff", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Payoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_BarrierOption.source + ".Payoff") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BarrierOption_CASH", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".CASH") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_errorEstimate", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".ErrorEstimate") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_NPV", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".NPV") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_result", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".Result") 
                                               [| _BarrierOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_setPricingEngine", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BarrierOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".SetPricingEngine") 
                                               [| _BarrierOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_valuationDate", Description="Create a BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BarrierOption",Description = "BarrierOption")>] 
         barrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BarrierOption = Helper.toCell<BarrierOption> barrieroption "BarrierOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BarrierOptionModel.Cast _BarrierOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BarrierOption.source + ".ValuationDate") 
                                               [| _BarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BarrierOption.cell
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
    [<ExcelFunction(Name="_BarrierOption_Range", Description="Create a range of BarrierOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BarrierOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
