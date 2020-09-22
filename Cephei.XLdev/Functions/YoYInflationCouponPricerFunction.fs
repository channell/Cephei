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
  this pricer can already do swaplets but to get volatility-dependent coupons you need the descendents.
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCouponPricer_capletPrice", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".CapletPrice") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_capletRate", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".CapletRate") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_capletVolatility", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".CapletVolatility") 
                                               [| _YoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_floorletPrice", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".FloorletPrice") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_floorletRate", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".FloorletRate") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_initialize", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".Initialize") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_setCapletVolatility", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _capletVol = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".SetCapletVolatility") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
                                ;  _capletVol.cell
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
        InflationCouponPricer interface
    *)
    [<ExcelFunction(Name="_YoYInflationCouponPricer_swapletPrice", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".SwapletPrice") 
                                               [| _YoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_swapletRate", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".SwapletRate") 
                                               [| _YoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic (Fun.YoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCouponPricer>) l

                let source = Helper.sourceFold "Fun.YoYInflationCouponPricer" 
                                               [| _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _capletVol.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_registerWith", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".RegisterWith") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_unregisterWith", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".UnregisterWith") 
                                               [| _YoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_update", Description="Create a YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCouponPricer",Description = "Reference to YoYInflationCouponPricer")>] 
         yoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCouponPricer = Helper.toCell<YoYInflationCouponPricer> yoyinflationcouponpricer "YoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationCouponPricer.cell :?> YoYInflationCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : YoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCouponPricer.source + ".Update") 
                                               [| _YoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_YoYInflationCouponPricer_Range", Description="Create a range of YoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
