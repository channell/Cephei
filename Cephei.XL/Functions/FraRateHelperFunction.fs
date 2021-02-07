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
  Rate helper for bootstrapping over %FRA rates
  </summary> *)
[<AutoSerializable(true)>]
module FraRateHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper7", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "int")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="monthsToEnd",Description = "int")>] 
         monthsToEnd : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" 
                let _monthsToEnd = Helper.toCell<int> monthsToEnd "monthsToEnd" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper7 
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _monthsToEnd.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper7" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _monthsToEnd.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _monthsToEnd.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Period")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _iborIndex.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _iborIndex.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _iborIndex.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper1", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Period")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "IborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper1
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _iborIndex.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper1" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _iborIndex.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _iborIndex.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper2", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Period")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "int")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" 
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper2
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _lengthInMonths.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper2" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _lengthInMonths.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _lengthInMonths.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper3", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Period")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "int")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" 
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper3
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _lengthInMonths.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper3" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _lengthInMonths.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _lengthInMonths.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper4", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "int")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="i",Description = "IborIndex")>] 
         i : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper4
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _i.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper4" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _i.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _i.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper6", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "int")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="monthsToEnd",Description = "int")>] 
         monthsToEnd : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "int")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" 
                let _monthsToEnd = Helper.toCell<int> monthsToEnd "monthsToEnd" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper6 
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _monthsToEnd.cell 
                                                            _fixingDays.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper6" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _monthsToEnd.source
                                               ;  _fixingDays.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _monthsToEnd.cell
                                ;  _fixingDays.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper5", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Quote")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "int")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="i",Description = "IborIndex")>] 
         i : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Pillar.Choice: MaturityDate, LastRelevantDate, CustomDate or empty")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Date or empty")>] 
         customPillarDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Quote> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" 
                let _i = Helper.toCell<IborIndex> i "i" 
                let _pillarChoice = Helper.toDefault<Pillar.Choice> pillarChoice "pillarChoice" Pillar.Choice.LastRelevantDate
                let _customPillarDate = Helper.toDefault<Date> customPillarDate "customPillarDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FraRateHelper5 
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _i.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source () = Helper.sourceFold "Fun.FraRateHelper5" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _i.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _i.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper_impliedQuote", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".ImpliedQuote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_setTermStructure", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "YieldTermStructure")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let _t = Helper.toCell<YieldTermStructure> t "t" 
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".SetTermStructure") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_update", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).Update
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_earliestDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".EarliestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_latestDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".LatestDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_latestRelevantDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".LatestRelevantDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_maturityDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".MaturityDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_pillarDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".PillarDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quote", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_FraRateHelper.source + ".Quote") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FraRateHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FraRateHelper_quoteError", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".QuoteError") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quoteIsValid", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".QuoteIsValid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quoteValue", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".QuoteValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_registerWith", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_unregisterWith", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((FraRateHelperModel.Cast _FraRateHelper.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FraRateHelper.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_Range", Description="Create a range of FraRateHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FraRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FraRateHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FraRateHelper> (c)) :> ICell
                let format (i : Cephei.Cell.List<FraRateHelper>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FraRateHelper>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
