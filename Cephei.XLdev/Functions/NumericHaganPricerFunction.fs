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
===========================================================================// NumericHaganPricer                    // ===========================================================================//   Prices a cms coupon via static replication as in Hagan's "Conundrums..." article via numerical integration based on prices of vanilla swaptions
  </summary> *)
[<AutoSerializable(true)>]
module NumericHaganPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NumericHaganPricer_integrate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_integrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="integrand",Description = "Reference to integrand")>] 
         integrand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _a = Helper.toCell<double> a "a" true
                let _b = Helper.toCell<double> b "b" true
                let _integrand = Helper.toCell<ConundrumIntegrand.ConundrumIntegrand> integrand "integrand" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).Integrate
                                                            _a.cell 
                                                            _b.cell 
                                                            _integrand.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".Integrate") 
                                               [| _NumericHaganPricer.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _integrand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _integrand.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="swaptionVol",Description = "Reference to swaptionVol")>] 
         swaptionVol : obj)
        ([<ExcelArgument(Name="modelOfYieldCurve",Description = "Reference to modelOfYieldCurve")>] 
         modelOfYieldCurve : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Reference to meanReversion")>] 
         meanReversion : obj)
        ([<ExcelArgument(Name="lowerLimit",Description = "Reference to lowerLimit")>] 
         lowerLimit : obj)
        ([<ExcelArgument(Name="upperLimit",Description = "Reference to upperLimit")>] 
         upperLimit : obj)
        ([<ExcelArgument(Name="precision",Description = "Reference to precision")>] 
         precision : obj)
        ([<ExcelArgument(Name="hardUpperLimit",Description = "Reference to hardUpperLimit")>] 
         hardUpperLimit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _swaptionVol = Helper.toHandle<Handle<SwaptionVolatilityStructure>> swaptionVol "swaptionVol" 
                let _modelOfYieldCurve = Helper.toCell<GFunctionFactory.YieldCurveModel> modelOfYieldCurve "modelOfYieldCurve" true
                let _meanReversion = Helper.toHandle<Handle<Quote>> meanReversion "meanReversion" 
                let _lowerLimit = Helper.toCell<double> lowerLimit "lowerLimit" true
                let _upperLimit = Helper.toCell<double> upperLimit "upperLimit" true
                let _precision = Helper.toCell<double> precision "precision" true
                let _hardUpperLimit = Helper.toCell<double> hardUpperLimit "hardUpperLimit" true
                let builder () = withMnemonic mnemonic (Fun.NumericHaganPricer 
                                                            _swaptionVol.cell 
                                                            _modelOfYieldCurve.cell 
                                                            _meanReversion.cell 
                                                            _lowerLimit.cell 
                                                            _upperLimit.cell 
                                                            _precision.cell 
                                                            _hardUpperLimit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NumericHaganPricer>) l

                let source = Helper.sourceFold "Fun.NumericHaganPricer" 
                                               [| _swaptionVol.source
                                               ;  _modelOfYieldCurve.source
                                               ;  _meanReversion.source
                                               ;  _lowerLimit.source
                                               ;  _upperLimit.source
                                               ;  _precision.source
                                               ;  _hardUpperLimit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _swaptionVol.cell
                                ;  _modelOfYieldCurve.cell
                                ;  _meanReversion.cell
                                ;  _lowerLimit.cell
                                ;  _upperLimit.cell
                                ;  _precision.cell
                                ;  _hardUpperLimit.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_refineIntegration", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_refineIntegration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="integralValue",Description = "Reference to integralValue")>] 
         integralValue : obj)
        ([<ExcelArgument(Name="integrand",Description = "Reference to integrand")>] 
         integrand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _integralValue = Helper.toCell<double> integralValue "integralValue" true
                let _integrand = Helper.toCell<ConundrumIntegrand.ConundrumIntegrand> integrand "integrand" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).RefineIntegration
                                                            _integralValue.cell 
                                                            _integrand.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".RefineIntegration") 
                                               [| _NumericHaganPricer.source
                                               ;  _integralValue.source
                                               ;  _integrand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _integralValue.cell
                                ;  _integrand.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_resetUpperLimit", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_resetUpperLimit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="stdDeviationsForUpperLimit",Description = "Reference to stdDeviationsForUpperLimit")>] 
         stdDeviationsForUpperLimit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _stdDeviationsForUpperLimit = Helper.toCell<double> stdDeviationsForUpperLimit "stdDeviationsForUpperLimit" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).ResetUpperLimit
                                                            _stdDeviationsForUpperLimit.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".ResetUpperLimit") 
                                               [| _NumericHaganPricer.source
                                               ;  _stdDeviationsForUpperLimit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _stdDeviationsForUpperLimit.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_stdDeviations", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_stdDeviations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).StdDeviations
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".StdDeviations") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swapletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".SwapletPrice") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_upperLimit", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_upperLimit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).UpperLimit
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".UpperLimit") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_capletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".CapletPrice") 
                                               [| _NumericHaganPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_capletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".CapletRate") 
                                               [| _NumericHaganPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_floorletPrice", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".FloorletPrice") 
                                               [| _NumericHaganPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_floorletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".FloorletRate") 
                                               [| _NumericHaganPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_initialize", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".Initialize") 
                                               [| _NumericHaganPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_meanReversion", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_meanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).MeanReversion
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".MeanReversion") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_setMeanReversion", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_setMeanReversion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="meanReversion",Description = "Reference to meanReversion")>] 
         meanReversion : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _meanReversion = Helper.toHandle<Handle<Quote>> meanReversion "meanReversion" 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).SetMeanReversion
                                                            _meanReversion.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".SetMeanReversion") 
                                               [| _NumericHaganPricer.source
                                               ;  _meanReversion.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _meanReversion.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swapletRate", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".SwapletRate") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_setSwaptionVolatility", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_setSwaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _v = Helper.toHandle<Handle<SwaptionVolatilityStructure>> v "v" 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).SetSwaptionVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".SetSwaptionVolatility") 
                                               [| _NumericHaganPricer.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_swaptionVolatility", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_swaptionVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).SwaptionVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".SwaptionVolatility") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_registerWith", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".RegisterWith") 
                                               [| _NumericHaganPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_unregisterWith", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".UnregisterWith") 
                                               [| _NumericHaganPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_update", Description="Create a NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NumericHaganPricer",Description = "Reference to NumericHaganPricer")>] 
         numerichaganpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NumericHaganPricer = Helper.toCell<NumericHaganPricer> numerichaganpricer "NumericHaganPricer" true 
                let builder () = withMnemonic mnemonic ((_NumericHaganPricer.cell :?> NumericHaganPricerModel).Update
                                                       ) :> ICell
                let format (o : NumericHaganPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NumericHaganPricer.source + ".Update") 
                                               [| _NumericHaganPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NumericHaganPricer.cell
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
    [<ExcelFunction(Name="_NumericHaganPricer_Range", Description="Create a range of NumericHaganPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NumericHaganPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NumericHaganPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NumericHaganPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NumericHaganPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NumericHaganPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NumericHaganPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
