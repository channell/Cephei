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

  </summary> *)
[<AutoSerializable(true)>]
module OvernightIndexFunction =

    (*
        ! returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_OvernightIndex_clone", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Clone") 
                                               [| _OvernightIndex.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndex", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="fixingCalendar",Description = "Reference to fixingCalendar")>] 
         fixingCalendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _fixingCalendar = Helper.toCell<Calendar> fixingCalendar "fixingCalendar" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.OvernightIndex 
                                                            _familyName.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _fixingCalendar.cell 
                                                            _dayCounter.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OvernightIndex>) l

                let source () = Helper.sourceFold "Fun.OvernightIndex" 
                                               [| _familyName.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _fixingCalendar.source
                                               ;  _dayCounter.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _fixingCalendar.cell
                                ;  _dayCounter.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
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
    [<ExcelFunction(Name="_OvernightIndex_businessDayConvention", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".BusinessDayConvention") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_endOfMonth", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".EndOfMonth") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_forecastFixing1", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".ForecastFixing1") 
                                               [| _OvernightIndex.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_forecastFixing", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".ForecastFixing") 
                                               [| _OvernightIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_forwardingTermStructure", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".ForwardingTermStructure") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
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
    [<ExcelFunction(Name="_OvernightIndex_maturityDate", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".MaturityDate") 
                                               [| _OvernightIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_currency", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Currency") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndex_dayCounter", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".DayCounter") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
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
    [<ExcelFunction(Name="_OvernightIndex_familyName", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".FamilyName") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_fixing", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Fixing") 
                                               [| _OvernightIndex.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_fixingCalendar", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".FixingCalendar") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OvernightIndex_fixingDate", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".FixingDate") 
                                               [| _OvernightIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_fixingDays", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".FixingDays") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_isValidFixingDate", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".IsValidFixingDate") 
                                               [| _OvernightIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_name", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Name") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_pastFixing", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".PastFixing") 
                                               [| _OvernightIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_tenor", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Tenor") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OvernightIndex> format
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
    [<ExcelFunction(Name="_OvernightIndex_update", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).Update
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".Update") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_valueDate", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".ValueDate") 
                                               [| _OvernightIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_addFixing", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".AddFixing") 
                                               [| _OvernightIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_addFixings", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".AddFixings") 
                                               [| _OvernightIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_addFixings1", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".AddFixings1") 
                                               [| _OvernightIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_allowsNativeFixings", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".AllowsNativeFixings") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_clearFixings", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".ClearFixings") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_registerWith", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".RegisterWith") 
                                               [| _OvernightIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_timeSeries", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".TimeSeries") 
                                               [| _OvernightIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_unregisterWith", Description="Create a OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OvernightIndex",Description = "Reference to OvernightIndex")>] 
         overnightindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OvernightIndex = Helper.toCell<OvernightIndex> overnightindex "OvernightIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OvernightIndexModel.Cast _OvernightIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OvernightIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OvernightIndex.source + ".UnregisterWith") 
                                               [| _OvernightIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OvernightIndex.cell
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
    [<ExcelFunction(Name="_OvernightIndex_Range", Description="Create a range of OvernightIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OvernightIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the OvernightIndex")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OvernightIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<OvernightIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<OvernightIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<OvernightIndex>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
