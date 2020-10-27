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
  The performance is relative to the index value on the base date.  The other inflation value is taken from the refPeriodEnd date with observation lag, so any roll/calendar etc. will be built in by the caller.  By default this is done in the InflationCoupon which uses ModifiedPreceding with fixing days assumed positive meaning earlier, i.e. always stay in same month (relative to referencePeriodEnd).  This is more sophisticated than an %IndexedCashFlow because it does date calculations itself.  We do not do any convexity adjustment for lags different to the natural ZCIIS lag that was used to create the forward inflation curve.
  </summary> *)
[<AutoSerializable(true)>]
module CPICouponFunction =

    (*
        ! adjusted fixing (already divided by the base fixing)
    *)
    [<ExcelFunction(Name="_CPICoupon_adjustedFixing", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "CPICoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
        ! \warning make sure that the interpolation used to create this is what you are using for the fixing, i.e. the observationInterpolation.
    *)
    [<ExcelFunction(Name="_CPICoupon_baseCPI", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_baseCPI
        ([<ExcelArgument(Name="Mnemonic",Description = "CPICoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).BaseCPI
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".BaseCPI") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CPICoupon")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="baseCPI",Description = "double")>] 
         baseCPI : obj)
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
        ([<ExcelArgument(Name="index",Description = "ZeroInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Period")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "InterpolationType: AsIndex, Flat, Linear")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "double")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="spread",Description = "CPICoupon")>] 
         spread : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "CPICoupon")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "CPICoupon")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="exCouponDate",Description = "CPICoupon")>] 
         exCouponDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<ZeroInflationIndex> index "index" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _observationInterpolation = Helper.toCell<InterpolationType> observationInterpolation "observationInterpolation" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _fixedRate = Helper.toCell<double> fixedRate "fixedRate" 
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _exCouponDate = Helper.toDefault<Date> exCouponDate "exCouponDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CPICoupon 
                                                            _baseCPI.cell 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _observationLag.cell 
                                                            _observationInterpolation.cell 
                                                            _dayCounter.cell 
                                                            _fixedRate.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _exCouponDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPICoupon>) l

                let source () = Helper.sourceFold "Fun.CPICoupon" 
                                               [| _baseCPI.source
                                               ;  _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _observationLag.source
                                               ;  _observationInterpolation.source
                                               ;  _dayCounter.source
                                               ;  _fixedRate.source
                                               ;  _spread.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _exCouponDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _baseCPI.cell
                                ;  _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _observationLag.cell
                                ;  _observationInterpolation.cell
                                ;  _dayCounter.cell
                                ;  _fixedRate.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _exCouponDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! index used
    *)
    [<ExcelFunction(Name="_CPICoupon_cpiIndex", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_cpiIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "ZeroInflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).CpiIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_CPICoupon.source + ".CpiIndex") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors fixed rate that will be inflated by the index ratio
    *)
    [<ExcelFunction(Name="_CPICoupon_fixedRate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_fixedRate
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).FixedRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".FixedRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
        ! allows for a different interpolation from the index
    *)
    [<ExcelFunction(Name="_CPICoupon_indexFixing", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
        ! utility method, calls indexFixing
    *)
    [<ExcelFunction(Name="_CPICoupon_indexObservation", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_indexObservation
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="onDate",Description = "Date")>] 
         onDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _onDate = Helper.toCell<Date> onDate "onDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).IndexObservation
                                                            _onDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".IndexObservation") 

                                               [| _onDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                ;  _onDate.cell
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
        ! how do you observe the index?  as-is, flat, linear?
    *)
    [<ExcelFunction(Name="_CPICoupon_observationInterpolation", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_observationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).ObservationInterpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".ObservationInterpolation") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
        ! spread paid over the fixing of the underlying index
    *)
    [<ExcelFunction(Name="_CPICoupon_spread", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accruedAmount", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_amount", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_dayCounter", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_CPICoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
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
    [<ExcelFunction(Name="_CPICoupon_fixingDate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_fixingDays", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_index", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source () = Helper.sourceFold (_CPICoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
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
    [<ExcelFunction(Name="_CPICoupon_observationLag", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_CPICoupon.source + ".ObservationLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
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
    [<ExcelFunction(Name="_CPICoupon_price", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCouponPricer")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="discountingCurve",Description = "YieldTermStructure")>] 
         discountingCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _discountingCurve = Helper.toHandle<YieldTermStructure> discountingCurve "discountingCurve" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Price
                                                            _discountingCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Price") 

                                               [| _discountingCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_pricer", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationCouponPricer")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCouponPricer>) l

                let source () = Helper.sourceFold (_CPICoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPICoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPICoupon_rate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_setPricer", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "InflationCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _pricer = Helper.toCell<InflationCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CPICoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_update", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Update
                                                       ) :> ICell
                let format (o : CPICoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accrualDays", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accrualEndDate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accrualPeriod", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accrualStartDate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accruedDays", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accruedPeriod", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_date", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_exCouponDate", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_nominal", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_referencePeriodEnd", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_referencePeriodStart", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_CompareTo", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_Equals", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_hasOccurred", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_tradingExCoupon", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_accept", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CPICoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_registerWith", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_unregisterWith", Description="Create a CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPICoupon",Description = "CPICoupon")>] 
         cpicoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPICoupon = Helper.toCell<CPICoupon> cpicoupon "CPICoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CPICouponModel.Cast _CPICoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPICoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CPICoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPICoupon.cell
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
    [<ExcelFunction(Name="_CPICoupon_Range", Description="Create a range of CPICoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CPICoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPICoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPICoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPICoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CPICoupon>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
