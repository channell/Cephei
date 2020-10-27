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
module RangeAccrualPricerFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualPricer_capletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_capletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_floorletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_floorletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_initialize", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_RangeAccrualPricer_swapletPrice", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_swapletRate", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_registerWith", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_unregisterWith", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_update", Description="Create a RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualPricer",Description = "RangeAccrualPricer")>] 
         rangeaccrualpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualPricer = Helper.toCell<RangeAccrualPricer> rangeaccrualpricer "RangeAccrualPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((RangeAccrualPricerModel.Cast _RangeAccrualPricer.cell).Update
                                                       ) :> ICell
                let format (o : RangeAccrualPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_RangeAccrualPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _RangeAccrualPricer.cell
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
    [<ExcelFunction(Name="_RangeAccrualPricer_Range", Description="Create a range of RangeAccrualPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let RangeAccrualPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RangeAccrualPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RangeAccrualPricer>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<RangeAccrualPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<RangeAccrualPricer>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
