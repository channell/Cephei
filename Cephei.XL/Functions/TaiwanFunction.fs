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
  Holidays for the Taiwan stock exchange (data from <http://www.tse.com.tw/en/trading/trading_days.php>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Peace Memorial Day, February 28</li>
<li>Labor Day, May 1st</li>
<li>Double Tenth National Day, October 10th</li>
</ul>  Other holidays for which no rule is given (data available for 2002-2013 only:)
<ul>
<li>Chinese Lunar New Year</li>
<li>Tomb Sweeping Day</li>
<li>Dragon Boat Festival</li>
<li>Moon Festival</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module TaiwanFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Taiwan", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Taiwan ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Taiwan>) l

                let source = Helper.sourceFold "Fun.Taiwan" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Taiwan> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Taiwan_addedHolidays", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Taiwan.source + ".AddedHolidays") 
                                               [| _Taiwan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_addHoliday", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Taiwan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".AddHoliday") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_adjust", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Adjust") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_advance1", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
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

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Advance1") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_advance", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
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

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Advance") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_businessDaysBetween", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
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

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".BusinessDaysBetween") 
                                               [| _Taiwan.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_calendar", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Taiwan.source + ".Calendar") 
                                               [| _Taiwan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Taiwan> format
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
    [<ExcelFunction(Name="_Taiwan_empty", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Empty") 
                                               [| _Taiwan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_endOfMonth", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".EndOfMonth") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_Equals", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Equals") 
                                               [| _Taiwan.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_isBusinessDay", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".IsBusinessDay") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_isEndOfMonth", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".IsEndOfMonth") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_isHoliday", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".IsHoliday") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_isWeekend", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".IsWeekend") 
                                               [| _Taiwan.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_name", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".Name") 
                                               [| _Taiwan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_removedHolidays", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Taiwan.source + ".RemovedHolidays") 
                                               [| _Taiwan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_removeHoliday", Description="Create a Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Taiwan",Description = "Reference to Taiwan")>] 
         taiwan : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Taiwan = Helper.toCell<Taiwan> taiwan "Taiwan"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Taiwan.cell :?> TaiwanModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Taiwan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Taiwan.source + ".RemoveHoliday") 
                                               [| _Taiwan.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Taiwan.cell
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
    [<ExcelFunction(Name="_Taiwan_Range", Description="Create a range of Taiwan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Taiwan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Taiwan")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Taiwan> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Taiwan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Taiwan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Taiwan>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"