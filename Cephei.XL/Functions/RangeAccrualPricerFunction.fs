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
module RangeAccrualPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualPricer_capletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".CapletPrice") 
                                               [| _RangeAccrualPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_capletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".CapletRate") 
                                               [| _RangeAccrualPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_floorletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".FloorletPrice") 
                                               [| _RangeAccrualPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_floorletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".FloorletRate") 
                                               [| _RangeAccrualPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_initialize", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".Initialize") 
                                               [| _RangeAccrualPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_RangeAccrualPricer_swapletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".SwapletPrice") 
                                               [| _RangeAccrualPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_swapletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".SwapletRate") 
                                               [| _RangeAccrualPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_registerWith", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".RegisterWith") 
                                               [| _RangeAccrualPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_unregisterWith", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".UnregisterWith") 
                                               [| _RangeAccrualPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_update", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "Reference to RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualPricer.cell :?> RangeAccrualPricerModel).Update
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualPricer.source + ".Update") 
                                               [| _RangeAccrualPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_Range", Description="Create a range of RangeAccrualPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RangeAccrualPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RangeAccrualPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RangeAccrualPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RangeAccrualPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RangeAccrualPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
