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
  Black-formula pricer for capped/floored yoy inflation coupons
  </summary> *)
[<AutoSerializable(true)>]
module BlackYoYInflationCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic (Fun.BlackYoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackYoYInflationCouponPricer>) l

                let source = Helper.sourceFold "Fun.BlackYoYInflationCouponPricer" 
                                               [| _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _capletVol.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackYoYInflationCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletPrice") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletRate") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletVolatility", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletVolatility") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackYoYInflationCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_floorletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".FloorletPrice") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_floorletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".FloorletRate") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_initialize", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".Initialize") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_setCapletVolatility", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SetCapletVolatility") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_swapletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SwapletPrice") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_swapletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SwapletRate") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_registerWith", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".RegisterWith") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_unregisterWith", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".UnregisterWith") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_update", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "Reference to BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder () = withMnemonic mnemonic ((_BlackYoYInflationCouponPricer.cell :?> BlackYoYInflationCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".Update") 
                                               [| _BlackYoYInflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_Range", Description="Create a range of BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackYoYInflationCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackYoYInflationCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackYoYInflationCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackYoYInflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackYoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
