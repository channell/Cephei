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
  Claim on a notional
  </summary> *)
[<AutoSerializable(true)>]
module FaceValueClaimFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FaceValueClaim_amount", Description="Create a FaceValueClaim",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FaceValueClaim_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueClaim",Description = "Reference to FaceValueClaim")>] 
         facevalueclaim : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="notional",Description = "Reference to notional")>] 
         notional : obj)
        ([<ExcelArgument(Name="recoveryRate",Description = "Reference to recoveryRate")>] 
         recoveryRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueClaim = Helper.toCell<FaceValueClaim> facevalueclaim "FaceValueClaim" true 
                let _d = Helper.toCell<Date> d "d" true
                let _notional = Helper.toCell<double> notional "notional" true
                let _recoveryRate = Helper.toCell<double> recoveryRate "recoveryRate" true
                let builder () = withMnemonic mnemonic ((_FaceValueClaim.cell :?> FaceValueClaimModel).Amount
                                                            _d.cell 
                                                            _notional.cell 
                                                            _recoveryRate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FaceValueClaim.source + ".Amount") 
                                               [| _FaceValueClaim.source
                                               ;  _d.source
                                               ;  _notional.source
                                               ;  _recoveryRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueClaim.cell
                                ;  _d.cell
                                ;  _notional.cell
                                ;  _recoveryRate.cell
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
    [<ExcelFunction(Name="_FaceValueClaim_registerWith", Description="Create a FaceValueClaim",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FaceValueClaim_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueClaim",Description = "Reference to FaceValueClaim")>] 
         facevalueclaim : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueClaim = Helper.toCell<FaceValueClaim> facevalueclaim "FaceValueClaim" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FaceValueClaim.cell :?> FaceValueClaimModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FaceValueClaim) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FaceValueClaim.source + ".RegisterWith") 
                                               [| _FaceValueClaim.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueClaim.cell
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
    [<ExcelFunction(Name="_FaceValueClaim_unregisterWith", Description="Create a FaceValueClaim",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FaceValueClaim_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueClaim",Description = "Reference to FaceValueClaim")>] 
         facevalueclaim : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueClaim = Helper.toCell<FaceValueClaim> facevalueclaim "FaceValueClaim" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FaceValueClaim.cell :?> FaceValueClaimModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FaceValueClaim) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FaceValueClaim.source + ".UnregisterWith") 
                                               [| _FaceValueClaim.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueClaim.cell
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
    [<ExcelFunction(Name="_FaceValueClaim_update", Description="Create a FaceValueClaim",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FaceValueClaim_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FaceValueClaim",Description = "Reference to FaceValueClaim")>] 
         facevalueclaim : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FaceValueClaim = Helper.toCell<FaceValueClaim> facevalueclaim "FaceValueClaim" true 
                let builder () = withMnemonic mnemonic ((_FaceValueClaim.cell :?> FaceValueClaimModel).Update
                                                       ) :> ICell
                let format (o : FaceValueClaim) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FaceValueClaim.source + ".Update") 
                                               [| _FaceValueClaim.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FaceValueClaim.cell
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
    [<ExcelFunction(Name="_FaceValueClaim_Range", Description="Create a range of FaceValueClaim",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FaceValueClaim_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FaceValueClaim")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FaceValueClaim> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FaceValueClaim>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FaceValueClaim>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FaceValueClaim>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
