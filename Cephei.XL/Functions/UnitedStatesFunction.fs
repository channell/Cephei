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
  Public holidays (see: http://www.opm.gov/fedhol/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday, or to Friday if on Saturday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1983)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the stock exchange (data from http://www.nyse.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1998)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Presidential election day, first Tuesday in November of election years (until 1980)</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Special historic closings (see http://www.nyse.com/pdfs/closings.pdf)</li>
</ul>  Holidays for the government bond market (data from http://www.bondmarkets.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the North American Energy Reliability Council (data from http://www.nerc.com/~oc/offpeaks.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday)</li>
</ul>  the correctness of the returned results is tested against a list of known holidays.
  </summary> *)
[<AutoSerializable(true)>]
module UnitedStatesFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UnitedStates", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m",Description = "UnitedStates.Market: Settlement, NYSE, GovernmentBond, NERC")>] 
         m : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m = Helper.toCell<UnitedStates.Market> m "m" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UnitedStates 
                                                            _m.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UnitedStates>) l

                let source () = Helper.sourceFold "Fun.UnitedStates" 
                                               [| _m.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UnitedStates> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedStates1", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.UnitedStates1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UnitedStates>) l

                let source () = Helper.sourceFold "Fun.UnitedStates1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UnitedStates> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedStates_addedHolidays", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_UnitedStates.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedStates_addHoliday", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : UnitedStates) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_adjust", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_advance1", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
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

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_advance", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
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

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_businessDaysBetween", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
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

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_calendar", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_UnitedStates.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UnitedStates> format
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
    [<ExcelFunction(Name="_UnitedStates_empty", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_endOfMonth", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_Equals", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_isBusinessDay", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_isEndOfMonth", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_isHoliday", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_isWeekend", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_name", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_removedHolidays", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_UnitedStates.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UnitedStates_removeHoliday", Description="Create a UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UnitedStates",Description = "UnitedStates")>] 
         unitedstates : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UnitedStates = Helper.toCell<UnitedStates> unitedstates "UnitedStates"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((UnitedStatesModel.Cast _UnitedStates.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : UnitedStates) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UnitedStates.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UnitedStates.cell
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
    [<ExcelFunction(Name="_UnitedStates_Range", Description="Create a range of UnitedStates",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UnitedStates_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UnitedStates> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<UnitedStates> (c)) :> ICell
                let format (i : Cephei.Cell.List<UnitedStates>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<UnitedStates>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
