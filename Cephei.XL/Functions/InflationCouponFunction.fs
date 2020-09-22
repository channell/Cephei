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
  The day counter is usually obtained from the inflation term structure that the inflation index uses for forecasting. There is no gearing or spread because these are relevant for YoY coupons but not zero inflation coupons.  inflation indices do not contain day counters or calendars.
  </summary> *)
[<AutoSerializable(true)>]
module InflationCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InflationCoupon_accruedAmount", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccruedAmount") 
                                               [| _InflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_InflationCoupon_amount", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Amount") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_dayCounter", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_InflationCoupon.source + ".DayCounter") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        ! fixing date
    *)
    [<ExcelFunction(Name="_InflationCoupon_fixingDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".FixingDate") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        ! fixing days
    *)
    [<ExcelFunction(Name="_InflationCoupon_fixingDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".FixingDays") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        Inspectors ! yoy inflation index
    *)
    [<ExcelFunction(Name="_InflationCoupon_index", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source = Helper.sourceFold (_InflationCoupon.source + ".Index") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        ! fixing of the underlying index, as observed by the coupon
    *)
    [<ExcelFunction(Name="_InflationCoupon_indexFixing", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".IndexFixing") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_create
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
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="exCouponDate",Description = "Reference to exCouponDate")>] 
         exCouponDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _index = Helper.toCell<InflationIndex> index "index" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _refPeriodStart = Helper.toCell<Date> refPeriodStart "refPeriodStart" true
                let _refPeriodEnd = Helper.toCell<Date> refPeriodEnd "refPeriodEnd" true
                let _exCouponDate = Helper.toCell<Date> exCouponDate "exCouponDate" true
                let builder () = withMnemonic mnemonic (Fun.InflationCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _observationLag.cell 
                                                            _dayCounter.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _exCouponDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCoupon>) l

                let source = Helper.sourceFold "Fun.InflationCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _observationLag.source
                                               ;  _dayCounter.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _exCouponDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _observationLag.cell
                                ;  _dayCounter.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _exCouponDate.cell
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
        ! how the coupon observes the index
    *)
    [<ExcelFunction(Name="_InflationCoupon_observationLag", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_InflationCoupon.source + ".ObservationLag") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_price", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="discountingCurve",Description = "Reference to discountingCurve")>] 
         discountingCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _discountingCurve = Helper.toHandle<YieldTermStructure> discountingCurve "discountingCurve" 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Price
                                                            _discountingCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Price") 
                                               [| _InflationCoupon.source
                                               ;  _discountingCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                ;  _discountingCurve.cell
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
    [<ExcelFunction(Name="_InflationCoupon_pricer", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCouponPricer>) l

                let source = Helper.sourceFold (_InflationCoupon.source + ".Pricer") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_rate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Rate") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_setPricer", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _pricer = Helper.toCell<InflationCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".SetPricer") 
                                               [| _InflationCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_update", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Update
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Update") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccrualDays") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualEndDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccrualEndDate") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualPeriod", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccrualPeriod") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualStartDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccrualStartDate") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accruedDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccruedDays") 
                                               [| _InflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accruedPeriod", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".AccruedPeriod") 
                                               [| _InflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_date", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Date") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_exCouponDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".ExCouponDate") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_nominal", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Nominal") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_referencePeriodEnd", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".ReferencePeriodEnd") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_referencePeriodStart", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".ReferencePeriodStart") 
                                               [| _InflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_CompareTo", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".CompareTo") 
                                               [| _InflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_Equals", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Equals") 
                                               [| _InflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_hasOccurred", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".HasOccurred") 
                                               [| _InflationCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_tradingExCoupon", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".TradingExCoupon") 
                                               [| _InflationCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accept", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".Accept") 
                                               [| _InflationCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_registerWith", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".RegisterWith") 
                                               [| _InflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_unregisterWith", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "Reference to InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_InflationCoupon.cell :?> InflationCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InflationCoupon.source + ".UnregisterWith") 
                                               [| _InflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_Range", Description="Create a range of InflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InflationCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InflationCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InflationCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InflationCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InflationCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InflationCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
