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
module WeekendsOnlyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_WeekendsOnly", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.WeekendsOnly ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<WeekendsOnly>) l

                let source = Helper.sourceFold "Fun.WeekendsOnly" 
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
    [<ExcelFunction(Name="_WeekendsOnly_addedHolidays", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_WeekendsOnly.source + ".AddedHolidays") 
                                               [| _WeekendsOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_addHoliday", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : WeekendsOnly) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".AddHoliday") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_adjust", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Adjust") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_advance1", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
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

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let _n = Helper.toCell<int> n "n" true
                let _unit = Helper.toCell<TimeUnit> unit "unit" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Advance1") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_advance", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
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

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let _p = Helper.toCell<Period> p "p" true
                let _c = Helper.toCell<BusinessDayConvention> c "c" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Advance") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_businessDaysBetween", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
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

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _from = Helper.toCell<Date> from "from" true
                let _To = Helper.toCell<Date> To "To" true
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" true
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".BusinessDaysBetween") 
                                               [| _WeekendsOnly.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_calendar", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Calendar") 
                                               [| _WeekendsOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_empty", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Empty") 
                                               [| _WeekendsOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_endOfMonth", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".EndOfMonth") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_Equals", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Equals") 
                                               [| _WeekendsOnly.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_isBusinessDay", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".IsBusinessDay") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_isEndOfMonth", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".IsEndOfMonth") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_isHoliday", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".IsHoliday") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_isWeekend", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _w = Helper.toCell<DayOfWeek> w "w" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".IsWeekend") 
                                               [| _WeekendsOnly.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_name", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".Name") 
                                               [| _WeekendsOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_removedHolidays", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_WeekendsOnly.source + ".RemovedHolidays") 
                                               [| _WeekendsOnly.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_removeHoliday", Description="Create a WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="WeekendsOnly",Description = "Reference to WeekendsOnly")>] 
         weekendsonly : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _WeekendsOnly = Helper.toCell<WeekendsOnly> weekendsonly "WeekendsOnly" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_WeekendsOnly.cell :?> WeekendsOnlyModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : WeekendsOnly) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_WeekendsOnly.source + ".RemoveHoliday") 
                                               [| _WeekendsOnly.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _WeekendsOnly.cell
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
    [<ExcelFunction(Name="_WeekendsOnly_Range", Description="Create a range of WeekendsOnly",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let WeekendsOnly_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the WeekendsOnly")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<WeekendsOnly> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<WeekendsOnly>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<WeekendsOnly>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<WeekendsOnly>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
