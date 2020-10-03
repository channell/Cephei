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
    [<ExcelFunction(Name="_simple_event_date", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "Reference to simple_event")>] 
         simple_event : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let builder () = withMnemonic mnemonic ((simple_eventModel.Cast _simple_event.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_simple_event.source + ".Date") 
                                               [| _simple_event.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic (Fun.simple_event 
                                                            _date.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<simple_event>) l

                let source = Helper.sourceFold "Fun.simple_event" 
                                               [| _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _date.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_simple_event_accept", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "Reference to simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((simple_eventModel.Cast _simple_event.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_simple_event.source + ".Accept") 
                                               [| _simple_event.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
                                ;  _v.cell
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
        ! If includeRefDate is true, then an event has not occurred if its date is the same as the refDate, i.e. this method returns false if the event date is the same as the refDate.
    *)
    [<ExcelFunction(Name="_simple_event_hasOccurred", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "Reference to simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _d = Helper.toCell<Date> d "d" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((simple_eventModel.Cast _simple_event.cell).HasOccurred
                                                            _d.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_simple_event.source + ".HasOccurred") 
                                               [| _simple_event.source
                                               ;  _d.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
                                ;  _d.cell
                                ;  _includeRefDate.cell
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
    [<ExcelFunction(Name="_simple_event_registerWith", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "Reference to simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((simple_eventModel.Cast _simple_event.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_simple_event.source + ".RegisterWith") 
                                               [| _simple_event.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event_unregisterWith", Description="Create a simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="simple_event",Description = "Reference to simple_event")>] 
         simple_event : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _simple_event = Helper.toCell<simple_event> simple_event "simple_event"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((simple_eventModel.Cast _simple_event.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : simple_event) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_simple_event.source + ".UnregisterWith") 
                                               [| _simple_event.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _simple_event.cell
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
    [<ExcelFunction(Name="_simple_event_Range", Description="Create a range of simple_event",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let simple_event_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the simple_event")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<simple_event> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<simple_event>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<simple_event>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<simple_event>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
