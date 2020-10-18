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
  Simple stock class
  </summary> *)
[<AutoSerializable(true)>]
module StockFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Stock_isExpired", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Stock")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Stock.source + ".IsExpired") 
                                               [| _Stock.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Stock")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "Quote")>] 
         quote : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toHandle<Quote> quote "quote" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Stock 
                                                            _quote.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Stock>) l

                let source () = Helper.sourceFold "Fun.Stock" 
                                               [| _quote.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Stock> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Stock_CASH", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Stock.source + ".CASH") 
                                               [| _Stock.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_errorEstimate", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Stock.source + ".ErrorEstimate") 
                                               [| _Stock.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_NPV", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Stock.source + ".NPV") 
                                               [| _Stock.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_result", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        ([<ExcelArgument(Name="tag",Description = "string")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Stock.source + ".Result") 
                                               [| _Stock.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_setPricingEngine", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        ([<ExcelArgument(Name="e",Description = "IPricingEngine")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Stock) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Stock.source + ".SetPricingEngine") 
                                               [| _Stock.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_valuationDate", Description="Create a Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Stock",Description = "Stock")>] 
         stock : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Stock = Helper.toCell<Stock> stock "Stock"  
                let builder (current : ICell) = withMnemonic mnemonic ((StockModel.Cast _Stock.cell).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Stock.source + ".ValuationDate") 
                                               [| _Stock.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Stock.cell
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
    [<ExcelFunction(Name="_Stock_Range", Description="Create a range of Stock",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Stock_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Stock> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Stock>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Stock>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Stock>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
