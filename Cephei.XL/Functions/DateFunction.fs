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
    [<ExcelFunction(Name="_Date_CompareTo", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="obj",Description = "Object")>] 
         obj : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let _obj = Helper.toCell<Object> obj "obj" 
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).CompareTo
                                                            _obj.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".CompareTo") 

                                               [| _obj.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _obj.cell
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
    [<ExcelFunction(Name="_Date4", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "DateTime")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<DateTime> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date4 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date4" 
                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Date5", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "int")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "int")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "int")>] 
         y : obj)
        ([<ExcelArgument(Name="h",Description = "int or empty")>] 
         h : obj)
        ([<ExcelArgument(Name="mi",Description = "int or empty")>] 
         mi : obj)
        ([<ExcelArgument(Name="s",Description = "int or empty")>] 
         s : obj)
        ([<ExcelArgument(Name="ms",Description = "int or empty")>] 
         ms : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" 
                let _m = Helper.toCell<int> m "m" 
                let _y = Helper.toCell<int> y "y" 
                let _h = Helper.toDefault<int> h "h" 0
                let _mi = Helper.toDefault<int> mi "mi" 0
                let _s = Helper.toDefault<int> s "s" 0
                let _ms = Helper.toDefault<int> ms "ms" 0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date5
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                            _h.cell 
                                                            _mi.cell 
                                                            _s.cell 
                                                            _ms.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Date3", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "int")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "int")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "int")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" 
                let _m = Helper.toCell<int> m "m" 
                let _y = Helper.toCell<int> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date3 
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date3" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Date2", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="d",Description = "int")>] 
         d : obj)
        ([<ExcelArgument(Name="m",Description = "Month: January, February, March, April, May, June, July, August, September, October, November, December, Jan, Feb, Mar, Apr, Jun, Jul, Aug, Sep, Oct, Nov, Dec")>] 
         m : obj)
        ([<ExcelArgument(Name="y",Description = "int")>] 
         y : obj)
        ([<ExcelArgument(Name="h",Description = "int or empty")>] 
         h : obj)
        ([<ExcelArgument(Name="mi",Description = "int or empty")>] 
         mi : obj)
        ([<ExcelArgument(Name="s",Description = "int or empty")>] 
         s : obj)
        ([<ExcelArgument(Name="ms",Description = "int or empty")>] 
         ms : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _d = Helper.toCell<int> d "d" 
                let _m = Helper.toCell<Month> m "m" 
                let _y = Helper.toCell<int> y "y" 
                let _h = Helper.toDefault<int> h "h" 0
                let _mi = Helper.toDefault<int> mi "mi" 0
                let _s = Helper.toDefault<int> s "s" 0
                let _ms = Helper.toDefault<int> ms "ms" 0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date2
                                                            _d.cell 
                                                            _m.cell 
                                                            _y.cell 
                                                            _h.cell 
                                                            _mi.cell 
                                                            _s.cell 
                                                            _ms.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date2" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
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
    [<ExcelFunction(Name="_Date1", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="serialNumber",Description = "int")>] 
         serialNumber : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _serialNumber = Helper.toCell<int> serialNumber "serialNumber" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date1
                                                            _serialNumber.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date1" 
                                               [| _serialNumber.source
                                               |]
                let hash = Helper.hashFold 
                                [| _serialNumber.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
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
    [<ExcelFunction(Name="_Date", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Date ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Date>) l

                let source () = Helper.sourceFold "Fun.Date" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Date> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Date_Day", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_Day
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Day
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Day") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
        QL compatible definition
    *)
    [<ExcelFunction(Name="_Date_DayOfWeek", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_DayOfWeek
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).DayOfWeek
                                                       ) :> ICell
                let format (o : DayOfWeek) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".DayOfWeek") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_DayOfYear", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_DayOfYear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).DayOfYear
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".DayOfYear") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Equals", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".Equals") 

                                               [| _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
        
    *)
    [<ExcelFunction(Name="_Date_fractionOfDay", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_fractionOfDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).FractionOfDay
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".FractionOfDay") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_fractionOfSecond", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_fractionOfSecond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).FractionOfSecond
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".FractionOfSecond") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_hours", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_hours
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Hours
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Hours") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_milliseconds", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_milliseconds
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Milliseconds
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Milliseconds") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_minutes", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_minutes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Minutes
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Minutes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Month", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_Month
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Month
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Month") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_seconds", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_seconds
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel1.Cast _Date.cell).Seconds

                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Seconds") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_serialNumber", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_serialNumber
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).SerialNumber
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".SerialNumber") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToLongDateString", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToLongDateString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).ToLongDateString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToLongDateString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToShortDateString", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToShortDateString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).ToShortDateString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToShortDateString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_ToString2", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToString2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="format",Description = "string")>] 
         format : obj)
        ([<ExcelArgument(Name="provider",Description = "IFormatProvider")>] 
         provider : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let _format = Helper.toCell<string> format "format" 
                let _provider = Helper.toCell<IFormatProvider> provider "provider" 
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).ToString2 
                                                            _format.cell 
                                                            _provider.cell 
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToString2") 

                                               [| _format.source
                                               ;  _provider.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _format.cell
                                ;  _provider.cell
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
    [<ExcelFunction(Name="_Date_ToString3", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToString3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="format",Description = "string")>] 
         format : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let _format = Helper.toCell<string> format "format" 
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).ToString3
                                                            _format.cell 
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToString3") 

                                               [| _format.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _format.cell
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
    [<ExcelFunction(Name="_Date_ToString1", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToString1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        ([<ExcelArgument(Name="provider",Description = "IFormatProvider")>] 
         provider : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let _provider = Helper.toCell<IFormatProvider> provider "provider" 
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel1.Cast _Date.cell).ToString1
                                                            _provider.cell 
                                                       ) :> ICell

                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToString1") 

                                               [| _provider.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Date.cell
                                ;  _provider.cell
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
    [<ExcelFunction(Name="_Date_ToString", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Date.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_weekday", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_weekday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Weekday
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Weekday") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Year", Description="Create a Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_Year
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Date",Description = "Date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Date = Helper.toCell<Date> date "Date"  
                let builder (current : ICell) = withMnemonic mnemonic ((DateModel.Cast _Date.cell).Year
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Date.source + ".Year") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Date.cell
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
    [<ExcelFunction(Name="_Date_Range", Description="Create a range of Date",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Date_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Date> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Date>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Date>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
