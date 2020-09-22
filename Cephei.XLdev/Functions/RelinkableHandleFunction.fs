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
  An instance of this class can be relinked so that it points to another observable. The change will be propagated to all handles that were created as copies of such instance.
  </summary> *)
[<AutoSerializable(true)>]
module RelinkableHandleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RelinkableHandle_linkTo", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_linkTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let _h = Helper.toCell<'T> h "h" true
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).LinkTo
                                                            _h.cell 
                                                       ) :> ICell
                let format (o : RelinkableHandle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".LinkTo") 
                                               [| _RelinkableHandle.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
                                ;  _h.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_linkTo", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_linkTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="registerAsObserver",Description = "Reference to registerAsObserver")>] 
         registerAsObserver : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let _h = Helper.toCell<'T> h "h" true
                let _registerAsObserver = Helper.toCell<bool> registerAsObserver "registerAsObserver" true
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).LinkTo1
                                                            _h.cell 
                                                            _registerAsObserver.cell 
                                                       ) :> ICell
                let format (o : RelinkableHandle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".LinkTo1") 
                                               [| _RelinkableHandle.source
                                               ;  _h.source
                                               ;  _registerAsObserver.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
                                ;  _h.cell
                                ;  _registerAsObserver.cell
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
    [<ExcelFunction(Name="_RelinkableHandle", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.RelinkableHandle 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RelinkableHandle>) l

                let source = Helper.sourceFold "Fun.RelinkableHandle" 
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
    [<ExcelFunction(Name="_RelinkableHandle1", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toCell<'T> h "h" true
                let builder () = withMnemonic mnemonic (Fun.RelinkableHandle1 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RelinkableHandle>) l

                let source = Helper.sourceFold "Fun.RelinkableHandle1" 
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
    [<ExcelFunction(Name="_RelinkableHandle2", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_create2
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
                let builder () = withMnemonic mnemonic (Fun.RelinkableHandle2 
                                                            _h.cell 
                                                            _registerAsObserver.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RelinkableHandle>) l

                let source = Helper.sourceFold "Fun.RelinkableHandle2" 
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
        ! dereferencing
    *)
    [<ExcelFunction(Name="_RelinkableHandle_currentLink", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_currentLink
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).CurrentLink
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".CurrentLink") 
                                               [| _RelinkableHandle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_empty", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".Empty") 
                                               [| _RelinkableHandle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_Equals", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".Equals") 
                                               [| _RelinkableHandle.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_link", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_link
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).Link
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".Link") 
                                               [| _RelinkableHandle.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_registerWith", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RelinkableHandle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".RegisterWith") 
                                               [| _RelinkableHandle.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_unregisterWith", Description="Create a RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RelinkableHandle",Description = "Reference to RelinkableHandle")>] 
         relinkablehandle : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RelinkableHandle = Helper.toCell<RelinkableHandle> relinkablehandle "RelinkableHandle" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RelinkableHandle.cell :?> RelinkableHandleModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RelinkableHandle) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RelinkableHandle.source + ".UnregisterWith") 
                                               [| _RelinkableHandle.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RelinkableHandle.cell
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
    [<ExcelFunction(Name="_RelinkableHandle_Range", Description="Create a range of RelinkableHandle",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RelinkableHandle_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RelinkableHandle")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RelinkableHandle> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RelinkableHandle>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RelinkableHandle>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RelinkableHandle>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
