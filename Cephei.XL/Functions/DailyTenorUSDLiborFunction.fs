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
  base class for the one day deposit ICE %USD %LIBOR indexes
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorUSDLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorUSDLibor", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "DailyTenorUSDLibor")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorUSDLibor 
                                                            _settlementDays.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorUSDLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorUSDLibor" 
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
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorUSDLibor1", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "DailyTenorUSDLibor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorUSDLibor1 
                                                            _settlementDays.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorUSDLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorUSDLibor1" 
                                               [| _settlementDays.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_businessDayConvention", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_clone", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Clone") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorUSDLibor_endOfMonth", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_forecastFixing1", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".ForecastFixing1") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_forecastFixing", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_forwardingTermStructure", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_maturityDate", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".MaturityDate") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_currency", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Currency") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorUSDLibor_dayCounter", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".DayCounter") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_familyName", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".FamilyName") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_fixing", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Fixing") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_fixingCalendar", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorUSDLibor_fixingDate", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".FixingDate") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_fixingDays", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".FixingDays") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_isValidFixingDate", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_name", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Name") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_pastFixing", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".PastFixing") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_tenor", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Tenor") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorUSDLibor> format
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_update", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).Update
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".Update") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_valueDate", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".ValueDate") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_addFixing", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".AddFixing") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_addFixings", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".AddFixings") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_addFixings1", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".AddFixings1") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_allowsNativeFixings", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_clearFixings", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".ClearFixings") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_registerWith", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".RegisterWith") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_timeSeries", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".TimeSeries") 
                                               [| _DailyTenorUSDLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_unregisterWith", Description="Create a DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorUSDLibor",Description = "DailyTenorUSDLibor")>] 
         dailytenorusdlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorUSDLibor = Helper.toCell<DailyTenorUSDLibor> dailytenorusdlibor "DailyTenorUSDLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorUSDLiborModel.Cast _DailyTenorUSDLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorUSDLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorUSDLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorUSDLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorUSDLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorUSDLibor_Range", Description="Create a range of DailyTenorUSDLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorUSDLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorUSDLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorUSDLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorUSDLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DailyTenorUSDLibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
