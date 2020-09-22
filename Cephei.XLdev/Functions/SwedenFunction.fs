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
  Holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Epiphany, January 6th</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Ascension</li>
<li>Whit(Pentecost) Monday </li>
<li>May Day, May 1st</li>
<li>National Day, June 6th</li>
<li>Midsummer Eve (Friday between June 19-25)</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas Day, December 25th</li>
<li>Boxing Day, December 26th</li>
<li>New Year's Eve, December 31th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SwedenFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Sweden", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Sweden 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sweden>) l

                let source = Helper.sourceFold "Fun.Sweden" 
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
    [<ExcelFunction(Name="_Sweden_addedHolidays", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Sweden.source + ".AddedHolidays") 
                                               [| _Sweden.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_addHoliday", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Sweden) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".AddHoliday") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_adjust", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Adjust") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_advance", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
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

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Advance") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_advance", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
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

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Advance1") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_businessDaysBetween", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
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

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Sweden.source + ".BusinessDaysBetween") 
                                               [| _Sweden.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_calendar", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Sweden.source + ".Calendar") 
                                               [| _Sweden.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_empty", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Empty") 
                                               [| _Sweden.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_endOfMonth", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".EndOfMonth") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_Equals", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Equals") 
                                               [| _Sweden.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_isBusinessDay", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".IsBusinessDay") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_isEndOfMonth", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".IsEndOfMonth") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_isHoliday", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".IsHoliday") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_isWeekend", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".IsWeekend") 
                                               [| _Sweden.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_name", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".Name") 
                                               [| _Sweden.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_removedHolidays", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Sweden.source + ".RemovedHolidays") 
                                               [| _Sweden.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_removeHoliday", Description="Create a Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sweden",Description = "Reference to Sweden")>] 
         sweden : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sweden = Helper.toCell<Sweden> sweden "Sweden" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Sweden.cell :?> SwedenModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Sweden) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sweden.source + ".RemoveHoliday") 
                                               [| _Sweden.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sweden.cell
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
    [<ExcelFunction(Name="_Sweden_Range", Description="Create a range of Sweden",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sweden_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Sweden")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Sweden> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Sweden>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Sweden>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Sweden>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
