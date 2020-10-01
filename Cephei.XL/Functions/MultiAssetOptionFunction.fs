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
  Base class for options on multiple assets
  </summary> *)
[<AutoSerializable(true)>]
module MultiAssetOptionFunction =

    (*
        greeks
    *)
    [<ExcelFunction(Name="_MultiAssetOption_delta", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Delta") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_dividendRho", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".DividendRho") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_gamma", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Gamma") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_isExpired", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".IsExpired") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_create
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
                let builder () = withMnemonic mnemonic (Fun.MultiAssetOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiAssetOption>) l

                let source = Helper.sourceFold "Fun.MultiAssetOption" 
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
                    ; subscriber = Helper.subscriberModel<MultiAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiAssetOption_rho", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Rho") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_theta", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Theta") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_vega", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Vega") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_exercise", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Exercise") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiAssetOption_payoff", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Payoff") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiAssetOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiAssetOption_CASH", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".CASH") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_errorEstimate", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".ErrorEstimate") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_NPV", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".NPV") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_result", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".Result") 
                                               [| _MultiAssetOption.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_setPricingEngine", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : MultiAssetOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".SetPricingEngine") 
                                               [| _MultiAssetOption.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_valuationDate", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "Reference to MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder () = withMnemonic mnemonic ((_MultiAssetOption.cell :?> MultiAssetOptionModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MultiAssetOption.source + ".ValuationDate") 
                                               [| _MultiAssetOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_Range", Description="Create a range of MultiAssetOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiAssetOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MultiAssetOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiAssetOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MultiAssetOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MultiAssetOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MultiAssetOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
