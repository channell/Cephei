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
1-year %Euribor index
  </summary> *)
[<AutoSerializable(true)>]
module Euribor1YFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1Y", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Euribor1Y 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor1Y>) l

                let source = Helper.sourceFold "Fun.Euribor1Y" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1Y1", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Euribor1Y1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Euribor1Y>) l

                let source = Helper.sourceFold "Fun.Euribor1Y1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
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
    [<ExcelFunction(Name="_Euribor1Y_businessDayConvention", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".BusinessDayConvention") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Euribor1Y_clone", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".Clone") 
                                               [| _Euribor1Y.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1Y_endOfMonth", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".EndOfMonth") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_forecastFixing1", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".ForecastFixing1") 
                                               [| _Euribor1Y.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Euribor1Y_forecastFixing", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".ForecastFixing") 
                                               [| _Euribor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_Euribor1Y_forwardingTermStructure", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".ForwardingTermStructure") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
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
    [<ExcelFunction(Name="_Euribor1Y_maturityDate", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".MaturityDate") 
                                               [| _Euribor1Y.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_Euribor1Y_currency", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".Currency") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1Y_dayCounter", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".DayCounter") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
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
    [<ExcelFunction(Name="_Euribor1Y_familyName", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".FamilyName") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_fixing", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".Fixing") 
                                               [| _Euribor1Y.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_Euribor1Y_fixingCalendar", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".FixingCalendar") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Euribor1Y_fixingDate", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".FixingDate") 
                                               [| _Euribor1Y.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_Euribor1Y_fixingDays", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".FixingDays") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_isValidFixingDate", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".IsValidFixingDate") 
                                               [| _Euribor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_Euribor1Y_name", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".Name") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_pastFixing", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".PastFixing") 
                                               [| _Euribor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_Euribor1Y_tenor", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Euribor1Y.source + ".Tenor") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Euribor1Y> format
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
    [<ExcelFunction(Name="_Euribor1Y_update", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).Update
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".Update") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_Euribor1Y_valueDate", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".ValueDate") 
                                               [| _Euribor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Euribor1Y_addFixing", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".AddFixing") 
                                               [| _Euribor1Y.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Euribor1Y_addFixings", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".AddFixings") 
                                               [| _Euribor1Y.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Euribor1Y_addFixings1", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".AddFixings1") 
                                               [| _Euribor1Y.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_Euribor1Y_allowsNativeFixings", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".AllowsNativeFixings") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_Euribor1Y_clearFixings", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).ClearFixings
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".ClearFixings") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_registerWith", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".RegisterWith") 
                                               [| _Euribor1Y.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_Euribor1Y_timeSeries", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".TimeSeries") 
                                               [| _Euribor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
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
    [<ExcelFunction(Name="_Euribor1Y_unregisterWith", Description="Create a Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Euribor1Y",Description = "Reference to Euribor1Y")>] 
         euribor1y : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Euribor1Y = Helper.toCell<Euribor1Y> euribor1y "Euribor1Y"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Euribor1Y.cell :?> Euribor1YModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Euribor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Euribor1Y.source + ".UnregisterWith") 
                                               [| _Euribor1Y.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Euribor1Y.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_Euribor1Y_Range", Description="Create a range of Euribor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Euribor1Y_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Euribor1Y")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Euribor1Y> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Euribor1Y>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Euribor1Y>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Euribor1Y>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
