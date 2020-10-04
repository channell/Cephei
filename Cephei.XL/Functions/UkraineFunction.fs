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
  Holidays for the Ukrainian stock exchange (data from <http://www.ukrse.kiev.ua/eng/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Orthodox Christmas, January 7th</li>
<li>International Women's Day, March 8th</li>
<li>Easter Monday</li>
<li>Holy Trinity Day, 50 days after Easter</li>
<li>International Workers' Solidarity Days, May 1st and 2nd</li>
<li>Victory Day, May 9th</li>
<li>Constitution Day, June 28th</li>
<li>Independence Day, August 24th</li>
<li>Defender's Day, October 14th (since 2015)</li>
</ul> Holidays falling on a Saturday or Sunday are moved to the following Monday.  calendars
  </summary> *)
[<AutoSerializable(true)>]
module UkraineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Ukraine", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toDefault<Ukraine.Market> m "m" Ukraine.Market.USE
                let builder () = withMnemonic mnemonic (Fun.Ukraine 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Ukraine>) l

                let source = Helper.sourceFold "Fun.Ukraine" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Ukraine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Ukraine_addedHolidays", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Ukraine.source + ".AddedHolidays") 
                                               [| _Ukraine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_addHoliday", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Ukraine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".AddHoliday") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_adjust", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Adjust") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_advance1", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
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

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Advance1") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_advance", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
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

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Advance") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_businessDaysBetween", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
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

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".BusinessDaysBetween") 
                                               [| _Ukraine.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_calendar", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Ukraine.source + ".Calendar") 
                                               [| _Ukraine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Ukraine> format
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
    [<ExcelFunction(Name="_Ukraine_empty", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Empty") 
                                               [| _Ukraine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_endOfMonth", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".EndOfMonth") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_Equals", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Equals") 
                                               [| _Ukraine.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_isBusinessDay", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".IsBusinessDay") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_isEndOfMonth", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".IsEndOfMonth") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_isHoliday", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".IsHoliday") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_isWeekend", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".IsWeekend") 
                                               [| _Ukraine.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_name", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".Name") 
                                               [| _Ukraine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_removedHolidays", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Ukraine.source + ".RemovedHolidays") 
                                               [| _Ukraine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_removeHoliday", Description="Create a Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Ukraine",Description = "Reference to Ukraine")>] 
         ukraine : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Ukraine = Helper.toCell<Ukraine> ukraine "Ukraine"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((UkraineModel.Cast _Ukraine.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Ukraine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Ukraine.source + ".RemoveHoliday") 
                                               [| _Ukraine.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Ukraine.cell
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
    [<ExcelFunction(Name="_Ukraine_Range", Description="Create a range of Ukraine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Ukraine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Ukraine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Ukraine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Ukraine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Ukraine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Ukraine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
