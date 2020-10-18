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
<li>Maunday Thursday</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>General Prayer Day, 25 days after Easter Monday</li>
<li>Ascension</li>
<li>Whit (Pentecost) Monday </li>
<li>New Year's Day, January 1st</li>
<li>Constitution Day, June 5th</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module DenmarkFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Denmark", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Denmark")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Denmark ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Denmark>) l

                let source () = Helper.sourceFold "Fun.Denmark" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Denmark> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Denmark_addedHolidays", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Denmark.source + ".AddedHolidays") 
                                               [| _Denmark.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Denmark_addHoliday", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Denmark) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".AddHoliday") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_adjust", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Adjust") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_advance1", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "TimeUnit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Advance1") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_advance", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Advance") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_businessDaysBetween", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
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

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".BusinessDaysBetween") 
                                               [| _Denmark.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_calendar", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Denmark.source + ".Calendar") 
                                               [| _Denmark.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Denmark> format
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
    [<ExcelFunction(Name="_Denmark_empty", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Empty") 
                                               [| _Denmark.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_endOfMonth", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".EndOfMonth") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_Equals", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Equals") 
                                               [| _Denmark.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_isBusinessDay", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".IsBusinessDay") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_isEndOfMonth", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".IsEndOfMonth") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_isHoliday", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".IsHoliday") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_isWeekend", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".IsWeekend") 
                                               [| _Denmark.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_name", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".Name") 
                                               [| _Denmark.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_removedHolidays", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Denmark.source + ".RemovedHolidays") 
                                               [| _Denmark.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Denmark_removeHoliday", Description="Create a Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Denmark",Description = "Denmark")>] 
         denmark : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Denmark = Helper.toCell<Denmark> denmark "Denmark"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((DenmarkModel.Cast _Denmark.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Denmark) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Denmark.source + ".RemoveHoliday") 
                                               [| _Denmark.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Denmark.cell
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
    [<ExcelFunction(Name="_Denmark_Range", Description="Create a range of Denmark",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Denmark_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Denmark> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Denmark>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Denmark>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Denmark>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
