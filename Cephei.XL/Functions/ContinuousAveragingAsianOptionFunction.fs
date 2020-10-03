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
  Continuous-averaging Asian option   add running average  instruments
  </summary> *)
[<AutoSerializable(true)>]
module ContinuousAveragingAsianOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="averageType",Description = "Reference to averageType")>] 
         averageType : obj)
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

                let _averageType = Helper.toCell<Average.Type> averageType "averageType" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ContinuousAveragingAsianOption 
                                                            _averageType.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ContinuousAveragingAsianOption>) l

                let source = Helper.sourceFold "Fun.ContinuousAveragingAsianOption" 
                                               [| _averageType.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _averageType.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_delta", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Delta") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_deltaForward", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".DeltaForward") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_dividendRho", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".DividendRho") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_elasticity", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Elasticity") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_gamma", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Gamma") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_isExpired", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".IsExpired") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_itmCashProbability", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".ItmCashProbability") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_rho", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Rho") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_strikeSensitivity", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".StrikeSensitivity") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_theta", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Theta") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_thetaPerDay", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".ThetaPerDay") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_vega", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Vega") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_exercise", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Exercise") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_payoff", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Payoff") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousAveragingAsianOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_CASH", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".CASH") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_errorEstimate", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".ErrorEstimate") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_NPV", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".NPV") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_result", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".Result") 
                                               [| _ContinuousAveragingAsianOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_setPricingEngine", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ContinuousAveragingAsianOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".SetPricingEngine") 
                                               [| _ContinuousAveragingAsianOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_valuationDate", Description="Create a ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousAveragingAsianOption",Description = "Reference to ContinuousAveragingAsianOption")>] 
         continuousaveragingasianoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousAveragingAsianOption = Helper.toCell<ContinuousAveragingAsianOption> continuousaveragingasianoption "ContinuousAveragingAsianOption"  
                let builder () = withMnemonic mnemonic ((ContinuousAveragingAsianOptionModel.Cast _ContinuousAveragingAsianOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ContinuousAveragingAsianOption.source + ".ValuationDate") 
                                               [| _ContinuousAveragingAsianOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousAveragingAsianOption.cell
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
    [<ExcelFunction(Name="_ContinuousAveragingAsianOption_Range", Description="Create a range of ContinuousAveragingAsianOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousAveragingAsianOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ContinuousAveragingAsianOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ContinuousAveragingAsianOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ContinuousAveragingAsianOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ContinuousAveragingAsianOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ContinuousAveragingAsianOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
