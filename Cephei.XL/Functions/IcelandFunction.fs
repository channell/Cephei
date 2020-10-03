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
  Holidays for the Iceland stock exchange (data from <http://www.icex.is/is/calendar?languageID=1>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Holy Thursday</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>First day of Summer (third or fourth Thursday in April)</li>
<li>Labour Day, May 1st</li>
<li>Ascension Thursday</li>
<li>Pentecost Monday</li>
<li>Independence Day, June 17th</li>
<li>Commerce Day, first Monday in August</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module IcelandFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Iceland", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Iceland ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Iceland>) l

                let source = Helper.sourceFold "Fun.Iceland" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Iceland> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Iceland_addedHolidays", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Iceland.source + ".AddedHolidays") 
                                               [| _Iceland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_addHoliday", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Iceland) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".AddHoliday") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_adjust", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Adjust") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_advance1", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
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

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Advance1") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_advance", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
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

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Advance") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_businessDaysBetween", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
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

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Iceland.source + ".BusinessDaysBetween") 
                                               [| _Iceland.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_calendar", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Iceland.source + ".Calendar") 
                                               [| _Iceland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Iceland> format
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
    [<ExcelFunction(Name="_Iceland_empty", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Empty") 
                                               [| _Iceland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_endOfMonth", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".EndOfMonth") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_Equals", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Equals") 
                                               [| _Iceland.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_isBusinessDay", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".IsBusinessDay") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_isEndOfMonth", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".IsEndOfMonth") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_isHoliday", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".IsHoliday") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_isWeekend", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".IsWeekend") 
                                               [| _Iceland.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_name", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".Name") 
                                               [| _Iceland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_removedHolidays", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Iceland.source + ".RemovedHolidays") 
                                               [| _Iceland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_removeHoliday", Description="Create a Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Iceland",Description = "Reference to Iceland")>] 
         iceland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Iceland = Helper.toCell<Iceland> iceland "Iceland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((IcelandModel.Cast _Iceland.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Iceland) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Iceland.source + ".RemoveHoliday") 
                                               [| _Iceland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Iceland.cell
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
    [<ExcelFunction(Name="_Iceland_Range", Description="Create a range of Iceland",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Iceland_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Iceland")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Iceland> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Iceland>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Iceland>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Iceland>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
