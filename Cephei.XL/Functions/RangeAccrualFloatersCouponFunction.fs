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
module RangeAccrualFloatersCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_endTime", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_endTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).EndTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".EndTime") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_lowerTrigger", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_lowerTrigger
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).LowerTrigger
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".LowerTrigger") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_observationDates", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_observationDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ObservationDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ObservationDates") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_observationsNo", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_observationsNo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ObservationsNo
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ObservationsNo") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_observationsSchedule", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_observationsSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ObservationsSchedule
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ObservationsSchedule") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
        
    *)
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_observationTimes", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_observationTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ObservationTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ObservationTimes") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_priceWithoutOptionality", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_priceWithoutOptionality
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).PriceWithoutOptionality
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".PriceWithoutOptionality") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
                                ;  _discountCurve.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="observationsSchedule",Description = "Reference to observationsSchedule")>] 
         observationsSchedule : obj)
        ([<ExcelArgument(Name="lowerTrigger",Description = "Reference to lowerTrigger")>] 
         lowerTrigger : obj)
        ([<ExcelArgument(Name="upperTrigger",Description = "Reference to upperTrigger")>] 
         upperTrigger : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _observationsSchedule = Helper.toCell<Schedule> observationsSchedule "observationsSchedule" true
                let _lowerTrigger = Helper.toCell<double> lowerTrigger "lowerTrigger" true
                let _upperTrigger = Helper.toCell<double> upperTrigger "upperTrigger" true
                let builder () = withMnemonic mnemonic (Fun.RangeAccrualFloatersCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _index.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _dayCounter.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _observationsSchedule.cell 
                                                            _lowerTrigger.cell 
                                                            _upperTrigger.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<RangeAccrualFloatersCoupon>) l

                let source = Helper.sourceFold "Fun.RangeAccrualFloatersCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _index.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _dayCounter.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _observationsSchedule.source
                                               ;  _lowerTrigger.source
                                               ;  _upperTrigger.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _index.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _dayCounter.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _observationsSchedule.cell
                                ;  _lowerTrigger.cell
                                ;  _upperTrigger.cell
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
        
    *)
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_startTime", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_startTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).StartTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".StartTime") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_upperTrigger", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_upperTrigger
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).UpperTrigger
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".UpperTrigger") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accruedAmount", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccruedAmount") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_adjustedFixing", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AdjustedFixing") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_amount", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Amount") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_convexityAdjustment", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ConvexityAdjustment") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_dayCounter", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".DayCounter") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
        Factory - for Leg generators
    *)
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_factory", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
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

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _index = Helper.toCell<InterestRateIndex> index "index" true
                let _gearing = Helper.toCell<double> gearing "gearing" true
                let _spread = Helper.toCell<double> spread "spread" true
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _isInArrears = Helper.toCell<bool> isInArrears "isInArrears" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Factory
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

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Factory") 
                                               [| _RangeAccrualFloatersCoupon.source
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
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_fixingDate", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".FixingDate") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_fixingDays", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".FixingDays") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_gearing", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Gearing") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_index", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Index") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_indexFixing", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".IndexFixing") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_isInArrears", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".IsInArrears") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_price", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Price") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_pricer", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Pricer") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
        Coupon interface
    *)
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_rate", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Rate") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_setPricer", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualFloatersCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".SetPricer") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_spread", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Spread") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_update", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Update
                                                       ) :> ICell
                let format (o : RangeAccrualFloatersCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Update") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accrualDays", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccrualDays") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accrualEndDate", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccrualEndDate") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accrualPeriod", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccrualPeriod") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accrualStartDate", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccrualStartDate") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accruedDays", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccruedDays") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accruedPeriod", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".AccruedPeriod") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_date", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Date") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_exCouponDate", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ExCouponDate") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_nominal", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Nominal") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_referencePeriodEnd", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ReferencePeriodEnd") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_referencePeriodStart", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".ReferencePeriodStart") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_CompareTo", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".CompareTo") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_Equals", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Equals") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_hasOccurred", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".HasOccurred") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_tradingExCoupon", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".TradingExCoupon") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_accept", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualFloatersCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".Accept") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_registerWith", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualFloatersCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".RegisterWith") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_unregisterWith", Description="Create a RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RangeAccrualFloatersCoupon",Description = "Reference to RangeAccrualFloatersCoupon")>] 
         rangeaccrualfloaterscoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _RangeAccrualFloatersCoupon = Helper.toCell<RangeAccrualFloatersCoupon> rangeaccrualfloaterscoupon "RangeAccrualFloatersCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_RangeAccrualFloatersCoupon.cell :?> RangeAccrualFloatersCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : RangeAccrualFloatersCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_RangeAccrualFloatersCoupon.source + ".UnregisterWith") 
                                               [| _RangeAccrualFloatersCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _RangeAccrualFloatersCoupon.cell
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
    [<ExcelFunction(Name="_RangeAccrualFloatersCoupon_Range", Description="Create a range of RangeAccrualFloatersCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let RangeAccrualFloatersCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the RangeAccrualFloatersCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<RangeAccrualFloatersCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<RangeAccrualFloatersCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<RangeAccrualFloatersCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<RangeAccrualFloatersCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
