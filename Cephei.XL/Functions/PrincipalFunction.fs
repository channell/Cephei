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
  %principal payment over a fixed period   This class implements part of the CashFlow interface but it is still abstract and provides derived classes with methods for accrual period calculations.
  </summary> *)
[<AutoSerializable(true)>]
module PrincipalFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Principal_accrualEndDate", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".AccrualEndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_accrualStartDate", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".AccrualStartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_amount", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Principal.source + ".Amount") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_date", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_date
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".Date") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_dayCounter", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Principal.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Principal> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        access to properties
    *)
    [<ExcelFunction(Name="_Principal_nominal", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Principal")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Principal.source + ".Nominal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
        Constructors
    *)
    [<ExcelFunction(Name="_Principal", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Principal")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Principal ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Principal>) l

                let source () = Helper.sourceFold "Fun.Principal" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Principal> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        default constructor
    *)
    [<ExcelFunction(Name="_Principal1", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Principal")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="amount",Description = "double")>] 
         amount : obj)
        ([<ExcelArgument(Name="nominal",Description = "double")>] 
         nominal : obj)
        ([<ExcelArgument(Name="paymentDate",Description = "Date")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="accrualStartDate",Description = "Date")>] 
         accrualStartDate : obj)
        ([<ExcelArgument(Name="accrualEndDate",Description = "Date")>] 
         accrualEndDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Principal")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Principal")>] 
         refPeriodEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _amount = Helper.toCell<double> amount "amount" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _accrualStartDate = Helper.toCell<Date> accrualStartDate "accrualStartDate" 
                let _accrualEndDate = Helper.toCell<Date> accrualEndDate "accrualEndDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Principal1 
                                                            _amount.cell 
                                                            _nominal.cell 
                                                            _paymentDate.cell 
                                                            _accrualStartDate.cell 
                                                            _accrualEndDate.cell 
                                                            _dayCounter.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Principal>) l

                let source () = Helper.sourceFold "Fun.Principal1" 
                                               [| _amount.source
                                               ;  _nominal.source
                                               ;  _paymentDate.source
                                               ;  _accrualStartDate.source
                                               ;  _accrualEndDate.source
                                               ;  _dayCounter.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _amount.cell
                                ;  _nominal.cell
                                ;  _paymentDate.cell
                                ;  _accrualStartDate.cell
                                ;  _accrualEndDate.cell
                                ;  _dayCounter.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Principal> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Principal_refPeriodEnd", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_refPeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).RefPeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".RefPeriodEnd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_refPeriodStart", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_refPeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).RefPeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".RefPeriodStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_setAmount", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_setAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="amount",Description = "double")>] 
         amount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _amount = Helper.toCell<double> amount "amount" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).SetAmount
                                                            _amount.cell 
                                                       ) :> ICell
                let format (o : Principal) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".SetAmount") 

                                               [| _amount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
                                ;  _amount.cell
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
    [<ExcelFunction(Name="_Principal_CompareTo", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="cf",Description = "CashFlow")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Principal.source + ".CompareTo") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_Equals", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="cf",Description = "Object")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".Equals") 

                                               [| _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
        ! returns the date that the cash flow trades exCoupon
    *)
    [<ExcelFunction(Name="_Principal_exCouponDate", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".ExCouponDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_hasOccurred", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "bool")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".HasOccurred") 

                                               [| _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_tradingExCoupon", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="refDate",Description = "Date")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".TradingExCoupon") 

                                               [| _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_accept", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="v",Description = "IAcyclicVisitor")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : Principal) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".Accept") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_registerWith", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Principal) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_unregisterWith", Description="Create a Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Principal",Description = "Principal")>] 
         principal : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Principal = Helper.toCell<Principal> principal "Principal"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((PrincipalModel.Cast _Principal.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Principal) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Principal.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Principal.cell
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
    [<ExcelFunction(Name="_Principal_Range", Description="Create a range of Principal",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Principal_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Principal> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Principal>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Principal>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Principal>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
