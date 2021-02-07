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
used to create an Event instance. to be replaced with specific events as soon as we find out which.
  </summary> *)
[<AutoSerializable(true)>]
module simple_eventFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_simple_event_date", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "simple_event")>] 
         simple_event : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let builder (current : ICell) = ((simple_eventModel.Cast _simple_event.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_simple_event.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _date = Helper.toCell<Date> date "date" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.simple_event 
                                                            _date.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<simple_event>) l

                let source () = Helper.sourceFold "Fun.simple_event" 
                                               [| _date.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _date.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<simple_event> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_simple_event_accept", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((simple_eventModel.Cast _simple_event.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_simple_event.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
                                ;  _v.cell
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
        ! If includeRefDate is true, then an event has not occurred if its date is the same as the refDate, i.e. this method returns false if the event date is the same as the refDate.
    *)
    [<ExcelFunction(Name="_simple_event_hasOccurred", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _d = Helper.toCell<Date> d "d" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((simple_eventModel.Cast _simple_event.cell).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_simple_event.source + ".HasOccurred") 

                                               [| _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
                                ;  _d.cell
                                ;  _includeRefDate.cell
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
    [<ExcelFunction(Name="_simple_event_registerWith", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((simple_eventModel.Cast _simple_event.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_simple_event.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event_unregisterWith", Description="Create a simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((simple_eventModel.Cast _simple_event.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_simple_event.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event_Range", Description="Create a range of simple_event",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let simple_event_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<simple_event> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<simple_event> (c)) :> ICell
                let format (i : Cephei.Cell.List<simple_event>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<simple_event>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
