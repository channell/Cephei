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
module WeakEventSourceFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_WeakEventSource_Clear", Description="Create a WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_Clear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeakEventSource",Description = "WeakEventSource")>] 
         weakeventsource : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeakEventSource = Helper.toModelReference<WeakEventSource> weakeventsource "WeakEventSource"  
                let builder (current : ICell) = ((WeakEventSourceModel.Cast _WeakEventSource.cell).Clear
                                                       ) :> ICell
                let format (o : WeakEventSource) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_WeakEventSource.source + ".Clear") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _WeakEventSource.cell
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
    [<ExcelFunction(Name="_WeakEventSource_Raise", Description="Create a WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_Raise
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeakEventSource",Description = "WeakEventSource")>] 
         weakeventsource : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeakEventSource = Helper.toModelReference<WeakEventSource> weakeventsource "WeakEventSource"  
                let builder (current : ICell) = ((WeakEventSourceModel.Cast _WeakEventSource.cell).Raise
                                                       ) :> ICell
                let format (o : WeakEventSource) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_WeakEventSource.source + ".Raise") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _WeakEventSource.cell
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
    [<ExcelFunction(Name="_WeakEventSource_Subscribe", Description="Create a WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_Subscribe
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeakEventSource",Description = "WeakEventSource")>] 
         weakeventsource : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeakEventSource = Helper.toModelReference<WeakEventSource> weakeventsource "WeakEventSource"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((WeakEventSourceModel.Cast _WeakEventSource.cell).Subscribe
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : WeakEventSource) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_WeakEventSource.source + ".Subscribe") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeakEventSource.cell
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
    [<ExcelFunction(Name="_WeakEventSource_Unsubscribe", Description="Create a WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_Unsubscribe
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeakEventSource",Description = "WeakEventSource")>] 
         weakeventsource : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeakEventSource = Helper.toModelReference<WeakEventSource> weakeventsource "WeakEventSource"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((WeakEventSourceModel.Cast _WeakEventSource.cell).Unsubscribe
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : WeakEventSource) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_WeakEventSource.source + ".Unsubscribe") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeakEventSource.cell
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
    [<ExcelFunction(Name="_WeakEventSource", Description="Create a WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.WeakEventSource ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<WeakEventSource>) l

                let source () = Helper.sourceFold "Fun.WeakEventSource" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<WeakEventSource> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_WeakEventSource_Range", Description="Create a range of WeakEventSource",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let WeakEventSource_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<WeakEventSource> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<WeakEventSource> (c)) :> ICell
                let format (i : Cephei.Cell.List<WeakEventSource>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<WeakEventSource>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
