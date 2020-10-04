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
  Zero-coupon inflation-swap bootstrap helper
  </summary> *)
[<AutoSerializable(true)>]
module ZeroCouponInflationSwapHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_impliedQuote", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".ImpliedQuote") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_setTermStructure", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        ([<ExcelArgument(Name="z",Description = "Reference to z")>] 
         z : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let _z = Helper.toCell<ZeroInflationTermStructure> z "z" 
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).SetTermStructure
                                                            _z.cell 
                                                       ) :> ICell
                let format (o : ZeroCouponInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".SetTermStructure") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               ;  _z.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
                                ;  _z.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_create
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
        ([<ExcelArgument(Name="zii",Description = "Reference to zii")>] 
         zii : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quote = Helper.toHandle<Quote> quote "quote" 
                let _swapObsLag = Helper.toCell<Period> swapObsLag "swapObsLag" 
                let _maturity = Helper.toCell<Date> maturity "maturity" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _zii = Helper.toCell<ZeroInflationIndex> zii "zii" 
                let builder () = withMnemonic mnemonic (Fun.ZeroCouponInflationSwapHelper 
                                                            _quote.cell 
                                                            _swapObsLag.cell 
                                                            _maturity.cell 
                                                            _calendar.cell 
                                                            _paymentConvention.cell 
                                                            _dayCounter.cell 
                                                            _zii.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroCouponInflationSwapHelper>) l

                let source = Helper.sourceFold "Fun.ZeroCouponInflationSwapHelper" 
                                               [| _quote.source
                                               ;  _swapObsLag.source
                                               ;  _maturity.source
                                               ;  _calendar.source
                                               ;  _paymentConvention.source
                                               ;  _dayCounter.source
                                               ;  _zii.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quote.cell
                                ;  _swapObsLag.cell
                                ;  _maturity.cell
                                ;  _calendar.cell
                                ;  _paymentConvention.cell
                                ;  _dayCounter.cell
                                ;  _zii.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroCouponInflationSwapHelper> format
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_earliestDate", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".EarliestDate") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_latestDate", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".LatestDate") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_latestRelevantDate", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".LatestRelevantDate") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_maturityDate", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".MaturityDate") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_pillarDate", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".PillarDate") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_quote", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".Quote") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroCouponInflationSwapHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_quoteError", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".QuoteError") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_quoteIsValid", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".QuoteIsValid") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_quoteValue", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".QuoteValue") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_registerWith", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroCouponInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".RegisterWith") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_unregisterWith", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroCouponInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".UnregisterWith") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_update", Description="Create a ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroCouponInflationSwapHelper",Description = "Reference to ZeroCouponInflationSwapHelper")>] 
         zerocouponinflationswaphelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroCouponInflationSwapHelper = Helper.toCell<ZeroCouponInflationSwapHelper> zerocouponinflationswaphelper "ZeroCouponInflationSwapHelper"  
                let builder () = withMnemonic mnemonic ((ZeroCouponInflationSwapHelperModel.Cast _ZeroCouponInflationSwapHelper.cell).Update
                                                       ) :> ICell
                let format (o : ZeroCouponInflationSwapHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroCouponInflationSwapHelper.source + ".Update") 
                                               [| _ZeroCouponInflationSwapHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroCouponInflationSwapHelper.cell
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
    [<ExcelFunction(Name="_ZeroCouponInflationSwapHelper_Range", Description="Create a range of ZeroCouponInflationSwapHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroCouponInflationSwapHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroCouponInflationSwapHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroCouponInflationSwapHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroCouponInflationSwapHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroCouponInflationSwapHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroCouponInflationSwapHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
