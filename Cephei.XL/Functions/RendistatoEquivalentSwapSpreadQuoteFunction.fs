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
  RendistatoCalculator equivalent swap spread Quote adapter
  </summary> *)
[<AutoSerializable(true)>]
module RendistatoEquivalentSwapSpreadQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote_isValid", Description="Create a RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapSpreadQuote",Description = "Reference to RendistatoEquivalentSwapSpreadQuote")>] 
         rendistatoequivalentswapspreadquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapSpreadQuote = Helper.toCell<RendistatoEquivalentSwapSpreadQuote> rendistatoequivalentswapspreadquote "RendistatoEquivalentSwapSpreadQuote" true 
                let builder () = withMnemonic mnemonic ((_RendistatoEquivalentSwapSpreadQuote.cell :?> RendistatoEquivalentSwapSpreadQuoteModel).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RendistatoEquivalentSwapSpreadQuote.source + ".IsValid") 
                                               [| _RendistatoEquivalentSwapSpreadQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapSpreadQuote.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote", Description="Create a RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r = Helper.toCell<RendistatoCalculator> r "r" true
                let builder () = withMnemonic mnemonic (Fun.RendistatoEquivalentSwapSpreadQuote 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RendistatoEquivalentSwapSpreadQuote>) l

                let source = Helper.sourceFold "Fun.RendistatoEquivalentSwapSpreadQuote" 
                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote_value", Description="Create a RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapSpreadQuote",Description = "Reference to RendistatoEquivalentSwapSpreadQuote")>] 
         rendistatoequivalentswapspreadquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapSpreadQuote = Helper.toCell<RendistatoEquivalentSwapSpreadQuote> rendistatoequivalentswapspreadquote "RendistatoEquivalentSwapSpreadQuote" true 
                let builder () = withMnemonic mnemonic ((_RendistatoEquivalentSwapSpreadQuote.cell :?> RendistatoEquivalentSwapSpreadQuoteModel).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RendistatoEquivalentSwapSpreadQuote.source + ".Value") 
                                               [| _RendistatoEquivalentSwapSpreadQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapSpreadQuote.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote_registerWith", Description="Create a RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapSpreadQuote",Description = "Reference to RendistatoEquivalentSwapSpreadQuote")>] 
         rendistatoequivalentswapspreadquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapSpreadQuote = Helper.toCell<RendistatoEquivalentSwapSpreadQuote> rendistatoequivalentswapspreadquote "RendistatoEquivalentSwapSpreadQuote" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RendistatoEquivalentSwapSpreadQuote.cell :?> RendistatoEquivalentSwapSpreadQuoteModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoEquivalentSwapSpreadQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RendistatoEquivalentSwapSpreadQuote.source + ".RegisterWith") 
                                               [| _RendistatoEquivalentSwapSpreadQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapSpreadQuote.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote_unregisterWith", Description="Create a RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RendistatoEquivalentSwapSpreadQuote",Description = "Reference to RendistatoEquivalentSwapSpreadQuote")>] 
         rendistatoequivalentswapspreadquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RendistatoEquivalentSwapSpreadQuote = Helper.toCell<RendistatoEquivalentSwapSpreadQuote> rendistatoequivalentswapspreadquote "RendistatoEquivalentSwapSpreadQuote" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RendistatoEquivalentSwapSpreadQuote.cell :?> RendistatoEquivalentSwapSpreadQuoteModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RendistatoEquivalentSwapSpreadQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RendistatoEquivalentSwapSpreadQuote.source + ".UnregisterWith") 
                                               [| _RendistatoEquivalentSwapSpreadQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RendistatoEquivalentSwapSpreadQuote.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_RendistatoEquivalentSwapSpreadQuote_Range", Description="Create a range of RendistatoEquivalentSwapSpreadQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RendistatoEquivalentSwapSpreadQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RendistatoEquivalentSwapSpreadQuote")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RendistatoEquivalentSwapSpreadQuote> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RendistatoEquivalentSwapSpreadQuote>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RendistatoEquivalentSwapSpreadQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RendistatoEquivalentSwapSpreadQuote>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
