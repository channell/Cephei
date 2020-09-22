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
module CappedFlooredCmsSpreadCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon1", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCmsSpreadCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsSpreadCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredCmsSpreadCoupon1" 
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
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

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _index = Helper.toCell<SwapSpreadIndex> index "index" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" true
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCmsSpreadCoupon
                                                            _paymentDate.cell 
                                                            _nominal.cell 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsSpreadCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredCmsSpreadCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
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
                                [| _paymentDate.cell
                                ;  _nominal.cell
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
        cap
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_cap", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Cap") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_convexityAdjustment", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ConvexityAdjustment") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_effectiveCap", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".EffectiveCap") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_effectiveFloor", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".EffectiveFloor") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_factory", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
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

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _index = Helper.toCell<InterestRateIndex> index "index" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Factory
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

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Factory") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
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
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_floor", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Floor") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isCapped", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsCapped") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isFloored", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsFloored") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_rate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Rate") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_setPricer", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".SetPricer") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedAmount", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedAmount") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_adjustedFixing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AdjustedFixing") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_amount", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Amount") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_dayCounter", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".DayCounter") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_fixingDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".FixingDate") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_fixingDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".FixingDays") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_gearing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Gearing") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_index", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Index") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_indexFixing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IndexFixing") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isInArrears", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsInArrears") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_price", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Price") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_pricer", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Pricer") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_spread", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Spread") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_update", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Update") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualDays") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualEndDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualEndDate") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualPeriod", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualPeriod") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualStartDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualStartDate") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedDays") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedPeriod", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedPeriod") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_date", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Date") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_exCouponDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ExCouponDate") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_nominal", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Nominal") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_referencePeriodEnd", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_referencePeriodStart", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ReferencePeriodStart") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_CompareTo", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".CompareTo") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_Equals", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Equals") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_hasOccurred", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".HasOccurred") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_tradingExCoupon", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".TradingExCoupon") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accept", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Accept") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_registerWith", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".RegisterWith") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_unregisterWith", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "Reference to CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsSpreadCoupon.cell :?> CappedFlooredCmsSpreadCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".UnregisterWith") 
                                               [| _CappedFlooredCmsSpreadCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_Range", Description="Create a range of CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CappedFlooredCmsSpreadCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCmsSpreadCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CappedFlooredCmsSpreadCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredCmsSpreadCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CappedFlooredCmsSpreadCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
