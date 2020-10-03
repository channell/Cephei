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
  Continuous-fixed lookback option
  </summary> *)
[<AutoSerializable(true)>]
module ContinuousFixedLookbackOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_create
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
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ContinuousFixedLookbackOption 
                                                            _minmax.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ContinuousFixedLookbackOption>) l

                let source = Helper.sourceFold "Fun.ContinuousFixedLookbackOption" 
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
                    ; subscriber = Helper.subscriberModel<ContinuousFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_delta", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Delta") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_deltaForward", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".DeltaForward") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_dividendRho", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".DividendRho") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_elasticity", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Elasticity") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_gamma", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Gamma") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_isExpired", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".IsExpired") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_itmCashProbability", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".ItmCashProbability") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_rho", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Rho") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_strikeSensitivity", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".StrikeSensitivity") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_theta", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Theta") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_thetaPerDay", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".ThetaPerDay") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_vega", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Vega") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_exercise", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Exercise") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_payoff", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Payoff") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ContinuousFixedLookbackOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_CASH", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".CASH") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_errorEstimate", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".ErrorEstimate") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_NPV", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".NPV") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_result", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".Result") 
                                               [| _ContinuousFixedLookbackOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_setPricingEngine", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ContinuousFixedLookbackOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".SetPricingEngine") 
                                               [| _ContinuousFixedLookbackOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_valuationDate", Description="Create a ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ContinuousFixedLookbackOption",Description = "Reference to ContinuousFixedLookbackOption")>] 
         continuousfixedlookbackoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ContinuousFixedLookbackOption = Helper.toCell<ContinuousFixedLookbackOption> continuousfixedlookbackoption "ContinuousFixedLookbackOption"  
                let builder () = withMnemonic mnemonic ((ContinuousFixedLookbackOptionModel.Cast _ContinuousFixedLookbackOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ContinuousFixedLookbackOption.source + ".ValuationDate") 
                                               [| _ContinuousFixedLookbackOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ContinuousFixedLookbackOption.cell
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
    [<ExcelFunction(Name="_ContinuousFixedLookbackOption_Range", Description="Create a range of ContinuousFixedLookbackOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ContinuousFixedLookbackOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ContinuousFixedLookbackOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ContinuousFixedLookbackOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ContinuousFixedLookbackOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ContinuousFixedLookbackOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ContinuousFixedLookbackOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
