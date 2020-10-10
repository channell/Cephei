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
  Base class for the one day deposit ICE %GBP %LIBOR indexes
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorGBPLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorGBPLibor", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorGBPLibor 
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorGBPLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorGBPLibor" 
                                               [| _settlementDays.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_businessDayConvention", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_clone", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Clone") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorGBPLibor_endOfMonth", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_forecastFixing1", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_forecastFixing", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_forwardingTermStructure", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_maturityDate", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".MaturityDate") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _valueDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_currency", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Currency") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorGBPLibor_dayCounter", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".DayCounter") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_familyName", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".FamilyName") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_fixing", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Fixing") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_fixingCalendar", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorGBPLibor_fixingDate", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".FixingDate") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _valueDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_fixingDays", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".FixingDays") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_isValidFixingDate", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_name", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Name") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_pastFixing", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".PastFixing") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_tenor", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Tenor") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorGBPLibor> format
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_update", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).Update
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".Update") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_valueDate", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".ValueDate") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _fixingDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_addFixing", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".AddFixing") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_addFixings", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".AddFixings") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_addFixings1", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".AddFixings") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_allowsNativeFixings", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_clearFixings", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".ClearFixings") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_registerWith", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".RegisterWith") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_timeSeries", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".TimeSeries") 
                                               [| _DailyTenorGBPLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_DailyTenorGBPLibor_unregisterWith", Description="Create a DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorGBPLibor",Description = "Reference to DailyTenorGBPLibor")>] 
         dailytenorgbplibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorGBPLibor = Helper.toCell<DailyTenorGBPLibor> dailytenorgbplibor "DailyTenorGBPLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorGBPLiborModel.Cast _DailyTenorGBPLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorGBPLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorGBPLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorGBPLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorGBPLibor.cell
                                ;  _handler.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DailyTenorGBPLibor_Range", Description="Create a range of DailyTenorGBPLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorGBPLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DailyTenorGBPLibor")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorGBPLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorGBPLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorGBPLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DailyTenorGBPLibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
