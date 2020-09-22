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
  Unit-Displaced-Black-formula pricer for capped/floored yoy inflation coupons
  </summary> *)
[<AutoSerializable(true)>]
module UnitDisplacedBlackYoYInflationCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic (Fun.UnitDisplacedBlackYoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UnitDisplacedBlackYoYInflationCouponPricer>) l

                let source = Helper.sourceFold "Fun.UnitDisplacedBlackYoYInflationCouponPricer" 
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_capletPrice", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".CapletPrice") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_capletRate", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".CapletRate") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_capletVolatility", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".CapletVolatility") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_floorletPrice", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".FloorletPrice") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_floorletRate", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".FloorletRate") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_initialize", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : UnitDisplacedBlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".Initialize") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_setCapletVolatility", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : UnitDisplacedBlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".SetCapletVolatility") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_swapletPrice", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".SwapletPrice") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_swapletRate", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".SwapletRate") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_registerWith", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UnitDisplacedBlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".RegisterWith") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_unregisterWith", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UnitDisplacedBlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".UnregisterWith") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_update", Description="Create a UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitDisplacedBlackYoYInflationCouponPricer",Description = "Reference to UnitDisplacedBlackYoYInflationCouponPricer")>] 
         unitdisplacedblackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitDisplacedBlackYoYInflationCouponPricer = Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> unitdisplacedblackyoyinflationcouponpricer "UnitDisplacedBlackYoYInflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_UnitDisplacedBlackYoYInflationCouponPricer.cell :?> UnitDisplacedBlackYoYInflationCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : UnitDisplacedBlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_UnitDisplacedBlackYoYInflationCouponPricer.source + ".Update") 
                                               [| _UnitDisplacedBlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitDisplacedBlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_UnitDisplacedBlackYoYInflationCouponPricer_Range", Description="Create a range of UnitDisplacedBlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let UnitDisplacedBlackYoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the UnitDisplacedBlackYoYInflationCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UnitDisplacedBlackYoYInflationCouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<UnitDisplacedBlackYoYInflationCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<UnitDisplacedBlackYoYInflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<UnitDisplacedBlackYoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
