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
<li>Bank Holiday, January 2nd</li>
<li>Bank Holiday, January 3rd</li>
<li>Coming of Age Day, 2nd Monday in January</li>
<li>National Foundation Day, February 11th</li>
<li>Vernal Equinox</li>
<li>Greenery Day, April 29th</li>
<li>Constitution Memorial Day, May 3rd</li>
<li>Holiday for a Nation, May 4th</li>
<li>Children's Day, May 5th</li>
<li>Marine Day, 3rd Monday in July</li>
<li>Mountain Day, August 11th (from 2016 onwards)</li>
<li>Respect for the Aged Day, 3rd Monday in September</li>
<li>Autumnal Equinox</li>
<li>Health and Sports Day, 2nd Monday in October</li>
<li>National Culture Day, November 3rd</li>
<li>Labor Thanksgiving Day, November 23rd</li>
<li>Emperor's Birthday, December 23rd</li>
<li>Bank Holiday, December 31st</li>
<li>a few one-shot holidays</li>
</ul> Holidays falling on a Sunday are observed on the Monday following except for the bank holidays associated with the new year.  calendars
  </summary> *)
[<AutoSerializable(true)>]
module JapanFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Japan", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Japan 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Japan>) l

                let source = Helper.sourceFold "Fun.Japan" 
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
    [<ExcelFunction(Name="_Japan_addedHolidays", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Japan.source + ".AddedHolidays") 
                                               [| _Japan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_addHoliday", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Japan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".AddHoliday") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_adjust", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Adjust") 
                                               [| _Japan.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_advance", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
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

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Advance") 
                                               [| _Japan.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_advance", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
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

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Advance1") 
                                               [| _Japan.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_businessDaysBetween", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
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

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Japan.source + ".BusinessDaysBetween") 
                                               [| _Japan.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_calendar", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Japan.source + ".Calendar") 
                                               [| _Japan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_empty", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Empty") 
                                               [| _Japan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_endOfMonth", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Japan.source + ".EndOfMonth") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_Equals", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Equals") 
                                               [| _Japan.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_isBusinessDay", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".IsBusinessDay") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_isEndOfMonth", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".IsEndOfMonth") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_isHoliday", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".IsHoliday") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_isWeekend", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".IsWeekend") 
                                               [| _Japan.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_name", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".Name") 
                                               [| _Japan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_removedHolidays", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Japan.source + ".RemovedHolidays") 
                                               [| _Japan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_removeHoliday", Description="Create a Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Japan",Description = "Reference to Japan")>] 
         japan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Japan = Helper.toCell<Japan> japan "Japan" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Japan.cell :?> JapanModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Japan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Japan.source + ".RemoveHoliday") 
                                               [| _Japan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Japan.cell
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
    [<ExcelFunction(Name="_Japan_Range", Description="Create a range of Japan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Japan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Japan")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Japan> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Japan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Japan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Japan>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
