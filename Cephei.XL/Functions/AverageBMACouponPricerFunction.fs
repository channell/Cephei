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
    [<ExcelFunction(Name="_AverageBMACouponPricer_capletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).CapletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".CapletPrice") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_capletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).CapletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".CapletRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_floorletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).FloorletPrice
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".FloorletPrice") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_floorletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="d",Description = "double")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _d = Helper.toCell<double> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).FloorletRate
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".FloorletRate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_initialize", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_swapletPrice", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_swapletRate", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_registerWith", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_unregisterWith", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_update", Description="Create a AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACouponPricer",Description = "AverageBMACouponPricer")>] 
         averagebmacouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACouponPricer = Helper.toCell<AverageBMACouponPricer> averagebmacouponpricer "AverageBMACouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((AverageBMACouponPricerModel.Cast _AverageBMACouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : AverageBMACouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AverageBMACouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AverageBMACouponPricer.cell
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
    [<ExcelFunction(Name="_AverageBMACouponPricer_Range", Description="Create a range of AverageBMACouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AverageBMACouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AverageBMACouponPricer> (c)) :> ICell
                let format (i : Generic.List<ICell<AverageBMACouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AverageBMACouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
