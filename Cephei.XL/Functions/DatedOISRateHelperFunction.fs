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
  Rate helper for bootstrapping over Overnight Indexed Swap rates
  </summary> *)
[<AutoSerializable(true)>]
module DatedOISRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DatedOISRateHelper", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="overnightIndex",Description = "Reference to overnightIndex")>] 
         overnightIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _startDate = Helper.toCell<Date> startDate "startDate" true
                let _endDate = Helper.toCell<Date> endDate "endDate" true
                let _fixedRate = Helper.toHandle<Quote> fixedRate "fixedRate" 
                let _overnightIndex = Helper.toCell<OvernightIndex> overnightIndex "overnightIndex" true
                let builder () = withMnemonic mnemonic (Fun.DatedOISRateHelper 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixedRate.cell 
                                                            _overnightIndex.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DatedOISRateHelper>) l

                let source = Helper.sourceFold "Fun.DatedOISRateHelper" 
                                               [| _startDate.source
                                               ;  _endDate.source
                                               ;  _fixedRate.source
                                               ;  _overnightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _startDate.cell
                                ;  _endDate.cell
                                ;  _fixedRate.cell
                                ;  _overnightIndex.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_impliedQuote", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".ImpliedQuote") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_setTermStructure", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let _t = Helper.toCell<YieldTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DatedOISRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".SetTermStructure") 
                                               [| _DatedOISRateHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_DatedOISRateHelper_earliestDate", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".EarliestDate") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_latestDate", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".LatestDate") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_latestRelevantDate", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".LatestRelevantDate") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_maturityDate", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".MaturityDate") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_pillarDate", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".PillarDate") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_quote", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".Quote") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_quoteError", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".QuoteError") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_quoteIsValid", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".QuoteIsValid") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_quoteValue", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".QuoteValue") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_registerWith", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DatedOISRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".RegisterWith") 
                                               [| _DatedOISRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_unregisterWith", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DatedOISRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".UnregisterWith") 
                                               [| _DatedOISRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_update", Description="Create a DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DatedOISRateHelper",Description = "Reference to DatedOISRateHelper")>] 
         datedoisratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DatedOISRateHelper = Helper.toCell<DatedOISRateHelper> datedoisratehelper "DatedOISRateHelper" true 
                let builder () = withMnemonic mnemonic ((_DatedOISRateHelper.cell :?> DatedOISRateHelperModel).Update
                                                       ) :> ICell
                let format (o : DatedOISRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DatedOISRateHelper.source + ".Update") 
                                               [| _DatedOISRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DatedOISRateHelper.cell
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
    [<ExcelFunction(Name="_DatedOISRateHelper_Range", Description="Create a range of DatedOISRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DatedOISRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DatedOISRateHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DatedOISRateHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DatedOISRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DatedOISRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DatedOISRateHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
