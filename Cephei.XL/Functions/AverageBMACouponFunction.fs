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
module AverageBMACouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMACoupon", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_create
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
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _index = Helper.toCell<BMAIndex> index "index" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _dayCounter = Helper.toDefault<DayCounter> dayCounter "dayCounter" null
                let builder () = withMnemonic mnemonic (Fun.AverageBMACoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _index.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AverageBMACoupon>) l

                let source = Helper.sourceFold "Fun.AverageBMACoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _index.source
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
                                ;  _index.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMACoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AverageBMACoupon_convexityAdjustment", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".ConvexityAdjustment") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_fixingDate", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".FixingDate") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_fixingDates", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_fixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).FixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".FixingDates") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_indexFixing", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".IndexFixing") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_indexFixings", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_indexFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).IndexFixings
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".IndexFixings") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accruedAmount", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccruedAmount") 
                                               [| _AverageBMACoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_adjustedFixing", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AdjustedFixing") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_amount", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Amount") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_dayCounter", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".DayCounter") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMACoupon> format
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
    [<ExcelFunction(Name="_AverageBMACoupon_factory", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
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

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
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
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Factory
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

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Factory") 
                                               [| _AverageBMACoupon.source
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
                                [| _AverageBMACoupon.cell
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
                    ; subscriber = Helper.subscriberModel<AverageBMACoupon> format
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
    [<ExcelFunction(Name="_AverageBMACoupon_fixingDays", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".FixingDays") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_gearing", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Gearing") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_index", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Index") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMACoupon> format
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
    [<ExcelFunction(Name="_AverageBMACoupon_isInArrears", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".IsInArrears") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_price", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Price") 
                                               [| _AverageBMACoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_pricer", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Pricer") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AverageBMACoupon> format
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
    [<ExcelFunction(Name="_AverageBMACoupon_rate", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Rate") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_setPricer", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : AverageBMACoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".SetPricer") 
                                               [| _AverageBMACoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_spread", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Spread") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_update", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Update
                                                       ) :> ICell
                let format (o : AverageBMACoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Update") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accrualDays", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccrualDays") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accrualEndDate", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccrualEndDate") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accrualPeriod", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccrualPeriod") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accrualStartDate", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccrualStartDate") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accruedDays", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccruedDays") 
                                               [| _AverageBMACoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accruedPeriod", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".AccruedPeriod") 
                                               [| _AverageBMACoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_date", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Date") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_exCouponDate", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".ExCouponDate") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_nominal", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Nominal") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_referencePeriodEnd", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".ReferencePeriodEnd") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_referencePeriodStart", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".ReferencePeriodStart") 
                                               [| _AverageBMACoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_CompareTo", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".CompareTo") 
                                               [| _AverageBMACoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_Equals", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Equals") 
                                               [| _AverageBMACoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_hasOccurred", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".HasOccurred") 
                                               [| _AverageBMACoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_tradingExCoupon", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".TradingExCoupon") 
                                               [| _AverageBMACoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_accept", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : AverageBMACoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".Accept") 
                                               [| _AverageBMACoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_registerWith", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".RegisterWith") 
                                               [| _AverageBMACoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_unregisterWith", Description="Create a AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AverageBMACoupon",Description = "Reference to AverageBMACoupon")>] 
         averagebmacoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AverageBMACoupon = Helper.toCell<AverageBMACoupon> averagebmacoupon "AverageBMACoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((AverageBMACouponModel.Cast _AverageBMACoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AverageBMACoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AverageBMACoupon.source + ".UnregisterWith") 
                                               [| _AverageBMACoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AverageBMACoupon.cell
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
    [<ExcelFunction(Name="_AverageBMACoupon_Range", Description="Create a range of AverageBMACoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AverageBMACoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AverageBMACoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AverageBMACoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AverageBMACoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AverageBMACoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AverageBMACoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
