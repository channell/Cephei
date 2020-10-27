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
module DigitalNotionalRiskFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DigitalNotionalRisk", Description="Create a DigitalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalNotionalRisk_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentOffset",Description = "EventPaymentOffset")>] 
         paymentOffset : obj)
        ([<ExcelArgument(Name="threshold",Description = "double")>] 
         threshold : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentOffset = Helper.toCell<EventPaymentOffset> paymentOffset "paymentOffset" 
                let _threshold = Helper.toCell<double> threshold "threshold" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DigitalNotionalRisk 
                                                            _paymentOffset.cell 
                                                            _threshold.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DigitalNotionalRisk>) l

                let source () = Helper.sourceFold "Fun.DigitalNotionalRisk" 
                                               [| _paymentOffset.source
                                               ;  _threshold.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentOffset.cell
                                ;  _threshold.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DigitalNotionalRisk> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DigitalNotionalRisk_updatePath", Description="Create a DigitalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalNotionalRisk_updatePath
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DigitalNotionalRisk",Description = "DigitalNotionalRisk")>] 
         digitalnotionalrisk : obj)
        ([<ExcelArgument(Name="events",Description = "Date,double range")>] 
         events : obj)
        ([<ExcelArgument(Name="path",Description = "NotionalPath")>] 
         path : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DigitalNotionalRisk = Helper.toCell<DigitalNotionalRisk> digitalnotionalrisk "DigitalNotionalRisk"  
                let _events = Helper.toCell<Generic.List<Generic.KeyValuePair<Date,double>>> events "events" 
                let _path = Helper.toCell<NotionalPath> path "path" 
                let builder (current : ICell) = withMnemonic mnemonic ((DigitalNotionalRiskModel.Cast _DigitalNotionalRisk.cell).UpdatePath
                                                            _events.cell 
                                                            _path.cell 
                                                       ) :> ICell
                let format (o : DigitalNotionalRisk) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DigitalNotionalRisk.source + ".UpdatePath") 

                                               [| _events.source
                                               ;  _path.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DigitalNotionalRisk.cell
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
    [<ExcelFunction(Name="_DigitalNotionalRisk_Range", Description="Create a range of DigitalNotionalRisk",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DigitalNotionalRisk_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DigitalNotionalRisk> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DigitalNotionalRisk>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DigitalNotionalRisk>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DigitalNotionalRisk>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
