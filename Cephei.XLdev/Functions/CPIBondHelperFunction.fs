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
  CPI bond helper for curve bootstrap
  </summary> *)
[<AutoSerializable(true)>]
module CPIBondHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPIBondHelper_cpiBond", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_cpiBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).CpiBond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPIBond>) l

                let source = Helper.sourceFold (_CPIBondHelper.source + ".CpiBond") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "Reference to growthOnly")>] 
         growthOnly : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "Reference to baseCPI")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="cpiIndex",Description = "Reference to cpiIndex")>] 
         cpiIndex : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "Reference to observationInterpolation")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
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

                let _price = Helper.toHandle<Handle<Quote>> price "price" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" true
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" true
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" true
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" true
                let _cpiIndex = Helper.toCell<ZeroInflationIndex> cpiIndex "cpiIndex" true
                let _observationInterpolation = Helper.toCell<InterpolationType> observationInterpolation "observationInterpolation" true
                let _schedule = Helper.toCell<Schedule> schedule "schedule" true
                let _fixedRate = Helper.toCell<Generic.List<double>> fixedRate "fixedRate" true
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _paymentCalendar = Helper.toCell<Calendar> paymentCalendar "paymentCalendar" true
                let _exCouponPeriod = Helper.toCell<Period> exCouponPeriod "exCouponPeriod" true
                let _exCouponCalendar = Helper.toCell<Calendar> exCouponCalendar "exCouponCalendar" true
                let _exCouponConvention = Helper.toCell<BusinessDayConvention> exCouponConvention "exCouponConvention" true
                let _exCouponEndOfMonth = Helper.toCell<bool> exCouponEndOfMonth "exCouponEndOfMonth" true
                let _useCleanPrice = Helper.toCell<bool> useCleanPrice "useCleanPrice" true
                let builder () = withMnemonic mnemonic (Fun.CPIBondHelper 
                                                            _price.cell 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _growthOnly.cell 
                                                            _baseCPI.cell 
                                                            _observationLag.cell 
                                                            _cpiIndex.cell 
                                                            _observationInterpolation.cell 
                                                            _schedule.cell 
                                                            _fixedRate.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _useCleanPrice.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPIBondHelper>) l

                let source = Helper.sourceFold "Fun.CPIBondHelper" 
                                               [| _price.source
                                               ;  _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _growthOnly.source
                                               ;  _baseCPI.source
                                               ;  _observationLag.source
                                               ;  _cpiIndex.source
                                               ;  _observationInterpolation.source
                                               ;  _schedule.source
                                               ;  _fixedRate.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
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
                                ;  _growthOnly.cell
                                ;  _baseCPI.cell
                                ;  _observationLag.cell
                                ;  _cpiIndex.cell
                                ;  _observationInterpolation.cell
                                ;  _schedule.cell
                                ;  _fixedRate.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_bond", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).Bond
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold (_CPIBondHelper.source + ".Bond") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_impliedQuote", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".ImpliedQuote") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_setTermStructure", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let _t = Helper.toCell<YieldTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : CPIBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".SetTermStructure") 
                                               [| _CPIBondHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_useCleanPrice", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_useCleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).UseCleanPrice
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".UseCleanPrice") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_earliestDate", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".EarliestDate") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_latestDate", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".LatestDate") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_latestRelevantDate", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".LatestRelevantDate") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_maturityDate", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".MaturityDate") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_pillarDate", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".PillarDate") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_quote", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_CPIBondHelper.source + ".Quote") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_quoteError", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".QuoteError") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_quoteIsValid", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".QuoteIsValid") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_quoteValue", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".QuoteValue") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_registerWith", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPIBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".RegisterWith") 
                                               [| _CPIBondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_unregisterWith", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CPIBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".UnregisterWith") 
                                               [| _CPIBondHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_update", Description="Create a CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBondHelper",Description = "Reference to CPIBondHelper")>] 
         cpibondhelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBondHelper = Helper.toCell<CPIBondHelper> cpibondhelper "CPIBondHelper" true 
                let builder () = withMnemonic mnemonic ((_CPIBondHelper.cell :?> CPIBondHelperModel).Update
                                                       ) :> ICell
                let format (o : CPIBondHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBondHelper.source + ".Update") 
                                               [| _CPIBondHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBondHelper.cell
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
    [<ExcelFunction(Name="_CPIBondHelper_Range", Description="Create a range of CPIBondHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBondHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CPIBondHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPIBondHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPIBondHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPIBondHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CPIBondHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
