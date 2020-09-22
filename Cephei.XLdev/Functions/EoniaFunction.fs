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
  %Eonia (Euro Overnight Index Average) rate fixed by the ECB.
  </summary> *)
[<AutoSerializable(true)>]
module EoniaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Eonia", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Eonia 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Eonia>) l

                let source = Helper.sourceFold "Fun.Eonia" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
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
    [<ExcelFunction(Name="_Eonia1", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Eonia1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Eonia>) l

                let source = Helper.sourceFold "Fun.Eonia1" 
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
        ! returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Eonia_clone", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source = Helper.sourceFold (_Eonia.source + ".Clone") 
                                               [| _Eonia.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
                                ;  _h.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Eonia_businessDayConvention", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".BusinessDayConvention") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_endOfMonth", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".EndOfMonth") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_forecastFixing", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Eonia.source + ".ForecastFixing") 
                                               [| _Eonia.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_forecastFixing", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Eonia.source + ".ForecastFixing1") 
                                               [| _Eonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_forwardingTermStructure", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Eonia.source + ".ForwardingTermStructure") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_Eonia_maturityDate", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".MaturityDate") 
                                               [| _Eonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_currency", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Eonia.source + ".Currency") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_dayCounter", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Eonia.source + ".DayCounter") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_Eonia_familyName", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".FamilyName") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_fixing", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Eonia.source + ".Fixing") 
                                               [| _Eonia.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_fixingCalendar", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Eonia.source + ".FixingCalendar") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_fixingDate", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".FixingDate") 
                                               [| _Eonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_fixingDays", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Eonia.source + ".FixingDays") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_isValidFixingDate", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".IsValidFixingDate") 
                                               [| _Eonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_name", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".Name") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_pastFixing", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".PastFixing") 
                                               [| _Eonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_tenor", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Eonia.source + ".Tenor") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_Eonia_update", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).Update
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".Update") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_valueDate", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".ValueDate") 
                                               [| _Eonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_addFixing", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".AddFixing") 
                                               [| _Eonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_addFixings", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".AddFixings") 
                                               [| _Eonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_addFixings", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".AddFixings1") 
                                               [| _Eonia.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_allowsNativeFixings", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".AllowsNativeFixings") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_clearFixings", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).ClearFixings
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".ClearFixings") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_registerWith", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".RegisterWith") 
                                               [| _Eonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_timeSeries", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".TimeSeries") 
                                               [| _Eonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_unregisterWith", Description="Create a Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Eonia",Description = "Reference to Eonia")>] 
         eonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Eonia = Helper.toCell<Eonia> eonia "Eonia" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Eonia.cell :?> EoniaModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Eonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Eonia.source + ".UnregisterWith") 
                                               [| _Eonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Eonia.cell
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
    [<ExcelFunction(Name="_Eonia_Range", Description="Create a range of Eonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Eonia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Eonia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Eonia> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Eonia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Eonia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Eonia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
