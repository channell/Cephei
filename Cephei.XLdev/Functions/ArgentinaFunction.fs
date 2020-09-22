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
  Holidays for the Buenos Aires stock exchange (data from <http://www.merval.sba.com.ar/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Holy Thursday</li>
<li>Good Friday</li>
<li>Labour Day, May 1st</li>
<li>May Revolution, May 25th</li>
<li>Death of General Manuel Belgrano, third Monday of June</li>
<li>Independence Day, July 9th</li>
<li>Death of General JosÃ© de San MartÃ­n, third Monday of August</li>
<li>Columbus Day, October 12th (moved to preceding Monday if on Tuesday or Wednesday and to following if on Thursday or Friday)</li>
<li>Immaculate Conception, December 8th</li>
<li>Christmas Eve, December 24th</li>
<li>New Year's Eve, December 31th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module ArgentinaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Argentina", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Argentina 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Argentina>) l

                let source = Helper.sourceFold "Fun.Argentina" 
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
    [<ExcelFunction(Name="_Argentina_addedHolidays", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Argentina.source + ".AddedHolidays") 
                                               [| _Argentina.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_addHoliday", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Argentina) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".AddHoliday") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_adjust", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Adjust") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_advance", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
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

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Advance") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_advance", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
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

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Advance1") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_businessDaysBetween", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
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

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Argentina.source + ".BusinessDaysBetween") 
                                               [| _Argentina.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_calendar", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Argentina.source + ".Calendar") 
                                               [| _Argentina.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_empty", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Empty") 
                                               [| _Argentina.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_endOfMonth", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".EndOfMonth") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_Equals", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Equals") 
                                               [| _Argentina.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_isBusinessDay", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".IsBusinessDay") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_isEndOfMonth", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".IsEndOfMonth") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_isHoliday", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".IsHoliday") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_isWeekend", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".IsWeekend") 
                                               [| _Argentina.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_name", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".Name") 
                                               [| _Argentina.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_removedHolidays", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Argentina.source + ".RemovedHolidays") 
                                               [| _Argentina.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_removeHoliday", Description="Create a Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Argentina",Description = "Reference to Argentina")>] 
         argentina : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Argentina = Helper.toCell<Argentina> argentina "Argentina" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Argentina.cell :?> ArgentinaModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Argentina) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Argentina.source + ".RemoveHoliday") 
                                               [| _Argentina.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Argentina.cell
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
    [<ExcelFunction(Name="_Argentina_Range", Description="Create a range of Argentina",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Argentina_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Argentina")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Argentina> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Argentina>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Argentina>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Argentina>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
