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
  From http://help.rmetrics.org/fExoticOptions/LookbackOptions.html :  For a partial-time floating strike lookback option, the lookback period starts at time zero and ends at an arbitrary date before expiration. Except for the partial lookback period, the option is similar to a floating strike lookback option. The partial-time floating strike lookback option is cheaper than a similar standard floating strike lookback option. Partial-time floating strike lookback options can be priced analytically using a model introduced by Heynen and Kat (1994).
  </summary> *)
[<AutoSerializable(true)>]
module ContinuousPartialFloatingLookbackOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="minmax",Description = "Reference to minmax")>] 
         minmax : obj)
        ([<ExcelArgument(Name="lambda",Description = "Reference to lambda")>] 
         lambda : obj)
        ([<ExcelArgument(Name="lookbackPeriodEnd",Description = "Reference to lookbackPeriodEnd")>] 
         lookbackPeriodEnd : obj)
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
                let _lambda = Helper.toCell<double> lambda "lambda" 
                let _lookbackPeriodEnd = Helper.toCell<Date> lookbackPeriodEnd "lookbackPeriodEnd" 
                let _payoff = Helper.toCell<TypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ContinuousPartialFloatingLookbackOption 
                                                            _minmax.cell 
                                                            _lambda.cell 
                                                            _lookbackPeriodEnd.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ContinuousPartialFloatingLookbackOption>) l

                let source () = Helper.sourceFold "Fun.ContinuousPartialFloatingLookbackOption" 
                                               [| _minmax.source
                                               ;  _lambda.source
                                               ;  _lookbackPeriodEnd.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _minmax.cell
                                ;  _lambda.cell
                                ;  _lookbackPeriodEnd.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_delta", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Delta") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_deltaForward", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".DeltaForward") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_dividendRho", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".DividendRho") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_elasticity", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Elasticity") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_gamma", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Gamma") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_isExpired", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".IsExpired") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_itmCashProbability", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".ItmCashProbability") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_rho", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Rho") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_strikeSensitivity", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".StrikeSensitivity") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_theta", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Theta") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_thetaPerDay", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".ThetaPerDay") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_vega", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Vega") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_exercise", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Exercise") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_payoff", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Payoff") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFloatingLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_CASH", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".CASH") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_errorEstimate", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".ErrorEstimate") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_NPV", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".NPV") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_result", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".Result") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_setPricingEngine", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ContinuousPartialFloatingLookbackOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".SetPricingEngine") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_valuationDate", Description="Create a ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFloatingLookbackOption",Description = "Reference to ContinuousPartialFloatingLookbackOption")>] 
         continuouspartialfloatinglookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFloatingLookbackOption = Helper.toCell<ContinuousPartialFloatingLookbackOption> continuouspartialfloatinglookbackoption "ContinuousPartialFloatingLookbackOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ContinuousPartialFloatingLookbackOptionModel.Cast _ContinuousPartialFloatingLookbackOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ContinuousPartialFloatingLookbackOption.source + ".ValuationDate") 
                                               [| _ContinuousPartialFloatingLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFloatingLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFloatingLookbackOption_Range", Description="Create a range of ContinuousPartialFloatingLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFloatingLookbackOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ContinuousPartialFloatingLookbackOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ContinuousPartialFloatingLookbackOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ContinuousPartialFloatingLookbackOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ContinuousPartialFloatingLookbackOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ContinuousPartialFloatingLookbackOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
