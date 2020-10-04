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
  From http://help.rmetrics.org/fExoticOptions/LookbackOptions.html :  For a partial-time fixed strike lookback option, the lookback period starts at a predetermined date after the initialization date of the option.  The partial-time fixed strike lookback call option payoff is given by the difference between the maximum observed price of the underlying asset during the lookback period and the fixed strike price. The partial-time fixed strike lookback put option payoff is given by the difference between the fixed strike price and the minimum observed price of the underlying asset during the lookback period. The partial-time fixed strike lookback option is cheaper than a similar standard fixed strike lookback option. Partial-time fixed strike lookback options can be priced analytically using a model introduced by Heynen and Kat (1994).
  </summary> *)
[<AutoSerializable(true)>]
module ContinuousPartialFixedLookbackOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lookbackPeriodStart",Description = "Reference to lookbackPeriodStart")>] 
         lookbackPeriodStart : obj)
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

                let _lookbackPeriodStart = Helper.toCell<Date> lookbackPeriodStart "lookbackPeriodStart" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ContinuousPartialFixedLookbackOption 
                                                            _lookbackPeriodStart.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ContinuousPartialFixedLookbackOption>) l

                let source = Helper.sourceFold "Fun.ContinuousPartialFixedLookbackOption" 
                                               [| _lookbackPeriodStart.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lookbackPeriodStart.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_delta", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Delta") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_deltaForward", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".DeltaForward") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_dividendRho", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".DividendRho") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_elasticity", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Elasticity") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_gamma", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Gamma") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_isExpired", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".IsExpired") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_itmCashProbability", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".ItmCashProbability") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_rho", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Rho") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_strikeSensitivity", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".StrikeSensitivity") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_theta", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Theta") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_thetaPerDay", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".ThetaPerDay") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_vega", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Vega") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_exercise", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Exercise") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_payoff", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Payoff") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousPartialFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_CASH", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".CASH") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_errorEstimate", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".ErrorEstimate") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_NPV", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".NPV") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_result", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".Result") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_setPricingEngine", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ContinuousPartialFixedLookbackOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".SetPricingEngine") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_valuationDate", Description="Create a ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousPartialFixedLookbackOption",Description = "Reference to ContinuousPartialFixedLookbackOption")>] 
         continuouspartialfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousPartialFixedLookbackOption = Helper.toCell<ContinuousPartialFixedLookbackOption> continuouspartialfixedlookbackoption "ContinuousPartialFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousPartialFixedLookbackOptionModel.Cast _ContinuousPartialFixedLookbackOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ContinuousPartialFixedLookbackOption.source + ".ValuationDate") 
                                               [| _ContinuousPartialFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousPartialFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousPartialFixedLookbackOption_Range", Description="Create a range of ContinuousPartialFixedLookbackOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ContinuousPartialFixedLookbackOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ContinuousPartialFixedLookbackOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ContinuousPartialFixedLookbackOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ContinuousPartialFixedLookbackOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ContinuousPartialFixedLookbackOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ContinuousPartialFixedLookbackOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
