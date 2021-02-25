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

  </summary> *)
[<AutoSerializable(true)>]
module CalendarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Calendar_addedHolidays", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_Calendar.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_addHoliday", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Calendar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_adjust", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Calendar")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toDefault<BusinessDayConvention> c "c" BusinessDayConvention.Following
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_Calendar_advance1", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "TimeUnit: Days, Weeks, Months, Years")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "Calendar")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Calendar")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toDefault<BusinessDayConvention> c "c" BusinessDayConvention.Following
                let _endOfMonth = Helper.toDefault<bool> endOfMonth "endOfMonth" false
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Calendar_advance", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "Calendar")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Calendar")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toDefault<BusinessDayConvention> c "c" BusinessDayConvention.Following
                let _endOfMonth = Helper.toDefault<bool> endOfMonth "endOfMonth" false
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Calendar_businessDaysBetween", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="from",Description = "Date")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Date")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "Calendar")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "Calendar")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toDefault<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toDefault<bool> includeLast "includeLast" false
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_Calendar_calendar", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Calendar.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Calendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default constructor returns a calendar with a null implementation, which is therefore unusable except as a placeholder.
    *)
    [<ExcelFunction(Name="_Calendar", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.Calendar ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold "Fun.Calendar" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Calendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Calendar1", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c",Description = "Calendar")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c = Helper.toCell<Calendar> c "c" 
                let builder (current : ICell) = (Fun.Calendar1 
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold "Fun.Calendar1" 
                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Calendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_Calendar_empty", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_endOfMonth", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_Equals", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_Calendar_isBusinessDay", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_isEndOfMonth", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_Calendar_isHoliday", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_Calendar_isWeekend", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_Calendar_name", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_removedHolidays", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_Calendar.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_removeHoliday", Description="Create a Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Calendar",Description = "Calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Calendar = Helper.toModelReference<Calendar> calendar "Calendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((CalendarModel.Cast _Calendar.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Calendar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Calendar.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Calendar.cell
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
    [<ExcelFunction(Name="_Calendar_Range", Description="Create a range of Calendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Calendar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Calendar> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Calendar> (c)) :> ICell
                let format (i : Cephei.Cell.List<Calendar>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Calendar>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
