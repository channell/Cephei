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
<li>New Year's Day, January 1st</li>
<li>Berchtoldstag, January 2nd</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Ascension Day</li>
<li>Whit Monday</li>
<li>Labour Day, May 1st</li>
<li>National Day, August 1st</li>
<li>Christmas, December 25th</li>
<li>St. Stephen's Day, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SwitzerlandFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Switzerland", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Switzerland ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Switzerland>) l

                let source () = Helper.sourceFold "Fun.Switzerland" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Switzerland> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Switzerland_addedHolidays", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Switzerland.source + ".AddedHolidays") 
                                               [| _Switzerland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_addHoliday", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Switzerland) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".AddHoliday") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_adjust", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Adjust") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_advance1", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
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

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Advance1") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_advance", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
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

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Advance") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_businessDaysBetween", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
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

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".BusinessDaysBetween") 
                                               [| _Switzerland.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_calendar", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Switzerland.source + ".Calendar") 
                                               [| _Switzerland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Switzerland> format
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
    [<ExcelFunction(Name="_Switzerland_empty", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Empty") 
                                               [| _Switzerland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_endOfMonth", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".EndOfMonth") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_Equals", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Equals") 
                                               [| _Switzerland.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_isBusinessDay", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".IsBusinessDay") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_isEndOfMonth", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".IsEndOfMonth") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_isHoliday", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".IsHoliday") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_isWeekend", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".IsWeekend") 
                                               [| _Switzerland.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_name", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".Name") 
                                               [| _Switzerland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_removedHolidays", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_Switzerland.source + ".RemovedHolidays") 
                                               [| _Switzerland.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_removeHoliday", Description="Create a Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Switzerland",Description = "Reference to Switzerland")>] 
         switzerland : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Switzerland = Helper.toCell<Switzerland> switzerland "Switzerland"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwitzerlandModel.Cast _Switzerland.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Switzerland) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Switzerland.source + ".RemoveHoliday") 
                                               [| _Switzerland.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Switzerland.cell
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
    [<ExcelFunction(Name="_Switzerland_Range", Description="Create a range of Switzerland",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Switzerland_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Switzerland")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Switzerland> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Switzerland>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Switzerland>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Switzerland>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
