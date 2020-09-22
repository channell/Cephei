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
  base class for the one day deposit ICE %JPY %LIBOR indexes
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorJPYLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorJPYLibor", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let builder () = withMnemonic mnemonic (Fun.DailyTenorJPYLibor 
                                                            _settlementDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorJPYLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorJPYLibor" 
                                               [| _settlementDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor1", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.DailyTenorJPYLibor1 
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorJPYLibor>) l

                let source = Helper.sourceFold "Fun.DailyTenorJPYLibor1" 
                                               [| _settlementDays.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_businessDayConvention", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_clone", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Clone") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_endOfMonth", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forecastFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forecastFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForecastFixing1") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forwardingTermStructure", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_maturityDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".MaturityDate") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_currency", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Currency") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_dayCounter", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".DayCounter") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_familyName", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FamilyName") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Fixing") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingCalendar", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingDate") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingDays", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingDays") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_isValidFixingDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_name", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Name") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_pastFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".PastFixing") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_tenor", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Tenor") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_update", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).Update
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Update") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_valueDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ValueDate") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixing") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixings") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixings1") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_allowsNativeFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_clearFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ClearFixings") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_registerWith", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".RegisterWith") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_timeSeries", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".TimeSeries") 
                                               [| _DailyTenorJPYLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_unregisterWith", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "Reference to DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_DailyTenorJPYLibor.cell :?> DailyTenorJPYLiborModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DailyTenorJPYLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorJPYLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_Range", Description="Create a range of DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DailyTenorJPYLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorJPYLibor> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorJPYLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorJPYLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DailyTenorJPYLibor>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
