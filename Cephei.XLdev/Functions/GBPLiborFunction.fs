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
  Pound Sterling LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.
  </summary> *)
[<AutoSerializable(true)>]
module GBPLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GBPLibor", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.GBPLibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GBPLibor>) l

                let source = Helper.sourceFold "Fun.GBPLibor" 
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
    [<ExcelFunction(Name="_GBPLibor1", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.GBPLibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GBPLibor>) l

                let source = Helper.sourceFold "Fun.GBPLibor1" 
                                               [| _tenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_GBPLibor_clone", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".Clone") 
                                               [| _GBPLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
        
    *)
    [<ExcelFunction(Name="_GBPLibor_maturityDate", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".MaturityDate") 
                                               [| _GBPLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_valueDate", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".ValueDate") 
                                               [| _GBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_businessDayConvention", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".BusinessDayConvention") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_endOfMonth", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".EndOfMonth") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_forecastFixing", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".ForecastFixing") 
                                               [| _GBPLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_forecastFixing", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".ForecastFixing1") 
                                               [| _GBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_forwardingTermStructure", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".ForwardingTermStructure") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_currency", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".Currency") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_dayCounter", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".DayCounter") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_familyName", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".FamilyName") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_fixing", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".Fixing") 
                                               [| _GBPLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_fixingCalendar", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".FixingCalendar") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_fixingDate", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".FixingDate") 
                                               [| _GBPLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_fixingDays", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".FixingDays") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_isValidFixingDate", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".IsValidFixingDate") 
                                               [| _GBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_name", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".Name") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_pastFixing", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".PastFixing") 
                                               [| _GBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_tenor", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_GBPLibor.source + ".Tenor") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_update", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).Update
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".Update") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_addFixing", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".AddFixing") 
                                               [| _GBPLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_addFixings", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".AddFixings") 
                                               [| _GBPLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_addFixings", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".AddFixings1") 
                                               [| _GBPLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_allowsNativeFixings", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".AllowsNativeFixings") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_clearFixings", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".ClearFixings") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_registerWith", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".RegisterWith") 
                                               [| _GBPLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_timeSeries", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".TimeSeries") 
                                               [| _GBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_unregisterWith", Description="Create a GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GBPLibor",Description = "Reference to GBPLibor")>] 
         gbplibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GBPLibor = Helper.toCell<GBPLibor> gbplibor "GBPLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GBPLibor.cell :?> GBPLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GBPLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GBPLibor.source + ".UnregisterWith") 
                                               [| _GBPLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GBPLibor.cell
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
    [<ExcelFunction(Name="_GBPLibor_Range", Description="Create a range of GBPLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GBPLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GBPLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GBPLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GBPLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GBPLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GBPLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
