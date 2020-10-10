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
  Rate helper for bootstrapping over interest-rate futures prices
  </summary> *)
[<AutoSerializable(true)>]
module FuturesRateHelperFunction =

    (*
        ! FuturesRateHelper inspectors
    *)
    [<ExcelFunction(Name="_FuturesRateHelper_convexityAdjustment", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_convexityAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).ConvexityAdjustment
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".ConvexityAdjustment") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper1", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="convAdj",Description = "Reference to convAdj")>] 
         convAdj : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<double> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let _convAdj = Helper.toDefault<double> convAdj "convAdj" 0.0
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper1 
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _i.cell 
                                                            _convAdj.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper1" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _i.source
                                               ;  _convAdj.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _i.cell
                                ;  _convAdj.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper2", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="convAdj",Description = "Reference to convAdj")>] 
         convAdj : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toHandle<Quote> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let _convAdj = Helper.toHandle<Quote> convAdj "convAdj" 
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper2
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _i.cell 
                                                            _convAdj.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper2" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _i.source
                                               ;  _convAdj.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _i.cell
                                ;  _convAdj.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper3", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="iborEndDate",Description = "Reference to iborEndDate")>] 
         iborEndDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="convAdj",Description = "Reference to convAdj")>] 
         convAdj : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<double> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _iborEndDate = Helper.toCell<Date> iborEndDate "iborEndDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _convAdj = Helper.toDefault<double> convAdj "convAdj" 0.0
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper3
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _iborEndDate.cell 
                                                            _dayCounter.cell 
                                                            _convAdj.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper3" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _iborEndDate.source
                                               ;  _dayCounter.source
                                               ;  _convAdj.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _iborEndDate.cell
                                ;  _dayCounter.cell
                                ;  _convAdj.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper4", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="iborEndDate",Description = "Reference to iborEndDate")>] 
         iborEndDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="convAdj",Description = "Reference to convAdj")>] 
         convAdj : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toHandle<Quote> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _iborEndDate = Helper.toCell<Date> iborEndDate "iborEndDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _convAdj = Helper.toHandle<Quote> convAdj "convAdj" 
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper4
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _iborEndDate.cell 
                                                            _dayCounter.cell 
                                                            _convAdj.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper4" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _iborEndDate.source
                                               ;  _dayCounter.source
                                               ;  _convAdj.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _iborEndDate.cell
                                ;  _dayCounter.cell
                                ;  _convAdj.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper5", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "Reference to lengthInMonths")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="convexityAdjustment",Description = "Reference to convexityAdjustment")>] 
         convexityAdjustment : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toCell<double> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _convexityAdjustment = Helper.toDefault<double> convexityAdjustment "convexityAdjustment" 0.0
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper5 
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _lengthInMonths.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _convexityAdjustment.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper5" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _lengthInMonths.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _convexityAdjustment.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _lengthInMonths.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _convexityAdjustment.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="price",Description = "Reference to price")>] 
         price : obj)
        ([<ExcelArgument(Name="iborStartDate",Description = "Reference to iborStartDate")>] 
         iborStartDate : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "Reference to lengthInMonths")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="convAdj",Description = "Reference to convAdj")>] 
         convAdj : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _price = Helper.toHandle<Quote> price "price" 
                let _iborStartDate = Helper.toCell<Date> iborStartDate "iborStartDate" 
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _convAdj = Helper.toHandle<Quote> convAdj "convAdj" 
                let _Type = Helper.toCell<Futures.Type> Type "Type" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FuturesRateHelper
                                                            _price.cell 
                                                            _iborStartDate.cell 
                                                            _lengthInMonths.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _convAdj.cell 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FuturesRateHelper>) l

                let source () = Helper.sourceFold "Fun.FuturesRateHelper" 
                                               [| _price.source
                                               ;  _iborStartDate.source
                                               ;  _lengthInMonths.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _convAdj.source
                                               ;  _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _price.cell
                                ;  _iborStartDate.cell
                                ;  _lengthInMonths.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _convAdj.cell
                                ;  _Type.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! RateHelper interface
    *)
    [<ExcelFunction(Name="_FuturesRateHelper_impliedQuote", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".ImpliedQuote") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_earliestDate", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".EarliestDate") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_latestDate", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".LatestDate") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_latestRelevantDate", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".LatestRelevantDate") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_maturityDate", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".MaturityDate") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_pillarDate", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".PillarDate") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_quote", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".Quote") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FuturesRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper_quoteError", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".QuoteError") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_quoteIsValid", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".QuoteIsValid") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_quoteValue", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".QuoteValue") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_registerWith", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FuturesRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".RegisterWith") 
                                               [| _FuturesRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
        ! \warning Being a pointer and not a shared_ptr, the term structure is not guaranteed to remain allocated for the whole life of the rate helper. It is responsibility of the programmer to ensure that the pointer remains valid. It is advised that this method is called only inside the term structure being bootstrapped, setting the pointer to <b>this</b>, i.e., the term structure itself.
    *)
    (*generiuc 
    [<ExcelFunction(Name="_FuturesRateHelper_setTermStructure", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let _ts = Helper.toCell<'TS> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).SetTermStructure
                                                            _ts.cell 
                                                       ) :> ICell
                let format (o : FuturesRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".SetTermStructure") 
                                               [| _FuturesRateHelper.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
                                ;  _ts.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_FuturesRateHelper_unregisterWith", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FuturesRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".UnregisterWith") 
                                               [| _FuturesRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_update", Description="Create a FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FuturesRateHelper",Description = "Reference to FuturesRateHelper")>] 
         futuresratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FuturesRateHelper = Helper.toCell<FuturesRateHelper> futuresratehelper "FuturesRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((FuturesRateHelperModel.Cast _FuturesRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : FuturesRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FuturesRateHelper.source + ".Update") 
                                               [| _FuturesRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FuturesRateHelper.cell
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
    [<ExcelFunction(Name="_FuturesRateHelper_Range", Description="Create a range of FuturesRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FuturesRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FuturesRateHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FuturesRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FuturesRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FuturesRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FuturesRateHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
