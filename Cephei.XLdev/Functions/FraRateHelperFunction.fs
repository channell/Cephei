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
    [<ExcelFunction(Name="_FraRateHelper", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "Reference to monthsToStart")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="monthsToEnd",Description = "Reference to monthsToEnd")>] 
         monthsToEnd : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Handle<Quote>> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" true
                let _monthsToEnd = Helper.toCell<int> monthsToEnd "monthsToEnd" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper" 
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
    [<ExcelFunction(Name="_FraRateHelper1", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Reference to periodToStart")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" true
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" true
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper1 
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _iborIndex.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper1" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _iborIndex.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _iborIndex.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
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
    [<ExcelFunction(Name="_FraRateHelper2", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Reference to periodToStart")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Handle<Quote>> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" true
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper2 
                                                            _rate.cell 
                                                            _periodToStart.cell 
                                                            _iborIndex.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper2" 
                                               [| _rate.source
                                               ;  _periodToStart.source
                                               ;  _iborIndex.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _periodToStart.cell
                                ;  _iborIndex.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
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
    [<ExcelFunction(Name="_FraRateHelper3", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Reference to periodToStart")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "Reference to lengthInMonths")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" true
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" true
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper3 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper3" 
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
    [<ExcelFunction(Name="_FraRateHelper4", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="periodToStart",Description = "Reference to periodToStart")>] 
         periodToStart : obj)
        ([<ExcelArgument(Name="lengthInMonths",Description = "Reference to lengthInMonths")>] 
         lengthInMonths : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Handle<Quote>> rate "rate" 
                let _periodToStart = Helper.toCell<Period> periodToStart "periodToStart" true
                let _lengthInMonths = Helper.toCell<int> lengthInMonths "lengthInMonths" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper4 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper4" 
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
    [<ExcelFunction(Name="_FraRateHelper5", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "Reference to monthsToStart")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" true
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" true
                let _i = Helper.toCell<IborIndex> i "i" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper5 
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _i.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper5" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _i.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _i.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
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
    [<ExcelFunction(Name="_FraRateHelper6", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "Reference to monthsToStart")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="monthsToEnd",Description = "Reference to monthsToEnd")>] 
         monthsToEnd : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toCell<double> rate "rate" true
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" true
                let _monthsToEnd = Helper.toCell<int> monthsToEnd "monthsToEnd" true
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper6 
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
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper6" 
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
    [<ExcelFunction(Name="_FraRateHelper7", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_create7
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        ([<ExcelArgument(Name="monthsToStart",Description = "Reference to monthsToStart")>] 
         monthsToStart : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="pillarChoice",Description = "Reference to pillarChoice")>] 
         pillarChoice : obj)
        ([<ExcelArgument(Name="customPillarDate",Description = "Reference to customPillarDate")>] 
         customPillarDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rate = Helper.toHandle<Handle<Quote>> rate "rate" 
                let _monthsToStart = Helper.toCell<int> monthsToStart "monthsToStart" true
                let _i = Helper.toCell<IborIndex> i "i" true
                let _pillarChoice = Helper.toCell<Pillar.Choice> pillarChoice "pillarChoice" true
                let _customPillarDate = Helper.toCell<Date> customPillarDate "customPillarDate" true
                let builder () = withMnemonic mnemonic (Fun.FraRateHelper7 
                                                            _rate.cell 
                                                            _monthsToStart.cell 
                                                            _i.cell 
                                                            _pillarChoice.cell 
                                                            _customPillarDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FraRateHelper>) l

                let source = Helper.sourceFold "Fun.FraRateHelper7" 
                                               [| _rate.source
                                               ;  _monthsToStart.source
                                               ;  _i.source
                                               ;  _pillarChoice.source
                                               ;  _customPillarDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rate.cell
                                ;  _monthsToStart.cell
                                ;  _i.cell
                                ;  _pillarChoice.cell
                                ;  _customPillarDate.cell
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
    [<ExcelFunction(Name="_FraRateHelper_impliedQuote", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_impliedQuote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).ImpliedQuote
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".ImpliedQuote") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_setTermStructure", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_setTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let _t = Helper.toCell<YieldTermStructure> t "t" true
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).SetTermStructure
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".SetTermStructure") 
                                               [| _FraRateHelper.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_update", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).Update
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".Update") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_earliestDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_earliestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).EarliestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".EarliestDate") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_latestDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_latestDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).LatestDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".LatestDate") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_latestRelevantDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_latestRelevantDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).LatestRelevantDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".LatestRelevantDate") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_maturityDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".MaturityDate") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_pillarDate", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_pillarDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).PillarDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".PillarDate") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quote", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_quote
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).Quote
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_FraRateHelper.source + ".Quote") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quoteError", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_quoteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).QuoteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".QuoteError") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quoteIsValid", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_quoteIsValid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).QuoteIsValid
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".QuoteIsValid") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_quoteValue", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_quoteValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).QuoteValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".QuoteValue") 
                                               [| _FraRateHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_registerWith", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".RegisterWith") 
                                               [| _FraRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_unregisterWith", Description="Create a FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FraRateHelper",Description = "Reference to FraRateHelper")>] 
         fraratehelper : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FraRateHelper = Helper.toCell<FraRateHelper> fraratehelper "FraRateHelper" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FraRateHelper.cell :?> FraRateHelperModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FraRateHelper) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FraRateHelper.source + ".UnregisterWith") 
                                               [| _FraRateHelper.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FraRateHelper.cell
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
    [<ExcelFunction(Name="_FraRateHelper_Range", Description="Create a range of FraRateHelper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FraRateHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FraRateHelper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FraRateHelper> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FraRateHelper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FraRateHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FraRateHelper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
