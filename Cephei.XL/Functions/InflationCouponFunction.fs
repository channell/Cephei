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
    [<ExcelFunction(Name="_InflationCoupon_accruedAmount", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_InflationCoupon_amount", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_dayCounter", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_InflationCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationCoupon> format
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
    [<ExcelFunction(Name="_InflationCoupon_fixingDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        ! fixing days
    *)
    [<ExcelFunction(Name="_InflationCoupon_fixingDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
        Inspectors ! yoy inflation index
    *)
    [<ExcelFunction(Name="_InflationCoupon_index", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationCoupon> format
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
    [<ExcelFunction(Name="_InflationCoupon_indexFixing", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCoupon")>] 
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
        ([<ExcelArgument(Name="index",Description = "InflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "InflationCoupon")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "InflationCoupon")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="exCouponDate",Description = "InflationCoupon")>] 
         exCouponDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<InflationIndex> index "index" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _exCouponDate = Helper.toDefault<Date> exCouponDate "exCouponDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InflationCoupon 
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

                let source () = Helper.sourceFold "Fun.InflationCoupon" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationCoupon> format
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
    [<ExcelFunction(Name="_InflationCoupon_observationLag", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_InflationCoupon.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationCoupon> format
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
    [<ExcelFunction(Name="_InflationCoupon_price", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCouponPricer")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="discountingCurve",Description = "YieldTermStructure")>] 
         discountingCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _discountingCurve = Helper.toHandle<YieldTermStructure> discountingCurve "discountingCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Price
                                                            _discountingCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Price") 

                                               [| _discountingCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                ;  _discountingCurve.cell
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
    [<ExcelFunction(Name="_InflationCoupon_pricer", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCouponPricer")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCouponPricer>) l

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InflationCoupon_rate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_setPricer", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "InflationCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _pricer = Helper.toCell<InflationCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_update", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Update
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualEndDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualPeriod", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accrualStartDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accruedDays", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accruedPeriod", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_date", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_exCouponDate", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_nominal", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_referencePeriodEnd", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_referencePeriodStart", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_CompareTo", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_Equals", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_hasOccurred", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_tradingExCoupon", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_accept", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_registerWith", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_unregisterWith", Description="Create a InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationCoupon",Description = "InflationCoupon")>] 
         inflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationCoupon = Helper.toCell<InflationCoupon> inflationcoupon "InflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationCouponModel.Cast _InflationCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationCoupon.cell
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
    [<ExcelFunction(Name="_InflationCoupon_Range", Description="Create a range of InflationCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InflationCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InflationCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<InflationCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InflationCoupon>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
