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
(*!! ommited 
(* <summary>
  Quote adapter for the last fixing available of a given Index
  </summary> *)
[<AutoSerializable(true)>]
module LastFixingQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LastFixingQuote_isValid", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".IsValid") 
                                               [| _LastFixingQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toCell<Index> index "index" 
                let builder () = withMnemonic mnemonic (Fun.LastFixingQuote 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LastFixingQuote>) l

                let source = Helper.sourceFold "Fun.LastFixingQuote" 
                                               [| _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LastFixingQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LastFixingQuote_referenceDate", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".ReferenceDate") 
                                               [| _LastFixingQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote_update", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).Update
                                                       ) :> ICell
                let format (o : LastFixingQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".Update") 
                                               [| _LastFixingQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote_value", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".Value") 
                                               [| _LastFixingQuote.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote_registerWith", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LastFixingQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".RegisterWith") 
                                               [| _LastFixingQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote_unregisterWith", Description="Create a LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LastFixingQuote",Description = "Reference to LastFixingQuote")>] 
         lastfixingquote : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LastFixingQuote = Helper.toCell<LastFixingQuote> lastfixingquote "LastFixingQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((LastFixingQuoteModel.Cast _LastFixingQuote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LastFixingQuote) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LastFixingQuote.source + ".UnregisterWith") 
                                               [| _LastFixingQuote.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LastFixingQuote.cell
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
    [<ExcelFunction(Name="_LastFixingQuote_Range", Description="Create a range of LastFixingQuote",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LastFixingQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LastFixingQuote")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LastFixingQuote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LastFixingQuote>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LastFixingQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LastFixingQuote>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
