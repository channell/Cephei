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
  Danish Krona LIBOR discontinued as of 2013.
  </summary> *)
[<AutoSerializable(true)>]
module DKKLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DKKLibor", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_create
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
                let builder () = withMnemonic mnemonic (Fun.DKKLibor 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DKKLibor>) l

                let source = Helper.sourceFold "Fun.DKKLibor" 
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
    [<ExcelFunction(Name="_DKKLibor1", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let builder () = withMnemonic mnemonic (Fun.DKKLibor1 
                                                            _tenor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DKKLibor>) l

                let source = Helper.sourceFold "Fun.DKKLibor1" 
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
    [<ExcelFunction(Name="_DKKLibor_clone", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".Clone") 
                                               [| _DKKLibor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_maturityDate", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".MaturityDate") 
                                               [| _DKKLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_valueDate", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".ValueDate") 
                                               [| _DKKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_businessDayConvention", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".BusinessDayConvention") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_endOfMonth", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".EndOfMonth") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_forecastFixing", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".ForecastFixing") 
                                               [| _DKKLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_forecastFixing", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".ForecastFixing1") 
                                               [| _DKKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_forwardingTermStructure", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".ForwardingTermStructure") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_currency", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".Currency") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_dayCounter", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".DayCounter") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_familyName", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".FamilyName") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_fixing", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".Fixing") 
                                               [| _DKKLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_fixingCalendar", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".FixingCalendar") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_fixingDate", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".FixingDate") 
                                               [| _DKKLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_fixingDays", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".FixingDays") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_isValidFixingDate", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".IsValidFixingDate") 
                                               [| _DKKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_name", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".Name") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_pastFixing", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".PastFixing") 
                                               [| _DKKLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_tenor", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_DKKLibor.source + ".Tenor") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_update", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).Update
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".Update") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_addFixing", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".AddFixing") 
                                               [| _DKKLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_addFixings", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".AddFixings") 
                                               [| _DKKLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_addFixings", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".AddFixings1") 
                                               [| _DKKLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_allowsNativeFixings", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".AllowsNativeFixings") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_clearFixings", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".ClearFixings") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_registerWith", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".RegisterWith") 
                                               [| _DKKLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_timeSeries", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".TimeSeries") 
                                               [| _DKKLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_unregisterWith", Description="Create a DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DKKLibor",Description = "Reference to DKKLibor")>] 
         dkklibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DKKLibor = Helper.toCell<DKKLibor> dkklibor "DKKLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DKKLibor.cell :?> DKKLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DKKLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DKKLibor.source + ".UnregisterWith") 
                                               [| _DKKLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DKKLibor.cell
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
    [<ExcelFunction(Name="_DKKLibor_Range", Description="Create a range of DKKLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DKKLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DKKLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DKKLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DKKLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DKKLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DKKLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
