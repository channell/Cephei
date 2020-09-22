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
  Holidays (see http://www.ecb.int):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday (since 2000)</li>
<li>Easter Monday (since 2000)</li>
<li>Labour Day, May 1st (since 2000)</li>
<li>Christmas, December 25th</li>
<li>Day of Goodwill, December 26th (since 2000)</li>
<li>December 31st (1998, 1999, and 2001)</li>
</ul>
  </summary> *)
[<AutoSerializable(true)>]
module TARGETFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TARGET", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.TARGET ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TARGET>) l

                let source = Helper.sourceFold "Fun.TARGET" 
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
    [<ExcelFunction(Name="_TARGET_addedHolidays", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_TARGET.source + ".AddedHolidays") 
                                               [| _TARGET.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_addHoliday", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : TARGET) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".AddHoliday") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_adjust", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Adjust") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_advance1", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
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

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Advance1") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_advance", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
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

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Advance") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_businessDaysBetween", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
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

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TARGET.source + ".BusinessDaysBetween") 
                                               [| _TARGET.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_calendar", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_TARGET.source + ".Calendar") 
                                               [| _TARGET.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_empty", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Empty") 
                                               [| _TARGET.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_endOfMonth", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".EndOfMonth") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_Equals", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Equals") 
                                               [| _TARGET.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_isBusinessDay", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".IsBusinessDay") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_isEndOfMonth", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".IsEndOfMonth") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_isHoliday", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".IsHoliday") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_isWeekend", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".IsWeekend") 
                                               [| _TARGET.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_name", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".Name") 
                                               [| _TARGET.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_removedHolidays", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_TARGET.source + ".RemovedHolidays") 
                                               [| _TARGET.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_removeHoliday", Description="Create a TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TARGET",Description = "Reference to TARGET")>] 
         target : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TARGET = Helper.toCell<TARGET> target "TARGET" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_TARGET.cell :?> TARGETModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : TARGET) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TARGET.source + ".RemoveHoliday") 
                                               [| _TARGET.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TARGET.cell
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
    [<ExcelFunction(Name="_TARGET_Range", Description="Create a range of TARGET",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TARGET_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TARGET")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TARGET> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TARGET>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TARGET>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TARGET>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
