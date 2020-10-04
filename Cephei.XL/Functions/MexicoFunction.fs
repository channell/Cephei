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
  Holidays for the Mexican stock exchange (data from <http://www.bmv.com.mx/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Constitution Day, first Monday in February (February 5th before 2006)</li>
<li>Birthday of Benito Juarez, third Monday in February (March 21st before 2006)</li>
<li>Holy Thursday</li>
<li>Good Friday</li>
<li>Labour Day, May 1st</li>
<li>National Day, September 16th</li>
<li>Revolution Day, third Monday in November (November 20th before 2006)</li>
<li>Our Lady of Guadalupe, December 12th</li>
<li>Christmas, December 25th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module MexicoFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Mexico", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Mexico ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Mexico>) l

                let source = Helper.sourceFold "Fun.Mexico" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Mexico> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Mexico_addedHolidays", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Mexico.source + ".AddedHolidays") 
                                               [| _Mexico.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_addHoliday", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Mexico) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".AddHoliday") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_adjust", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Adjust") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_advance1", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
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

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Advance") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_advance", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
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

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Advance") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_businessDaysBetween", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
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

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Mexico.source + ".BusinessDaysBetween") 
                                               [| _Mexico.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_calendar", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Mexico.source + ".Calendar") 
                                               [| _Mexico.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Mexico> format
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
    [<ExcelFunction(Name="_Mexico_empty", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Empty") 
                                               [| _Mexico.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_endOfMonth", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".EndOfMonth") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_Equals", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Equals") 
                                               [| _Mexico.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_isBusinessDay", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".IsBusinessDay") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_isEndOfMonth", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".IsEndOfMonth") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_isHoliday", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".IsHoliday") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_isWeekend", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".IsWeekend") 
                                               [| _Mexico.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_name", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".Name") 
                                               [| _Mexico.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_removedHolidays", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Mexico.source + ".RemovedHolidays") 
                                               [| _Mexico.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_removeHoliday", Description="Create a Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mexico",Description = "Reference to Mexico")>] 
         mexico : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Mexico = Helper.toCell<Mexico> mexico "Mexico"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((MexicoModel.Cast _Mexico.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Mexico) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Mexico.source + ".RemoveHoliday") 
                                               [| _Mexico.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Mexico.cell
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
    [<ExcelFunction(Name="_Mexico_Range", Description="Create a range of Mexico",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Mexico_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Mexico")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Mexico> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Mexico>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Mexico>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Mexico>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
