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
  Black-formula pricer for capped/floored Ibor coupons References for timing adjustments Black76             Hull, Options, Futures and other derivatives, 4th ed., page 550 BivariateLognormal  http://ssrn.com/abstract=2170721 The bivariate lognormal adjustment implementation is still considered experimental
  </summary> *)
[<AutoSerializable(true)>]
module BlackIborCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackIborCouponPricer", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="timingAdjustment",Description = "Reference to timingAdjustment")>] 
         timingAdjustment : obj)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _v = Helper.toHandle<Handle<OptionletVolatilityStructure>> v "v" 
                let _timingAdjustment = Helper.toCell<TimingAdjustment> timingAdjustment "timingAdjustment" true
                let _correlation = Helper.toHandle<Handle<Quote>> correlation "correlation" 
                let builder () = withMnemonic mnemonic (Fun.BlackIborCouponPricer 
                                                            _v.cell 
                                                            _timingAdjustment.cell 
                                                            _correlation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackIborCouponPricer>) l

                let source = Helper.sourceFold "Fun.BlackIborCouponPricer" 
                                               [| _v.source
                                               ;  _timingAdjustment.source
                                               ;  _correlation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _v.cell
                                ;  _timingAdjustment.cell
                                ;  _correlation.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletPrice") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "Reference to effectiveCap")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletRate") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_floorletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".FloorletPrice") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_floorletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "Reference to effectiveFloor")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".FloorletRate") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_initialize", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".Initialize") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_swapletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".SwapletPrice") 
                                               [| _BlackIborCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_swapletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".SwapletRate") 
                                               [| _BlackIborCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletVolatility", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<OptionletVolatilityStructure>>) l

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletVolatility") 
                                               [| _BlackIborCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_setCapletVolatility", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _v = Helper.toHandle<Handle<OptionletVolatilityStructure>> v "v" 
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).SetCapletVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".SetCapletVolatility") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_registerWith", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".RegisterWith") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_unregisterWith", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".UnregisterWith") 
                                               [| _BlackIborCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_update", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "Reference to BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer" true 
                let builder () = withMnemonic mnemonic ((_BlackIborCouponPricer.cell :?> BlackIborCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackIborCouponPricer.source + ".Update") 
                                               [| _BlackIborCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_Range", Description="Create a range of BlackIborCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackIborCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackIborCouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackIborCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackIborCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackIborCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
