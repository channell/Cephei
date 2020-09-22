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
  Bachelier-formula pricer for capped/floored yoy inflation coupons
  </summary> *)
[<AutoSerializable(true)>]
module BachelierYoYInflationCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic (Fun.BachelierYoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierYoYInflationCouponPricer>) l

                let source = Helper.sourceFold "Fun.BachelierYoYInflationCouponPricer" 
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletPrice") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletRate") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletVolatility", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletVolatility") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_floorletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".FloorletPrice") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_floorletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".FloorletRate") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_initialize", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".Initialize") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_setCapletVolatility", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _capletVol = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SetCapletVolatility") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_swapletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SwapletPrice") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_swapletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SwapletRate") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_registerWith", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".RegisterWith") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_unregisterWith", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".UnregisterWith") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_update", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "Reference to BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BachelierYoYInflationCouponPricer.cell :?> BachelierYoYInflationCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".Update") 
                                               [| _BachelierYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_Range", Description="Create a range of BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BachelierYoYInflationCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BachelierYoYInflationCouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BachelierYoYInflationCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BachelierYoYInflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BachelierYoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
