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
  Holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday)</li>
<li>Good Friday</li>
<li>Family Day, Easter Monday</li>
<li>Human Rights Day, March 21st (possibly moved to Monday)</li>
<li>Freedom Day, April 27th (possibly moved to Monday)</li>
<li>Workers Day, May 1st (possibly moved to Monday)</li>
<li>Youth Day, June 16th (possibly moved to Monday)</li>
<li>National Women's Day, August 9th (possibly moved to Monday)</li>
<li>Heritage Day, September 24th (possibly moved to Monday)</li>
<li>Day of Reconciliation, December 16th (possibly moved to Monday)</li>
<li>Christmas December 25th </li>
<li>Day of Goodwill December 26th (possibly moved to Monday)</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SouthAfricaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SouthAfrica", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SouthAfrica ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SouthAfrica>) l

                let source () = Helper.sourceFold "Fun.SouthAfrica" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SouthAfrica> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SouthAfrica_addedHolidays", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SouthAfrica.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_addHoliday", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SouthAfrica) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_adjust", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_advance1", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
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

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_advance", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
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

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_businessDaysBetween", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
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

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_calendar", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SouthAfrica> format
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
    [<ExcelFunction(Name="_SouthAfrica_empty", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_endOfMonth", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_Equals", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_isBusinessDay", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_isEndOfMonth", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_isHoliday", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_isWeekend", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_name", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_removedHolidays", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_SouthAfrica.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_removeHoliday", Description="Create a SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SouthAfrica",Description = "SouthAfrica")>] 
         southafrica : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SouthAfrica = Helper.toCell<SouthAfrica> southafrica "SouthAfrica"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SouthAfricaModel.Cast _SouthAfrica.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SouthAfrica) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SouthAfrica.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SouthAfrica.cell
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
    [<ExcelFunction(Name="_SouthAfrica_Range", Description="Create a range of SouthAfrica",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SouthAfrica_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SouthAfrica> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SouthAfrica> (c)) :> ICell
                let format (i : Generic.List<ICell<SouthAfrica>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SouthAfrica>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
