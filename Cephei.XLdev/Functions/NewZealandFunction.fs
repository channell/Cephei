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
<li>New Year's Day, January 1st (possibly moved to Monday or Tuesday)</li>
<li>Day after New Year's Day, January 2st (possibly moved to Monday or Tuesday)</li>
<li>Anniversary Day, Monday nearest January 22nd</li>
<li>Waitangi Day. February 6th</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>ANZAC Day. April 25th</li>
<li>Queen's Birthday, first Monday in June</li>
<li>Labour Day, fourth Monday in October</li>
<li>Christmas, December 25th (possibly moved to Monday or Tuesday)</li>
<li>Boxing Day, December 26th (possibly moved to Monday or Tuesday)</li>
</ul> The holiday rules for New Zealand were documented by David Gilbert for IDB (http://www.jrefinery.com/ibd/)  calendars
  </summary> *)
[<AutoSerializable(true)>]
module NewZealandFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NewZealand", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NewZealand 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NewZealand>) l

                let source = Helper.sourceFold "Fun.NewZealand" 
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
    [<ExcelFunction(Name="_NewZealand_addedHolidays", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_NewZealand.source + ".AddedHolidays") 
                                               [| _NewZealand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_addHoliday", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : NewZealand) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".AddHoliday") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_adjust", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Adjust") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_advance", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
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

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Advance
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Advance") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_advance", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
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

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Advance1
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Advance1") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_businessDaysBetween", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
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

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".BusinessDaysBetween") 
                                               [| _NewZealand.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_calendar", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_NewZealand.source + ".Calendar") 
                                               [| _NewZealand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_empty", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Empty") 
                                               [| _NewZealand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_endOfMonth", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".EndOfMonth") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_Equals", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Equals") 
                                               [| _NewZealand.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_isBusinessDay", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".IsBusinessDay") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_isEndOfMonth", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".IsEndOfMonth") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_isHoliday", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".IsHoliday") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_isWeekend", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".IsWeekend") 
                                               [| _NewZealand.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_name", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".Name") 
                                               [| _NewZealand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_removedHolidays", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_NewZealand.source + ".RemovedHolidays") 
                                               [| _NewZealand.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_removeHoliday", Description="Create a NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NewZealand",Description = "Reference to NewZealand")>] 
         newzealand : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NewZealand = Helper.toCell<NewZealand> newzealand "NewZealand" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_NewZealand.cell :?> NewZealandModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : NewZealand) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NewZealand.source + ".RemoveHoliday") 
                                               [| _NewZealand.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NewZealand.cell
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
    [<ExcelFunction(Name="_NewZealand_Range", Description="Create a range of NewZealand",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NewZealand_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NewZealand")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NewZealand> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NewZealand>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NewZealand>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NewZealand>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
