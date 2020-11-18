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
module DerivedQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DerivedQuote", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="element",Description = "Quote")>] 
         element : obj)
        ([<ExcelArgument(Name="f",Description = "double,double")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _element = Helper.toHandle<Quote> element "element" 
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DerivedQuote 
                                                            _element.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DerivedQuote>) l

                let source () = Helper.sourceFold "Fun.DerivedQuote" 
                                               [| _element.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _element.cell
                                ;  _f.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DerivedQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DerivedQuote_isValid", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DerivedQuote",Description = "DerivedQuote")>] 
         derivedquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DerivedQuote = Helper.toCell<DerivedQuote> derivedquote "DerivedQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DerivedQuoteModel.Cast _DerivedQuote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DerivedQuote.source + ".IsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DerivedQuote.cell
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
    [<ExcelFunction(Name="_DerivedQuote_update", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DerivedQuote",Description = "DerivedQuote")>] 
         derivedquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DerivedQuote = Helper.toCell<DerivedQuote> derivedquote "DerivedQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DerivedQuoteModel.Cast _DerivedQuote.cell).Update
                                                       ) :> ICell
                let format (o : DerivedQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DerivedQuote.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DerivedQuote.cell
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
        ! Quote interface
    *)
    [<ExcelFunction(Name="_DerivedQuote_value", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DerivedQuote",Description = "DerivedQuote")>] 
         derivedquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DerivedQuote = Helper.toCell<DerivedQuote> derivedquote "DerivedQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((DerivedQuoteModel.Cast _DerivedQuote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DerivedQuote.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DerivedQuote.cell
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
    [<ExcelFunction(Name="_DerivedQuote_registerWith", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DerivedQuote",Description = "DerivedQuote")>] 
         derivedquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DerivedQuote = Helper.toCell<DerivedQuote> derivedquote "DerivedQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DerivedQuoteModel.Cast _DerivedQuote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DerivedQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DerivedQuote.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DerivedQuote.cell
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
    [<ExcelFunction(Name="_DerivedQuote_unregisterWith", Description="Create a DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DerivedQuote",Description = "DerivedQuote")>] 
         derivedquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DerivedQuote = Helper.toCell<DerivedQuote> derivedquote "DerivedQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DerivedQuoteModel.Cast _DerivedQuote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DerivedQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DerivedQuote.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DerivedQuote.cell
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
    [<ExcelFunction(Name="_DerivedQuote_Range", Description="Create a range of DerivedQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DerivedQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DerivedQuote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<DerivedQuote> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<DerivedQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DerivedQuote>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
