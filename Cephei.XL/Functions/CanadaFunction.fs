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
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Family Day, third Monday of February (since 2008)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Victoria Day, The Monday on or preceding 24 May</li>
<li>Canada Day, July 1st (possibly moved to Monday)</li>
<li>Provincial Holiday, first Monday of August</li>
<li>Labour Day, first Monday of September</li>
<li>Thanksgiving Day, second Monday of October</li>
<li>Remembrance Day, November 11th (possibly moved to Monday)</li>
<li>Christmas, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  Holidays for the Toronto stock exchange (TSX):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Family Day, third Monday of February (since 2008)</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Victoria Day, The Monday on or preceding 24 May</li>
<li>Canada Day, July 1st (possibly moved to Monday)</li>
<li>Provincial Holiday, first Monday of August</li>
<li>Labour Day, first Monday of September</li>
<li>Thanksgiving Day, second Monday of October</li>
<li>Christmas, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module CanadaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Canada1", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Canada1 () 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Canada>) l

                let source = Helper.sourceFold "Fun.Canada1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Canada> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Canada", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<Canada.Market> m "m" 
                let builder () = withMnemonic mnemonic (Fun.Canada
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Canada>) l

                let source = Helper.sourceFold "Fun.Canada" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Canada> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Canada_addedHolidays", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Canada.source + ".AddedHolidays") 
                                               [| _Canada.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_addHoliday", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Canada) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".AddHoliday") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_adjust", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Adjust") 
                                               [| _Canada.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_advance1", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
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

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Advance1") 
                                               [| _Canada.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_advance", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
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

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Advance") 
                                               [| _Canada.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_businessDaysBetween", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
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

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Canada.source + ".BusinessDaysBetween") 
                                               [| _Canada.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_calendar", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Canada.source + ".Calendar") 
                                               [| _Canada.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Canada> format
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
    [<ExcelFunction(Name="_Canada_empty", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Empty") 
                                               [| _Canada.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_endOfMonth", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Canada.source + ".EndOfMonth") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_Equals", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Equals") 
                                               [| _Canada.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_isBusinessDay", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".IsBusinessDay") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_isEndOfMonth", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".IsEndOfMonth") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_isHoliday", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".IsHoliday") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_isWeekend", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".IsWeekend") 
                                               [| _Canada.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_name", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".Name") 
                                               [| _Canada.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_removedHolidays", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Canada.source + ".RemovedHolidays") 
                                               [| _Canada.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_removeHoliday", Description="Create a Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Canada",Description = "Reference to Canada")>] 
         canada : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Canada = Helper.toCell<Canada> canada "Canada"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((CanadaModel.Cast _Canada.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Canada) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Canada.source + ".RemoveHoliday") 
                                               [| _Canada.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Canada.cell
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
    [<ExcelFunction(Name="_Canada_Range", Description="Create a range of Canada",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Canada_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Canada")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Canada> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Canada>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Canada>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Canada>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
