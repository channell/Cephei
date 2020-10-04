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
  Holidays: From the Botswana <a href="http://www.ilo.org/dyn/travail/docs/1766/Public%20Holidays%20Act.pdf">Public Holidays Act</a> The days named in the Schedule shall be public holidays within Botswana: Provided that
<ul>
<li>when any of the said days fall on a Sunday the following Monday shall be observed as a public holiday;</li>
<li>if 2nd January, 1st October or Boxing Day falls on a Monday, the following Tuesday shall be observed as a public holiday;</li>
<li>when Botswana Day referred to in the Schedule falls on a Saturday, the next following Monday shall be observed as a public holiday.</li>
</ul>
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Ascension</li>
<li>Sir Seretse Khama Day, July 1st</li>
<li>Presidents' Day</li>
<li>Independence Day, September 30th</li>
<li>Botswana Day, October 1st</li>
<li>Christmas, December 25th </li>
<li>Boxing Day, December 26th</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module BotswanaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Botswana", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Botswana ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Botswana>) l

                let source = Helper.sourceFold "Fun.Botswana" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Botswana> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Botswana_addedHolidays", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Botswana.source + ".AddedHolidays") 
                                               [| _Botswana.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_addHoliday", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Botswana) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".AddHoliday") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_adjust", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Adjust") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_advance1", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
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

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Advance1") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_advance", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
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

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Advance") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_businessDaysBetween", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
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

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Botswana.source + ".BusinessDaysBetween") 
                                               [| _Botswana.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_calendar", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Botswana.source + ".Calendar") 
                                               [| _Botswana.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Botswana> format
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
    [<ExcelFunction(Name="_Botswana_empty", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Empty") 
                                               [| _Botswana.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_endOfMonth", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".EndOfMonth") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_Equals", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Equals") 
                                               [| _Botswana.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_isBusinessDay", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".IsBusinessDay") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_isEndOfMonth", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".IsEndOfMonth") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_isHoliday", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".IsHoliday") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_isWeekend", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".IsWeekend") 
                                               [| _Botswana.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_name", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".Name") 
                                               [| _Botswana.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_removedHolidays", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Botswana.source + ".RemovedHolidays") 
                                               [| _Botswana.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_removeHoliday", Description="Create a Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Botswana",Description = "Reference to Botswana")>] 
         botswana : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Botswana = Helper.toCell<Botswana> botswana "Botswana"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((BotswanaModel.Cast _Botswana.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Botswana) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Botswana.source + ".RemoveHoliday") 
                                               [| _Botswana.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Botswana.cell
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
    [<ExcelFunction(Name="_Botswana_Range", Description="Create a range of Botswana",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Botswana_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Botswana")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Botswana> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Botswana>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Botswana>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Botswana>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
