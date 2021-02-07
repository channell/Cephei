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
module ProportionalNotionalRiskFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ProportionalNotionalRisk", Description="Create a ProportionalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProportionalNotionalRisk_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentOffset",Description = "EventPaymentOffset")>] 
         paymentOffset : obj)
        ([<ExcelArgument(Name="attachement",Description = "double")>] 
         attachement : obj)
        ([<ExcelArgument(Name="exhaustion",Description = "double")>] 
         exhaustion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentOffset = Helper.toCell<EventPaymentOffset> paymentOffset "paymentOffset" 
                let _attachement = Helper.toCell<double> attachement "attachement" 
                let _exhaustion = Helper.toCell<double> exhaustion "exhaustion" 
                let builder (current : ICell) = (Fun.ProportionalNotionalRisk 
                                                            _paymentOffset.cell 
                                                            _attachement.cell 
                                                            _exhaustion.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ProportionalNotionalRisk>) l

                let source () = Helper.sourceFold "Fun.ProportionalNotionalRisk" 
                                               [| _paymentOffset.source
                                               ;  _attachement.source
                                               ;  _exhaustion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentOffset.cell
                                ;  _attachement.cell
                                ;  _exhaustion.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProportionalNotionalRisk> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ProportionalNotionalRisk_updatePath", Description="Create a ProportionalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProportionalNotionalRisk_updatePath
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProportionalNotionalRisk",Description = "ProportionalNotionalRisk")>] 
         proportionalnotionalrisk : obj)
        ([<ExcelArgument(Name="events",Description = "Date,double range")>] 
         events : obj)
        ([<ExcelArgument(Name="path",Description = "NotionalPath")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProportionalNotionalRisk = Helper.toCell<ProportionalNotionalRisk> proportionalnotionalrisk "ProportionalNotionalRisk"  
                let _events = Helper.toCell<Generic.List<Generic.KeyValuePair<Date,double>>> events "events" 
                let _path = Helper.toCell<NotionalPath> path "path" 
                let builder (current : ICell) = ((ProportionalNotionalRiskModel.Cast _ProportionalNotionalRisk.cell).UpdatePath
                                                            _events.cell 
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : ProportionalNotionalRisk) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ProportionalNotionalRisk.source + ".UpdatePath") 

                                               [| _events.source
                                               ;  _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProportionalNotionalRisk.cell
                                ;  _events.cell
                                ;  _path.cell
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
    [<ExcelFunction(Name="_ProportionalNotionalRisk_Range", Description="Create a range of ProportionalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProportionalNotionalRisk_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ProportionalNotionalRisk> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ProportionalNotionalRisk> (c)) :> ICell
                let format (i : Cephei.Cell.List<ProportionalNotionalRisk>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ProportionalNotionalRisk>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
