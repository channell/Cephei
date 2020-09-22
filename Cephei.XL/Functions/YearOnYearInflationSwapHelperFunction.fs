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
  Year-on-year inflation-swap bootstrap helper
  </summary> *)
[<AutoSerializable(true)>]
module YearOnYearInflationSwapHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_impliedQuote", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".ImpliedQuote") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_setTermStructure", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let _y = Helper.toCell<YoYInflationTermStructure> y "y" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).SetTermStructure
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".SetTermStructure") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quote",Description = "Reference to quote")>] 
         quote : obj)
        ([<ExcelArgument(Name="swapObsLag",Description = "Reference to swapObsLag")>] 
         swapObsLag : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="yii",Description = "Reference to yii")>] 
         yii : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toHandle<Quote> quote "quote" 
                let _swapObsLag = Helper.toCell<Period> swapObsLag "swapObsLag" true
                let _maturity = Helper.toCell<Date> maturity "maturity" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _yii = Helper.toCell<YoYInflationIndex> yii "yii" true
                let builder () = withMnemonic mnemonic (Fun.YearOnYearInflationSwapHelper 
                                                            _quote.cell 
                                                            _swapObsLag.cell 
                                                            _maturity.cell 
                                                            _calendar.cell 
                                                            _paymentConvention.cell 
                                                            _dayCounter.cell 
                                                            _yii.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YearOnYearInflationSwapHelper>) l

                let source = Helper.sourceFold "Fun.YearOnYearInflationSwapHelper" 
                                               [| _quote.source
                                               ;  _swapObsLag.source
                                               ;  _maturity.source
                                               ;  _calendar.source
                                               ;  _paymentConvention.source
                                               ;  _dayCounter.source
                                               ;  _yii.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
                                ;  _swapObsLag.cell
                                ;  _maturity.cell
                                ;  _calendar.cell
                                ;  _paymentConvention.cell
                                ;  _dayCounter.cell
                                ;  _yii.cell
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
        earliest relevant date The earliest date at which discounts are needed by the helper in order to provide a quote.
    *)
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_earliestDate", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".EarliestDate") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_latestDate", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".LatestDate") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_latestRelevantDate", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".LatestRelevantDate") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_maturityDate", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".MaturityDate") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_pillarDate", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".PillarDate") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_quote", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".Quote") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_quoteError", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".QuoteError") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_quoteIsValid", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".QuoteIsValid") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_quoteValue", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".QuoteValue") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_registerWith", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".RegisterWith") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_unregisterWith", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".UnregisterWith") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_update", Description="Create a YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YearOnYearInflationSwapHelper",Description = "Reference to YearOnYearInflationSwapHelper")>] 
         yearonyearinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YearOnYearInflationSwapHelper = Helper.toCell<YearOnYearInflationSwapHelper> yearonyearinflationswaphelper "YearOnYearInflationSwapHelper" true 
                let builder () = withMnemonic mnemonic ((_YearOnYearInflationSwapHelper.cell :?> YearOnYearInflationSwapHelperModel).Update
                                                       ) :> ICell
                let format (o : YearOnYearInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YearOnYearInflationSwapHelper.source + ".Update") 
                                               [| _YearOnYearInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YearOnYearInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_YearOnYearInflationSwapHelper_Range", Description="Create a range of YearOnYearInflationSwapHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YearOnYearInflationSwapHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YearOnYearInflationSwapHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YearOnYearInflationSwapHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YearOnYearInflationSwapHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YearOnYearInflationSwapHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YearOnYearInflationSwapHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
