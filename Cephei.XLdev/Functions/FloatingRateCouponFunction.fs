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
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedAmount", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedAmount") 
                                               [| _FloatingRateCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_adjustedFixing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AdjustedFixing") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_amount", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Amount") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_convexityAdjustment", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".ConvexityAdjustment") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_dayCounter", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".DayCounter") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_factory", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
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

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
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
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Factory
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

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Factory") 
                                               [| _FloatingRateCoupon.source
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
    [<ExcelFunction(Name="_FloatingRateCoupon_fixingDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".FixingDate") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_fixingDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".FixingDays") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FloatingRateCoupon 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCoupon>) l

                let source = Helper.sourceFold "Fun.FloatingRateCoupon" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
        constructors
    *)
    [<ExcelFunction(Name="_FloatingRateCoupon1", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_create1
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

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" true
                let _nominal = Helper.toCell<double> nominal "nominal" true
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
                let builder () = withMnemonic mnemonic (Fun.FloatingRateCoupon1 
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

                let source = Helper.sourceFold "Fun.FloatingRateCoupon1" 
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
    [<ExcelFunction(Name="_FloatingRateCoupon_gearing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Gearing") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_index", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRateIndex>) l

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Index") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_indexFixing", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".IndexFixing") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_isInArrears", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_isInArrears
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).IsInArrears
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".IsInArrears") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_price", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="yts",Description = "Reference to yts")>] 
         yts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _yts = Helper.toCell<YieldTermStructure> yts "yts" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Price
                                                            _yts.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Price") 
                                               [| _FloatingRateCoupon.source
                                               ;  _yts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_pricer", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingRateCouponPricer>) l

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Pricer") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_rate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Rate") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_setPricer", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _pricer = Helper.toCell<FloatingRateCouponPricer> pricer "pricer" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".SetPricer") 
                                               [| _FloatingRateCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_spread", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Spread") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_update", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Update
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Update") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualDays") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualEndDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualEndDate") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualPeriod", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualPeriod") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accrualStartDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccrualStartDate") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedDays", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedDays") 
                                               [| _FloatingRateCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accruedPeriod", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".AccruedPeriod") 
                                               [| _FloatingRateCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_date", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Date") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_exCouponDate", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".ExCouponDate") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_nominal", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Nominal") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_referencePeriodEnd", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".ReferencePeriodEnd") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_referencePeriodStart", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".ReferencePeriodStart") 
                                               [| _FloatingRateCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_CompareTo", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _cf = Helper.toCell<CashFlow> cf "cf" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".CompareTo") 
                                               [| _FloatingRateCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_Equals", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _cf = Helper.toCell<Object> cf "cf" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Equals") 
                                               [| _FloatingRateCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_hasOccurred", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let _includeRefDate = Helper.toNullable<Nullable<bool>> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".HasOccurred") 
                                               [| _FloatingRateCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_tradingExCoupon", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _refDate = Helper.toCell<Date> refDate "refDate" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".TradingExCoupon") 
                                               [| _FloatingRateCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_accept", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _v = Helper.toCell<IAcyclicVisitor> v "v" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".Accept") 
                                               [| _FloatingRateCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_registerWith", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".RegisterWith") 
                                               [| _FloatingRateCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_unregisterWith", Description="Create a FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingRateCoupon",Description = "Reference to FloatingRateCoupon")>] 
         floatingratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingRateCoupon = Helper.toCell<FloatingRateCoupon> floatingratecoupon "FloatingRateCoupon" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FloatingRateCoupon.cell :?> FloatingRateCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FloatingRateCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingRateCoupon.source + ".UnregisterWith") 
                                               [| _FloatingRateCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingRateCoupon.cell
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
    [<ExcelFunction(Name="_FloatingRateCoupon_Range", Description="Create a range of FloatingRateCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingRateCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloatingRateCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingRateCoupon> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatingRateCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatingRateCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FloatingRateCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
