﻿(*
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
  US Dollar LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.
  </summary> *)
[<AutoSerializable(true)>]
module USDLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor1", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.USDLibor1 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDLibor>) l

                let source = Helper.sourceFold "Fun.USDLibor1" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let builder () = withMnemonic mnemonic (Fun.USDLibor
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USDLibor>) l

                let source = Helper.sourceFold "Fun.USDLibor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Other methods
    *)
    [<ExcelFunction(Name="_USDLibor_clone", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_USDLibor.source + ".Clone") 
                                               [| _USDLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor_maturityDate", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".MaturityDate") 
                                               [| _USDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
        Date calculations  See <https://www.theice.com/marketdata/reports/170>.
    *)
    [<ExcelFunction(Name="_USDLibor_valueDate", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".ValueDate") 
                                               [| _USDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_USDLibor_businessDayConvention", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".BusinessDayConvention") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_endOfMonth", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".EndOfMonth") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_forecastFixing1", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".ForecastFixing1") 
                                               [| _USDLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_forecastFixing", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".ForecastFixing") 
                                               [| _USDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_forwardingTermStructure", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_USDLibor.source + ".ForwardingTermStructure") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor_currency", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_USDLibor.source + ".Currency") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor_dayCounter", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_USDLibor.source + ".DayCounter") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
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
    [<ExcelFunction(Name="_USDLibor_familyName", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".FamilyName") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_fixing", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".Fixing") 
                                               [| _USDLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_fixingCalendar", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_USDLibor.source + ".FixingCalendar") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USDLibor_fixingDate", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".FixingDate") 
                                               [| _USDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_fixingDays", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".FixingDays") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_isValidFixingDate", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".IsValidFixingDate") 
                                               [| _USDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_name", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".Name") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_pastFixing", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".PastFixing") 
                                               [| _USDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_tenor", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_USDLibor.source + ".Tenor") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USDLibor> format
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
    [<ExcelFunction(Name="_USDLibor_update", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).Update
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".Update") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_addFixing", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".AddFixing") 
                                               [| _USDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_addFixings", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".AddFixings") 
                                               [| _USDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_addFixings1", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".AddFixings1") 
                                               [| _USDLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_allowsNativeFixings", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".AllowsNativeFixings") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_clearFixings", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".ClearFixings") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_registerWith", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".RegisterWith") 
                                               [| _USDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_timeSeries", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".TimeSeries") 
                                               [| _USDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_unregisterWith", Description="Create a USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USDLibor",Description = "Reference to USDLibor")>] 
         usdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USDLibor = Helper.toCell<USDLibor> usdlibor "USDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_USDLibor.cell :?> USDLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USDLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_USDLibor.source + ".UnregisterWith") 
                                               [| _USDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USDLibor.cell
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
    [<ExcelFunction(Name="_USDLibor_Range", Description="Create a range of USDLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let USDLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the USDLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USDLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<USDLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<USDLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<USDLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"