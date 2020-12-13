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
  %Coupon paying a fixed interest rate
  </summary> *)
[<AutoSerializable(true)>]
module FixedRateCouponFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateCoupon_accruedAmount", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccruedAmount") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
        ! CashFlow interface
    *)
    [<ExcelFunction(Name="_FixedRateCoupon_amount", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_dayCounter", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateCoupon", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="interestRate",Description = "InterestRate")>] 
         interestRate : obj)
        ([<ExcelArgument(Name="accrualStartDate",Description = "Date")>] 
         accrualStartDate : obj)
        ([<ExcelArgument(Name="accrualEndDate",Description = "Date")>] 
         accrualEndDate : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date or empty")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date or empty")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="exCouponDate",Description = "Date or empty")>] 
         exCouponDate : obj)
        ([<ExcelArgument(Name="amount",Description = "double")>] 
         amount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _interestRate = Helper.toCell<InterestRate> interestRate "interestRate" 
                let _accrualStartDate = Helper.toCell<Date> accrualStartDate "accrualStartDate" 
                let _accrualEndDate = Helper.toCell<Date> accrualEndDate "accrualEndDate" 
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _exCouponDate = Helper.toDefault<Date> exCouponDate "exCouponDate" null
                let _amount = Helper.toNullable<double> amount "amount"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _interestRate.cell 
                                                            _accrualStartDate.cell 
                                                            _accrualEndDate.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _exCouponDate.cell 
                                                            _amount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateCoupon>) l

                let source () = Helper.sourceFold "Fun.FixedRateCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _interestRate.source
                                               ;  _accrualStartDate.source
                                               ;  _accrualEndDate.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _exCouponDate.source
                                               ;  _amount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _interestRate.cell
                                ;  _accrualStartDate.cell
                                ;  _accrualEndDate.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _exCouponDate.cell
                                ;  _amount.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateCoupon> format
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
    [<ExcelFunction(Name="_FixedRateCoupon1", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="accrualStartDate",Description = "Date")>] 
         accrualStartDate : obj)
        ([<ExcelArgument(Name="accrualEndDate",Description = "Date")>] 
         accrualEndDate : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Date or empty")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Date or empty")>] 
         refPeriodEnd : obj)
        ([<ExcelArgument(Name="exCouponDate",Description = "Date or empty")>] 
         exCouponDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _rate = Helper.toCell<double> rate "rate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _accrualStartDate = Helper.toCell<Date> accrualStartDate "accrualStartDate" 
                let _accrualEndDate = Helper.toCell<Date> accrualEndDate "accrualEndDate" 
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let _exCouponDate = Helper.toDefault<Date> exCouponDate "exCouponDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FixedRateCoupon1 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _rate.cell 
                                                            _dayCounter.cell 
                                                            _accrualStartDate.cell 
                                                            _accrualEndDate.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                            _exCouponDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateCoupon>) l

                let source () = Helper.sourceFold "Fun.FixedRateCoupon1" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _rate.source
                                               ;  _dayCounter.source
                                               ;  _accrualStartDate.source
                                               ;  _accrualEndDate.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               ;  _exCouponDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _rate.cell
                                ;  _dayCounter.cell
                                ;  _accrualStartDate.cell
                                ;  _accrualEndDate.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                ;  _exCouponDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateCoupon_interestRate", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_interestRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).InterestRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".InterestRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Coupon interface
    *)
    [<ExcelFunction(Name="_FixedRateCoupon_rate", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Rate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accrualDays", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccrualDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accrualEndDate", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accrualPeriod", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccrualPeriod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accrualStartDate", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accruedDays", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccruedDays") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accruedPeriod", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".AccruedPeriod") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_date", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_exCouponDate", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_nominal", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_referencePeriodEnd", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".ReferencePeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_referencePeriodStart", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".ReferencePeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_CompareTo", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_Equals", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_hasOccurred", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_tradingExCoupon", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_accept", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : FixedRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_registerWith", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_unregisterWith", Description="Create a FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateCoupon",Description = "FixedRateCoupon")>] 
         fixedratecoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateCoupon = Helper.toCell<FixedRateCoupon> fixedratecoupon "FixedRateCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FixedRateCouponModel.Cast _FixedRateCoupon.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedRateCoupon) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FixedRateCoupon.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateCoupon.cell
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
    [<ExcelFunction(Name="_FixedRateCoupon_Range", Description="Create a range of FixedRateCoupon",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FixedRateCoupon> (c)) :> ICell
                let format (i : Cephei.Cell.List<FixedRateCoupon>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FixedRateCoupon>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
