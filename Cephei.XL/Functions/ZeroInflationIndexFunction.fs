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
  Base class for zero inflation indices.
  </summary> *)
[<AutoSerializable(true)>]
module ZeroInflationIndexFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_clone", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Clone") 
                                               [| _ZeroInflationIndex.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! \warning the forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_fixing", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Reference to aFixingDate")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Fixing") 
                                               [| _ZeroInflationIndex.source
                                               ;  _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                ;  _aFixingDate.cell
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
        ! Always use the evaluation date as the reference date
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="region",Description = "Reference to region")>] 
         region : obj)
        ([<ExcelArgument(Name="revised",Description = "Reference to revised")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="availabilityLag",Description = "Reference to availabilityLag")>] 
         availabilityLag : obj)
        ([<ExcelArgument(Name="currency",Description = "Reference to currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" true
                let _region = Helper.toCell<Region> region "region" true
                let _revised = Helper.toCell<bool> revised "revised" true
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _availabilityLag = Helper.toCell<Period> availabilityLag "availabilityLag" true
                let _currency = Helper.toCell<Currency> currency "currency" true
                let _ts = Helper.toHandle<ZeroInflationTermStructure> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.ZeroInflationIndex 
                                                            _familyName.cell 
                                                            _region.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _frequency.cell 
                                                            _availabilityLag.cell 
                                                            _currency.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold "Fun.ZeroInflationIndex" 
                                               [| _familyName.source
                                               ;  _region.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _frequency.source
                                               ;  _availabilityLag.source
                                               ;  _currency.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _region.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
                                ;  _frequency.cell
                                ;  _availabilityLag.cell
                                ;  _currency.cell
                                ;  _ts.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_zeroInflationTermStructure", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".ZeroInflationTermStructure") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! this method creates all the "fixings" for the relevant period of the index.  E.g. for monthly indices it will put the same value in every calendar day in the month.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixing", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixing") 
                                               [| _ZeroInflationIndex.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                ;  _fixingDate.cell
                                ;  _fixing.cell
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
        ! The availability lag describes when the index is
<i>available</i>, not how it is used.  Specifically the fixing for, say, January, may only be available in April but the index will always return the index value applicable for January as its January fixing (independent of the lag in availability).
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_availabilityLag", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".AvailabilityLag") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_currency", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Currency") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_familyName", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".FamilyName") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! Inflation indices do not have fixing calendars.  An inflation index value is valid for every day (including weekends) of a calendar period.  I.e. it uses the NullCalendar as its fixing calendar.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_fixingCalendar", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".FixingCalendar") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_frequency", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Frequency") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! Forecasting index values using an inflation term structure uses the interpolation of the inflation term structure unless interpolation is set to false.  In this case the extrapolated values are constant within each period taking the mid-period extrapolated value.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_interpolated", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Interpolated") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_isValidFixingDate", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".IsValidFixingDate") 
                                               [| _ZeroInflationIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_name", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Name") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_region", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Region") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_revised", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Revised") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_update", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).Update
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".Update") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixings") 
                                               [| _ZeroInflationIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixings1", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixings1") 
                                               [| _ZeroInflationIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_allowsNativeFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".AllowsNativeFixings") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_clearFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).ClearFixings
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".ClearFixings") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_registerWith", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".RegisterWith") 
                                               [| _ZeroInflationIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_timeSeries", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".TimeSeries") 
                                               [| _ZeroInflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_unregisterWith", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "Reference to ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ZeroInflationIndex.cell :?> ZeroInflationIndexModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZeroInflationIndex.source + ".UnregisterWith") 
                                               [| _ZeroInflationIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_Range", Description="Create a range of ZeroInflationIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZeroInflationIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZeroInflationIndex")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroInflationIndex> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZeroInflationIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZeroInflationIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZeroInflationIndex>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
