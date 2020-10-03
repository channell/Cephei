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
  Fixed-coupon bond helper for curve bootstrap
  </summary> *)
[<AutoSerializable(true)>]
module FixedRateBondHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_fixedRateBond", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_fixedRateBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).FixedRateBond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBond>) l

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".FixedRateBond") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="coupons",Description = "Reference to coupons")>] 
         coupons : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Reference to exCouponPeriod")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Reference to exCouponCalendar")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "Reference to exCouponConvention")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "Reference to exCouponEndOfMonth")>] 
         exCouponEndOfMonth : obj)
        ([<ExcelArgument(Name="useCleanPrice",Description = "Reference to useCleanPrice")>] 
         useCleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toHandle<Quote> price "price" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _coupons = Helper.toCell<Generic.List<double>> coupons "coupons" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _redemption = Helper.toDefault<double> redemption "redemption" 100.0
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _useCleanPrice = Helper.toDefault<bool> useCleanPrice "useCleanPrice" true
                let builder () = withMnemonic mnemonic (Fun.FixedRateBondHelper 
                                                            _price.cell 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _coupons.cell 
                                                            _dayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _useCleanPrice.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FixedRateBondHelper>) l

                let source = Helper.sourceFold "Fun.FixedRateBondHelper" 
                                               [| _price.source
                                               ;  _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _coupons.source
                                               ;  _dayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _useCleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _coupons.cell
                                ;  _dayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _useCleanPrice.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_bond", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).Bond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".Bond") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_impliedQuote", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".ImpliedQuote") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        RateHelper interface
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_setTermStructure", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FixedRateBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".SetTermStructure") 
                                               [| _FixedRateBondHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_useCleanPrice", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_useCleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).UseCleanPrice
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".UseCleanPrice") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_earliestDate", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".EarliestDate") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        The latest date at which discounts are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_latestDate", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".LatestDate") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        ! The latest date at which data are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_latestRelevantDate", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".LatestRelevantDate") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        ! instrument's maturity date
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_maturityDate", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".MaturityDate") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        ! pillar date
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_pillarDate", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".PillarDate") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
        ! BootstrapHelper interface
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_quote", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".Quote") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBondHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FixedRateBondHelper_quoteError", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".QuoteError") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_quoteIsValid", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".QuoteIsValid") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_quoteValue", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".QuoteValue") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_registerWith", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedRateBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".RegisterWith") 
                                               [| _FixedRateBondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_unregisterWith", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FixedRateBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".UnregisterWith") 
                                               [| _FixedRateBondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_update", Description="Create a FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBondHelper",Description = "Reference to FixedRateBondHelper")>] 
         fixedratebondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBondHelper = Helper.toCell<FixedRateBondHelper> fixedratebondhelper "FixedRateBondHelper"  
                let builder () = withMnemonic mnemonic ((FixedRateBondHelperModel.Cast _FixedRateBondHelper.cell).Update
                                                       ) :> ICell
                let format (o : FixedRateBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FixedRateBondHelper.source + ".Update") 
                                               [| _FixedRateBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FixedRateBondHelper.cell
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
    [<ExcelFunction(Name="_FixedRateBondHelper_Range", Description="Create a range of FixedRateBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FixedRateBondHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FixedRateBondHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FixedRateBondHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FixedRateBondHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FixedRateBondHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FixedRateBondHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
