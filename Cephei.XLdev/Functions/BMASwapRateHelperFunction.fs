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
  Rate helper for bootstrapping over BMA swap rates
  </summary> *)
[<AutoSerializable(true)>]
module BMASwapRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="liborFraction",Description = "Reference to liborFraction")>] 
         liborFraction : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bmaPeriod",Description = "Reference to bmaPeriod")>] 
         bmaPeriod : obj)
        ([<ExcelArgument(Name="bmaConvention",Description = "Reference to bmaConvention")>] 
         bmaConvention : obj)
        ([<ExcelArgument(Name="bmaDayCount",Description = "Reference to bmaDayCount")>] 
         bmaDayCount : obj)
        ([<ExcelArgument(Name="bmaIndex",Description = "Reference to bmaIndex")>] 
         bmaIndex : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _liborFraction = Helper.toHandle<Handle<Quote>> liborFraction "liborFraction" 
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _bmaPeriod = Helper.toCell<Period> bmaPeriod "bmaPeriod" true
                let _bmaConvention = Helper.toCell<BusinessDayConvention> bmaConvention "bmaConvention" true
                let _bmaDayCount = Helper.toCell<DayCounter> bmaDayCount "bmaDayCount" true
                let _bmaIndex = Helper.toCell<BMAIndex> bmaIndex "bmaIndex" true
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" true
                let builder () = withMnemonic mnemonic (Fun.BMASwapRateHelper 
                                                            _liborFraction.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bmaPeriod.cell 
                                                            _bmaConvention.cell 
                                                            _bmaDayCount.cell 
                                                            _bmaIndex.cell 
                                                            _iborIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BMASwapRateHelper>) l

                let source = Helper.sourceFold "Fun.BMASwapRateHelper" 
                                               [| _liborFraction.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bmaPeriod.source
                                               ;  _bmaConvention.source
                                               ;  _bmaDayCount.source
                                               ;  _bmaIndex.source
                                               ;  _iborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _liborFraction.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _calendar.cell
                                ;  _bmaPeriod.cell
                                ;  _bmaConvention.cell
                                ;  _bmaDayCount.cell
                                ;  _bmaIndex.cell
                                ;  _iborIndex.cell
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
        RateHelper interface
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_impliedQuote", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".ImpliedQuote") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_setTermStructure", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let _t = Helper.toCell<YieldTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".SetTermStructure") 
                                               [| _BMASwapRateHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        ! Observer interface
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_update", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).Update
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".Update") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_earliestDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".EarliestDate") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_latestDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".LatestDate") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_latestRelevantDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".LatestRelevantDate") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_maturityDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".MaturityDate") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_pillarDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".PillarDate") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quote", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".Quote") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteError", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteError") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteIsValid", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteIsValid") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteValue", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteValue") 
                                               [| _BMASwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_registerWith", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".RegisterWith") 
                                               [| _BMASwapRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_unregisterWith", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "Reference to BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BMASwapRateHelper.cell :?> BMASwapRateHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BMASwapRateHelper.source + ".UnregisterWith") 
                                               [| _BMASwapRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_Range", Description="Create a range of BMASwapRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BMASwapRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BMASwapRateHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BMASwapRateHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BMASwapRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BMASwapRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BMASwapRateHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
