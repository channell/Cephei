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
  Aonia (Australia Overnight Index Average) rate fixed by the RBA.  See <http://www.isda.org/publications/pdf/Supplement-13-to-2000DefinitionsAnnex.pdf>.
  </summary> *)
[<AutoSerializable(true)>]
module AoniaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Aonia", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Aonia 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Aonia>) l

                let source = Helper.sourceFold "Fun.Aonia" 
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
        ! returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Aonia_clone", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source = Helper.sourceFold (_Aonia.source + ".Clone") 
                                               [| _Aonia.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_businessDayConvention", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".BusinessDayConvention") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_endOfMonth", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".EndOfMonth") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_forecastFixing1", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Aonia.source + ".ForecastFixing1") 
                                               [| _Aonia.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    
    [<ExcelFunction(Name="_Aonia_forecastFixing", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Aonia.source + ".ForecastFixing") 
                                               [| _Aonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_forwardingTermStructure", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Aonia.source + ".ForwardingTermStructure") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_maturityDate", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".MaturityDate") 
                                               [| _Aonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_currency", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Aonia.source + ".Currency") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_dayCounter", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Aonia.source + ".DayCounter") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_familyName", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".FamilyName") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_fixing", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Aonia.source + ".Fixing") 
                                               [| _Aonia.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_fixingCalendar", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Aonia.source + ".FixingCalendar") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_fixingDate", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".FixingDate") 
                                               [| _Aonia.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_fixingDays", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Aonia.source + ".FixingDays") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_isValidFixingDate", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".IsValidFixingDate") 
                                               [| _Aonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_name", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".Name") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_pastFixing", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".PastFixing") 
                                               [| _Aonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_tenor", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Aonia.source + ".Tenor") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_update", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).Update
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".Update") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_valueDate", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".ValueDate") 
                                               [| _Aonia.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_addFixing", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".AddFixing") 
                                               [| _Aonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_addFixings", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".AddFixings") 
                                               [| _Aonia.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_addFixings1", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".AddFixings1") 
                                               [| _Aonia.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_allowsNativeFixings", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".AllowsNativeFixings") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_clearFixings", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).ClearFixings
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".ClearFixings") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_registerWith", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".RegisterWith") 
                                               [| _Aonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_timeSeries", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".TimeSeries") 
                                               [| _Aonia.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_unregisterWith", Description="Create a Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Aonia",Description = "Reference to Aonia")>] 
         aonia : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Aonia = Helper.toCell<Aonia> aonia "Aonia" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_Aonia.cell :?> AoniaModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Aonia) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Aonia.source + ".UnregisterWith") 
                                               [| _Aonia.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Aonia.cell
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
    [<ExcelFunction(Name="_Aonia_Range", Description="Create a range of Aonia",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Aonia_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Aonia")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Aonia> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Aonia>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Aonia>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Aonia>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
