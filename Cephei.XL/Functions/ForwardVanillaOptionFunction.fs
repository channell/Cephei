﻿(*
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
    [<ExcelFunction(Name="_ForwardVanillaOption", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="moneyness",Description = "Reference to moneyness")>] 
         moneyness : obj)
        ([<ExcelArgument(Name="resetDate",Description = "Reference to resetDate")>] 
         resetDate : obj)
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

                let _moneyness = Helper.toCell<double> moneyness "moneyness" 
                let _resetDate = Helper.toCell<Date> resetDate "resetDate" 
                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.ForwardVanillaOption 
                                                            _moneyness.cell 
                                                            _resetDate.cell 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardVanillaOption>) l

                let source = Helper.sourceFold "Fun.ForwardVanillaOption" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ForwardVanillaOption_delta", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Delta") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_deltaForward", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".DeltaForward") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_dividendRho", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".DividendRho") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_elasticity", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Elasticity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Elasticity") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_gamma", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Gamma") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_isExpired", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".IsExpired") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_itmCashProbability", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".ItmCashProbability") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_rho", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Rho") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_strikeSensitivity", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".StrikeSensitivity") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_theta", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Theta") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_thetaPerDay", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).ThetaPerDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".ThetaPerDay") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_vega", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Vega") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_exercise", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Exercise") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ForwardVanillaOption_payoff", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Payoff") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_ForwardVanillaOption_CASH", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".CASH") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_errorEstimate", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".ErrorEstimate") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_NPV", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".NPV") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_result", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".Result") 
                                               [| _ForwardVanillaOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_setPricingEngine", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".SetPricingEngine") 
                                               [| _ForwardVanillaOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_valuationDate", Description="Create a ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaOption",Description = "Reference to ForwardVanillaOption")>] 
         forwardvanillaoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaOption = Helper.toCell<ForwardVanillaOption> forwardvanillaoption "ForwardVanillaOption"  
                let builder () = withMnemonic mnemonic ((_ForwardVanillaOption.cell :?> ForwardVanillaOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ForwardVanillaOption.source + ".ValuationDate") 
                                               [| _ForwardVanillaOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaOption.cell
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
    [<ExcelFunction(Name="_ForwardVanillaOption_Range", Description="Create a range of ForwardVanillaOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ForwardVanillaOption")>] 
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
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardVanillaOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ForwardVanillaOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"