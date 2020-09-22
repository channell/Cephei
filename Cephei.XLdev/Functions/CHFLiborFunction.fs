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
  Swiss Franc LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.  This is the rate fixed in London by BBA. Use ZIBOR if you're interested in the Zurich fixing.
  </summary> *)
[<AutoSerializable(true)>]
module CHFLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CHFLibor", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_create
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
                let builder () = withMnemonic mnemonic (Fun.CHFLibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CHFLibor>) l

                let source = Helper.sourceFold "Fun.CHFLibor" 
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
    [<ExcelFunction(Name="_CHFLibor1", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.CHFLibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CHFLibor>) l

                let source = Helper.sourceFold "Fun.CHFLibor1" 
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
    [<ExcelFunction(Name="_CHFLibor_clone", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".Clone") 
                                               [| _CHFLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_maturityDate", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".MaturityDate") 
                                               [| _CHFLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_valueDate", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".ValueDate") 
                                               [| _CHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_businessDayConvention", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".BusinessDayConvention") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_endOfMonth", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".EndOfMonth") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_forecastFixing", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".ForecastFixing") 
                                               [| _CHFLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_forecastFixing", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".ForecastFixing1") 
                                               [| _CHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_forwardingTermStructure", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".ForwardingTermStructure") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_currency", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".Currency") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_dayCounter", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".DayCounter") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_familyName", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".FamilyName") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_fixing", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".Fixing") 
                                               [| _CHFLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_fixingCalendar", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".FixingCalendar") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_fixingDate", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".FixingDate") 
                                               [| _CHFLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_fixingDays", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".FixingDays") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_isValidFixingDate", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".IsValidFixingDate") 
                                               [| _CHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_name", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".Name") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_pastFixing", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".PastFixing") 
                                               [| _CHFLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_tenor", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_CHFLibor.source + ".Tenor") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_update", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).Update
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".Update") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_addFixing", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".AddFixing") 
                                               [| _CHFLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_addFixings", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".AddFixings") 
                                               [| _CHFLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_addFixings", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".AddFixings1") 
                                               [| _CHFLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_allowsNativeFixings", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".AllowsNativeFixings") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_clearFixings", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".ClearFixings") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_registerWith", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".RegisterWith") 
                                               [| _CHFLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_timeSeries", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".TimeSeries") 
                                               [| _CHFLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_unregisterWith", Description="Create a CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CHFLibor",Description = "Reference to CHFLibor")>] 
         chflibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CHFLibor = Helper.toCell<CHFLibor> chflibor "CHFLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CHFLibor.cell :?> CHFLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CHFLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CHFLibor.source + ".UnregisterWith") 
                                               [| _CHFLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CHFLibor.cell
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
    [<ExcelFunction(Name="_CHFLibor_Range", Description="Create a range of CHFLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CHFLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CHFLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CHFLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CHFLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CHFLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CHFLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
