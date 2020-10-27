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

  </summary> *)
[<AutoSerializable(true)>]
module ForwardVanillaOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaOption", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "ForwardVanillaOption")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="moneyness",Description = "double")>] 
         moneyness : obj)
        ([<ExcelArgument(Name="resetDate",Description = "Date")>] 
         resetDate : obj)
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

                let _moneyness = Helper.toCell<double> moneyness "moneyness" 
                let _resetDate = Helper.toCell<Date> resetDate "resetDate" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ForwardVanillaOption 
                                                            _moneyness.cell 
                                                            _resetDate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardVanillaOption>) l

                let source () = Helper.sourceFold "Fun.ForwardVanillaOption" 
                                               [| _moneyness.source
                                               ;  _resetDate.source
                                               ;  _payoff.source
                                               ;  _exercise.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _moneyness.cell
                                ;  _resetDate.cell
                                ;  _payoff.cell
                                ;  _exercise.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaOption_delta", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_deltaForward", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".DeltaForward") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_dividendRho", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_elasticity", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Elasticity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_gamma", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_isExpired", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_itmCashProbability", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".ItmCashProbability") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_rho", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_strikeSensitivity", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".StrikeSensitivity") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_theta", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_thetaPerDay", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".ThetaPerDay") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_vega", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_exercise", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaOption_payoff", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Payoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardVanillaOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaOption_CASH", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_errorEstimate", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_NPV", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_result", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_setPricingEngine", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_valuationDate", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaOptionModel.Cast _ForwardVanillaOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_Range", Description="Create a range of ForwardVanillaOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardVanillaOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardVanillaOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardVanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<ForwardVanillaOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
