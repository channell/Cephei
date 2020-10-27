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
  Overnight %GBP %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module GBPLiborONFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GBPLiborON", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GBPLiborON 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GBPLiborON>) l

                let source () = Helper.sourceFold "Fun.GBPLiborON" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_GBPLiborON_businessDayConvention", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_GBPLiborON_clone", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GBPLiborON_endOfMonth", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_forecastFixing1", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_GBPLiborON_forecastFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_GBPLiborON_forwardingTermStructure", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_GBPLiborON_maturityDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_GBPLiborON_currency", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GBPLiborON_dayCounter", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_GBPLiborON_familyName", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixingCalendar", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GBPLiborON_fixingDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_GBPLiborON_fixingDays", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_isValidFixingDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_GBPLiborON_name", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_pastFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_GBPLiborON_tenor", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GBPLiborON> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_GBPLiborON_update", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).Update
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_GBPLiborON_valueDate", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_GBPLiborON_addFixing", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_GBPLiborON_addFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_GBPLiborON_addFixings1", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_GBPLiborON_allowsNativeFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_GBPLiborON_clearFixings", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).ClearFixings
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_registerWith", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_GBPLiborON_timeSeries", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
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
    [<ExcelFunction(Name="_GBPLiborON_unregisterWith", Description="Create a GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLiborON",Description = "GBPLiborON")>] 
         gbpliboron : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLiborON = Helper.toCell<GBPLiborON> gbpliboron "GBPLiborON"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((GBPLiborONModel.Cast _GBPLiborON.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLiborON) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GBPLiborON.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLiborON.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_GBPLiborON_Range", Description="Create a range of GBPLiborON",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GBPLiborON_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GBPLiborON> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GBPLiborON>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GBPLiborON>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GBPLiborON>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
