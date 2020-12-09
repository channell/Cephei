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
  Euribor rate adjusted for the mismatch between the actual/360 convention used for Euribor and the actual/365 convention previously used by a few pre-EUR currencies.
  </summary> *)
[<AutoSerializable(true)>]
module Euribor365Function =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor3651", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Euribor3651 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor365>) l

                let source () = Helper.sourceFold "Fun.Euribor365" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Period")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Euribor365 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor365>) l

                let source () = Helper.sourceFold "Fun.Euribor3651" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_businessDayConvention", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_clone", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_endOfMonth", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forecastFixing1", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".ForecastFixing1") 

                                               [| _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forecastFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_forwardingTermStructure", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_maturityDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_currency", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_dayCounter", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_familyName", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixingCalendar", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor365_fixingDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_fixingDays", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_isValidFixingDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_name", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_pastFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_tenor", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_Euribor365.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor365> format
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
    [<ExcelFunction(Name="_Euribor365_update", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).Update
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_valueDate", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixing", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_addFixings1", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_allowsNativeFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_clearFixings", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_registerWith", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_timeSeries", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_unregisterWith", Description="Create a Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor365",Description = "Euribor365")>] 
         euribor365 : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor365 = Helper.toCell<Euribor365> euribor365 "Euribor365"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((Euribor365Model.Cast _Euribor365.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor365) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Euribor365.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor365.cell
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
    [<ExcelFunction(Name="_Euribor365_Range", Description="Create a range of Euribor365",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Euribor365_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor365> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Euribor365> (c)) :> ICell
                let format (i : Generic.List<ICell<Euribor365>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Euribor365>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
