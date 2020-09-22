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
  1-year %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor1YFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor1Y", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor1Y 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor1Y>) l

                let source = Helper.sourceFold "Fun.EURLibor1Y" 
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
    [<ExcelFunction(Name="_EURLibor1Y1", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor1Y1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor1Y>) l

                let source = Helper.sourceFold "Fun.EURLibor1Y1" 
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
        
    *)
    [<ExcelFunction(Name="_EURLibor1Y_maturityDate", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".MaturityDate") 
                                               [| _EURLibor1Y.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_valueDate", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".ValueDate") 
                                               [| _EURLibor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_businessDayConvention", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".BusinessDayConvention") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_clone", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Clone") 
                                               [| _EURLibor1Y.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
                                ;  _forwarding.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_endOfMonth", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".EndOfMonth") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_forecastFixing1", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".ForecastFixing1") 
                                               [| _EURLibor1Y.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_forecastFixing", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".ForecastFixing") 
                                               [| _EURLibor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_forwardingTermStructure", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".ForwardingTermStructure") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_currency", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Currency") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_dayCounter", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".DayCounter") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_familyName", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".FamilyName") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_fixing", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Fixing") 
                                               [| _EURLibor1Y.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_fixingCalendar", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".FixingCalendar") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_fixingDate", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".FixingDate") 
                                               [| _EURLibor1Y.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_fixingDays", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".FixingDays") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_isValidFixingDate", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".IsValidFixingDate") 
                                               [| _EURLibor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_name", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Name") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_pastFixing", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".PastFixing") 
                                               [| _EURLibor1Y.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_tenor", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Tenor") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_update", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).Update
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".Update") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_addFixing", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".AddFixing") 
                                               [| _EURLibor1Y.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_addFixings", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".AddFixings") 
                                               [| _EURLibor1Y.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_addFixings1", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".AddFixings1") 
                                               [| _EURLibor1Y.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_allowsNativeFixings", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".AllowsNativeFixings") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_clearFixings", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".ClearFixings") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_registerWith", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".RegisterWith") 
                                               [| _EURLibor1Y.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_timeSeries", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".TimeSeries") 
                                               [| _EURLibor1Y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_unregisterWith", Description="Create a EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor1Y",Description = "Reference to EURLibor1Y")>] 
         eurlibor1y : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor1Y = Helper.toCell<EURLibor1Y> eurlibor1y "EURLibor1Y" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor1Y.cell :?> EURLibor1YModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor1Y) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor1Y.source + ".UnregisterWith") 
                                               [| _EURLibor1Y.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor1Y.cell
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
    [<ExcelFunction(Name="_EURLibor1Y_Range", Description="Create a range of EURLibor1Y",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor1Y_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor1Y")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor1Y> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor1Y>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor1Y>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor1Y>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
