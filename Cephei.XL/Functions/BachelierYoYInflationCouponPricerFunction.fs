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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="capletVol",Description = "YoYOptionletVolatilitySurface")>] 
         capletVol : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BachelierYoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BachelierYoYInflationCouponPricer>) l

                let source () = Helper.sourceFold "Fun.BachelierYoYInflationCouponPricer" 
                                               [| _capletVol.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _capletVol.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierYoYInflationCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _effectiveCap.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _effectiveCap.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_capletVolatility", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".CapletVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BachelierYoYInflationCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_floorletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _effectiveFloor.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_floorletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _effectiveFloor.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_initialize", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "InflationCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _coupon.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_setCapletVolatility", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "YoYOptionletVolatilitySurface")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SetCapletVolatility") 

                                               [| _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _capletVol.cell
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
    (*
        InflationCouponPricer interface
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_swapletPrice", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_swapletRate", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_registerWith", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _handler.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_unregisterWith", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
                                ;  _handler.cell
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
    (*
        observer interface
    *)
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_update", Description="Create a BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BachelierYoYInflationCouponPricer",Description = "BachelierYoYInflationCouponPricer")>] 
         bachelieryoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BachelierYoYInflationCouponPricer = Helper.toCell<BachelierYoYInflationCouponPricer> bachelieryoyinflationcouponpricer "BachelierYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BachelierYoYInflationCouponPricerModel.Cast _BachelierYoYInflationCouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : BachelierYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BachelierYoYInflationCouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BachelierYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BachelierYoYInflationCouponPricer_Range", Description="Create a range of BachelierYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BachelierYoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BachelierYoYInflationCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BachelierYoYInflationCouponPricer> (c)) :> ICell
                let format (i : Generic.List<ICell<BachelierYoYInflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BachelierYoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
