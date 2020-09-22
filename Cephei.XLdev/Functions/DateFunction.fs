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
module DateFunction =

    (*
        IComparable interface
    *)
    [<ExcelFunction(Name="_Date_CompareTo", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        ([<ExcelArgument(Name="obj",Description = "Reference to obj")>] 
         obj : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let _obj = Helper.toCell<Object> obj "obj" true
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).CompareTo
                                                            _obj.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".CompareTo") 
                                               [| _Date.source
                                               ;  _obj.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _obj.cell
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
    [<ExcelFunction(Name="_Date", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<DateTime> d "d" true
                let builder () = withMnemonic mnemonic (Fun.Date 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date" 
                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
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
        
    *)
    [<ExcelFunction(Name="_Date1", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="mi",Description = "Reference to mi")>] 
         mi : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        ([<ExcelArgument(Name="ms",Description = "Reference to ms")>] 
         ms : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" true
                let _m = Helper.toCell<int> m "m" true
                let _y = Helper.toCell<int> y "y" true
                let _h = Helper.toCell<int> h "h" true
                let _mi = Helper.toCell<int> mi "mi" true
                let _s = Helper.toCell<int> s "s" true
                let _ms = Helper.toCell<int> ms "ms" true
                let builder () = withMnemonic mnemonic (Fun.Date1 
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                            _h.cell 
                                                            _mi.cell 
                                                            _s.cell 
                                                            _ms.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date1" 
                                               [| _d.source
                                               ;  _m.source
                                               ;  _y.source
                                               ;  _h.source
                                               ;  _mi.source
                                               ;  _s.source
                                               ;  _ms.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _m.cell
                                ;  _y.cell
                                ;  _h.cell
                                ;  _mi.cell
                                ;  _s.cell
                                ;  _ms.cell
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
        
    *)
    [<ExcelFunction(Name="_Date2", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" true
                let _m = Helper.toCell<int> m "m" true
                let _y = Helper.toCell<int> y "y" true
                let builder () = withMnemonic mnemonic (Fun.Date2 
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date2" 
                                               [| _d.source
                                               ;  _m.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _m.cell
                                ;  _y.cell
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
        
    *)
    [<ExcelFunction(Name="_Date3", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="mi",Description = "Reference to mi")>] 
         mi : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        ([<ExcelArgument(Name="ms",Description = "Reference to ms")>] 
         ms : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" true
                let _m = Helper.toCell<Month> m "m" true
                let _y = Helper.toCell<int> y "y" true
                let _h = Helper.toCell<int> h "h" true
                let _mi = Helper.toCell<int> mi "mi" true
                let _s = Helper.toCell<int> s "s" true
                let _ms = Helper.toCell<int> ms "ms" true
                let builder () = withMnemonic mnemonic (Fun.Date3 
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                            _h.cell 
                                                            _mi.cell 
                                                            _s.cell 
                                                            _ms.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date3" 
                                               [| _d.source
                                               ;  _m.source
                                               ;  _y.source
                                               ;  _h.source
                                               ;  _mi.source
                                               ;  _s.source
                                               ;  _ms.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                ;  _m.cell
                                ;  _y.cell
                                ;  _h.cell
                                ;  _mi.cell
                                ;  _s.cell
                                ;  _ms.cell
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
        ! Constructor taking a serial number as given by Excel. Serial numbers in Excel have a known problem with leap year 1900
    *)
    [<ExcelFunction(Name="_Date4", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="serialNumber",Description = "Reference to serialNumber")>] 
         serialNumber : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _serialNumber = Helper.toCell<int> serialNumber "serialNumber" true
                let builder () = withMnemonic mnemonic (Fun.Date4 
                                                            _serialNumber.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date4" 
                                               [| _serialNumber.source
                                               |]
                let hash = Helper.hashFold 
                                [| _serialNumber.cell
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
        ! Default constructor returning a null date.
    *)
    [<ExcelFunction(Name="_Date5", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Date5 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source = Helper.sourceFold "Fun.Date5" 
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
    [<ExcelFunction(Name="_Date_Day", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_Day
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Day
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Day") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
        QL compatible definition
    *)
    [<ExcelFunction(Name="_Date_DayOfWeek", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_DayOfWeek
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).DayOfWeek
                                                       ) :> ICell
                let format (o : DayOfWeek) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".DayOfWeek") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_DayOfYear", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_DayOfYear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).DayOfYear
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".DayOfYear") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Equals", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let _o = Helper.toCell<Object> o "o" true
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".Equals") 
                                               [| _Date.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
        
    *)
    [<ExcelFunction(Name="_Date_fractionOfDay", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_fractionOfDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).FractionOfDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".FractionOfDay") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_fractionOfSecond", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_fractionOfSecond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).FractionOfSecond
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".FractionOfSecond") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_hours", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_hours
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Hours
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Hours") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_milliseconds", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_milliseconds
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Milliseconds
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Milliseconds") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_minutes", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_minutes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Minutes
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Minutes") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_month", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_month
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Month
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Month") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Month", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_Month
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Month
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Month") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_seconds", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_seconds
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Seconds
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Seconds") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_serialNumber", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_serialNumber
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).SerialNumber
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".SerialNumber") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToLongDateString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToLongDateString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToLongDateString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToLongDateString") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToShortDateString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToShortDateString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToShortDateString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToShortDateString") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        ([<ExcelArgument(Name="format",Description = "Reference to format")>] 
         format : obj)
        ([<ExcelArgument(Name="provider",Description = "Reference to provider")>] 
         provider : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let _format = Helper.toCell<string> format "format" true
                let _provider = Helper.toCell<IFormatProvider> provider "provider" true
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToString
                                                            _format.cell 
                                                            _provider.cell 
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToString") 
                                               [| _Date.source
                                               ;  _format.source
                                               ;  _provider.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _format.cell
                                ;  _provider.cell
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
    [<ExcelFunction(Name="_Date_ToString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        ([<ExcelArgument(Name="format",Description = "Reference to format")>] 
         format : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let _format = Helper.toCell<string> format "format" true
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToString1
                                                            _format.cell 
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToString1") 
                                               [| _Date.source
                                               ;  _format.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _format.cell
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
    [<ExcelFunction(Name="_Date_ToString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        ([<ExcelArgument(Name="provider",Description = "Reference to provider")>] 
         provider : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let _provider = Helper.toCell<IFormatProvider> provider "provider" true
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToString2
                                                            _provider.cell 
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToString2") 
                                               [| _Date.source
                                               ;  _provider.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _provider.cell
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
    [<ExcelFunction(Name="_Date_ToString", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).ToString3
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Date.source + ".ToString3") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_weekday", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_weekday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Weekday
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Weekday") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_year", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_year
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Year
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Year") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Year", Description="Create a Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_Year
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Reference to Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date" true 
                let builder () = withMnemonic mnemonic ((_Date.cell :?> DateModel).Year
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Date.source + ".Year") 
                                               [| _Date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Range", Description="Create a range of Date",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Date_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Date")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Date> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Date>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Date>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
