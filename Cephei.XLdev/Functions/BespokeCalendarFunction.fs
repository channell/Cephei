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
  This calendar has no predefined set of business days. Holidays and weekdays can be defined by means of the provided interface. Instances constructed by copying remain linked to the original one; adding a new holiday or weekday will affect all linked instances.  calendars
  </summary> *)
[<AutoSerializable(true)>]
module BespokeCalendarFunction =

    (*
        ! marks the passed day as part of the weekend
    *)
    [<ExcelFunction(Name="_BespokeCalendar_addWeekend", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_addWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).AddWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : BespokeCalendar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".AddWeekend") 
                                               [| _BespokeCalendar.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
        
    *)
    [<ExcelFunction(Name="_BespokeCalendar", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="name",Description = "Reference to name")>] 
         name : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _name = Helper.toCell<string> name "name" true
                let builder () = withMnemonic mnemonic (Fun.BespokeCalendar 
                                                            _name.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BespokeCalendar>) l

                let source = Helper.sourceFold "Fun.BespokeCalendar" 
                                               [| _name.source
                                               |]
                let hash = Helper.hashFold 
                                [| _name.cell
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
        ! \warning different bespoke calendars created with the same name (or different bespoke calendars created with no name) will compare as equal.
    *)
    [<ExcelFunction(Name="_BespokeCalendar1", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BespokeCalendar1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BespokeCalendar>) l

                let source = Helper.sourceFold "Fun.BespokeCalendar1" 
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
    [<ExcelFunction(Name="_BespokeCalendar_name", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Name") 
                                               [| _BespokeCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_addedHolidays", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BespokeCalendar.source + ".AddedHolidays") 
                                               [| _BespokeCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_addHoliday", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : BespokeCalendar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".AddHoliday") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_adjust", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Adjust") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_advance", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
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

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Advance") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_advance", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
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

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Advance1") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_businessDaysBetween", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
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

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".BusinessDaysBetween") 
                                               [| _BespokeCalendar.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_calendar", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Calendar") 
                                               [| _BespokeCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_empty", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Empty") 
                                               [| _BespokeCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_endOfMonth", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".EndOfMonth") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_Equals", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".Equals") 
                                               [| _BespokeCalendar.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_isBusinessDay", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".IsBusinessDay") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_isEndOfMonth", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".IsEndOfMonth") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_isHoliday", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".IsHoliday") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_isWeekend", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".IsWeekend") 
                                               [| _BespokeCalendar.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
        
    *)
    [<ExcelFunction(Name="_BespokeCalendar_removedHolidays", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_BespokeCalendar.source + ".RemovedHolidays") 
                                               [| _BespokeCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_removeHoliday", Description="Create a BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BespokeCalendar",Description = "Reference to BespokeCalendar")>] 
         bespokecalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BespokeCalendar = Helper.toCell<BespokeCalendar> bespokecalendar "BespokeCalendar" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BespokeCalendar.cell :?> BespokeCalendarModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : BespokeCalendar) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BespokeCalendar.source + ".RemoveHoliday") 
                                               [| _BespokeCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BespokeCalendar.cell
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
    [<ExcelFunction(Name="_BespokeCalendar_Range", Description="Create a range of BespokeCalendar",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BespokeCalendar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BespokeCalendar")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BespokeCalendar> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BespokeCalendar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BespokeCalendar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BespokeCalendar>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
