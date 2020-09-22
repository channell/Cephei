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
    [<ExcelFunction(Name="_SaudiArabia", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SaudiArabia 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SaudiArabia>) l

                let source = Helper.sourceFold "Fun.SaudiArabia" 
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
    [<ExcelFunction(Name="_SaudiArabia_addedHolidays", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SaudiArabia.source + ".AddedHolidays") 
                                               [| _SaudiArabia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_addHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SaudiArabia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".AddHoliday") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_adjust", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Adjust") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_advance", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Advance") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_SaudiArabia_advance", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Advance1") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_SaudiArabia_businessDaysBetween", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
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

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".BusinessDaysBetween") 
                                               [| _SaudiArabia.source
                                               ;  _from.source
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
    [<ExcelFunction(Name="_SaudiArabia_calendar", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SaudiArabia.source + ".Calendar") 
                                               [| _SaudiArabia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_empty", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Empty") 
                                               [| _SaudiArabia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_endOfMonth", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".EndOfMonth") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_Equals", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Equals") 
                                               [| _SaudiArabia.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isBusinessDay", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".IsBusinessDay") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isEndOfMonth", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".IsEndOfMonth") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".IsHoliday") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_isWeekend", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".IsWeekend") 
                                               [| _SaudiArabia.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_name", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".Name") 
                                               [| _SaudiArabia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_removedHolidays", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SaudiArabia.source + ".RemovedHolidays") 
                                               [| _SaudiArabia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_removeHoliday", Description="Create a SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SaudiArabia",Description = "Reference to SaudiArabia")>] 
         saudiarabia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SaudiArabia = Helper.toCell<SaudiArabia> saudiarabia "SaudiArabia" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_SaudiArabia.cell :?> SaudiArabiaModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : SaudiArabia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SaudiArabia.source + ".RemoveHoliday") 
                                               [| _SaudiArabia.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SaudiArabia.cell
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
    [<ExcelFunction(Name="_SaudiArabia_Range", Description="Create a range of SaudiArabia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SaudiArabia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SaudiArabia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SaudiArabia> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SaudiArabia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SaudiArabia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SaudiArabia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
