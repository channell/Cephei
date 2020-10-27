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
  base option class
  </summary> *)
[<AutoSerializable(true)>]
module OptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Option_exercise", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_exercise
        ([<ExcelArgument(Name="Mnemonic",Description = "Exercise")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).Exercise
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source () = Helper.sourceFold (_Option.source + ".Exercise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Option> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Option", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Option")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Option 
                                                            _payoff.cell 
                                                            _exercise.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Option>) l

                let source () = Helper.sourceFold "Fun.Option" 
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
                    ; subscriber = Helper.subscriberModel<Option> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Option_payoff", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_payoff
        ([<ExcelArgument(Name="Mnemonic",Description = "Payoff")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).Payoff
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Payoff>) l

                let source () = Helper.sourceFold (_Option.source + ".Payoff") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Option> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Option_CASH", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Option.source + ".CASH") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_errorEstimate", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Option.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
        ! returns whether the instrument is still tradable.
    *)
    [<ExcelFunction(Name="_Option_isExpired", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Option.source + ".IsExpired") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_NPV", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Option.source + ".NPV") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_result", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Option.source + ".Result") 

                                               [| _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_setPricingEngine", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Option) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Option.source + ".SetPricingEngine") 

                                               [| _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_valuationDate", Description="Create a Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Option",Description = "Option")>] 
         option : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Option = Helper.toCell<Option> option "Option"  
                let builder (current : ICell) = withMnemonic mnemonic ((OptionModel.Cast _Option.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Option.source + ".ValuationDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Option.cell
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
    [<ExcelFunction(Name="_Option_Range", Description="Create a range of Option",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Option_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Option> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Option>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Option>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Option>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
