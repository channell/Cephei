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
module RendistatoBasketFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoBasket_btps", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_btps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Btps
                                                       ) :> ICell
                let format (i : Generic.List<BTP>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Btps") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoBasket_cleanPriceQuotes", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_cleanPriceQuotes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).CleanPriceQuotes
                                                       ) :> ICell
                let format (i : Generic.List<Handle<Quote>>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".CleanPriceQuotes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoBasket_outstanding", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_outstanding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Outstanding
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Outstanding") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
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
    [<ExcelFunction(Name="_RendistatoBasket_outstandings", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_outstandings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Outstandings
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Outstandings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoBasket_registerWith", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoBasket) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_RendistatoBasket", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="btps",Description = "BTP range")>] 
         btps : obj)
        ([<ExcelArgument(Name="outstandings",Description = "double range")>] 
         outstandings : obj)
        ([<ExcelArgument(Name="cleanPriceQuote ranges",Description = "Quote range")>] 
         cleanPriceQuotes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _btps = Helper.toCell<Generic.List<BTP>> btps "btps" 
                let _outstandings = Helper.toCell<Generic.List<double>> outstandings "outstandings" 
                let _cleanPriceQuotes = Helper.toCell<Generic.List<Handle<Quote>>> cleanPriceQuotes "cleanPriceQuotes" 
                let builder (current : ICell) = (Fun.RendistatoBasket 
                                                            _btps.cell 
                                                            _outstandings.cell 
                                                            _cleanPriceQuotes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RendistatoBasket>) l

                let source () = Helper.sourceFold "Fun.RendistatoBasket" 
                                               [| _btps.source
                                               ;  _outstandings.source
                                               ;  _cleanPriceQuotes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _btps.cell
                                ;  _outstandings.cell
                                ;  _cleanPriceQuotes.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<RendistatoBasket> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoBasket_size", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
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
    [<ExcelFunction(Name="_RendistatoBasket_unregisterWith", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoBasket) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                ;  _handler.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_RendistatoBasket_update", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Update
                                                       ) :> ICell
                let format (o : RendistatoBasket) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
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
    [<ExcelFunction(Name="_RendistatoBasket_weights", Description="Create a RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoBasket",Description = "RendistatoBasket")>] 
         rendistatobasket : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoBasket = Helper.toModelReference<RendistatoBasket> rendistatobasket "RendistatoBasket"  
                let builder (current : ICell) = ((RendistatoBasketModel.Cast _RendistatoBasket.cell).Weights
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_RendistatoBasket.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RendistatoBasket.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_RendistatoBasket_Range", Description="Create a range of RendistatoBasket",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RendistatoBasket_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RendistatoBasket> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<RendistatoBasket> (c)) :> ICell
                let format (i : Cephei.Cell.List<RendistatoBasket>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<RendistatoBasket>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
