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
module CADLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CADLibor1", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.CADLibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CADLibor>) l

                let source = Helper.sourceFold "Fun.CADLibor1" 
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
        
    *)
    [<ExcelFunction(Name="_CADLibor", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_create
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
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.CADLibor
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CADLibor>) l

                let source = Helper.sourceFold "Fun.CADLibor" 
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
        Other methods
    *)
    [<ExcelFunction(Name="_CADLibor_clone", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_CADLibor.source + ".Clone") 
                                               [| _CADLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_maturityDate", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".MaturityDate") 
                                               [| _CADLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_valueDate", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".ValueDate") 
                                               [| _CADLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_businessDayConvention", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".BusinessDayConvention") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_endOfMonth", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".EndOfMonth") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_forecastFixing1", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".ForecastFixing1") 
                                               [| _CADLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_forecastFixing", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".ForecastFixing") 
                                               [| _CADLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_forwardingTermStructure", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_CADLibor.source + ".ForwardingTermStructure") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_currency", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_CADLibor.source + ".Currency") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_dayCounter", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CADLibor.source + ".DayCounter") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_familyName", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".FamilyName") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_fixing", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".Fixing") 
                                               [| _CADLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_fixingCalendar", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CADLibor.source + ".FixingCalendar") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_fixingDate", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".FixingDate") 
                                               [| _CADLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_fixingDays", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".FixingDays") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_isValidFixingDate", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".IsValidFixingDate") 
                                               [| _CADLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_name", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".Name") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_pastFixing", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".PastFixing") 
                                               [| _CADLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_tenor", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_CADLibor.source + ".Tenor") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_update", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).Update
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".Update") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_addFixing", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".AddFixing") 
                                               [| _CADLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_addFixings", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".AddFixings") 
                                               [| _CADLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_addFixings1", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".AddFixings1") 
                                               [| _CADLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_allowsNativeFixings", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".AllowsNativeFixings") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_clearFixings", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".ClearFixings") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_registerWith", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".RegisterWith") 
                                               [| _CADLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_timeSeries", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".TimeSeries") 
                                               [| _CADLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_unregisterWith", Description="Create a CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CADLibor",Description = "Reference to CADLibor")>] 
         cadlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CADLibor = Helper.toCell<CADLibor> cadlibor "CADLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CADLibor.cell :?> CADLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CADLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CADLibor.source + ".UnregisterWith") 
                                               [| _CADLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CADLibor.cell
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
    [<ExcelFunction(Name="_CADLibor_Range", Description="Create a range of CADLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CADLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CADLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CADLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CADLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CADLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CADLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
