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
  Continuous-floating lookback option
  </summary> *)
[<AutoSerializable(true)>]
module ContinuousFloatingLookbackOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="minmax",Description = "Reference to minmax")>] 
         minmax : obj)
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

                let _minmax = Helper.toCell<double> minmax "minmax" 
                let _payoff = Helper.toCell<TypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ContinuousFloatingLookbackOption 
                                                            _minmax.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ContinuousFloatingLookbackOption>) l

                let source = Helper.sourceFold "Fun.ContinuousFloatingLookbackOption" 
                                               [| _minmax.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _minmax.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_delta", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Delta") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_deltaForward", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".DeltaForward") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_dividendRho", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".DividendRho") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_elasticity", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Elasticity") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_gamma", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Gamma") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_isExpired", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".IsExpired") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_itmCashProbability", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".ItmCashProbability") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_rho", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Rho") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_strikeSensitivity", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".StrikeSensitivity") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_theta", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Theta") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_thetaPerDay", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".ThetaPerDay") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_vega", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Vega") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_exercise", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Exercise") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_payoff", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Payoff") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_CASH", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".CASH") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_errorEstimate", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".ErrorEstimate") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_NPV", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".NPV") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_result", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".Result") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_setPricingEngine", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ContinuousFloatingLookbackOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".SetPricingEngine") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_valuationDate", Description="Create a ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFloatingLookbackOption",Description = "Reference to ContinuousFloatingLookbackOption")>] 
         continuousfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFloatingLookbackOption = Helper.toCell<ContinuousFloatingLookbackOption> continuousfloatinglookbackoption "ContinuousFloatingLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFloatingLookbackOptionModel.Cast _ContinuousFloatingLookbackOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ContinuousFloatingLookbackOption.source + ".ValuationDate") 
                                               [| _ContinuousFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFloatingLookbackOption_Range", Description="Create a range of ContinuousFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousFloatingLookbackOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ContinuousFloatingLookbackOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ContinuousFloatingLookbackOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ContinuousFloatingLookbackOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ContinuousFloatingLookbackOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ContinuousFloatingLookbackOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
