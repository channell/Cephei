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
module CappedFlooredCouponFunction =

    (*
        cap
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_cap", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Cap") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<FloatingRateCoupon> underlying "underlying" true
                let _cap = Helper.toNullable<Nullable<double>> cap "cap"
                let _floor = Helper.toNullable<Nullable<double>> floor "floor"
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCoupon 
                                                            _underlying.cell 
                                                            _cap.cell 
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredCoupon" 
                                               [| _underlying.source
                                               ;  _cap.source
                                               ;  _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlying.cell
                                ;  _cap.cell
                                ;  _floor.cell
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon1", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCoupon1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_convexityAdjustment", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".ConvexityAdjustment") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! effective cap of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_effectiveCap", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".EffectiveCap") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! effective floor of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_effectiveFloor", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".EffectiveFloor") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_factory", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "Reference to isInArrears")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _index = Helper.toCell<InterestRateIndex> index "index" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _cap = Helper.toNullable<Nullable<double>> cap "cap"
                let _floor = Helper.toNullable<Nullable<double>> floor "floor"
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Factory
                                                            _nominal.cell 
                                                            _paymentDate.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _cap.cell 
                                                            _floor.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Factory") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _nominal.source
                                               ;  _paymentDate.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _cap.source
                                               ;  _floor.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _dayCounter.source
                                               ;  _isInArrears.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _nominal.cell
                                ;  _paymentDate.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _cap.cell
                                ;  _floor.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                ;  _isInArrears.cell
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
        ! floor
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_floor", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Floor") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_isCapped", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsCapped") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_isFloored", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsFloored") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        Coupon interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_rate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Rate") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_setPricer", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".SetPricer") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _pricer.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedAmount", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedAmount") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! convexity-adjusted fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_adjustedFixing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AdjustedFixing") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_amount", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Amount") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_dayCounter", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".DayCounter") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! fixing days
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_fixingDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".FixingDate") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! floating index
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_fixingDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".FixingDays") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_gearing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Gearing") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        properties
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_index", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Index") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! spread paid over the fixing of the underlying index ! fixing of the underlying index
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_indexFixing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".IndexFixing") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! whether or not the coupon fixes in arrears
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_isInArrears", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsInArrears") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        methods
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_price", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Price") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _yts.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_pricer", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Pricer") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_spread", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Spread") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_update", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Update") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualDays") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualEndDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualEndDate") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualPeriod", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualPeriod") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualStartDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualStartDate") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedDays") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedPeriod", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedPeriod") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_date", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Date") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_exCouponDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".ExCouponDate") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_nominal", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Nominal") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_referencePeriodEnd", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_referencePeriodStart", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".ReferencePeriodStart") 
                                               [| _CappedFlooredCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_CompareTo", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".CompareTo") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_Equals", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Equals") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_hasOccurred", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<Nullable<bool>> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".HasOccurred") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_tradingExCoupon", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".TradingExCoupon") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accept", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".Accept") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_registerWith", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".RegisterWith") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_unregisterWith", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "Reference to CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCoupon.cell :?> CappedFlooredCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCoupon.source + ".UnregisterWith") 
                                               [| _CappedFlooredCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_Range", Description="Create a range of CappedFlooredCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CappedFlooredCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CappedFlooredCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CappedFlooredCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
