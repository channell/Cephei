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
module CappedFlooredIborCouponFunction =

    (*
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_CappedFlooredIborCoupon", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CappedFlooredIborCoupon ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredIborCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredIborCoupon" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredIborCoupon1", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_create1
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

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredIborCoupon1 
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredIborCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredIborCoupon1" 
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
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_factory", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
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

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<IborIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Factory
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

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Factory") 
                                               [| _CappedFlooredIborCoupon.source
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
                                [| _CappedFlooredIborCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_cap", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Cap") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_convexityAdjustment", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".ConvexityAdjustment") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_effectiveCap", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".EffectiveCap") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_effectiveFloor", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".EffectiveFloor") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
        ! floor
    *)
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_floor", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Floor") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_isCapped", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".IsCapped") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_isFloored", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".IsFloored") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_rate", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Rate") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_setPricer", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".SetPricer") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accruedAmount", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccruedAmount") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_adjustedFixing", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AdjustedFixing") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_amount", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Amount") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_dayCounter", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".DayCounter") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_fixingDate", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".FixingDate") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_fixingDays", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".FixingDays") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_gearing", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Gearing") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_index", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Index") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_indexFixing", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".IndexFixing") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_isInArrears", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".IsInArrears") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_price", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Price") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_pricer", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Pricer") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredIborCoupon> format
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_spread", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Spread") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_update", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CappedFlooredIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Update") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accrualDays", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccrualDays") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accrualEndDate", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccrualEndDate") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accrualPeriod", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccrualPeriod") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accrualStartDate", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccrualStartDate") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accruedDays", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccruedDays") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accruedPeriod", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".AccruedPeriod") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_date", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Date") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_exCouponDate", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".ExCouponDate") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_nominal", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Nominal") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_referencePeriodEnd", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_referencePeriodStart", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".ReferencePeriodStart") 
                                               [| _CappedFlooredIborCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_CompareTo", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".CompareTo") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_Equals", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Equals") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_hasOccurred", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".HasOccurred") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_tradingExCoupon", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".TradingExCoupon") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_accept", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".Accept") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_registerWith", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".RegisterWith") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_unregisterWith", Description="Create a CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredIborCoupon",Description = "Reference to CappedFlooredIborCoupon")>] 
         cappedfloorediborcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredIborCoupon = Helper.toCell<CappedFlooredIborCoupon> cappedfloorediborcoupon "CappedFlooredIborCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((CappedFlooredIborCouponModel.Cast _CappedFlooredIborCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredIborCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredIborCoupon.source + ".UnregisterWith") 
                                               [| _CappedFlooredIborCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredIborCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredIborCoupon_Range", Description="Create a range of CappedFlooredIborCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredIborCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CappedFlooredIborCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredIborCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CappedFlooredIborCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredIborCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CappedFlooredIborCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
