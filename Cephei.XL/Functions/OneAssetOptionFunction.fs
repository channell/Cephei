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
  Base class for options on a single asset
  </summary> *)
[<AutoSerializable(true)>]
module OneAssetOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OneAssetOption_delta", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Delta") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_deltaForward", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".DeltaForward") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_dividendRho", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".DividendRho") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_elasticity", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Elasticity") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_gamma", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Gamma") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_isExpired", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".IsExpired") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_itmCashProbability", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".ItmCashProbability") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_create
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

                let _payoff = Helper.toCell<Payoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.OneAssetOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OneAssetOption>) l

                let source = Helper.sourceFold "Fun.OneAssetOption" 
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
                    ; subscriber = Helper.subscriberModel<OneAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OneAssetOption_rho", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Rho") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_strikeSensitivity", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".StrikeSensitivity") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_theta", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Theta") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_thetaPerDay", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".ThetaPerDay") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_vega", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Vega") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_exercise", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_OneAssetOption.source + ".Exercise") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OneAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OneAssetOption_payoff", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_OneAssetOption.source + ".Payoff") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OneAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OneAssetOption_CASH", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".CASH") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_errorEstimate", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".ErrorEstimate") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_NPV", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".NPV") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_result", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".Result") 
                                               [| _OneAssetOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_setPricingEngine", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : OneAssetOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".SetPricingEngine") 
                                               [| _OneAssetOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_valuationDate", Description="Create a OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OneAssetOption",Description = "Reference to OneAssetOption")>] 
         oneassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OneAssetOption = Helper.toCell<OneAssetOption> oneassetoption "OneAssetOption"  
                let builder () = withMnemonic mnemonic ((OneAssetOptionModel.Cast _OneAssetOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OneAssetOption.source + ".ValuationDate") 
                                               [| _OneAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OneAssetOption.cell
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
    [<ExcelFunction(Name="_OneAssetOption_Range", Description="Create a range of OneAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OneAssetOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OneAssetOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OneAssetOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OneAssetOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OneAssetOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OneAssetOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
