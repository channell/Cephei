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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackYoYInflationCouponPricer 
                                                            _capletVol.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackYoYInflationCouponPricer>) l

                let source () = Helper.sourceFold "Fun.BlackYoYInflationCouponPricer" 
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_capletVolatility", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".CapletVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_floorletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_floorletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_initialize", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "InflationCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _coupon = Helper.toCell<InflationCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_setCapletVolatility", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="capletVol",Description = "YoYOptionletVolatilitySurface")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _capletVol = Helper.toHandle<YoYOptionletVolatilitySurface> capletVol "capletVol" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).SetCapletVolatility
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SetCapletVolatility") 

                                               [| _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_swapletPrice", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_swapletRate", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_registerWith", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_unregisterWith", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_update", Description="Create a BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackYoYInflationCouponPricer",Description = "BlackYoYInflationCouponPricer")>] 
         blackyoyinflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackYoYInflationCouponPricer = Helper.toCell<BlackYoYInflationCouponPricer> blackyoyinflationcouponpricer "BlackYoYInflationCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackYoYInflationCouponPricerModel.Cast _BlackYoYInflationCouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : BlackYoYInflationCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackYoYInflationCouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackYoYInflationCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackYoYInflationCouponPricer_Range", Description="Create a range of BlackYoYInflationCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackYoYInflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackYoYInflationCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackYoYInflationCouponPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<BlackYoYInflationCouponPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackYoYInflationCouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
