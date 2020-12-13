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
module SpreadOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadOption", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "PlainVanillaPayoff")>] 
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

                let _payoff = Helper.toCell<PlainVanillaPayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SpreadOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadOption>) l

                let source () = Helper.sourceFold "Fun.SpreadOption" 
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
                    ; subscriber = Helper.subscriberModel<SpreadOption> format
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
    [<ExcelFunction(Name="_SpreadOption_delta", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_dividendRho", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_gamma", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_isExpired", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_rho", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_theta", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_vega", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_exercise", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_SpreadOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadOption_payoff", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_SpreadOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadOption_CASH", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_errorEstimate", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_NPV", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_result", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_setPricingEngine", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : SpreadOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_valuationDate", Description="Create a SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadOption",Description = "SpreadOption")>] 
         spreadoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadOption = Helper.toCell<SpreadOption> spreadoption "SpreadOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadOptionModel.Cast _SpreadOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SpreadOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadOption.cell
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
    [<ExcelFunction(Name="_SpreadOption_Range", Description="Create a range of SpreadOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SpreadOption> (c)) :> ICell
                let format (i : Cephei.Cell.List<SpreadOption>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SpreadOption>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
