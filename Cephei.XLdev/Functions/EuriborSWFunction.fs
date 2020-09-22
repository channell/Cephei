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
  1-week %Euribor index
  </summary> *)
[<AutoSerializable(true)>]
module EuriborSWFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EuriborSW", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EuriborSW 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSW>) l

                let source = Helper.sourceFold "Fun.EuriborSW" 
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
    [<ExcelFunction(Name="_EuriborSW1", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.EuriborSW1 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EuriborSW>) l

                let source = Helper.sourceFold "Fun.EuriborSW1" 
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
        Inspectors
    *)
    [<ExcelFunction(Name="_EuriborSW_businessDayConvention", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".BusinessDayConvention") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_clone", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".Clone") 
                                               [| _EuriborSW.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_endOfMonth", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".EndOfMonth") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_forecastFixing", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".ForecastFixing") 
                                               [| _EuriborSW.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_forecastFixing", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".ForecastFixing1") 
                                               [| _EuriborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_forwardingTermStructure", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".ForwardingTermStructure") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_maturityDate", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".MaturityDate") 
                                               [| _EuriborSW.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_currency", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".Currency") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_dayCounter", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".DayCounter") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_familyName", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".FamilyName") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_fixing", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".Fixing") 
                                               [| _EuriborSW.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_fixingCalendar", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".FixingCalendar") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_fixingDate", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".FixingDate") 
                                               [| _EuriborSW.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_fixingDays", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".FixingDays") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_isValidFixingDate", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".IsValidFixingDate") 
                                               [| _EuriborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_name", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".Name") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_pastFixing", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".PastFixing") 
                                               [| _EuriborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_tenor", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EuriborSW.source + ".Tenor") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_update", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).Update
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".Update") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_valueDate", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".ValueDate") 
                                               [| _EuriborSW.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_addFixing", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".AddFixing") 
                                               [| _EuriborSW.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_addFixings", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".AddFixings") 
                                               [| _EuriborSW.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_addFixings", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".AddFixings1") 
                                               [| _EuriborSW.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_allowsNativeFixings", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".AllowsNativeFixings") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_clearFixings", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).ClearFixings
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".ClearFixings") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_registerWith", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".RegisterWith") 
                                               [| _EuriborSW.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_timeSeries", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".TimeSeries") 
                                               [| _EuriborSW.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_unregisterWith", Description="Create a EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EuriborSW",Description = "Reference to EuriborSW")>] 
         euriborsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EuriborSW = Helper.toCell<EuriborSW> euriborsw "EuriborSW" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EuriborSW.cell :?> EuriborSWModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EuriborSW) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EuriborSW.source + ".UnregisterWith") 
                                               [| _EuriborSW.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EuriborSW.cell
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
    [<ExcelFunction(Name="_EuriborSW_Range", Description="Create a range of EuriborSW",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EuriborSW_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EuriborSW")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EuriborSW> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EuriborSW>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EuriborSW>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EuriborSW>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
