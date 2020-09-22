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
(*!! ignored for excel interface
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module NotTradableExceptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NotTradableException", Description="Create a NotTradableException",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotTradableException_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "Reference to message")>] 
         message : obj)
        ([<ExcelArgument(Name="inner",Description = "Reference to inner")>] 
         inner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" true
                let _inner = Helper.toCell<Exception> inner "inner" true
                let builder () = withMnemonic mnemonic (Fun.NotTradableException 
                                                            _message.cell 
                                                            _inner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NotTradableException>) l

                let source = Helper.sourceFold "Fun.NotTradableException" 
                                               [| _message.source
                                               ;  _inner.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
                                ;  _inner.cell
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
    [<ExcelFunction(Name="_NotTradableException1", Description="Create a NotTradableException",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotTradableException_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="message",Description = "Reference to message")>] 
         message : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _message = Helper.toCell<string> message "message" true
                let builder () = withMnemonic mnemonic (Fun.NotTradableException1 
                                                            _message.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NotTradableException>) l

                let source = Helper.sourceFold "Fun.NotTradableException1" 
                                               [| _message.source
                                               |]
                let hash = Helper.hashFold 
                                [| _message.cell
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
    [<ExcelFunction(Name="_NotTradableException2", Description="Create a NotTradableException",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotTradableException_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NotTradableException2 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NotTradableException>) l

                let source = Helper.sourceFold "Fun.NotTradableException2" 
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
    [<ExcelFunction(Name="_NotTradableException_Range", Description="Create a range of NotTradableException",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NotTradableException_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NotTradableException")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NotTradableException> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NotTradableException>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NotTradableException>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NotTradableException>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)