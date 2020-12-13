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
    [<ExcelFunction(Name="_BMASwapRateHelper", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="liborFraction",Description = "Quote")>] 
         liborFraction : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="bmaPeriod",Description = "Period")>] 
         bmaPeriod : obj)
        ([<ExcelArgument(Name="bmaConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         bmaConvention : obj)
        ([<ExcelArgument(Name="bmaDayCount",Description = "DayCounter")>] 
         bmaDayCount : obj)
        ([<ExcelArgument(Name="bmaIndex",Description = "BMAIndex")>] 
         bmaIndex : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _liborFraction = Helper.toHandle<Quote> liborFraction "liborFraction" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _bmaPeriod = Helper.toCell<Period> bmaPeriod "bmaPeriod" 
                let _bmaConvention = Helper.toCell<BusinessDayConvention> bmaConvention "bmaConvention" 
                let _bmaDayCount = Helper.toCell<DayCounter> bmaDayCount "bmaDayCount" 
                let _bmaIndex = Helper.toCell<BMAIndex> bmaIndex "bmaIndex" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BMASwapRateHelper 
                                                            _liborFraction.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _bmaPeriod.cell 
                                                            _bmaConvention.cell 
                                                            _bmaDayCount.cell 
                                                            _bmaIndex.cell 
                                                            _iborIndex.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BMASwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.BMASwapRateHelper" 
                                               [| _liborFraction.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _calendar.source
                                               ;  _bmaPeriod.source
                                               ;  _bmaConvention.source
                                               ;  _bmaDayCount.source
                                               ;  _bmaIndex.source
                                               ;  _iborIndex.source
                                               ;  _evaluationDate.source
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
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMASwapRateHelper> format
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
    [<ExcelFunction(Name="_BMASwapRateHelper_impliedQuote", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".ImpliedQuote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_setTermStructure", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".SetTermStructure") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
                                ;  _t.cell
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
        ! Observer interface
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_update", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_earliestDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".EarliestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        The latest date at which discounts are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_latestDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".LatestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        ! The latest date at which data are needed by the helper in order to provide a quote. It does not necessarily equal the maturity of the underlying instrument.
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_latestRelevantDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".LatestRelevantDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        ! instrument's maturity date
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_maturityDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        ! pillar date
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_pillarDate", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".PillarDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
        ! BootstrapHelper interface
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_quote", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".Quote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMASwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteError", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteIsValid", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteIsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_quoteValue", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".QuoteValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_registerWith", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_unregisterWith", Description="Create a BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMASwapRateHelper",Description = "BMASwapRateHelper")>] 
         bmaswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMASwapRateHelper = Helper.toCell<BMASwapRateHelper> bmaswapratehelper "BMASwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMASwapRateHelperModel.Cast _BMASwapRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMASwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMASwapRateHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMASwapRateHelper.cell
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
    [<ExcelFunction(Name="_BMASwapRateHelper_Range", Description="Create a range of BMASwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMASwapRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BMASwapRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BMASwapRateHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<BMASwapRateHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BMASwapRateHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
