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
  Holidays for the Prague stock exchange (see http://www.pse.cz/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Liberation Day, May 8th</li>
<li>SS. Cyril and Methodius, July 5th</li>
<li>Jan Hus Day, July 6th</li>
<li>Czech Statehood Day, September 28th</li>
<li>Independence Day, October 28th</li>
<li>Struggle for Freedom and Democracy Day, November 17th</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>St. Stephen, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module CzechRepublicFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CzechRepublic", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.CzechRepublic 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CzechRepublic>) l

                let source = Helper.sourceFold "Fun.CzechRepublic" 
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
    [<ExcelFunction(Name="_CzechRepublic_addedHolidays", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CzechRepublic.source + ".AddedHolidays") 
                                               [| _CzechRepublic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_addHoliday", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : CzechRepublic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".AddHoliday") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_adjust", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Adjust") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_advance", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
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

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Advance") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_advance", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
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

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Advance1") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_businessDaysBetween", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
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

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".BusinessDaysBetween") 
                                               [| _CzechRepublic.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_calendar", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CzechRepublic.source + ".Calendar") 
                                               [| _CzechRepublic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_empty", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Empty") 
                                               [| _CzechRepublic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_endOfMonth", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".EndOfMonth") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_Equals", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Equals") 
                                               [| _CzechRepublic.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_isBusinessDay", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".IsBusinessDay") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_isEndOfMonth", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".IsEndOfMonth") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_isHoliday", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".IsHoliday") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_isWeekend", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".IsWeekend") 
                                               [| _CzechRepublic.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_name", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".Name") 
                                               [| _CzechRepublic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_removedHolidays", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CzechRepublic.source + ".RemovedHolidays") 
                                               [| _CzechRepublic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_removeHoliday", Description="Create a CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CzechRepublic",Description = "Reference to CzechRepublic")>] 
         czechrepublic : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CzechRepublic = Helper.toCell<CzechRepublic> czechrepublic "CzechRepublic" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_CzechRepublic.cell :?> CzechRepublicModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : CzechRepublic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CzechRepublic.source + ".RemoveHoliday") 
                                               [| _CzechRepublic.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CzechRepublic.cell
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
    [<ExcelFunction(Name="_CzechRepublic_Range", Description="Create a range of CzechRepublic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CzechRepublic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CzechRepublic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CzechRepublic> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CzechRepublic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CzechRepublic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CzechRepublic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
