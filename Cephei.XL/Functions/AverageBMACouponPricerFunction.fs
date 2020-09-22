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

  </summary> *)
[<AutoSerializable(true)>]
module AverageBMACouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMACouponPricer_capletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).CapletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".CapletPrice") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_capletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).CapletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".CapletRate") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_floorletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).FloorletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".FloorletPrice") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_floorletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _d = Helper.toCell<double> d "d" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).FloorletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".FloorletRate") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_initialize", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".Initialize") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_swapletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".SwapletPrice") 
                                               [| _AverageBMACouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_swapletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".SwapletRate") 
                                               [| _AverageBMACouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_registerWith", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".RegisterWith") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_unregisterWith", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".UnregisterWith") 
                                               [| _AverageBMACouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_update", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "Reference to AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer" true 
                let builder () = withMnemonic mnemonic ((_AverageBMACouponPricer.cell :?> AverageBMACouponPricerModel).Update
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACouponPricer.source + ".Update") 
                                               [| _AverageBMACouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_Range", Description="Create a range of AverageBMACouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AverageBMACouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AverageBMACouponPricer> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AverageBMACouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AverageBMACouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AverageBMACouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
