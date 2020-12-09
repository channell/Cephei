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
simple quote class   market element returning a stored value
  </summary> *)
[<AutoSerializable(true)>]
module SimpleQuoteFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimpleQuote_isValid", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_isValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).IsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".IsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
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
    [<ExcelFunction(Name="_SimpleQuote_reset", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).Reset
                                                       ) :> ICell
                let format (o : SimpleQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
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
        ! returns the difference between the new value and the old value
    *)
    [<ExcelFunction(Name="_SimpleQuote_setValue", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_setValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let _value = Helper.toNullable<double> value "value"
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).SetValue
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".SetValue") 

                                               [| _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_SimpleQuote1", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _value = Helper.toNullable<double> value "value"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SimpleQuote1 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpleQuote>) l

                let source () = Helper.sourceFold "Fun.SimpleQuote1" 
                                               [| _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _value.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimpleQuote> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimpleQuote", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SimpleQuote ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpleQuote>) l

                let source () = Helper.sourceFold "Fun.SimpleQuote" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimpleQuote> format
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
    [<ExcelFunction(Name="_SimpleQuote_value", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".Value") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
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
    [<ExcelFunction(Name="_SimpleQuote_registerWith", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SimpleQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
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
    [<ExcelFunction(Name="_SimpleQuote_unregisterWith", Description="Create a SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpleQuote",Description = "SimpleQuote")>] 
         simplequote : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpleQuote = Helper.toCell<SimpleQuote> simplequote "SimpleQuote"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SimpleQuoteModel.Cast _SimpleQuote.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SimpleQuote) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimpleQuote.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpleQuote.cell
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
    [<ExcelFunction(Name="_SimpleQuote_Range", Description="Create a range of SimpleQuote",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimpleQuote_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimpleQuote> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SimpleQuote> (c)) :> ICell
                let format (i : Generic.List<ICell<SimpleQuote>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SimpleQuote>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
