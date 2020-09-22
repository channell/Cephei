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
  All copies of an instance of this class refer to the same observable by means of a relinkable smart pointer. When such pointer is relinked to another observable, the change will be propagated to all the copies.
<tt>registerAsObserver</tt> is not needed since C# does automatic garbage collection
  </summary> *)
[<AutoSerializable(true)>]
module HandleFunction =

    (*
        ! dereferencing
    *)
    [<ExcelFunction(Name="_Handle_currentLink", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_currentLink
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).CurrentLink
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".CurrentLink") 
                                               [| _Handle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
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
        ! checks if the contained shared pointer points to anything
    *)
    [<ExcelFunction(Name="_Handle_empty", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".Empty") 
                                               [| _Handle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
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
    [<ExcelFunction(Name="_Handle_Equals", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".Equals") 
                                               [| _Handle.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_Handle", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toCell<'T> h "h" true
                let builder () = withMnemonic mnemonic (Fun.Handle 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle>) l

                let source = Helper.sourceFold "Fun.Handle" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
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
    [<ExcelFunction(Name="_Handle1", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="registerAsObserver",Description = "Reference to registerAsObserver")>] 
         registerAsObserver : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toCell<'T> h "h" true
                let _registerAsObserver = Helper.toCell<bool> registerAsObserver "registerAsObserver" true
                let builder () = withMnemonic mnemonic (Fun.Handle1 
                                                            _h.cell 
                                                            _registerAsObserver.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle>) l

                let source = Helper.sourceFold "Fun.Handle1" 
                                               [| _h.source
                                               ;  _registerAsObserver.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _registerAsObserver.cell
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
    [<ExcelFunction(Name="_Handle2", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Handle2 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle>) l

                let source = Helper.sourceFold "Fun.Handle2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_Handle_link", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_link
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).Link
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".Link") 
                                               [| _Handle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
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
        dereferencing of the observable to the Link
    *)
    [<ExcelFunction(Name="_Handle_registerWith", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Handle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".RegisterWith") 
                                               [| _Handle.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
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
    [<ExcelFunction(Name="_Handle_unregisterWith", Description="Create a Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Handle",Description = "Reference to Handle")>] 
         handle : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Handle = Helper.toCell<Handle> handle "Handle" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Handle.cell :?> HandleModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Handle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Handle.source + ".UnregisterWith") 
                                               [| _Handle.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Handle.cell
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
    [<ExcelFunction(Name="_Handle_Range", Description="Create a range of Handle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Handle_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Handle")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Handle> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Handle>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Handle>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Handle>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
