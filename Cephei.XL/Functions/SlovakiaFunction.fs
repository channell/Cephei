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
  Holidays for the Bratislava stock exchange (data from <http://www.bsse.sk/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Epiphany, January 6th</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>May Day, May 1st</li>
<li>Liberation of the Republic, May 8th</li>
<li>SS. Cyril and Methodius, July 5th</li>
<li>Slovak National Uprising, August 29th</li>
<li>Constitution of the Slovak Republic, September 1st</li>
<li>Our Lady of the Seven Sorrows, September 15th</li>
<li>All Saints Day, November 1st</li>
<li>Freedom and Democracy of the Slovak Republic, November 17th</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>St. Stephen, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SlovakiaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Slovakia", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Slovakia ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Slovakia>) l

                let source = Helper.sourceFold "Fun.Slovakia" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Slovakia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Slovakia_addedHolidays", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Slovakia.source + ".AddedHolidays") 
                                               [| _Slovakia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_addHoliday", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Slovakia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".AddHoliday") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_adjust", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Adjust") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_advance1", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
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

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Advance") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_advance", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
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

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Advance") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_businessDaysBetween", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
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

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".BusinessDaysBetween") 
                                               [| _Slovakia.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_calendar", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Slovakia.source + ".Calendar") 
                                               [| _Slovakia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Slovakia> format
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
    [<ExcelFunction(Name="_Slovakia_empty", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Empty") 
                                               [| _Slovakia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_endOfMonth", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".EndOfMonth") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_Equals", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Equals") 
                                               [| _Slovakia.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_isBusinessDay", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".IsBusinessDay") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_isEndOfMonth", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".IsEndOfMonth") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_isHoliday", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".IsHoliday") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_isWeekend", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".IsWeekend") 
                                               [| _Slovakia.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_name", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".Name") 
                                               [| _Slovakia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_removedHolidays", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Slovakia.source + ".RemovedHolidays") 
                                               [| _Slovakia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_removeHoliday", Description="Create a Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Slovakia",Description = "Reference to Slovakia")>] 
         slovakia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Slovakia = Helper.toCell<Slovakia> slovakia "Slovakia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Slovakia.cell :?> SlovakiaModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Slovakia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Slovakia.source + ".RemoveHoliday") 
                                               [| _Slovakia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Slovakia.cell
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
    [<ExcelFunction(Name="_Slovakia_Range", Description="Create a range of Slovakia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Slovakia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Slovakia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Slovakia> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Slovakia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Slovakia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Slovakia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
