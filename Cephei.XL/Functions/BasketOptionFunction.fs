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
    [<ExcelFunction(Name="_BasketOption", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "BasketOption")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "BasketPayoff")>] 
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

                let _payoff = Helper.toCell<BasketPayoff> payoff "payoff" 
                let _exercise = Helper.toCell<Exercise> exercise "exercise" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BasketOption 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasketOption>) l

                let source () = Helper.sourceFold "Fun.BasketOption" 
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
                    ; subscriber = Helper.subscriberModel<BasketOption> format
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
    [<ExcelFunction(Name="_BasketOption_delta", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Delta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Delta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_dividendRho", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).DividendRho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".DividendRho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_gamma", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Gamma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Gamma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_isExpired", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_rho", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_theta", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_vega", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Vega
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Vega") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_exercise", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_BasketOption.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasketOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasketOption_payoff", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Payoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_BasketOption.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasketOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasketOption_CASH", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_errorEstimate", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_NPV", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_result", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_setPricingEngine", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : BasketOption) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_valuationDate", Description="Create a BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasketOption",Description = "BasketOption")>] 
         basketoption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasketOption = Helper.toCell<BasketOption> basketoption "BasketOption"  
                let builder (current : ICell) = withMnemonic mnemonic ((BasketOptionModel.Cast _BasketOption.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BasketOption.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BasketOption.cell
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
    [<ExcelFunction(Name="_BasketOption_Range", Description="Create a range of BasketOption",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BasketOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BasketOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BasketOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BasketOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BasketOption>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
