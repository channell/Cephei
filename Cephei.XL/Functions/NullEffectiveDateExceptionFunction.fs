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
(*!! ignored
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module NullEffectiveDateExceptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NullEffectiveDateException", Description="Create a NullEffectiveDateException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NullEffectiveDateException_create
        ([<ExcelArgument(Name="Mnemonic",Description = "NullEffectiveDateException")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "string")>] 
         message : obj)
        ([<ExcelArgument(Name="inner",Description = "Exception")>] 
         inner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" 
                let _inner = Helper.toCell<Exception> inner "inner" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NullEffectiveDateException 
                                                            _message.cell 
                                                            _inner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NullEffectiveDateException>) l

                let source () = Helper.sourceFold "Fun.NullEffectiveDateException" 
                                               [| _message.source
                                               ;  _inner.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
                                ;  _inner.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NullEffectiveDateException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NullEffectiveDateException1", Description="Create a NullEffectiveDateException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NullEffectiveDateException_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "NullEffectiveDateException")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "string")>] 
         message : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.NullEffectiveDateException1 
                                                            _message.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NullEffectiveDateException>) l

                let source () = Helper.sourceFold "Fun.NullEffectiveDateException1" 
                                               [| _message.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NullEffectiveDateException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NullEffectiveDateException", Description="Create a NullEffectiveDateException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NullEffectiveDateException_create
        ([<ExcelArgument(Name="Mnemonic",Description = "NullEffectiveDateException")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.NullEffectiveDateException ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NullEffectiveDateException>) l

                let source () = Helper.sourceFold "Fun.NullEffectiveDateException" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NullEffectiveDateException> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NullEffectiveDateException_Range", Description="Create a range of NullEffectiveDateException",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NullEffectiveDateException_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NullEffectiveDateException> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NullEffectiveDateException>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NullEffectiveDateException>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NullEffectiveDateException>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
