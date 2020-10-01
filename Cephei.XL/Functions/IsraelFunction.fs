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
  Due to the lack of reliable sources, the settlement calendar has the same holidays as the Tel Aviv stock-exchange.  Holidays for the Tel-Aviv Stock Exchange (data from <http://www.tase.co.il>):
<ul>
<li>Friday</li>
<li>Saturday</li>
</ul> Other holidays for wich no rule is given (data available for 2013-2044 only:)
<ul>
<li>Purim, Adar 14th (between Feb 24th & Mar 26th)</li>
<li>Passover I, Nisan 15th (between Mar 26th & Apr 25th)</li>
<li>Passover VII, Nisan 21st (between Apr 1st & May 1st)</li>
<li>Memorial Day, Nisan 27th (between Apr 7th & May 7th)</li>
<li>Indipendence Day, Iyar 5th (between Apr 15th & May 15th)</li>
<li>Pentecost (Shavuot), Sivan 6th (between May 15th & June 14th)</li>
<li>Fast Day</li>
<li>Jewish New Year, Tishrei 1st & 2nd (between Sep 5th & Oct 5th)</li>
<li>Yom Kippur, Tishrei 10th (between Sep 14th & Oct 14th)</li>
<li>Sukkoth, Tishrei 15th (between Sep 19th & Oct 19th)</li>
<li>Simchat Tora, Tishrei 22nd (between Sep 26th & Oct 26th)</li>
</ul>   calendars
  </summary> *)
[<AutoSerializable(true)>]
module IsraelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Israel", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Israel.Market> m "m" 
                let builder () = withMnemonic mnemonic (Fun.Israel 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Israel>) l

                let source = Helper.sourceFold "Fun.Israel" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Israel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Israel_addedHolidays", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Israel.source + ".AddedHolidays") 
                                               [| _Israel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_addHoliday", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Israel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".AddHoliday") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_adjust", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Adjust") 
                                               [| _Israel.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_advance1", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
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

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Advance1") 
                                               [| _Israel.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_advance", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
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

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Advance") 
                                               [| _Israel.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_businessDaysBetween", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
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

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Israel.source + ".BusinessDaysBetween") 
                                               [| _Israel.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_calendar", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Israel.source + ".Calendar") 
                                               [| _Israel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Israel> format
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
    [<ExcelFunction(Name="_Israel_empty", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Empty") 
                                               [| _Israel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_endOfMonth", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Israel.source + ".EndOfMonth") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_Equals", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Equals") 
                                               [| _Israel.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_isBusinessDay", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".IsBusinessDay") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_isEndOfMonth", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".IsEndOfMonth") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_isHoliday", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".IsHoliday") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_isWeekend", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".IsWeekend") 
                                               [| _Israel.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_name", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".Name") 
                                               [| _Israel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_removedHolidays", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Israel.source + ".RemovedHolidays") 
                                               [| _Israel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_removeHoliday", Description="Create a Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Israel",Description = "Reference to Israel")>] 
         israel : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Israel = Helper.toCell<Israel> israel "Israel"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Israel.cell :?> IsraelModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Israel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Israel.source + ".RemoveHoliday") 
                                               [| _Israel.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Israel.cell
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
    [<ExcelFunction(Name="_Israel_Range", Description="Create a range of Israel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Israel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Israel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Israel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Israel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Israel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Israel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
