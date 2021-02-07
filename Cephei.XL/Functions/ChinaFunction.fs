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
<li>New Year's day, January 1st (possibly followed by one or two more holidays)</li>
<li>Labour Day, first week in May</li>
<li>National Day, one week from October 1st</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2019 only):
<ul>
<li>Chinese New Year</li>
<li>Ching Ming Festival</li>
<li>Tuen Ng Festival</li>
<li>Mid-Autumn Festival</li>
<li>70th anniversary of the victory of anti-Japaneses war</li>
</ul>  SSE data from <http://www.sse.com.cn/> IB data from <http://www.chinamoney.com.cn/>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module ChinaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_China", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="market",Description = "China.Market: SSE, IB or empty")>] 
         market : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _market = Helper.toDefault<China.Market> market "market" China.Market.SSE
                let builder (current : ICell) = (Fun.China 
                                                            _market.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<China>) l

                let source () = Helper.sourceFold "Fun.China" 
                                               [| _market.source
                                               |]
                let hash = Helper.hashFold 
                                [| _market.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<China> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_China_addedHolidays", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_China.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_addHoliday", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : China) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_adjust", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_China.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_advance1", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "TimeUnit: Days, Weeks, Months, Years")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_China.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_advance", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_China.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_businessDaysBetween", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="from",Description = "Date")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Date")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "bool")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "bool")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_China.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_calendar", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_China.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _China.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<China> format
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
    [<ExcelFunction(Name="_China_empty", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_endOfMonth", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_China.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_Equals", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_isBusinessDay", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_isEndOfMonth", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_isHoliday", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_isWeekend", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_name", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_removedHolidays", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_China.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_removeHoliday", Description="Create a China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="China",Description = "China")>] 
         china : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _China = Helper.toCell<China> china "China"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((ChinaModel.Cast _China.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : China) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_China.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _China.cell
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
    [<ExcelFunction(Name="_China_Range", Description="Create a range of China",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let China_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<China> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<China> (c)) :> ICell
                let format (i : Cephei.Cell.List<China>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<China>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
