﻿(*
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

  </summary> *)
[<AutoSerializable(true)>]
module ScheduleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Schedule_at", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_at
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).At
                                                            _i.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".At") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Schedule_businessDayConvention", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_calendar", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Schedule.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Schedule_Count", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_Count
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Count
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".Count") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_date", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Date
                                                            _i.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".Date") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Schedule_dates", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Dates
                                                       ) :> ICell
                let format (i : Cephei.Cell.List<Date>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Schedule.source + ".Dates") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other inspectors
    *)
    [<ExcelFunction(Name="_Schedule_empty", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_endDate", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_endDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).EndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".EndDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_endOfMonth", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_isRegular", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_isRegular
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).IsRegular
                                                       ) :> ICell
                let format (i : Generic.IList<bool>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_Schedule.source + ".IsRegular") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Schedule_isRegular1", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_isRegular1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).IsRegular1
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".IsRegular1") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_Schedule_nextDate", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_nextDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).NextDate
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".NextDate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Schedule_previousDate", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_previousDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).PreviousDate
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".PreviousDate") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Schedule_rule", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_rule
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Rule
                                                       ) :> ICell
                let format (o : DateGeneration.Rule) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".Rule") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="effectiveDate",Description = "Date")>] 
         effectiveDate : obj)
        ([<ExcelArgument(Name="terminationDate",Description = "Date")>] 
         terminationDate : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period or empty")>] 
         tenor : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar or empty")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         convention : obj)
        ([<ExcelArgument(Name="terminationDateConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         terminationDateConvention : obj)
        ([<ExcelArgument(Name="rule",Description = "DateGeneration.Rule: Backward, Forward, Zero, ThirdWednesday, Twentieth, TwentiethIMM, OldCDS, CDS, CDS2015")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="firstDate",Description = "Date or empty")>] 
         firstDate : obj)
        ([<ExcelArgument(Name="nextToLastDate",Description = "Date or empty")>] 
         nextToLastDate : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _effectiveDate = Helper.toCell<Date> effectiveDate "effectiveDate" 
                let _terminationDate = Helper.toCell<Date> terminationDate "terminationDate" 
                let _tenor = Helper.toDefault<Period> tenor "tenor" null
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _convention = Helper.toDefault<BusinessDayConvention> convention "convention" BusinessDayConvention.Unadjusted
                let _terminationDateConvention = Helper.toCell<BusinessDayConvention> terminationDateConvention "terminationDateConvention"
                let _rule = Helper.toCell<DateGeneration.Rule> rule "rule"
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth"
                let _firstDate = Helper.toDefault<Date> firstDate "firstDate" null
                let _nextToLastDate = Helper.toDefault<Date> nextToLastDate "nextToLastDate" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.Schedule 
                                                            _effectiveDate.cell 
                                                            _terminationDate.cell 
                                                            _tenor.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _terminationDateConvention.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _firstDate.cell 
                                                            _nextToLastDate.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold "Fun.Schedule" 
                                               [| _effectiveDate.source
                                               ;  _terminationDate.source
                                               ;  _tenor.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _terminationDateConvention.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _firstDate.source
                                               ;  _nextToLastDate.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _effectiveDate.cell
                                ;  _terminationDate.cell
                                ;  _tenor.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _terminationDateConvention.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _firstDate.cell
                                ;  _nextToLastDate.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Schedule2", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.Schedule2 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold "Fun.Schedule2" 
                                               [| _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Schedule1", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Date range")>] 
         dates : obj)
        ([<ExcelArgument(Name="calendar",Description = "Calendar or empty")>] 
         calendar : obj)
        ([<ExcelArgument(Name="convention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest or empty")>] 
         convention : obj)
        ([<ExcelArgument(Name="terminationDateConvention",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         terminationDateConvention : obj)
        ([<ExcelArgument(Name="tenor",Description = "Period or empty")>] 
         tenor : obj)
        ([<ExcelArgument(Name="rule",Description = "DateGeneration.Rule: Backward, Forward, Zero, ThirdWednesday, Twentieth, TwentiethIMM, OldCDS, CDS, CDS2015")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="isRegular",Description = "bool or empty")>] 
         isRegular : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _convention = Helper.toDefault<BusinessDayConvention> convention "convention" BusinessDayConvention.Unadjusted
                let _terminationDateConvention = Helper.toNullable<BusinessDayConvention> terminationDateConvention "terminationDateConvention"
                let _tenor = Helper.toDefault<Period> tenor "tenor" null
                let _rule = Helper.toNullable<DateGeneration.Rule> rule "rule"
                let _endOfMonth = Helper.toNullable<bool> endOfMonth "endOfMonth"
                let _isRegular = Helper.toDefault<Generic.IList<bool>> isRegular "isRegular" null
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.Schedule1
                                                            _dates.cell 
                                                            _calendar.cell 
                                                            _convention.cell 
                                                            _terminationDateConvention.cell 
                                                            _tenor.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _isRegular.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold "Fun.Schedule1" 
                                               [| _dates.source
                                               ;  _calendar.source
                                               ;  _convention.source
                                               ;  _terminationDateConvention.source
                                               ;  _tenor.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _isRegular.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _calendar.cell
                                ;  _convention.cell
                                ;  _terminationDateConvention.cell
                                ;  _tenor.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _isRegular.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Date access
    *)
    [<ExcelFunction(Name="_Schedule_size", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_startDate", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".StartDate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_tenor", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Schedule.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Schedule_terminationDateBusinessDayConvention", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_terminationDateBusinessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).TerminationDateBusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".TerminationDateBusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
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
    [<ExcelFunction(Name="_Schedule_this", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).This
                                                            _i.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Schedule.source + ".This") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _i.cell
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
        ! truncated schedule
    *)
    [<ExcelFunction(Name="_Schedule_until", Description="Create a Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_until
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Schedule",Description = "Schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="truncationDate",Description = "Date")>] 
         truncationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Schedule = Helper.toModelReference<Schedule> schedule "Schedule"  
                let _truncationDate = Helper.toCell<Date> truncationDate "truncationDate" 
                let builder (current : ICell) = ((ScheduleModel.Cast _Schedule.cell).Until
                                                            _truncationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_Schedule.source + ".Until") 

                                               [| _truncationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Schedule.cell
                                ;  _truncationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Schedule> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Schedule_Range", Description="Create a range of Schedule",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Schedule_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Schedule> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Schedule> (c)) :> ICell
                let format (i : Cephei.Cell.List<Schedule>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Schedule>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
