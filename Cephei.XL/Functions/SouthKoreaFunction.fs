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
  Public holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Independence Day, March 1st</li>
<li>Arbour Day, April 5th (until 2005)</li>
<li>Labour Day, May 1st</li>
<li>Children's Day, May 5th</li>
<li>Memorial Day, June 6th</li>
<li>Constitution Day, July 17th (until 2007)</li>
<li>Liberation Day, August 15th</li>
<li>National Fondation Day, October 3th</li>
<li>Christmas Day, December 25th</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2032 only:)
<ul>
<li>Lunar New Year, the last day of the previous lunar year</li>
<li>Election Days</li>
<li>National Assemblies</li>
<li>Presidency</li>
<li>Regional Election Days</li>
<li>Buddha's birthday</li>
<li>Harvest Moon Day</li>
</ul>  Holidays for the Korea exchange (data from <http://www.krx.co.kr> or
<http://www.dooriworld.com/daishin/holiday/holiday.html>):
<ul>
<li>Public holidays as listed above</li>
<li>Year-end closing</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SouthKoreaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SouthKorea", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SouthKorea ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SouthKorea>) l

                let source = Helper.sourceFold "Fun.SouthKorea" 
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
    [<ExcelFunction(Name="_SouthKorea1", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<SouthKorea.Market> m "m" true
                let builder () = withMnemonic mnemonic (Fun.SouthKorea1 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SouthKorea>) l

                let source = Helper.sourceFold "Fun.SouthKorea1" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
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
        
    *)
    [<ExcelFunction(Name="_SouthKorea_addedHolidays", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SouthKorea.source + ".AddedHolidays") 
                                               [| _SouthKorea.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_addHoliday", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SouthKorea) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".AddHoliday") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_adjust", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Adjust") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_advance1", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
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

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Advance1") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_advance", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
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

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Advance") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_businessDaysBetween", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
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

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".BusinessDaysBetween") 
                                               [| _SouthKorea.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_calendar", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SouthKorea.source + ".Calendar") 
                                               [| _SouthKorea.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_empty", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Empty") 
                                               [| _SouthKorea.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_endOfMonth", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".EndOfMonth") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_Equals", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Equals") 
                                               [| _SouthKorea.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_isBusinessDay", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".IsBusinessDay") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_isEndOfMonth", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".IsEndOfMonth") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_isHoliday", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".IsHoliday") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_isWeekend", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".IsWeekend") 
                                               [| _SouthKorea.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_name", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".Name") 
                                               [| _SouthKorea.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_removedHolidays", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SouthKorea.source + ".RemovedHolidays") 
                                               [| _SouthKorea.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_removeHoliday", Description="Create a SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthKorea",Description = "Reference to SouthKorea")>] 
         southkorea : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthKorea = Helper.toCell<SouthKorea> southkorea "SouthKorea" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SouthKorea.cell :?> SouthKoreaModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SouthKorea) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SouthKorea.source + ".RemoveHoliday") 
                                               [| _SouthKorea.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthKorea.cell
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
    [<ExcelFunction(Name="_SouthKorea_Range", Description="Create a range of SouthKorea",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SouthKorea_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SouthKorea")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SouthKorea> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SouthKorea>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SouthKorea>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SouthKorea>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
