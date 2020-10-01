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
module OvernightIndexedCouponPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_capletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).CapletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".CapletPrice") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_capletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).CapletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".CapletRate") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_floorletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).FloorletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".FloorletPrice") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_floorletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).FloorletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".FloorletRate") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_initialize", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "Reference to coupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".Initialize") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_swapletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".SwapletPrice") 
                                               [| _OvernightIndexedCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_swapletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".SwapletRate") 
                                               [| _OvernightIndexedCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_registerWith", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".RegisterWith") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_unregisterWith", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".UnregisterWith") 
                                               [| _OvernightIndexedCouponPricer.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_update", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "Reference to OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder () = withMnemonic mnemonic ((_OvernightIndexedCouponPricer.cell :?> OvernightIndexedCouponPricerModel).Update
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".Update") 
                                               [| _OvernightIndexedCouponPricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_Range", Description="Create a range of OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OvernightIndexedCouponPricer")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndexedCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightIndexedCouponPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightIndexedCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OvernightIndexedCouponPricer>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
