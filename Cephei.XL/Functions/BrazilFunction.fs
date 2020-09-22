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
  Banking holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
</ul>  Holidays for the Bovespa stock exchange
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Sao Paulo City Day, January 25th</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Revolution Day, July 9th</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Black Consciousness Day, November 20th (since 2007)</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
<li>the last business day of the year</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.
  </summary> *)
[<AutoSerializable(true)>]
module BrazilFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Brazil1", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Brazil1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Brazil>) l

                let source = Helper.sourceFold "Fun.Brazil" 
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
    [<ExcelFunction(Name="_Brazil", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="market",Description = "Reference to market")>] 
         market : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _market = Helper.toCell<Brazil.Market> market "market" true
                let builder () = withMnemonic mnemonic (Fun.Brazil
                                                            _market.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Brazil>) l

                let source = Helper.sourceFold "Fun.Brazil" 
                                               [| _market.source
                                               |]
                let hash = Helper.hashFold 
                                [| _market.cell
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
    [<ExcelFunction(Name="_Brazil_addedHolidays", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Brazil.source + ".AddedHolidays") 
                                               [| _Brazil.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_addHoliday", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Brazil) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".AddHoliday") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_adjust", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Adjust") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_advance1", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
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

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Advance1") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_advance", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
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

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Advance") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_businessDaysBetween", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
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

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Brazil.source + ".BusinessDaysBetween") 
                                               [| _Brazil.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_calendar", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Brazil.source + ".Calendar") 
                                               [| _Brazil.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_empty", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Empty") 
                                               [| _Brazil.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_endOfMonth", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".EndOfMonth") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_Equals", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Equals") 
                                               [| _Brazil.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_isBusinessDay", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".IsBusinessDay") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_isEndOfMonth", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".IsEndOfMonth") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_isHoliday", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".IsHoliday") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_isWeekend", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".IsWeekend") 
                                               [| _Brazil.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_name", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".Name") 
                                               [| _Brazil.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_removedHolidays", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Brazil.source + ".RemovedHolidays") 
                                               [| _Brazil.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_removeHoliday", Description="Create a Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Brazil",Description = "Reference to Brazil")>] 
         brazil : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Brazil = Helper.toCell<Brazil> brazil "Brazil" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Brazil.cell :?> BrazilModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Brazil) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Brazil.source + ".RemoveHoliday") 
                                               [| _Brazil.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Brazil.cell
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
    [<ExcelFunction(Name="_Brazil_Range", Description="Create a range of Brazil",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Brazil_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Brazil")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Brazil> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Brazil>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Brazil>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Brazil>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
