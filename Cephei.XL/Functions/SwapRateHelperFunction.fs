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
Rate helper for bootstrapping over swap rates
  </summary> *)
[<AutoSerializable(true)>]
module SwapRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper_forwardStart", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_forwardStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).ForwardStart
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".ForwardStart") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper_impliedQuote", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".ImpliedQuote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_setTermStructure", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : SwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".SetTermStructure") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
        SwapRateHelper inspectors
    *)
    [<ExcelFunction(Name="_SwapRateHelper_spread", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".Spread") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_swap", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).Swap
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VanillaSwap>) l

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".Swap") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper2", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="fixedFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         fixedFrequency : obj)
        ([<ExcelArgument(Name="fixedConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         fixedConvention : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        ([<ExcelArgument(Name="fwdStart",Description = "Period or empty")>] 
         fwdStart : obj)
        ([<ExcelArgument(Name="discount",Description = "YieldTermStructure")>] 
         discount : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _fixedFrequency = Helper.toCell<Frequency> fixedFrequency "fixedFrequency" 
                let _fixedConvention = Helper.toCell<BusinessDayConvention> fixedConvention "fixedConvention" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _fwdStart = Helper.toDefault<Period> fwdStart "fwdStart" null
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _settlementDays = Helper.toNullable<int> settlementDays "settlementDays"
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapRateHelper2 
                                                            _rate.cell 
                                                            _tenor.cell 
                                                            _calendar.cell 
                                                            _fixedFrequency.cell 
                                                            _fixedConvention.cell 
                                                            _fixedDayCount.cell 
                                                            _iborIndex.cell 
                                                            _spread.cell 
                                                            _fwdStart.cell 
                                                            _discount.cell 
                                                            _settlementDays.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.SwapRateHelper2" 
                                               [| _rate.source
                                               ;  _tenor.source
                                               ;  _calendar.source
                                               ;  _fixedFrequency.source
                                               ;  _fixedConvention.source
                                               ;  _fixedDayCount.source
                                               ;  _iborIndex.source
                                               ;  _spread.source
                                               ;  _fwdStart.source
                                               ;  _discount.source
                                               ;  _settlementDays.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _tenor.cell
                                ;  _calendar.cell
                                ;  _fixedFrequency.cell
                                ;  _fixedConvention.cell
                                ;  _fixedDayCount.cell
                                ;  _iborIndex.cell
                                ;  _spread.cell
                                ;  _fwdStart.cell
                                ;  _discount.cell
                                ;  _settlementDays.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="fixedFrequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         fixedFrequency : obj)
        ([<ExcelArgument(Name="fixedConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         fixedConvention : obj)
        ([<ExcelArgument(Name="fixedDayCount",Description = "DayCounter")>] 
         fixedDayCount : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        ([<ExcelArgument(Name="fwdStart",Description = "Period or empty")>] 
         fwdStart : obj)
        ([<ExcelArgument(Name="discount",Description = "YieldTermStructure")>] 
         discount : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _fixedFrequency = Helper.toCell<Frequency> fixedFrequency "fixedFrequency" 
                let _fixedConvention = Helper.toCell<BusinessDayConvention> fixedConvention "fixedConvention" 
                let _fixedDayCount = Helper.toCell<DayCounter> fixedDayCount "fixedDayCount" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _fwdStart = Helper.toDefault<Period> fwdStart "fwdStart" null
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _settlementDays = Helper.toNullable<int> settlementDays "settlementDays"
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapRateHelper
                                                            _rate.cell 
                                                            _tenor.cell 
                                                            _calendar.cell 
                                                            _fixedFrequency.cell 
                                                            _fixedConvention.cell 
                                                            _fixedDayCount.cell 
                                                            _iborIndex.cell 
                                                            _spread.cell 
                                                            _fwdStart.cell 
                                                            _discount.cell 
                                                            _settlementDays.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.SwapRateHelper" 
                                               [| _rate.source
                                               ;  _tenor.source
                                               ;  _calendar.source
                                               ;  _fixedFrequency.source
                                               ;  _fixedConvention.source
                                               ;  _fixedDayCount.source
                                               ;  _iborIndex.source
                                               ;  _spread.source
                                               ;  _fwdStart.source
                                               ;  _discount.source
                                               ;  _settlementDays.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _tenor.cell
                                ;  _calendar.cell
                                ;  _fixedFrequency.cell
                                ;  _fixedConvention.cell
                                ;  _fixedDayCount.cell
                                ;  _iborIndex.cell
                                ;  _spread.cell
                                ;  _fwdStart.cell
                                ;  _discount.cell
                                ;  _settlementDays.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper3", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="swapIndex",Description = "SwapIndex")>] 
         swapIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        ([<ExcelArgument(Name="fwdStart",Description = "Period or empty")>] 
         fwdStart : obj)
        ([<ExcelArgument(Name="discount",Description = "YieldTermStructure")>] 
         discount : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _swapIndex = Helper.toCell<SwapIndex> swapIndex "swapIndex" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _fwdStart = Helper.toDefault<Period> fwdStart "fwdStart" null
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapRateHelper3
                                                            _rate.cell 
                                                            _swapIndex.cell 
                                                            _spread.cell 
                                                            _fwdStart.cell 
                                                            _discount.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.SwapRateHelper3" 
                                               [| _rate.source
                                               ;  _swapIndex.source
                                               ;  _spread.source
                                               ;  _fwdStart.source
                                               ;  _discount.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _swapIndex.cell
                                ;  _spread.cell
                                ;  _fwdStart.cell
                                ;  _discount.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper1", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="swapIndex",Description = "SwapIndex")>] 
         swapIndex : obj)
        ([<ExcelArgument(Name="spread",Description = "Quote")>] 
         spread : obj)
        ([<ExcelArgument(Name="fwdStart",Description = "Period or empty")>] 
         fwdStart : obj)
        ([<ExcelArgument(Name="discount",Description = "YieldTermStructure")>] 
         discount : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _swapIndex = Helper.toCell<SwapIndex> swapIndex "swapIndex" 
                let _spread = Helper.toHandle<Quote> spread "spread" 
                let _fwdStart = Helper.toDefault<Period> fwdStart "fwdStart" null
                let _discount = Helper.toHandle<YieldTermStructure> discount "discount" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapRateHelper1
                                                            _rate.cell 
                                                            _swapIndex.cell 
                                                            _spread.cell 
                                                            _fwdStart.cell 
                                                            _discount.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapRateHelper>) l

                let source () = Helper.sourceFold "Fun.SwapRateHelper1" 
                                               [| _rate.source
                                               ;  _swapIndex.source
                                               ;  _spread.source
                                               ;  _fwdStart.source
                                               ;  _discount.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _swapIndex.cell
                                ;  _spread.cell
                                ;  _fwdStart.cell
                                ;  _discount.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
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
    [<ExcelFunction(Name="_SwapRateHelper_update", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : SwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_earliestDate", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".EarliestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_latestDate", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".LatestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_latestRelevantDate", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".LatestRelevantDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_maturityDate", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_pillarDate", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".PillarDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_quote", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".Quote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapRateHelper_quoteError", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".QuoteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_quoteIsValid", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".QuoteIsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_quoteValue", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".QuoteValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_registerWith", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_unregisterWith", Description="Create a SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapRateHelper",Description = "SwapRateHelper")>] 
         swapratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapRateHelper = Helper.toCell<SwapRateHelper> swapratehelper "SwapRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapRateHelperModel.Cast _SwapRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapRateHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapRateHelper.cell
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
    [<ExcelFunction(Name="_SwapRateHelper_Range", Description="Create a range of SwapRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwapRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<SwapRateHelper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<SwapRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SwapRateHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
