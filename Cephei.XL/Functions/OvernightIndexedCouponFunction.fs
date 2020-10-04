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
module OvernightIndexedCouponFunction =

    (*
        ! accrual (compounding) periods
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_dt", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_dt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Dt
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Dt") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixing dates for the rates to be compounded
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_fixingDates", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_fixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).FixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".FixingDates") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_indexFixings", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_indexFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).IndexFixings
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".IndexFixings") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_create
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
        ([<ExcelArgument(Name="overnightIndex",Description = "Reference to overnightIndex")>] 
         overnightIndex : obj)
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
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let builder () = withMnemonic mnemonic (Fun.OvernightIndexedCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _overnightIndex.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndexedCoupon>) l

                let source = Helper.sourceFold "Fun.OvernightIndexedCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _overnightIndex.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _overnightIndex.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! value dates for the rates to be compounded
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_valueDates", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_valueDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).ValueDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".ValueDates") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accruedAmount", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccruedAmount") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_adjustedFixing", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AdjustedFixing") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_amount", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Amount") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
        ! convexity adjustment
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_convexityAdjustment", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".ConvexityAdjustment") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_dayCounter", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".DayCounter") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedCoupon> format
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_factory", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
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

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
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
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Factory
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

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Factory") 
                                               [| _OvernightIndexedCoupon.source
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
                                [| _OvernightIndexedCoupon.cell
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedCoupon> format
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_fixingDate", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".FixingDate") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_fixingDays", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".FixingDays") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_gearing", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Gearing") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_index", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Index") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedCoupon> format
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_indexFixing", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".IndexFixing") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_isInArrears", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".IsInArrears") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_price", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Price") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_pricer", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Pricer") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndexedCoupon> format
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_rate", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Rate") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_setPricer", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".SetPricer") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
        ! index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_OvernightIndexedCoupon_spread", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Spread") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_update", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Update
                                                       ) :> ICell
                let format (o : OvernightIndexedCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Update") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accrualDays", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccrualDays") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accrualEndDate", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccrualEndDate") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accrualPeriod", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccrualPeriod") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accrualStartDate", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccrualStartDate") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accruedDays", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccruedDays") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accruedPeriod", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".AccruedPeriod") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_date", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Date") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_exCouponDate", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".ExCouponDate") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_nominal", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Nominal") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_referencePeriodEnd", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".ReferencePeriodEnd") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_referencePeriodStart", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".ReferencePeriodStart") 
                                               [| _OvernightIndexedCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_CompareTo", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".CompareTo") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_Equals", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Equals") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_hasOccurred", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".HasOccurred") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_tradingExCoupon", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".TradingExCoupon") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_accept", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".Accept") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_registerWith", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".RegisterWith") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_unregisterWith", Description="Create a OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndexedCoupon",Description = "Reference to OvernightIndexedCoupon")>] 
         overnightindexedcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndexedCoupon = Helper.toCell<OvernightIndexedCoupon> overnightindexedcoupon "OvernightIndexedCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((OvernightIndexedCouponModel.Cast _OvernightIndexedCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndexedCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_OvernightIndexedCoupon.source + ".UnregisterWith") 
                                               [| _OvernightIndexedCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndexedCoupon.cell
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
    [<ExcelFunction(Name="_OvernightIndexedCoupon_Range", Description="Create a range of OvernightIndexedCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndexedCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OvernightIndexedCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndexedCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightIndexedCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightIndexedCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<OvernightIndexedCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
