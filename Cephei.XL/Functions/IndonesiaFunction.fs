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
  Holidays for the Indonesia stock exchange (data from <http://www.idx.co.id/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Ascension of Jesus Christ</li>
<li>Independence Day, August 17th</li>
<li>Christmas, December 25th</li>
</ul>  Other holidays for which no rule is given (data available for 2005-2013 only:)
<ul>
<li>Idul Adha</li>
<li>Ied Adha</li>
<li>Imlek</li>
<li>Moslem's New Year Day</li>
<li>Chinese New Year</li>
<li>Nyepi (Saka's New Year)</li>
<li>Birthday of Prophet Muhammad SAW</li>
<li>Waisak</li>
<li>Ascension of Prophet Muhammad SAW</li>
<li>Idul Fitri</li>
<li>Ied Fitri</li>
<li>Other national leaves</li>
</ul> calendars
  </summary> *)
[<AutoSerializable(true)>]
module IndonesiaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Indonesia", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Indonesia.Market> m "m" true
                let builder () = withMnemonic mnemonic (Fun.Indonesia 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Indonesia>) l

                let source = Helper.sourceFold "Fun.Indonesia" 
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
    [<ExcelFunction(Name="_Indonesia1", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Indonesia1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Indonesia>) l

                let source = Helper.sourceFold "Fun.Indonesia1" 
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
    [<ExcelFunction(Name="_Indonesia_addedHolidays", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Indonesia.source + ".AddedHolidays") 
                                               [| _Indonesia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_addHoliday", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Indonesia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".AddHoliday") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_adjust", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Adjust") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_advance1", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
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

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Advance1") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_advance", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
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

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Advance") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_businessDaysBetween", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
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

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".BusinessDaysBetween") 
                                               [| _Indonesia.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_calendar", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Indonesia.source + ".Calendar") 
                                               [| _Indonesia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_empty", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Empty") 
                                               [| _Indonesia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_endOfMonth", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".EndOfMonth") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_Equals", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Equals") 
                                               [| _Indonesia.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_isBusinessDay", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".IsBusinessDay") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_isEndOfMonth", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".IsEndOfMonth") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_isHoliday", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".IsHoliday") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_isWeekend", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".IsWeekend") 
                                               [| _Indonesia.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_name", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".Name") 
                                               [| _Indonesia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_removedHolidays", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Indonesia.source + ".RemovedHolidays") 
                                               [| _Indonesia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_removeHoliday", Description="Create a Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Indonesia",Description = "Reference to Indonesia")>] 
         indonesia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Indonesia = Helper.toCell<Indonesia> indonesia "Indonesia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_Indonesia.cell :?> IndonesiaModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Indonesia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Indonesia.source + ".RemoveHoliday") 
                                               [| _Indonesia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Indonesia.cell
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
    [<ExcelFunction(Name="_Indonesia_Range", Description="Create a range of Indonesia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Indonesia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Indonesia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Indonesia> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Indonesia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Indonesia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Indonesia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
