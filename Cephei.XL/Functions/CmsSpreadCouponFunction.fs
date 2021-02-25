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
module CmsSpreadCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadCoupon", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_create
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
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = (Fun.CmsSpreadCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsSpreadCoupon>) l

                let source () = Helper.sourceFold "Fun.CmsSpreadCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _gearing.source
                                               ;  _spread.source
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
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                ;  _isInArrears.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon1", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.CmsSpreadCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsSpreadCoupon>) l

                let source () = Helper.sourceFold "Fun.CmsSpreadCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_swapSpreadIndex", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_swapSpreadIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).SwapSpreadIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapSpreadIndex>) l

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".SwapSpreadIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsSpreadCoupon_accruedAmount", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_adjustedFixing", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_amount", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
        ! convexity adjustment
    *)
    [<ExcelFunction(Name="_CmsSpreadCoupon_convexityAdjustment", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_dayCounter", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_factory", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
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

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<InterestRateIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Factory
                                                            _nominal.cell 
                                                            _paymentDate.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Factory") 

                                               [| _nominal.source
                                               ;  _paymentDate.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _dayCounter.source
                                               ;  _isInArrears.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
                                ;  _nominal.cell
                                ;  _paymentDate.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                ;  _isInArrears.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_fixingDate", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_fixingDays", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_gearing", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_index", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_indexFixing", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_isInArrears", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_price", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_pricer", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsSpreadCoupon> format
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_rate", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_setPricer", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_CmsSpreadCoupon_spread", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_update", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accrualDays", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accrualEndDate", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accrualPeriod", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accrualStartDate", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accruedDays", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accruedPeriod", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_date", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_exCouponDate", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_nominal", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_referencePeriodEnd", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_referencePeriodStart", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_CompareTo", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_Equals", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_hasOccurred", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_tradingExCoupon", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_accept", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_registerWith", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_unregisterWith", Description="Create a CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsSpreadCoupon",Description = "CmsSpreadCoupon")>] 
         cmsspreadcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsSpreadCoupon = Helper.toModelReference<CmsSpreadCoupon> cmsspreadcoupon "CmsSpreadCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CmsSpreadCouponModel.Cast _CmsSpreadCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CmsSpreadCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsSpreadCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsSpreadCoupon.cell
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
    [<ExcelFunction(Name="_CmsSpreadCoupon_Range", Description="Create a range of CmsSpreadCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsSpreadCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsSpreadCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CmsSpreadCoupon> (c)) :> ICell
                let format (i : Cephei.Cell.List<CmsSpreadCoupon>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CmsSpreadCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
