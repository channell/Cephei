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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_capletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).CapletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".CapletPrice") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_capletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).CapletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".CapletRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_floorletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).FloorletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".FloorletPrice") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_floorletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).FloorletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".FloorletRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_initialize", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_swapletPrice", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_swapletRate", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_registerWith", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_unregisterWith", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_update", Description="Create a OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCouponPricer",Description = "OvernightIndexedCouponPricer")>] 
         overnightindexedcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCouponPricer = Helper.toCell<OvernightIndexedCouponPricer> overnightindexedcouponpricer "OvernightIndexedCouponPricer"  
                let builder (current : ICell) = ((OvernightIndexedCouponPricerModel.Cast _OvernightIndexedCouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : OvernightIndexedCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndexedCouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCouponPricer.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCouponPricer_Range", Description="Create a range of OvernightIndexedCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndexedCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<OvernightIndexedCouponPricer> (c)) :> ICell
                let format (i : Cephei.Cell.List<OvernightIndexedCouponPricer>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<OvernightIndexedCouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
