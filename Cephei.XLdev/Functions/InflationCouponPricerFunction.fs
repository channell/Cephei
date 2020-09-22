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
  The main reason we can't use FloatingRateCouponPricer as the base is that it takes a FloatingRateCoupon which takes an InterestRateIndex and we need an inflation index (these are lagged).  The basic inflation-specific thing that the pricer has to do is deal with different lags in the index and the option e.g. the option could look 3 months back and the index 2.  We add the requirement that pricers do inverseCap/Floor-lets. These are cap/floor-lets as usually defined, i.e. pay out if underlying is above/below a strike.  The non-inverse (usual) versions are from a coupon point of view (a capped coupon has a maximum at the strike).  We add the inverse prices so that conventional caps can be priced simply.
  </summary> *)
[<AutoSerializable(true)>]
module InflationCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InflationCouponPricer_capletPrice", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".CapletPrice") 
                                               [| _InflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_capletRate", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".CapletRate") 
                                               [| _InflationCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_floorletPrice", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".FloorletPrice") 
                                               [| _InflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_floorletRate", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".FloorletRate") 
                                               [| _InflationCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_initialize", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _i = Helper.toCell<InflationCoupon> i "i" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).Initialize
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : InflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".Initialize") 
                                               [| _InflationCouponPricer.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_registerWith", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".RegisterWith") 
                                               [| _InflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
        Interface
    *)
    [<ExcelFunction(Name="_InflationCouponPricer_swapletPrice", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".SwapletPrice") 
                                               [| _InflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_swapletRate", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".SwapletRate") 
                                               [| _InflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_unregisterWith", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".UnregisterWith") 
                                               [| _InflationCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_update", Description="Create a InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCouponPricer",Description = "Reference to InflationCouponPricer")>] 
         inflationcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCouponPricer = Helper.toCell<InflationCouponPricer> inflationcouponpricer "InflationCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_InflationCouponPricer.cell :?> InflationCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : InflationCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCouponPricer.source + ".Update") 
                                               [| _InflationCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCouponPricer.cell
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
    [<ExcelFunction(Name="_InflationCouponPricer_Range", Description="Create a range of InflationCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InflationCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InflationCouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InflationCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InflationCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InflationCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
