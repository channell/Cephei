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
  This calendar has no holidays. It ensures that dates at whole-month distances have the same day of month.
  </summary> *)
[<AutoSerializable(true)>]
module NullCalendarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NullCalendar", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NullCalendar ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NullCalendar>) l

                let source = Helper.sourceFold "Fun.NullCalendar" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_NullCalendar_addedHolidays", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_NullCalendar.source + ".AddedHolidays") 
                                               [| _NullCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        
    *)
    [<ExcelFunction(Name="_NullCalendar_addHoliday", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : NullCalendar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".AddHoliday") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_NullCalendar_adjust", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Adjust") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_NullCalendar_advance1", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "Reference to unit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Advance") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_NullCalendar_advance", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Advance") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_NullCalendar_businessDaysBetween", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "Reference to includeFirst")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "Reference to includeLast")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".BusinessDaysBetween") 
                                               [| _NullCalendar.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_NullCalendar_calendar", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_NullCalendar.source + ".Calendar") 
                                               [| _NullCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
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
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_NullCalendar_empty", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Empty") 
                                               [| _NullCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
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
    [<ExcelFunction(Name="_NullCalendar_endOfMonth", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".EndOfMonth") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_NullCalendar_Equals", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Equals") 
                                               [| _NullCalendar.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_NullCalendar_isBusinessDay", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".IsBusinessDay") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_NullCalendar_isEndOfMonth", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".IsEndOfMonth") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_NullCalendar_isHoliday", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".IsHoliday") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_NullCalendar_isWeekend", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".IsWeekend") 
                                               [| _NullCalendar.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_NullCalendar_name", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".Name") 
                                               [| _NullCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
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
    [<ExcelFunction(Name="_NullCalendar_removedHolidays", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_NullCalendar.source + ".RemovedHolidays") 
                                               [| _NullCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
        
    *)
    [<ExcelFunction(Name="_NullCalendar_removeHoliday", Description="Create a NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NullCalendar",Description = "Reference to NullCalendar")>] 
         nullcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NullCalendar = Helper.toCell<NullCalendar> nullcalendar "NullCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NullCalendar.cell :?> NullCalendarModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : NullCalendar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NullCalendar.source + ".RemoveHoliday") 
                                               [| _NullCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NullCalendar.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_NullCalendar_Range", Description="Create a range of NullCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NullCalendar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NullCalendar")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NullCalendar> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NullCalendar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NullCalendar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NullCalendar>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
