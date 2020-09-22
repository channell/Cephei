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
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Ascension Thursday</li>
<li>Whit Monday</li>
<li>Corpus Christi</li>
<li>Labour Day, May 1st</li>
<li>National Day, October 3rd</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Frankfurt Stock exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Xetra exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Eurex exchange (data from http://www.eurexchange.com/index.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Euwax exchange (data from http://www.boerse-stuttgart.de):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Whit Monday</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.
  </summary> *)
[<AutoSerializable(true)>]
module GermanyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Germany", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Germany 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Germany>) l

                let source = Helper.sourceFold "Fun.Germany" 
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
    [<ExcelFunction(Name="_Germany1", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Market> m "m" true
                let builder () = withMnemonic mnemonic (Fun.Germany1 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Germany>) l

                let source = Helper.sourceFold "Fun.Germany1" 
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
    [<ExcelFunction(Name="_Germany_addedHolidays", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Germany.source + ".AddedHolidays") 
                                               [| _Germany.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_addHoliday", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Germany) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".AddHoliday") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_adjust", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Adjust") 
                                               [| _Germany.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_advance", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
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

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Advance") 
                                               [| _Germany.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_advance", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
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

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Advance1") 
                                               [| _Germany.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_businessDaysBetween", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
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

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Germany.source + ".BusinessDaysBetween") 
                                               [| _Germany.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_calendar", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Germany.source + ".Calendar") 
                                               [| _Germany.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_empty", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Empty") 
                                               [| _Germany.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_endOfMonth", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Germany.source + ".EndOfMonth") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_Equals", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Equals") 
                                               [| _Germany.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_isBusinessDay", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".IsBusinessDay") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_isEndOfMonth", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".IsEndOfMonth") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_isHoliday", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".IsHoliday") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_isWeekend", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".IsWeekend") 
                                               [| _Germany.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_name", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".Name") 
                                               [| _Germany.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_removedHolidays", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Germany.source + ".RemovedHolidays") 
                                               [| _Germany.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_removeHoliday", Description="Create a Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Germany",Description = "Reference to Germany")>] 
         germany : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Germany = Helper.toCell<Germany> germany "Germany" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Germany.cell :?> GermanyModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Germany) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Germany.source + ".RemoveHoliday") 
                                               [| _Germany.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Germany.cell
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
    [<ExcelFunction(Name="_Germany_Range", Description="Create a range of Germany",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Germany_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Germany")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Germany> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Germany>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Germany>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Germany>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
