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
module CappedFlooredCmsCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
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
        ([<ExcelArgument(Name="index",Description = "SwapIndex")>] 
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

                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<SwapIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CappedFlooredCmsCoupon 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsCoupon>) l

                let source () = Helper.sourceFold "Fun.CappedFlooredCmsCoupon" 
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
                                [| _nominal.cell
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
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon1", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CappedFlooredCmsCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsCoupon>) l

                let source () = Helper.sourceFold "Fun.CappedFlooredCmsCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_factory", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
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

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
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
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Factory") 

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
                                [| _CappedFlooredCmsCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_cap", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Cap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_convexityAdjustment", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_effectiveCap", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".EffectiveCap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_effectiveFloor", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".EffectiveFloor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
        ! floor
    *)
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_floor", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Floor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isCapped", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsCapped") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isFloored", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsFloored") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_rate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_setPricer", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedAmount", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_adjustedFixing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_amount", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_dayCounter", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_fixingDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_fixingDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_gearing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_index", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_indexFixing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isInArrears", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_price", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_pricer", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCmsCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_spread", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_update", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualEndDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualPeriod", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualStartDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedPeriod", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_date", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_exCouponDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_nominal", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_referencePeriodEnd", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_referencePeriodStart", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_CompareTo", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_Equals", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_hasOccurred", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_tradingExCoupon", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accept", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_registerWith", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_unregisterWith", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CappedFlooredCmsCouponModel.Cast _CappedFlooredCmsCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_Range", Description="Create a range of CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCmsCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CappedFlooredCmsCoupon> (c)) :> ICell
                let format (i : Generic.List<ICell<CappedFlooredCmsCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CappedFlooredCmsCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
