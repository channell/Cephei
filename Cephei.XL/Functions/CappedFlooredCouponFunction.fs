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
    [<ExcelFunction(Name="_CappedFlooredCoupon_cap", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Cap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon1", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "FloatingRateCoupon")>] 
         underlying : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<FloatingRateCoupon> underlying "underlying" 
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let builder (current : ICell) = (Fun.CappedFlooredCoupon1 
                                                            _underlying.cell 
                                                            _cap.cell 
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCoupon>) l

                let source () = Helper.sourceFold "Fun.CappedFlooredCoupon1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCoupon", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.CappedFlooredCoupon ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCoupon>) l

                let source () = Helper.sourceFold "Fun.CappedFlooredCoupon" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredCoupon_convexityAdjustment", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_effectiveCap", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".EffectiveCap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_effectiveFloor", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".EffectiveFloor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_factory", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
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
        ([<ExcelArgument(Name="gearing",Description = "double")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "double")>] 
         spread : obj)
        ([<ExcelArgument(Name="cap",Description = "double")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "double")>] 
         floor : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="isInArrears",Description = "bool")>] 
         isInArrears : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<InterestRateIndex> index "index" 
                let _gearing = Helper.toCell<double> gearing "gearing" 
                let _spread = Helper.toCell<double> spread "spread" 
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" 
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Factory") 

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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_floor", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Floor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_isCapped", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsCapped") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_isFloored", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsFloored") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_rate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_setPricer", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedAmount", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_adjustedFixing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_amount", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_dayCounter", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_fixingDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_fixingDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_gearing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_index", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_indexFixing", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_isInArrears", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_price", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_pricer", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_spread", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_update", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualEndDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualPeriod", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accrualStartDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedDays", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accruedPeriod", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_date", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_exCouponDate", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_nominal", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_referencePeriodEnd", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_referencePeriodStart", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_CompareTo", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_Equals", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_hasOccurred", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_tradingExCoupon", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_accept", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_registerWith", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_unregisterWith", Description="Create a CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCoupon",Description = "CappedFlooredCoupon")>] 
         cappedflooredcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCoupon = Helper.toCell<CappedFlooredCoupon> cappedflooredcoupon "CappedFlooredCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CappedFlooredCouponModel.Cast _CappedFlooredCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CappedFlooredCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCoupon_Range", Description="Create a range of CappedFlooredCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CappedFlooredCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CappedFlooredCoupon> (c)) :> ICell
                let format (i : Cephei.Cell.List<CappedFlooredCoupon>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CappedFlooredCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
