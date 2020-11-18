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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon1", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CappedFlooredCmsSpreadCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsSpreadCoupon>) l

                let source () = Helper.sourceFold "Fun.CappedFlooredCmsSpreadCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Date")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="index",Description = "SwapSpreadIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="gearing",Description = "double or empty")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "double or empty")>] 
         spread : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date or empty")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date or empty")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter or empty")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "bool or empty")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<SwapSpreadIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CappedFlooredCmsSpreadCoupon
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

                let source () = Helper.sourceFold "Fun.CappedFlooredCmsSpreadCoupon" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_cap", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Cap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_convexityAdjustment", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! effective cap of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_effectiveCap", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".EffectiveCap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! effective floor of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_effectiveFloor", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".EffectiveFloor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_factory", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="startDate",Description = "Date")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Date")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="index",Description = "InterestRateIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="gearing",Description = "double or empty")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "double or empty")>] 
         spread : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date or empty")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date or empty")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter or empty")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "bool or empty")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<InterestRateIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Factory") 

                                               [| _nominal.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_floor", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Floor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isCapped", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsCapped") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isFloored", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsFloored") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        Coupon interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_rate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_setPricer", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _pricer.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedAmount", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! convexity-adjusted fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_adjustedFixing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_amount", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_dayCounter", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_fixingDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! floating index
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_fixingDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_gearing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        properties
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_index", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_indexFixing", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! whether or not the coupon fixes in arrears
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_isInArrears", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        methods
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_price", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _yts.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_pricer", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_spread", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_update", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualEndDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualPeriod", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accrualStartDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedDays", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accruedPeriod", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_date", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_exCouponDate", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_nominal", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_referencePeriodEnd", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_referencePeriodStart", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_CompareTo", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_Equals", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_hasOccurred", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_tradingExCoupon", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_accept", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_registerWith", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_unregisterWith", Description="Create a CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsSpreadCoupon",Description = "CappedFlooredCmsSpreadCoupon")>] 
         cappedflooredcmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsSpreadCoupon = Helper.toCell<CappedFlooredCmsSpreadCoupon> cappedflooredcmsspreadcoupon "CappedFlooredCmsSpreadCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsSpreadCouponModel.Cast _CappedFlooredCmsSpreadCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsSpreadCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsSpreadCoupon_Range", Description="Create a range of CappedFlooredCmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsSpreadCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCmsSpreadCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<CappedFlooredCmsSpreadCoupon> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredCmsSpreadCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CappedFlooredCmsSpreadCoupon>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
