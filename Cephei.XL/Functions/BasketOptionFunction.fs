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
  Basket option on a number of assets   instruments
  </summary> *)
[<AutoSerializable(true)>]
module BasketOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BasketOption", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_create
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

                let _payoff = Helper.toCell<BasketPayoff> payoff "payoff" true
                let _exercise = Helper.toCell<Exercise> exercise "exercise" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.BasketOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasketOption>) l

                let source = Helper.sourceFold "Fun.BasketOption" 
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
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        greeks
    *)
    [<ExcelFunction(Name="_BasketOption_delta", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Delta") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_dividendRho", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".DividendRho") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_gamma", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Gamma") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_BasketOption_isExpired", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".IsExpired") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_rho", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Rho") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_theta", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Theta") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_vega", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Vega") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_exercise", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_BasketOption.source + ".Exercise") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasketOption_payoff", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_BasketOption.source + ".Payoff") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasketOption_CASH", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".CASH") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_errorEstimate", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".ErrorEstimate") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_NPV", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".NPV") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_result", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let _tag = Helper.toCell<string> tag "tag" true
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".Result") 
                                               [| _BasketOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_setPricingEngine", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let _e = Helper.toCell<IPricingEngine> e "e" true
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BasketOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".SetPricingEngine") 
                                               [| _BasketOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_valuationDate", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "Reference to BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption" true 
                let builder () = withMnemonic mnemonic ((_BasketOption.cell :?> BasketOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasketOption.source + ".ValuationDate") 
                                               [| _BasketOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_Range", Description="Create a range of BasketOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasketOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BasketOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BasketOption> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BasketOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BasketOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BasketOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
