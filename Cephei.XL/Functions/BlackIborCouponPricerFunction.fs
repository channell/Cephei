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
    [<ExcelFunction(Name="_BlackIborCouponPricer", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="v",Description = "OptionletVolatilityStructure")>] 
         v : obj)
        ([<ExcelArgument(Name="timingAdjustment",Description = "BlackIborCouponPricer.TimingAdjustment: Black76, BivariateLognormal or empty")>] 
         timingAdjustment : obj)
        ([<ExcelArgument(Name="correlation",Description = "Quote")>] 
         correlation : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _v = Helper.toDefaultHandle<OptionletVolatilityStructure> v "v" null
                let _timingAdjustment = Helper.toDefault<BlackIborCouponPricer.TimingAdjustment> timingAdjustment "timingAdjustment" BlackIborCouponPricer.TimingAdjustment.Black76
                let _correlation = Helper.toDefaultHandle<Quote> correlation "correlation" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackIborCouponPricer 
                                                            _v.cell 
                                                            _timingAdjustment.cell 
                                                            _correlation.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackIborCouponPricer>) l

                let source () = Helper.sourceFold "Fun.BlackIborCouponPricer" 
                                               [| _v.source
                                               ;  _timingAdjustment.source
                                               ;  _correlation.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _v.cell
                                ;  _timingAdjustment.cell
                                ;  _correlation.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackIborCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).CapletPrice
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletPrice") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveCap",Description = "double")>] 
         effectiveCap : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _effectiveCap = Helper.toCell<double> effectiveCap "effectiveCap" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).CapletRate
                                                            _effectiveCap.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletRate") 

                                               [| _effectiveCap.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_floorletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_floorletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).FloorletPrice
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".FloorletPrice") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_floorletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_floorletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="effectiveFloor",Description = "double")>] 
         effectiveFloor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _effectiveFloor = Helper.toCell<double> effectiveFloor "effectiveFloor" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).FloorletRate
                                                            _effectiveFloor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".FloorletRate") 

                                               [| _effectiveFloor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_initialize", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="coupon",Description = "FloatingRateCoupon")>] 
         coupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _coupon = Helper.toCell<FloatingRateCoupon> coupon "coupon" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).Initialize
                                                            _coupon.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".Initialize") 

                                               [| _coupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_swapletPrice", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_swapletPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).SwapletPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".SwapletPrice") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_swapletRate", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_swapletRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).SwapletRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".SwapletRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_capletVolatility", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_capletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).CapletVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<OptionletVolatilityStructure>>) l

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".CapletVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackIborCouponPricer> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackIborCouponPricer_setCapletVolatility", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_setCapletVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="v",Description = "OptionletVolatilityStructure")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _v = Helper.toDefaultHandle<OptionletVolatilityStructure> v "v" null
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).SetCapletVolatility
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".SetCapletVolatility") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_registerWith", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_unregisterWith", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_update", Description="Create a BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackIborCouponPricer",Description = "BlackIborCouponPricer")>] 
         blackiborcouponpricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackIborCouponPricer = Helper.toCell<BlackIborCouponPricer> blackiborcouponpricer "BlackIborCouponPricer"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackIborCouponPricerModel.Cast _BlackIborCouponPricer.cell).Update
                                                       ) :> ICell
                let format (o : BlackIborCouponPricer) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackIborCouponPricer.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackIborCouponPricer.cell
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
    [<ExcelFunction(Name="_BlackIborCouponPricer_Range", Description="Create a range of BlackIborCouponPricer",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackIborCouponPricer_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackIborCouponPricer> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackIborCouponPricer> (c)) :> ICell
                let format (i : Generic.List<ICell<BlackIborCouponPricer>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackIborCouponPricer>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
