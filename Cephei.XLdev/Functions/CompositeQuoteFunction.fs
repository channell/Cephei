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
module CompositeQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CompositeQuote", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="element1",Description = "Reference to element1")>] 
         element1 : obj)
        ([<ExcelArgument(Name="element2",Description = "Reference to element2")>] 
         element2 : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _element1 = Helper.toHandle<Handle<Quote>> element1 "element1" 
                let _element2 = Helper.toHandle<Handle<Quote>> element2 "element2" 
                let _f = Helper.toCell<Func<double,double,double>> f "f" true
                let builder () = withMnemonic mnemonic (Fun.CompositeQuote 
                                                            _element1.cell 
                                                            _element2.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CompositeQuote>) l

                let source = Helper.sourceFold "Fun.CompositeQuote" 
                                               [| _element1.source
                                               ;  _element2.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _element1.cell
                                ;  _element2.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_CompositeQuote_isValid", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".IsValid") 
                                               [| _CompositeQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
    [<ExcelFunction(Name="_CompositeQuote_update", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).Update
                                                       ) :> ICell
                let format (o : CompositeQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".Update") 
                                               [| _CompositeQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
        ! Quote interface
    *)
    [<ExcelFunction(Name="_CompositeQuote_value", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".Value") 
                                               [| _CompositeQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
        inspectors
    *)
    [<ExcelFunction(Name="_CompositeQuote_value1", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).Value1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".Value1") 
                                               [| _CompositeQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
    [<ExcelFunction(Name="_CompositeQuote_value2", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_value2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).Value2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".Value2") 
                                               [| _CompositeQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
    [<ExcelFunction(Name="_CompositeQuote_registerWith", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CompositeQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".RegisterWith") 
                                               [| _CompositeQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
    [<ExcelFunction(Name="_CompositeQuote_unregisterWith", Description="Create a CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CompositeQuote",Description = "Reference to CompositeQuote")>] 
         compositequote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CompositeQuote = Helper.toCell<CompositeQuote> compositequote "CompositeQuote" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CompositeQuote.cell :?> CompositeQuoteModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CompositeQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CompositeQuote.source + ".UnregisterWith") 
                                               [| _CompositeQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CompositeQuote.cell
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
    [<ExcelFunction(Name="_CompositeQuote_Range", Description="Create a range of CompositeQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CompositeQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CompositeQuote")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CompositeQuote> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CompositeQuote>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CompositeQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CompositeQuote>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
