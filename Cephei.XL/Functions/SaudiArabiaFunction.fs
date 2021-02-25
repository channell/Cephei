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
  Holidays for the Tadawul financial market (data from <http://www.tadawul.com.sa>):
<ul>
<li>Thursdays</li>
<li>Fridays</li>
<li>National Day of Saudi Arabia, September 23rd</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2011 only:)
<ul>
<li>Eid Al-Adha</li>
<li>Eid Al-Fitr</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SaudiArabiaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SaudiArabia", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.SaudiArabia ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SaudiArabia>) l

                let source () = Helper.sourceFold "Fun.SaudiArabia" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SaudiArabia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SaudiArabia_addedHolidays", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_SaudiArabia.source + ".AddedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_addHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SaudiArabia) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".AddHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_adjust", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention: Following, ModifiedFollowing, Preceding, ModifiedPreceding, Unadjusted, HalfMonthModifiedFollowing, Nearest")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Adjust") 

                                               [| _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_advance1", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Advance1") 

                                               [| _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_advance", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Advance") 

                                               [| _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_businessDaysBetween", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".BusinessDaysBetween") 

                                               [| _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_calendar", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Calendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SaudiArabia> format
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
    [<ExcelFunction(Name="_SaudiArabia_empty", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_endOfMonth", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".EndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_Equals", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isBusinessDay", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".IsBusinessDay") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isEndOfMonth", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".IsEndOfMonth") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".IsHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isWeekend", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".IsWeekend") 

                                               [| _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_name", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_removedHolidays", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<Date>) (l : string) = Helper.Range.fromList i l

                let source () = Helper.sourceFold (_SaudiArabia.source + ".RemovedHolidays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_removeHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toModelReference<SaudiArabia> saudiarabia "SaudiArabia"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = ((SaudiArabiaModel.Cast _SaudiArabia.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SaudiArabia) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SaudiArabia.source + ".RemoveHoliday") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_Range", Description="Create a range of SaudiArabia",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SaudiArabia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SaudiArabia> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SaudiArabia> (c)) :> ICell
                let format (i : Cephei.Cell.List<SaudiArabia>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SaudiArabia>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
