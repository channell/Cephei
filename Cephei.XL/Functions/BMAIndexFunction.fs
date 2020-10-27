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
  The BMA index is the short-term tax-exempt reference index of the Bond Market Association.  It has tenor one week, is fixed weekly on Wednesdays and is applied with a one-day's fixing gap from Thursdays on for one week.  It is the tax-exempt correspondent of the 1M USD-Libor.
  </summary> *)
[<AutoSerializable(true)>]
module BMAIndexFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BMAIndex", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "BMAIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BMAIndex 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BMAIndex>) l

                let source () = Helper.sourceFold "Fun.BMAIndex" 
                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        This method returns a schedule of fixing dates between start and end.
    *)
    [<ExcelFunction(Name="_BMAIndex_fixingSchedule", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_fixingSchedule
        ([<ExcelArgument(Name="Mnemonic",Description = "Schedule")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="start",Description = "Date")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Date")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).FixingSchedule
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Schedule>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".FixingSchedule") 

                                               [| _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                ;  _start.cell
                                ;  _End.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMAIndex_forecastFixing", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_BMAIndex_forwardingTermStructure", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".ForwardingTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMAIndex_isValidFixingDate", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
        Date calculations
    *)
    [<ExcelFunction(Name="_BMAIndex_maturityDate", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
        Index interface BMA is fixed weekly on Wednesdays.
    *)
    [<ExcelFunction(Name="_BMAIndex_name", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_currency", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMAIndex_dayCounter", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "DayCounter")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
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
    [<ExcelFunction(Name="_BMAIndex_familyName", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_fixing", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_fixingCalendar", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BMAIndex_fixingDate", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_fixingDays", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_pastFixing", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_tenor", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_BMAIndex.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BMAIndex> format
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
    [<ExcelFunction(Name="_BMAIndex_update", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).Update
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_valueDate", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_addFixing", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_addFixings", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_addFixings1", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".AddFixings") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_allowsNativeFixings", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_clearFixings", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_registerWith", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_timeSeries", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_unregisterWith", Description="Create a BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BMAIndex",Description = "BMAIndex")>] 
         bmaindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BMAIndex = Helper.toCell<BMAIndex> bmaindex "BMAIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BMAIndexModel.Cast _BMAIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BMAIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BMAIndex.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BMAIndex.cell
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
    [<ExcelFunction(Name="_BMAIndex_Range", Description="Create a range of BMAIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BMAIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BMAIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BMAIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BMAIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BMAIndex>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
