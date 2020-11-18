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
module FloatingRateCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedAmount", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_adjustedFixing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AdjustedFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_amount", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_convexityAdjustment", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".ConvexityAdjustment") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_dayCounter", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
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
    [<ExcelFunction(Name="_FloatingRateCoupon_factory", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
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

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
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
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Factory
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

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Factory") 

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
                                [| _FloatingRateCoupon.cell
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
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
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
    [<ExcelFunction(Name="_FloatingRateCoupon_fixingDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".FixingDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_fixingDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon1", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateCoupon1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold "Fun.FloatingRateCoupon1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructors
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_create
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

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FloatingRateCoupon
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
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source () = Helper.sourceFold "Fun.FloatingRateCoupon" 
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
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon_gearing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Gearing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_index", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
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
    [<ExcelFunction(Name="_FloatingRateCoupon_indexFixing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".IndexFixing") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_isInArrears", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".IsInArrears") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_price", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "YieldTermStructure")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Price") 

                                               [| _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_pricer", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Pricer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingRateCoupon> format
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
    [<ExcelFunction(Name="_FloatingRateCoupon_rate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_setPricer", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "FloatingRateCouponPricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".SetPricer") 

                                               [| _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_spread", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_update", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Update
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualEndDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualPeriod", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualStartDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedPeriod", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_date", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_exCouponDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_nominal", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_referencePeriodEnd", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_referencePeriodStart", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_CompareTo", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_Equals", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_hasOccurred", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_tradingExCoupon", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accept", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_registerWith", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_unregisterWith", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FloatingRateCouponModel.Cast _FloatingRateCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FloatingRateCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_Range", Description="Create a range of FloatingRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FloatingRateCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingRateCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<FloatingRateCoupon> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<FloatingRateCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FloatingRateCoupon>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
