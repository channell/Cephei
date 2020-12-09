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
module EventSetFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EventSet", Description="Create a EventSet",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EventSet_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="events",Description = "Date,double range")>] 
         events : obj)
        ([<ExcelArgument(Name="eventsStart",Description = "Date")>] 
         eventsStart : obj)
        ([<ExcelArgument(Name="eventsEnd",Description = "Date")>] 
         eventsEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _events = Helper.toCell<Generic.List<Generic.KeyValuePair<Date,double>>> events "events" 
                let _eventsStart = Helper.toCell<Date> eventsStart "eventsStart" 
                let _eventsEnd = Helper.toCell<Date> eventsEnd "eventsEnd" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EventSet 
                                                            _events.cell 
                                                            _eventsStart.cell 
                                                            _eventsEnd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EventSet>) l

                let source () = Helper.sourceFold "Fun.EventSet" 
                                               [| _events.source
                                               ;  _eventsStart.source
                                               ;  _eventsEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _events.cell
                                ;  _eventsStart.cell
                                ;  _eventsEnd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EventSet> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EventSet_newSimulation", Description="Create a EventSet",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EventSet_newSimulation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EventSet",Description = "EventSet")>] 
         eventset : obj)
        ([<ExcelArgument(Name="start",Description = "Date")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EventSet = Helper.toCell<EventSet> eventset "EventSet"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder (current : ICell) = withMnemonic mnemonic ((EventSetModel.Cast _EventSet.cell).NewSimulation
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CatSimulation>) l

                let source () = Helper.sourceFold (_EventSet.source + ".NewSimulation") 

                                               [| _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EventSet.cell
                                ;  _start.cell
                                ;  _End.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EventSet> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_EventSet_Range", Description="Create a range of EventSet",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EventSet_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EventSet> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EventSet> (c)) :> ICell
                let format (i : Generic.List<ICell<EventSet>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EventSet>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
