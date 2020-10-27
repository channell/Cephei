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
===========================================================================// AnalyticHaganPricer                           // ===========================================================================
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticHaganPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swaptionVol",Description = "SwaptionVolatilityStructure")>] 
         swaptionVol : obj)
        ([<ExcelArgument(Name="modelOfYieldCurve",Description = "GFunctionFactory.YieldCurveModel: Standard, ExactYield, ParallelShifts, NonParallelShifts")>] 
         modelOfYieldCurve : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swaptionVol = Helper.toHandle<SwaptionVolatilityStructure> swaptionVol "swaptionVol" 
                let _modelOfYieldCurve = Helper.toCell<GFunctionFactory.YieldCurveModel> modelOfYieldCurve "modelOfYieldCurve" 
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticHaganPricer 
                                                            _swaptionVol.cell 
                                                            _modelOfYieldCurve.cell 
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHaganPricer>) l

                let source () = Helper.sourceFold "Fun.AnalyticHaganPricer" 
                                               [| _swaptionVol.source
                                               ;  _modelOfYieldCurve.source
                                               ;  _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swaptionVol.cell
                                ;  _modelOfYieldCurve.cell
                                ;  _meanReversion.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticHaganPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Hagan 3.4c
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer_swapletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_capletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_capletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_floorletPrice", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_floorletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_initialize", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_meanReversion", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_meanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).MeanReversion
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".MeanReversion") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_setMeanReversion", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_setMeanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).SetMeanReversion
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".SetMeanReversion") 

                                               [| _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _meanReversion.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_swapletRate", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_setSwaptionVolatility", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_setSwaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="v",Description = "SwaptionVolatilityStructure")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _v = Helper.toHandle<SwaptionVolatilityStructure> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).SetSwaptionVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".SetSwaptionVolatility") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_swaptionVolatility", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_swaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).SwaptionVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".SwaptionVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticHaganPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticHaganPricer_registerWith", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_unregisterWith", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_update", Description="Create a AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHaganPricer",Description = "AnalyticHaganPricer")>] 
         analytichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHaganPricer = Helper.toCell<AnalyticHaganPricer> analytichaganpricer "AnalyticHaganPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticHaganPricerModel.Cast _AnalyticHaganPricer.cell).Update
                                                       ) :> ICell
                let format (o : AnalyticHaganPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticHaganPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticHaganPricer.cell
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
    [<ExcelFunction(Name="_AnalyticHaganPricer_Range", Description="Create a range of AnalyticHaganPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticHaganPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticHaganPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticHaganPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticHaganPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AnalyticHaganPricer>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
