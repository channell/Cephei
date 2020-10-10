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
  Holidays for the National Stock Exchange (data from <http://www.nse-india.com/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>Republic Day, January 26th</li>
<li>Good Friday</li>
<li>Ambedkar Jayanti, April 14th</li>
<li>May Day, May 1st</li>
<li>Independence Day, August 15th</li>
<li>Gandhi Jayanti, October 2nd</li>
<li>Christmas, December 25th</li>
</ul>  Other holidays for which no rule is given (data available for 2005-2013 only:)
<ul>
<li>Bakri Id</li>
<li>Moharram</li>
<li>Mahashivratri</li>
<li>Holi</li>
<li>Ram Navami</li>
<li>Mahavir Jayanti</li>
<li>Id-E-Milad</li>
<li>Maharashtra Day</li>
<li>Buddha Pournima</li>
<li>Ganesh Chaturthi</li>
<li>Dasara</li>
<li>Laxmi Puja</li>
<li>Bhaubeej</li>
<li>Ramzan Id</li>
<li>Guru Nanak Jayanti</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module IndiaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_India", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.India ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<India>) l

                let source () = Helper.sourceFold "Fun.India" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<India> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_India_addedHolidays", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_India.source + ".AddedHolidays") 
                                               [| _India.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_addHoliday", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : India) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".AddHoliday") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_adjust", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_India.source + ".Adjust") 
                                               [| _India.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_advance1", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
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

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_India.source + ".Advance1") 
                                               [| _India.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_advance", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
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

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_India.source + ".Advance") 
                                               [| _India.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_businessDaysBetween", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
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

                let _India = Helper.toCell<India> india "India"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_India.source + ".BusinessDaysBetween") 
                                               [| _India.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_calendar", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_India.source + ".Calendar") 
                                               [| _India.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<India> format
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
    [<ExcelFunction(Name="_India_empty", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".Empty") 
                                               [| _India.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_endOfMonth", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_India.source + ".EndOfMonth") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_Equals", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".Equals") 
                                               [| _India.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_isBusinessDay", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".IsBusinessDay") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_isEndOfMonth", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".IsEndOfMonth") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_isHoliday", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".IsHoliday") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_isWeekend", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".IsWeekend") 
                                               [| _India.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_name", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".Name") 
                                               [| _India.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_removedHolidays", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_India.source + ".RemovedHolidays") 
                                               [| _India.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_removeHoliday", Description="Create a India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="India",Description = "Reference to India")>] 
         india : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _India = Helper.toCell<India> india "India"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((IndiaModel.Cast _India.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : India) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_India.source + ".RemoveHoliday") 
                                               [| _India.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _India.cell
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
    [<ExcelFunction(Name="_India_Range", Description="Create a range of India",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let India_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the India")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<India> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<India>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<India>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<India>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
