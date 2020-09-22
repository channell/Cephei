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
<li>Easter Monday</li>
<li>Whit(Pentecost) Monday </li>
<li>New Year's Day, January 1st</li>
<li>National Day, March 15th</li>
<li>Labour Day, May 1st</li>
<li>Constitution Day, August 20th</li>
<li>Republic Day, October 23rd</li>
<li>All Saints Day, November 1st</li>
<li>Christmas, December 25th</li>
<li>2nd Day of Christmas, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module HungaryFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Hungary", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Hungary ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Hungary>) l

                let source = Helper.sourceFold "Fun.Hungary" 
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
    [<ExcelFunction(Name="_Hungary_addedHolidays", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Hungary.source + ".AddedHolidays") 
                                               [| _Hungary.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_addHoliday", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Hungary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".AddHoliday") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_adjust", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Adjust") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_advance1", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
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

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Advance1") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_advance", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
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

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Advance") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_businessDaysBetween", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
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

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Hungary.source + ".BusinessDaysBetween") 
                                               [| _Hungary.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_calendar", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Hungary.source + ".Calendar") 
                                               [| _Hungary.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_empty", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Empty") 
                                               [| _Hungary.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_endOfMonth", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".EndOfMonth") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_Equals", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Equals") 
                                               [| _Hungary.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_isBusinessDay", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".IsBusinessDay") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_isEndOfMonth", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".IsEndOfMonth") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_isHoliday", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".IsHoliday") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_isWeekend", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".IsWeekend") 
                                               [| _Hungary.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_name", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".Name") 
                                               [| _Hungary.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_removedHolidays", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Hungary.source + ".RemovedHolidays") 
                                               [| _Hungary.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_removeHoliday", Description="Create a Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Hungary",Description = "Reference to Hungary")>] 
         hungary : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Hungary = Helper.toCell<Hungary> hungary "Hungary" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Hungary.cell :?> HungaryModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Hungary) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Hungary.source + ".RemoveHoliday") 
                                               [| _Hungary.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Hungary.cell
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
    [<ExcelFunction(Name="_Hungary_Range", Description="Create a range of Hungary",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Hungary_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Hungary")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Hungary> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Hungary>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Hungary>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Hungary>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
