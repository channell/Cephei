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
  fwdFx = spotFx + fwdPoint isFxBaseCurrencyCollateralCurrency indicates if the base currency of the fx currency pair is the one used as collateral
  </summary> *)
[<AutoSerializable(true)>]
module FxSwapRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FxSwapRateHelper_businessDayConvention", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".BusinessDayConvention") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_calendar", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".Calendar") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FxSwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FxSwapRateHelper_endOfMonth", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "FxSwapRateHelper")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".EndOfMonth") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_fixingDays", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "FxSwapRateHelper")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".FixingDays") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FxSwapRateHelper")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="fwdPoint",Description = "Quote")>] 
         fwdPoint : obj)
        ([<ExcelArgument(Name="spotFx",Description = "Quote")>] 
         spotFx : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="isFxBaseCurrencyCollateralCurrency",Description = "bool")>] 
         isFxBaseCurrencyCollateralCurrency : obj)
        ([<ExcelArgument(Name="coll",Description = "YieldTermStructure")>] 
         coll : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _fwdPoint = Helper.toHandle<Quote> fwdPoint "fwdPoint" 
                let _spotFx = Helper.toHandle<Quote> spotFx "spotFx" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _isFxBaseCurrencyCollateralCurrency = Helper.toCell<bool> isFxBaseCurrencyCollateralCurrency "isFxBaseCurrencyCollateralCurrency" 
                let _coll = Helper.toHandle<YieldTermStructure> coll "coll" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FxSwapRateHelper 
                                                            _fwdPoint.cell 
                                                            _spotFx.cell 
                                                            _tenor.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _isFxBaseCurrencyCollateralCurrency.cell 
                                                            _coll.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FxSwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.FxSwapRateHelper" 
                                               [| _fwdPoint.source
                                               ;  _spotFx.source
                                               ;  _tenor.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _isFxBaseCurrencyCollateralCurrency.source
                                               ;  _coll.source
                                               |]
                let hash = Helper.hashFold 
                                [| _fwdPoint.cell
                                ;  _spotFx.cell
                                ;  _tenor.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _isFxBaseCurrencyCollateralCurrency.cell
                                ;  _coll.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FxSwapRateHelper> format
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
    [<ExcelFunction(Name="_FxSwapRateHelper_impliedQuote", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".ImpliedQuote") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_isFxBaseCurrencyCollateralCurrency", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_isFxBaseCurrencyCollateralCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).IsFxBaseCurrencyCollateralCurrency
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".IsFxBaseCurrencyCollateralCurrency") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_setTermStructure", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FxSwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".SetTermStructure") 
                                               [| _FxSwapRateHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
        FxSwapRateHelper inspectors
    *)
    [<ExcelFunction(Name="_FxSwapRateHelper_spot", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_spot
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).Spot
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".Spot") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_tenor", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".Tenor") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FxSwapRateHelper> format
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
    [<ExcelFunction(Name="_FxSwapRateHelper_update", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : FxSwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".Update") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_earliestDate", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".EarliestDate") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_latestDate", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".LatestDate") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_latestRelevantDate", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".LatestRelevantDate") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_maturityDate", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".MaturityDate") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_pillarDate", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".PillarDate") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_quote", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".Quote") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FxSwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FxSwapRateHelper_quoteError", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".QuoteError") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_quoteIsValid", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".QuoteIsValid") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_quoteValue", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".QuoteValue") 
                                               [| _FxSwapRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_registerWith", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FxSwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".RegisterWith") 
                                               [| _FxSwapRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_unregisterWith", Description="Create a FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FxSwapRateHelper",Description = "FxSwapRateHelper")>] 
         fxswapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FxSwapRateHelper = Helper.toCell<FxSwapRateHelper> fxswapratehelper "FxSwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FxSwapRateHelperModel.Cast _FxSwapRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FxSwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FxSwapRateHelper.source + ".UnregisterWith") 
                                               [| _FxSwapRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FxSwapRateHelper.cell
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
    [<ExcelFunction(Name="_FxSwapRateHelper_Range", Description="Create a range of FxSwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FxSwapRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FxSwapRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FxSwapRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FxSwapRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FxSwapRateHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
