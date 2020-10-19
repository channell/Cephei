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

  </summary> *)
[<AutoSerializable(true)>]
module ThailandFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Thailand", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Thailand")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Thailand ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Thailand>) l

                let source () = Helper.sourceFold "Fun.Thailand" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Thailand> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Thailand_addedHolidays", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Thailand.source + ".AddedHolidays") 
                                               [| _Thailand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_addHoliday", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Thailand) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".AddHoliday") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_adjust", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Adjust") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_advance1", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
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

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Advance1") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_advance", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
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

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Advance") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_businessDaysBetween", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
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

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".BusinessDaysBetween") 
                                               [| _Thailand.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_calendar", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Thailand.source + ".Calendar") 
                                               [| _Thailand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Thailand> format
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
    [<ExcelFunction(Name="_Thailand_empty", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Empty") 
                                               [| _Thailand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_endOfMonth", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".EndOfMonth") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_Equals", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Equals") 
                                               [| _Thailand.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_isBusinessDay", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".IsBusinessDay") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_isEndOfMonth", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".IsEndOfMonth") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_isHoliday", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".IsHoliday") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_isWeekend", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".IsWeekend") 
                                               [| _Thailand.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_name", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".Name") 
                                               [| _Thailand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_removedHolidays", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Thailand.source + ".RemovedHolidays") 
                                               [| _Thailand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_removeHoliday", Description="Create a Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Thailand",Description = "Thailand")>] 
         thailand : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Thailand = Helper.toCell<Thailand> thailand "Thailand"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((ThailandModel.Cast _Thailand.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Thailand) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Thailand.source + ".RemoveHoliday") 
                                               [| _Thailand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Thailand.cell
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
    [<ExcelFunction(Name="_Thailand_Range", Description="Create a range of Thailand",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Thailand_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Thailand> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Thailand>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Thailand>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Thailand>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
