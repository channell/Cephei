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
module SoniaFunction =

    (*
        ! %Sonia (Sterling Overnight Index Average) rate.
    *)
    [<ExcelFunction(Name="_Sonia", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Sonia 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Sonia>) l

                let source = Helper.sourceFold "Fun.Sonia" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
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
    [<ExcelFunction(Name="_Sonia_clone", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source = Helper.sourceFold (_Sonia.source + ".Clone") 
                                               [| _Sonia.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
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
    [<ExcelFunction(Name="_Sonia_businessDayConvention", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".BusinessDayConvention") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_endOfMonth", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".EndOfMonth") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_forecastFixing1", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Sonia.source + ".ForecastFixing1") 
                                               [| _Sonia.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_forecastFixing", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Sonia.source + ".ForecastFixing") 
                                               [| _Sonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_forwardingTermStructure", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Sonia.source + ".ForwardingTermStructure") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
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
    [<ExcelFunction(Name="_Sonia_maturityDate", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".MaturityDate") 
                                               [| _Sonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_currency", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Sonia.source + ".Currency") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Sonia_dayCounter", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Sonia.source + ".DayCounter") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
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
    [<ExcelFunction(Name="_Sonia_familyName", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".FamilyName") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_fixing", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Sonia.source + ".Fixing") 
                                               [| _Sonia.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_fixingCalendar", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Sonia.source + ".FixingCalendar") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Sonia_fixingDate", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".FixingDate") 
                                               [| _Sonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_fixingDays", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Sonia.source + ".FixingDays") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_isValidFixingDate", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".IsValidFixingDate") 
                                               [| _Sonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_name", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".Name") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_pastFixing", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".PastFixing") 
                                               [| _Sonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_tenor", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Sonia.source + ".Tenor") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Sonia> format
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
    [<ExcelFunction(Name="_Sonia_update", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).Update
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".Update") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_valueDate", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".ValueDate") 
                                               [| _Sonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_addFixing", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".AddFixing") 
                                               [| _Sonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_addFixings", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".AddFixings") 
                                               [| _Sonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_addFixings1", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".AddFixings1") 
                                               [| _Sonia.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_allowsNativeFixings", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".AllowsNativeFixings") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_clearFixings", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).ClearFixings
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".ClearFixings") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_registerWith", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".RegisterWith") 
                                               [| _Sonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_timeSeries", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".TimeSeries") 
                                               [| _Sonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_unregisterWith", Description="Create a Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Sonia",Description = "Reference to Sonia")>] 
         sonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Sonia = Helper.toCell<Sonia> sonia "Sonia"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Sonia.cell :?> SoniaModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Sonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Sonia.source + ".UnregisterWith") 
                                               [| _Sonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Sonia.cell
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
    [<ExcelFunction(Name="_Sonia_Range", Description="Create a range of Sonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Sonia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Sonia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Sonia> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Sonia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Sonia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Sonia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
