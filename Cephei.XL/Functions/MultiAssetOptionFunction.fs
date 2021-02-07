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
    [<ExcelFunction(Name="_MultiAssetOption_delta", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_dividendRho", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_gamma", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
        Instrument interface
    *)
    [<ExcelFunction(Name="_MultiAssetOption_isExpired", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Payoff")>] 
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

                let _payoff = Helper.toCell<Payoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = (Fun.MultiAssetOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiAssetOption>) l

                let source () = Helper.sourceFold "Fun.MultiAssetOption" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_MultiAssetOption_rho", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_theta", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_vega", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_exercise", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_MultiAssetOption_payoff", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_MultiAssetOption_CASH", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_errorEstimate", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_NPV", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_result", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_setPricingEngine", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : MultiAssetOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_valuationDate", Description="Create a MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiAssetOption",Description = "MultiAssetOption")>] 
         multiassetoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiAssetOption = Helper.toCell<MultiAssetOption> multiassetoption "MultiAssetOption"  
                let builder (current : ICell) = ((MultiAssetOptionModel.Cast _MultiAssetOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_MultiAssetOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MultiAssetOption.cell
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
    [<ExcelFunction(Name="_MultiAssetOption_Range", Description="Create a range of MultiAssetOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiAssetOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiAssetOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MultiAssetOption> (c)) :> ICell
                let format (i : Cephei.Cell.List<MultiAssetOption>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MultiAssetOption>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
