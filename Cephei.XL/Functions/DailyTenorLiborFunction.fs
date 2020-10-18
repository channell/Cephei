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
  One day deposit LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.
  </summary> *)
[<AutoSerializable(true)>]
module DailyTenorLiborFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorLibor1", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "DailyTenorLibor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="financialCenterCalendar",Description = "Calendar")>] 
         financialCenterCalendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _financialCenterCalendar = Helper.toCell<Calendar> financialCenterCalendar "financialCenterCalendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorLibor1 
                                                            _familyName.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _financialCenterCalendar.cell 
                                                            _dayCounter.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorLibor" 
                                               [| _familyName.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _financialCenterCalendar.source
                                               ;  _dayCounter.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _financialCenterCalendar.cell
                                ;  _dayCounter.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        http://www.bba.org.uk/bba/jsp/polopoly.jsp?d=225&a=1412 : no o/n or s/n fixings (as the case may be) will take place when the principal centre of the currency concerned is closed but London is open on the fixing day.
    *)
    [<ExcelFunction(Name="_DailyTenorLibor", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_create
        ([<ExcelArgument(Name="Mnemonic",Description = "DailyTenorLibor")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "int")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="financialCenterCalendar",Description = "Calendar")>] 
         financialCenterCalendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "DayCounter")>] 
         dayCounter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _financialCenterCalendar = Helper.toCell<Calendar> financialCenterCalendar "financialCenterCalendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.DailyTenorLibor
                                                            _familyName.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _financialCenterCalendar.cell 
                                                            _dayCounter.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DailyTenorLibor>) l

                let source () = Helper.sourceFold "Fun.DailyTenorLibor" 
                                               [| _familyName.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _financialCenterCalendar.source
                                               ;  _dayCounter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _financialCenterCalendar.cell
                                ;  _dayCounter.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
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
    [<ExcelFunction(Name="_DailyTenorLibor_businessDayConvention", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".BusinessDayConvention") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_clone", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "IborIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="forwarding",Description = "YieldTermStructure")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Clone") 
                                               [| _DailyTenorLibor.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorLibor_endOfMonth", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".EndOfMonth") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_forecastFixing1", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="d1",Description = "Date")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Date")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".ForecastFixing1") 
                                               [| _DailyTenorLibor.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_forecastFixing", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".ForecastFixing") 
                                               [| _DailyTenorLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_forwardingTermStructure", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".ForwardingTermStructure") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
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
    [<ExcelFunction(Name="_DailyTenorLibor_maturityDate", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".MaturityDate") 
                                               [| _DailyTenorLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_currency", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Currency") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorLibor_dayCounter", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".DayCounter") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
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
    [<ExcelFunction(Name="_DailyTenorLibor_familyName", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".FamilyName") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_fixing", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Fixing") 
                                               [| _DailyTenorLibor.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_fixingCalendar", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".FixingCalendar") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DailyTenorLibor_fixingDate", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".FixingDate") 
                                               [| _DailyTenorLibor.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_fixingDays", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".FixingDays") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_isValidFixingDate", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".IsValidFixingDate") 
                                               [| _DailyTenorLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_name", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Name") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_pastFixing", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".PastFixing") 
                                               [| _DailyTenorLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_tenor", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Tenor") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DailyTenorLibor> format
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
    [<ExcelFunction(Name="_DailyTenorLibor_update", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).Update
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".Update") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_valueDate", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".ValueDate") 
                                               [| _DailyTenorLibor.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_addFixing", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".AddFixing") 
                                               [| _DailyTenorLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_addFixings", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".AddFixings") 
                                               [| _DailyTenorLibor.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_addFixings1", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".AddFixings1") 
                                               [| _DailyTenorLibor.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_allowsNativeFixings", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".AllowsNativeFixings") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_clearFixings", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).ClearFixings
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".ClearFixings") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_registerWith", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".RegisterWith") 
                                               [| _DailyTenorLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_timeSeries", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".TimeSeries") 
                                               [| _DailyTenorLibor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_unregisterWith", Description="Create a DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DailyTenorLibor",Description = "DailyTenorLibor")>] 
         dailytenorlibor : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DailyTenorLibor = Helper.toCell<DailyTenorLibor> dailytenorlibor "DailyTenorLibor"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((DailyTenorLiborModel.Cast _DailyTenorLibor.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : DailyTenorLibor) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DailyTenorLibor.source + ".UnregisterWith") 
                                               [| _DailyTenorLibor.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DailyTenorLibor.cell
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
    [<ExcelFunction(Name="_DailyTenorLibor_Range", Description="Create a range of DailyTenorLibor",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DailyTenorLibor_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DailyTenorLibor> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DailyTenorLibor>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DailyTenorLibor>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DailyTenorLibor>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
