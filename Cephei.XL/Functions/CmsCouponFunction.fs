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
  CMS coupon class   This class does not perform any date adjustment, i.e., the start and end date passed upon construction should be already rolled to a business day.
  </summary> *)
[<AutoSerializable(true)>]
module CmsCouponFunction =

    (*
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_CmsCoupon", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.CmsCoupon ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsCoupon>) l

                let source () = Helper.sourceFold "Fun.CmsCoupon" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsCoupon1", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_create1
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
        ([<ExcelArgument(Name="swapIndex",Description = "Reference to swapIndex")>] 
         swapIndex : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
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
                let _swapIndex = Helper.toCell<SwapIndex> swapIndex "swapIndex" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let _isInArrears = Helper.toDefault<bool> isInArrears "isInArrears" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CmsCoupon1 
                                                            _nominal.cell 
                                                            _paymentDate.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _swapIndex.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                            _isInArrears.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CmsCoupon>) l

                let source () = Helper.sourceFold "Fun.CmsCoupon1" 
                                               [| _nominal.source
                                               ;  _paymentDate.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _swapIndex.source
                                               ;  _gearing.source
                                               ;  _spread.source
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
                                ;  _swapIndex.cell
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
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
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
    [<ExcelFunction(Name="_CmsCoupon_factory", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
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

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
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
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Factory") 
                                               [| _CmsCoupon.source
                                               ;  _nominal.source
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
                                [| _CmsCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
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
    [<ExcelFunction(Name="_CmsCoupon_swapIndex", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_swapIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).SwapIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_CmsCoupon.source + ".SwapIndex") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CmsCoupon_accruedAmount", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccruedAmount") 
                                               [| _CmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_adjustedFixing", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AdjustedFixing") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_amount", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Amount") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_convexityAdjustment", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".ConvexityAdjustment") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_dayCounter", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CmsCoupon.source + ".DayCounter") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
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
    [<ExcelFunction(Name="_CmsCoupon_fixingDate", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".FixingDate") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_fixingDays", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".FixingDays") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_gearing", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Gearing") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_index", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Index") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
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
    [<ExcelFunction(Name="_CmsCoupon_indexFixing", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".IndexFixing") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_isInArrears", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".IsInArrears") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_price", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Price") 
                                               [| _CmsCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_pricer", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Pricer") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CmsCoupon> format
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
    [<ExcelFunction(Name="_CmsCoupon_rate", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Rate") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_setPricer", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".SetPricer") 
                                               [| _CmsCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_spread", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Spread") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_update", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Update
                                                       ) :> ICell
                let format (o : CmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Update") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accrualDays", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccrualDays") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accrualEndDate", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccrualEndDate") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accrualPeriod", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccrualPeriod") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accrualStartDate", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccrualStartDate") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accruedDays", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccruedDays") 
                                               [| _CmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accruedPeriod", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".AccruedPeriod") 
                                               [| _CmsCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_date", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Date") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_exCouponDate", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".ExCouponDate") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_nominal", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Nominal") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_referencePeriodEnd", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_referencePeriodStart", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".ReferencePeriodStart") 
                                               [| _CmsCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_CompareTo", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".CompareTo") 
                                               [| _CmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_Equals", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Equals") 
                                               [| _CmsCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_hasOccurred", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".HasOccurred") 
                                               [| _CmsCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_tradingExCoupon", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".TradingExCoupon") 
                                               [| _CmsCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_accept", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".Accept") 
                                               [| _CmsCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_registerWith", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".RegisterWith") 
                                               [| _CmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_unregisterWith", Description="Create a CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CmsCoupon",Description = "Reference to CmsCoupon")>] 
         cmscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CmsCoupon = Helper.toCell<CmsCoupon> cmscoupon "CmsCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CmsCouponModel.Cast _CmsCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CmsCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CmsCoupon.source + ".UnregisterWith") 
                                               [| _CmsCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CmsCoupon.cell
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
    [<ExcelFunction(Name="_CmsCoupon_Range", Description="Create a range of CmsCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CmsCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CmsCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CmsCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CmsCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CmsCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CmsCoupon>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
