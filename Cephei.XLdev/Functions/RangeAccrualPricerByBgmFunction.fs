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
module RangeAccrualPricerByBgmFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        ([<ExcelArgument(Name="smilesOnExpiry",Description = "Reference to smilesOnExpiry")>] 
         smilesOnExpiry : obj)
        ([<ExcelArgument(Name="smilesOnPayment",Description = "Reference to smilesOnPayment")>] 
         smilesOnPayment : obj)
        ([<ExcelArgument(Name="withSmile",Description = "Reference to withSmile")>] 
         withSmile : obj)
        ([<ExcelArgument(Name="byCallSpread",Description = "Reference to byCallSpread")>] 
         byCallSpread : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _correlation = Helper.toCell<double> correlation "correlation" true
                let _smilesOnExpiry = Helper.toCell<SmileSection> smilesOnExpiry "smilesOnExpiry" true
                let _smilesOnPayment = Helper.toCell<SmileSection> smilesOnPayment "smilesOnPayment" true
                let _withSmile = Helper.toCell<bool> withSmile "withSmile" true
                let _byCallSpread = Helper.toCell<bool> byCallSpread "byCallSpread" true
                let builder () = withMnemonic mnemonic (Fun.RangeAccrualPricerByBgm 
                                                            _correlation.cell 
                                                            _smilesOnExpiry.cell 
                                                            _smilesOnPayment.cell 
                                                            _withSmile.cell 
                                                            _byCallSpread.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualPricerByBgm>) l

                let source = Helper.sourceFold "Fun.RangeAccrualPricerByBgm" 
                                               [| _correlation.source
                                               ;  _smilesOnExpiry.source
                                               ;  _smilesOnPayment.source
                                               ;  _withSmile.source
                                               ;  _byCallSpread.source
                                               |]
                let hash = Helper.hashFold 
                                [| _correlation.cell
                                ;  _smilesOnExpiry.cell
                                ;  _smilesOnPayment.cell
                                ;  _withSmile.cell
                                ;  _byCallSpread.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_swapletPrice", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".SwapletPrice") 
                                               [| _RangeAccrualPricerByBgm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_capletPrice", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".CapletPrice") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_capletRate", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".CapletRate") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
                                ;  _effectiveCap.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_floorletPrice", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".FloorletPrice") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_floorletRate", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".FloorletRate") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
                                ;  _effectiveFloor.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_initialize", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricerByBgm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".Initialize") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
                                ;  _coupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_swapletRate", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".SwapletRate") 
                                               [| _RangeAccrualPricerByBgm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_registerWith", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricerByBgm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".RegisterWith") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_unregisterWith", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricerByBgm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".UnregisterWith") 
                                               [| _RangeAccrualPricerByBgm.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
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
        observer interface
    *)
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_update", Description="Create a RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricerByBgm",Description = "Reference to RangeAccrualPricerByBgm")>] 
         rangeaccrualpricerbybgm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricerByBgm = Helper.toCell<RangeAccrualPricerByBgm> rangeaccrualpricerbybgm "RangeAccrualPricerByBgm" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricerByBgm.cell :?> RangeAccrualPricerByBgmModel).Update
                                                       ) :> ICell
                let format (o : RangeAccrualPricerByBgm) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricerByBgm.source + ".Update") 
                                               [| _RangeAccrualPricerByBgm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricerByBgm.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricerByBgm_Range", Description="Create a range of RangeAccrualPricerByBgm",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricerByBgm_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RangeAccrualPricerByBgm")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RangeAccrualPricerByBgm> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RangeAccrualPricerByBgm>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RangeAccrualPricerByBgm>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RangeAccrualPricerByBgm>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
