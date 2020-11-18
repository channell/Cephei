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
  Prices a cms coupon using a linear terminal swap rate model The slope parameter is linked to a gaussian short rate model. Reference: Andersen, Piterbarg, Interest Rate Modeling, 16.3.2  The cut off point for integration can be set - by explicitly specifying the lower and upper bound - by defining the lower and upper bound to be the strike where a vanilla swaption has 1% or less vega of the atm swaption - by defining the lower and upper bound to be the strike where undeflated ( ) payer resp. receiver prices are below a given threshold - by specificying a number of standard deviations to cover using a Black Scholes process with an atm volatility as a benchmark In every case the lower and upper bound are applied though. In case the smile section is shifted lognormal, the specified lower and upper bound are applied to strike + shift so that e.g. a zero lower bound always refers to the lower bound of the rates in the shifted lognormal model. Note that for normal volatility input the lower rate bound should probably be adjusted to an appropriate negative value, there is no automatic adjustment in this case.
  </summary> *)
[<AutoSerializable(true)>]
module LinearTsrPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LinearTsrPricer_capletPrice", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_capletRate", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_floorletPrice", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_floorletRate", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_initialize", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swaptionVol",Description = "SwaptionVolatilityStructure")>] 
         swaptionVol : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        ([<ExcelArgument(Name="couponDiscountCurve",Description = "YieldTermStructure")>] 
         couponDiscountCurve : obj)
        ([<ExcelArgument(Name="settings",Description = "LinearTsrPricer.Settings or empty")>] 
         settings : obj)
        ([<ExcelArgument(Name="integrator",Description = "Integrator or empty")>] 
         integrator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swaptionVol = Helper.toHandle<SwaptionVolatilityStructure> swaptionVol "swaptionVol" 
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let _couponDiscountCurve = Helper.toHandle<YieldTermStructure> couponDiscountCurve "couponDiscountCurve" 
                let _settings = Helper.toDefault<LinearTsrPricer.Settings> settings "settings" null
                let _integrator = Helper.toDefault<Integrator> integrator "integrator" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LinearTsrPricer 
                                                            _swaptionVol.cell 
                                                            _meanReversion.cell 
                                                            _couponDiscountCurve.cell 
                                                            _settings.cell 
                                                            _integrator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LinearTsrPricer>) l

                let source () = Helper.sourceFold "Fun.LinearTsrPricer" 
                                               [| _swaptionVol.source
                                               ;  _meanReversion.source
                                               ;  _couponDiscountCurve.source
                                               ;  _settings.source
                                               ;  _integrator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swaptionVol.cell
                                ;  _meanReversion.cell
                                ;  _couponDiscountCurve.cell
                                ;  _settings.cell
                                ;  _integrator.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearTsrPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LinearTsrPricer_meanReversion", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_meanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).MeanReversion
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".MeanReversion") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_setMeanReversion", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_setMeanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Quote")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _meanReversion = Helper.toHandle<Quote> meanReversion "meanReversion" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).SetMeanReversion
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".SetMeanReversion") 

                                               [| _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_swapletPrice", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_swapletRate", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_setSwaptionVolatility", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_setSwaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="v",Description = "SwaptionVolatilityStructure")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _v = Helper.toHandle<SwaptionVolatilityStructure> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).SetSwaptionVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".SetSwaptionVolatility") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_swaptionVolatility", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_swaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).SwaptionVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".SwaptionVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearTsrPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LinearTsrPricer_registerWith", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_unregisterWith", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_update", Description="Create a LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearTsrPricer",Description = "LinearTsrPricer")>] 
         lineartsrpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearTsrPricer = Helper.toCell<LinearTsrPricer> lineartsrpricer "LinearTsrPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearTsrPricerModel.Cast _LinearTsrPricer.cell).Update
                                                       ) :> ICell
                let format (o : LinearTsrPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LinearTsrPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearTsrPricer.cell
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
    [<ExcelFunction(Name="_LinearTsrPricer_Range", Description="Create a range of LinearTsrPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearTsrPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LinearTsrPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<LinearTsrPricer> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<LinearTsrPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LinearTsrPricer>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
