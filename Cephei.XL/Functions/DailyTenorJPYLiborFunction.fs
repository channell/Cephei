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
    [<ExcelFunction(Name="_DailyTenorJPYLibor", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorJPYLibor 
                                                            _settlementDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorJPYLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorJPYLibor" 
                                               [| _settlementDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorJPYLibor1", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorJPYLibor1 
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorJPYLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorJPYLibor1" 
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
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_businessDayConvention", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".BusinessDayConvention") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_clone", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Clone") 

                                               [| _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorJPYLibor_endOfMonth", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".EndOfMonth") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forecastFixing1", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForecastFixing") 

                                               [| _d1.source
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forecastFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_forwardingTermStructure", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_maturityDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_currency", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorJPYLibor_dayCounter", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_familyName", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingCalendar", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_fixingDays", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_isValidFixingDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_name", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_pastFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_tenor", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorJPYLibor> format
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_update", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).Update
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_valueDate", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixing", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixing") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_addFixings1", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AddFixings") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_allowsNativeFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_clearFixings", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_registerWith", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_timeSeries", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_unregisterWith", Description="Create a DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorJPYLibor",Description = "DailyTenorJPYLibor")>] 
         dailytenorjpylibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorJPYLibor = Helper.toCell<DailyTenorJPYLibor> dailytenorjpylibor "DailyTenorJPYLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorJPYLiborModel.Cast _DailyTenorJPYLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorJPYLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorJPYLibor.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorJPYLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorJPYLibor_Range", Description="Create a range of DailyTenorJPYLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorJPYLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorJPYLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<DailyTenorJPYLibor> (c)) :> ICell
                let format (i : Cephei.Cell.List<DailyTenorJPYLibor>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<DailyTenorJPYLibor>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
