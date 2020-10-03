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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
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
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCmsCoupon 
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

                let source = Helper.sourceFold "Fun.CappedFlooredCmsCoupon" 
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon1", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CappedFlooredCmsCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredCmsCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredCmsCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_factory", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
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
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Factory
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

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Factory") 
                                               [| _CappedFlooredCmsCoupon.source
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
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_cap", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Cap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Cap") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_convexityAdjustment", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ConvexityAdjustment") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_effectiveCap", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).EffectiveCap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".EffectiveCap") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_effectiveFloor", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).EffectiveFloor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".EffectiveFloor") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_floor", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Floor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Floor") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isCapped", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsCapped") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isFloored", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsFloored") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_rate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Rate") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_setPricer", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".SetPricer") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedAmount", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedAmount") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_adjustedFixing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AdjustedFixing") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_amount", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Amount") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_dayCounter", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".DayCounter") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_fixingDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".FixingDate") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_fixingDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".FixingDays") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_gearing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Gearing") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_index", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Index") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_indexFixing", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IndexFixing") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_isInArrears", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".IsInArrears") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_price", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Price") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_pricer", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Pricer") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_spread", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Spread") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_update", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Update
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Update") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualDays") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualEndDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualEndDate") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualPeriod", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualPeriod") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accrualStartDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccrualStartDate") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedDays", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedDays") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accruedPeriod", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".AccruedPeriod") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_date", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Date") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_exCouponDate", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ExCouponDate") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_nominal", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Nominal") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_referencePeriodEnd", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_referencePeriodStart", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".ReferencePeriodStart") 
                                               [| _CappedFlooredCmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_CompareTo", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".CompareTo") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_Equals", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Equals") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_hasOccurred", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".HasOccurred") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_tradingExCoupon", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".TradingExCoupon") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_accept", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".Accept") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_registerWith", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".RegisterWith") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_unregisterWith", Description="Create a CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredCmsCoupon",Description = "Reference to CappedFlooredCmsCoupon")>] 
         cappedflooredcmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredCmsCoupon = Helper.toCell<CappedFlooredCmsCoupon> cappedflooredcmscoupon "CappedFlooredCmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredCmsCoupon.cell :?> CappedFlooredCmsCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredCmsCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredCmsCoupon.source + ".UnregisterWith") 
                                               [| _CappedFlooredCmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredCmsCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredCmsCoupon_Range", Description="Create a range of CappedFlooredCmsCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredCmsCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CappedFlooredCmsCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredCmsCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CappedFlooredCmsCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredCmsCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CappedFlooredCmsCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
