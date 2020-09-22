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
  2-weeks %EUR %Libor index
  </summary> *)
[<AutoSerializable(true)>]
module EURLibor2WFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EURLibor2W", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EURLibor2W 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor2W>) l

                let source = Helper.sourceFold "Fun.EURLibor2W" 
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
    [<ExcelFunction(Name="_EURLibor2W1", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EURLibor2W1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EURLibor2W>) l

                let source = Helper.sourceFold "Fun.EURLibor2W1" 
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
    [<ExcelFunction(Name="_EURLibor2W_maturityDate", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".MaturityDate") 
                                               [| _EURLibor2W.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_valueDate", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".ValueDate") 
                                               [| _EURLibor2W.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_businessDayConvention", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".BusinessDayConvention") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_clone", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".Clone") 
                                               [| _EURLibor2W.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_endOfMonth", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".EndOfMonth") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_forecastFixing", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".ForecastFixing") 
                                               [| _EURLibor2W.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_forecastFixing", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".ForecastFixing1") 
                                               [| _EURLibor2W.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_forwardingTermStructure", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".ForwardingTermStructure") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_currency", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".Currency") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_dayCounter", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".DayCounter") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_familyName", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".FamilyName") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_fixing", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".Fixing") 
                                               [| _EURLibor2W.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_fixingCalendar", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".FixingCalendar") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_fixingDate", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".FixingDate") 
                                               [| _EURLibor2W.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_fixingDays", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".FixingDays") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_isValidFixingDate", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".IsValidFixingDate") 
                                               [| _EURLibor2W.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_name", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".Name") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_pastFixing", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".PastFixing") 
                                               [| _EURLibor2W.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_tenor", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EURLibor2W.source + ".Tenor") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_update", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).Update
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".Update") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_addFixing", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".AddFixing") 
                                               [| _EURLibor2W.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_addFixings", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".AddFixings") 
                                               [| _EURLibor2W.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_addFixings", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".AddFixings1") 
                                               [| _EURLibor2W.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_allowsNativeFixings", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".AllowsNativeFixings") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_clearFixings", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).ClearFixings
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".ClearFixings") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_registerWith", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".RegisterWith") 
                                               [| _EURLibor2W.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_timeSeries", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".TimeSeries") 
                                               [| _EURLibor2W.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_unregisterWith", Description="Create a EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EURLibor2W",Description = "Reference to EURLibor2W")>] 
         eurlibor2w : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EURLibor2W = Helper.toCell<EURLibor2W> eurlibor2w "EURLibor2W" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EURLibor2W.cell :?> EURLibor2WModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EURLibor2W) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EURLibor2W.source + ".UnregisterWith") 
                                               [| _EURLibor2W.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EURLibor2W.cell
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
    [<ExcelFunction(Name="_EURLibor2W_Range", Description="Create a range of EURLibor2W",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EURLibor2W_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EURLibor2W")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EURLibor2W> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EURLibor2W>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EURLibor2W>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EURLibor2W>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
