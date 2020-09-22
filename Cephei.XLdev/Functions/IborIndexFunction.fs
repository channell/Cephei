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
  base class for Inter-Bank-Offered-Rate indexes (e.g. %Libor, etc.)
  </summary> *)
[<AutoSerializable(true)>]
module IborIndexFunction =

    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_IborIndex_businessDayConvention", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".BusinessDayConvention") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_clone", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _forwarding = Helper.toHandle<Handle<YieldTermStructure>> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_IborIndex.source + ".Clone") 
                                               [| _IborIndex.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_endOfMonth", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".EndOfMonth") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_forecastFixing", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _d1 = Helper.toCell<Date> d1 "d1" true
                let _d2 = Helper.toCell<Date> d2 "d2" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).ForecastFixing
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".ForecastFixing") 
                                               [| _IborIndex.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_forecastFixing", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).ForecastFixing1
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".ForecastFixing1") 
                                               [| _IborIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_forwardingTermStructure", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_IborIndex.source + ".ForwardingTermStructure") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="fixingCalendar",Description = "Reference to fixingCalendar")>] 
         fixingCalendar : obj)
        ([<ExcelArgument(Name="convention",Description = "Reference to convention")>] 
         convention : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" true
                let _tenor = Helper.toCell<Period> tenor "tenor" true
                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _currency = Helper.toCell<Currency> currency "currency" true
                let _fixingCalendar = Helper.toCell<Calendar> fixingCalendar "fixingCalendar" true
                let _convention = Helper.toCell<BusinessDayConvention> convention "convention" true
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" true
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" true
                let _h = Helper.toHandle<Handle<YieldTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic (Fun.IborIndex 
                                                            _familyName.cell 
                                                            _tenor.cell 
                                                            _settlementDays.cell 
                                                            _currency.cell 
                                                            _fixingCalendar.cell 
                                                            _convention.cell 
                                                            _endOfMonth.cell 
                                                            _dayCounter.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold "Fun.IborIndex" 
                                               [| _familyName.source
                                               ;  _tenor.source
                                               ;  _settlementDays.source
                                               ;  _currency.source
                                               ;  _fixingCalendar.source
                                               ;  _convention.source
                                               ;  _endOfMonth.source
                                               ;  _dayCounter.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _tenor.cell
                                ;  _settlementDays.cell
                                ;  _currency.cell
                                ;  _fixingCalendar.cell
                                ;  _convention.cell
                                ;  _endOfMonth.cell
                                ;  _dayCounter.cell
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_IborIndex1", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.IborIndex1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold "Fun.IborIndex1" 
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_IborIndex_maturityDate", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".MaturityDate") 
                                               [| _IborIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_currency", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_IborIndex.source + ".Currency") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_dayCounter", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_IborIndex.source + ".DayCounter") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_familyName", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".FamilyName") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_fixing", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".Fixing") 
                                               [| _IborIndex.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_fixingCalendar", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_IborIndex.source + ".FixingCalendar") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_fixingDate", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".FixingDate") 
                                               [| _IborIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_fixingDays", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".FixingDays") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_isValidFixingDate", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".IsValidFixingDate") 
                                               [| _IborIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_name", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".Name") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_pastFixing", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".PastFixing") 
                                               [| _IborIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_tenor", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_IborIndex.source + ".Tenor") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_update", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).Update
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".Update") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_valueDate", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".ValueDate") 
                                               [| _IborIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_addFixing", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".AddFixing") 
                                               [| _IborIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_addFixings", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".AddFixings") 
                                               [| _IborIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_addFixings", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".AddFixings1") 
                                               [| _IborIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_allowsNativeFixings", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".AllowsNativeFixings") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_clearFixings", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).ClearFixings
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".ClearFixings") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_registerWith", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".RegisterWith") 
                                               [| _IborIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_timeSeries", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".TimeSeries") 
                                               [| _IborIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_unregisterWith", Description="Create a IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="IborIndex",Description = "Reference to IborIndex")>] 
         iborindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _IborIndex = Helper.toCell<IborIndex> iborindex "IborIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_IborIndex.cell :?> IborIndexModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : IborIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_IborIndex.source + ".UnregisterWith") 
                                               [| _IborIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _IborIndex.cell
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
    [<ExcelFunction(Name="_IborIndex_Range", Description="Create a range of IborIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let IborIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the IborIndex")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<IborIndex> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<IborIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<IborIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<IborIndex>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
