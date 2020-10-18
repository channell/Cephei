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

  </summary> *)
[<AutoSerializable(true)>]
module JointCalendarFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar4", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        ([<ExcelArgument(Name="c3",Description = "Calendar")>] 
         c3 : obj)
        ([<ExcelArgument(Name="c4",Description = "Calendar")>] 
         c4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let _c3 = Helper.toCell<Calendar> c3 "c3" 
                let _c4 = Helper.toCell<Calendar> c4 "c4" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar4 
                                                            _c1.cell 
                                                            _c2.cell 
                                                            _c3.cell 
                                                            _c4.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar4" 
                                               [| _c1.source
                                               ;  _c2.source
                                               ;  _c3.source
                                               ;  _c4.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                ;  _c3.cell
                                ;  _c4.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        ([<ExcelArgument(Name="r",Description = "JointCalendar.JointCalendarRule")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let _r = Helper.toCell<JointCalendar.JointCalendarRule> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar
                                                            _c1.cell 
                                                            _c2.cell 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar" 
                                               [| _c1.source
                                               ;  _c2.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar1", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        ([<ExcelArgument(Name="c3",Description = "Calendar")>] 
         c3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let _c3 = Helper.toCell<Calendar> c3 "c3" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar1
                                                            _c1.cell 
                                                            _c2.cell 
                                                            _c3.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar1" 
                                               [| _c1.source
                                               ;  _c2.source
                                               ;  _c3.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                ;  _c3.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar2", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        ([<ExcelArgument(Name="c3",Description = "Calendar")>] 
         c3 : obj)
        ([<ExcelArgument(Name="r",Description = "JointCalendar.JointCalendarRule")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let _c3 = Helper.toCell<Calendar> c3 "c3" 
                let _r = Helper.toCell<JointCalendar.JointCalendarRule> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar2
                                                            _c1.cell 
                                                            _c2.cell 
                                                            _c3.cell 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar2" 
                                               [| _c1.source
                                               ;  _c2.source
                                               ;  _c3.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                ;  _c3.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar3", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        ([<ExcelArgument(Name="c3",Description = "Calendar")>] 
         c3 : obj)
        ([<ExcelArgument(Name="c4",Description = "Calendar")>] 
         c4 : obj)
        ([<ExcelArgument(Name="r",Description = "JointCalendar.JointCalendarRule")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let _c3 = Helper.toCell<Calendar> c3 "c3" 
                let _c4 = Helper.toCell<Calendar> c4 "c4" 
                let _r = Helper.toCell<JointCalendar.JointCalendarRule> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar3
                                                            _c1.cell 
                                                            _c2.cell 
                                                            _c3.cell 
                                                            _c4.cell 
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar3" 
                                               [| _c1.source
                                               ;  _c2.source
                                               ;  _c3.source
                                               ;  _c4.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                ;  _c3.cell
                                ;  _c4.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Depending on the chosen rule, this calendar has a set of business days given by either the union or the intersection of the sets of business days of the given calendars. \test the correctness of the returned results is tested by reproducing the calculations.
    *)
    [<ExcelFunction(Name="_JointCalendar5", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "JointCalendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="c1",Description = "Calendar")>] 
         c1 : obj)
        ([<ExcelArgument(Name="c2",Description = "Calendar")>] 
         c2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _c1 = Helper.toCell<Calendar> c1 "c1" 
                let _c2 = Helper.toCell<Calendar> c2 "c2" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.JointCalendar5 
                                                            _c1.cell 
                                                            _c2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<JointCalendar>) l

                let source () = Helper.sourceFold "Fun.JointCalendar5" 
                                               [| _c1.source
                                               ;  _c2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _c1.cell
                                ;  _c2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_JointCalendar_addedHolidays", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_JointCalendar.source + ".AddedHolidays") 
                                               [| _JointCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_addHoliday", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : JointCalendar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".AddHoliday") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_adjust", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Adjust") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_advance1", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "TimeUnit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Advance1") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_advance", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Period")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "BusinessDayConvention")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "bool")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Advance") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_businessDaysBetween", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
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

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".BusinessDaysBetween") 
                                               [| _JointCalendar.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_calendar", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_JointCalendar.source + ".Calendar") 
                                               [| _JointCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<JointCalendar> format
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
    [<ExcelFunction(Name="_JointCalendar_empty", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Empty") 
                                               [| _JointCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_endOfMonth", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".EndOfMonth") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_Equals", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Equals") 
                                               [| _JointCalendar.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_isBusinessDay", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".IsBusinessDay") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_isEndOfMonth", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".IsEndOfMonth") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_isHoliday", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".IsHoliday") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_isWeekend", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="w",Description = "DayOfWeek")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".IsWeekend") 
                                               [| _JointCalendar.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_name", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".Name") 
                                               [| _JointCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_removedHolidays", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_JointCalendar.source + ".RemovedHolidays") 
                                               [| _JointCalendar.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_removeHoliday", Description="Create a JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="JointCalendar",Description = "JointCalendar")>] 
         jointcalendar : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _JointCalendar = Helper.toCell<JointCalendar> jointcalendar "JointCalendar"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((JointCalendarModel.Cast _JointCalendar.cell).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : JointCalendar) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_JointCalendar.source + ".RemoveHoliday") 
                                               [| _JointCalendar.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _JointCalendar.cell
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
    [<ExcelFunction(Name="_JointCalendar_Range", Description="Create a range of JointCalendar",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let JointCalendar_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<JointCalendar> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<JointCalendar>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<JointCalendar>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<JointCalendar>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
