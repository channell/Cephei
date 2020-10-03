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
  %Coupon paying a YoY-inflation type index
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_adjustedFixing", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AdjustedFixing") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
        Inspectors index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_gearing", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Gearing") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
        ! spread paid over the fixing of the underlying index
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_spread", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Spread") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_yoyIndex", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_yoyIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).YoyIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".YoyIndex") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_create
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
        ([<ExcelArgument(Name="yoyIndex",Description = "Reference to yoyIndex")>] 
         yoyIndex : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
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
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _yoyIndex = Helper.toCell<YoYInflationIndex> yoyIndex "yoyIndex" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let builder () = withMnemonic mnemonic (Fun.YoYInflationCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _yoyIndex.cell 
                                                            _observationLag.cell 
                                                            _dayCounter.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationCoupon>) l

                let source = Helper.sourceFold "Fun.YoYInflationCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _yoyIndex.source
                                               ;  _observationLag.source
                                               ;  _dayCounter.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _yoyIndex.cell
                                ;  _observationLag.cell
                                ;  _dayCounter.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_accruedAmount", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccruedAmount") 
                                               [| _YoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_amount", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Amount") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_dayCounter", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".DayCounter") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
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
    [<ExcelFunction(Name="_YoYInflationCoupon_fixingDate", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".FixingDate") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_fixingDays", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".FixingDays") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_index", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Index") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
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
    [<ExcelFunction(Name="_YoYInflationCoupon_indexFixing", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".IndexFixing") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
        ! how the coupon observes the index
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_observationLag", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".ObservationLag") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
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
    [<ExcelFunction(Name="_YoYInflationCoupon_price", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="discountingCurve",Description = "Reference to discountingCurve")>] 
         discountingCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _discountingCurve = Helper.toHandle<YieldTermStructure> discountingCurve "discountingCurve" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Price
                                                            _discountingCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Price") 
                                               [| _YoYInflationCoupon.source
                                               ;  _discountingCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_pricer", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCouponPricer>) l

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Pricer") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationCoupon_rate", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Rate") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_setPricer", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _pricer = Helper.toCell<InflationCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".SetPricer") 
                                               [| _YoYInflationCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_update", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Update
                                                       ) :> ICell
                let format (o : YoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Update") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accrualDays", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccrualDays") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accrualEndDate", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccrualEndDate") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accrualPeriod", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccrualPeriod") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accrualStartDate", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccrualStartDate") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accruedDays", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccruedDays") 
                                               [| _YoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accruedPeriod", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".AccruedPeriod") 
                                               [| _YoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_date", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Date") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_exCouponDate", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".ExCouponDate") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_nominal", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Nominal") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_referencePeriodEnd", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".ReferencePeriodEnd") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_referencePeriodStart", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".ReferencePeriodStart") 
                                               [| _YoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_CompareTo", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".CompareTo") 
                                               [| _YoYInflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_Equals", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Equals") 
                                               [| _YoYInflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_hasOccurred", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".HasOccurred") 
                                               [| _YoYInflationCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_tradingExCoupon", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".TradingExCoupon") 
                                               [| _YoYInflationCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_accept", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".Accept") 
                                               [| _YoYInflationCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_registerWith", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".RegisterWith") 
                                               [| _YoYInflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_unregisterWith", Description="Create a YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationCoupon",Description = "Reference to YoYInflationCoupon")>] 
         yoyinflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationCoupon = Helper.toCell<YoYInflationCoupon> yoyinflationcoupon "YoYInflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YoYInflationCoupon.cell :?> YoYInflationCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationCoupon.source + ".UnregisterWith") 
                                               [| _YoYInflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_YoYInflationCoupon_Range", Description="Create a range of YoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
