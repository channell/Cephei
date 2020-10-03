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
  Rate helper for bootstrapping over basis swap spreads Assumes that you have, at a minimum, either: - shortIndex with attached YieldTermStructure - longIndex with attached YieldTermStructure - Discount curve linked to discount swap engine The other leg is then solved for i.e. index curve (if no YieldTermStructure is attached to its index). The settlement date of the spot is assumed to be equal to the settlement date of the swap itself. termstructures
  </summary> *)
[<AutoSerializable(true)>]
module BasisSwapHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwapHelper", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="spreadQuote",Description = "Reference to spreadQuote")>] 
         spreadQuote : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="settlementCalendar",Description = "Reference to settlementCalendar")>] 
         settlementCalendar : obj)
        ([<ExcelArgument(Name="rollConvention",Description = "Reference to rollConvention")>] 
         rollConvention : obj)
        ([<ExcelArgument(Name="shortIndex",Description = "Reference to shortIndex")>] 
         shortIndex : obj)
        ([<ExcelArgument(Name="longIndex",Description = "Reference to longIndex")>] 
         longIndex : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        ([<ExcelArgument(Name="eom",Description = "Reference to eom")>] 
         eom : obj)
        ([<ExcelArgument(Name="spreadOnShort",Description = "Reference to spreadOnShort")>] 
         spreadOnShort : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _spreadQuote = Helper.toHandle<Quote> spreadQuote "spreadQuote" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _settlementCalendar = Helper.toCell<Calendar> settlementCalendar "settlementCalendar" 
                let _rollConvention = Helper.toCell<BusinessDayConvention> rollConvention "rollConvention" 
                let _shortIndex = Helper.toCell<IborIndex> shortIndex "shortIndex" 
                let _longIndex = Helper.toCell<IborIndex> longIndex "longIndex" 
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _eom = Helper.toDefault<bool> eom "eom" true
                let _spreadOnShort = Helper.toDefault<bool> spreadOnShort "spreadOnShort" true
                let builder () = withMnemonic mnemonic (Fun.BasisSwapHelper 
                                                            _spreadQuote.cell 
                                                            _settlementDays.cell 
                                                            _swapTenor.cell 
                                                            _settlementCalendar.cell 
                                                            _rollConvention.cell 
                                                            _shortIndex.cell 
                                                            _longIndex.cell 
                                                            _discount.cell 
                                                            _eom.cell 
                                                            _spreadOnShort.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasisSwapHelper>) l

                let source = Helper.sourceFold "Fun.BasisSwapHelper" 
                                               [| _spreadQuote.source
                                               ;  _settlementDays.source
                                               ;  _swapTenor.source
                                               ;  _settlementCalendar.source
                                               ;  _rollConvention.source
                                               ;  _shortIndex.source
                                               ;  _longIndex.source
                                               ;  _discount.source
                                               ;  _eom.source
                                               ;  _spreadOnShort.source
                                               |]
                let hash = Helper.hashFold 
                                [| _spreadQuote.cell
                                ;  _settlementDays.cell
                                ;  _swapTenor.cell
                                ;  _settlementCalendar.cell
                                ;  _rollConvention.cell
                                ;  _shortIndex.cell
                                ;  _longIndex.cell
                                ;  _discount.cell
                                ;  _eom.cell
                                ;  _spreadOnShort.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwapHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \name RateHelper interface
@{
    *)
    [<ExcelFunction(Name="_BasisSwapHelper_impliedQuote", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".ImpliedQuote") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_setTermStructure", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BasisSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".SetTermStructure") 
                                               [| _BasisSwapHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
        @} ! \name inspectors
@{
    *)
    [<ExcelFunction(Name="_BasisSwapHelper_swap", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).Swap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BasisSwap>) l

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".Swap") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwapHelper> format
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
    [<ExcelFunction(Name="_BasisSwapHelper_update", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).Update
                                                       ) :> ICell
                let format (o : BasisSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".Update") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_earliestDate", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".EarliestDate") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_latestDate", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".LatestDate") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_latestRelevantDate", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".LatestRelevantDate") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_maturityDate", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".MaturityDate") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_pillarDate", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".PillarDate") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_quote", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".Quote") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BasisSwapHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BasisSwapHelper_quoteError", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".QuoteError") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_quoteIsValid", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".QuoteIsValid") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_quoteValue", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".QuoteValue") 
                                               [| _BasisSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_registerWith", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BasisSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".RegisterWith") 
                                               [| _BasisSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_unregisterWith", Description="Create a BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BasisSwapHelper",Description = "Reference to BasisSwapHelper")>] 
         basisswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BasisSwapHelper = Helper.toCell<BasisSwapHelper> basisswaphelper "BasisSwapHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((BasisSwapHelperModel.Cast _BasisSwapHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BasisSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BasisSwapHelper.source + ".UnregisterWith") 
                                               [| _BasisSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BasisSwapHelper.cell
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
    [<ExcelFunction(Name="_BasisSwapHelper_Range", Description="Create a range of BasisSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BasisSwapHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BasisSwapHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BasisSwapHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BasisSwapHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BasisSwapHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BasisSwapHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
