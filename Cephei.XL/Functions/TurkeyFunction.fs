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
  Holidays for the Istanbul Stock Exchange: (data from <http://borsaistanbul.com/en/products-and-markets/official-holidays>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>National Sovereignty and Children’s Day, April 23rd</li>
<li>Youth and Sports Day, May 19th</li>
<li>Victory Day, August 30th</li>
<li>Republic Day, October 29th</li>
<li>Local Holidays (Kurban, Ramadan; 2004 to 2013 only) </li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module TurkeyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Turkey", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Turkey ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Turkey>) l

                let source = Helper.sourceFold "Fun.Turkey" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Turkey> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Turkey_addedHolidays", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Turkey.source + ".AddedHolidays") 
                                               [| _Turkey.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_addHoliday", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Turkey) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".AddHoliday") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_adjust", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Adjust") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_advance1", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
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

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Advance1") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_advance", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
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

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Advance") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_businessDaysBetween", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
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

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Turkey.source + ".BusinessDaysBetween") 
                                               [| _Turkey.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_calendar", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Turkey.source + ".Calendar") 
                                               [| _Turkey.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Turkey> format
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
    [<ExcelFunction(Name="_Turkey_empty", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Empty") 
                                               [| _Turkey.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_endOfMonth", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".EndOfMonth") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_Equals", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Equals") 
                                               [| _Turkey.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_isBusinessDay", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".IsBusinessDay") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_isEndOfMonth", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".IsEndOfMonth") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_isHoliday", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".IsHoliday") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_isWeekend", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".IsWeekend") 
                                               [| _Turkey.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_name", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".Name") 
                                               [| _Turkey.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_removedHolidays", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Turkey.source + ".RemovedHolidays") 
                                               [| _Turkey.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_removeHoliday", Description="Create a Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Turkey",Description = "Reference to Turkey")>] 
         turkey : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Turkey = Helper.toCell<Turkey> turkey "Turkey"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Turkey.cell :?> TurkeyModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Turkey) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Turkey.source + ".RemoveHoliday") 
                                               [| _Turkey.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Turkey.cell
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
    [<ExcelFunction(Name="_Turkey_Range", Description="Create a range of Turkey",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Turkey_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Turkey")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Turkey> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Turkey>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Turkey>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Turkey>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
