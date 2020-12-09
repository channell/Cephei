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
    [<ExcelFunction(Name="_ZeroInflationIndex_clone", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="h",Description = "ZeroInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
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
    [<ExcelFunction(Name="_ZeroInflationIndex_fixing", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Date")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "ZeroInflationIndex")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toDefault<bool> forecastTodaysFixing "forecastTodaysFixing" false
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Fixing") 

                                               [| _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                ;  _aFixingDate.cell
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
        ! Always use the evaluation date as the reference date
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "string")>] 
         familyName : obj)
        ([<ExcelArgument(Name="region",Description = "Region")>] 
         region : obj)
        ([<ExcelArgument(Name="revised",Description = "bool")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="availabilityLag",Description = "Period")>] 
         availabilityLag : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        ([<ExcelArgument(Name="ts",Description = "ZeroInflationTermStructure")>] 
         ts : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _region = Helper.toCell<Region> region "region" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _availabilityLag = Helper.toCell<Period> availabilityLag "availabilityLag" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let _ts = Helper.toHandle<ZeroInflationTermStructure> ts "ts" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ZeroInflationIndex 
                                                            _familyName.cell 
                                                            _region.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _frequency.cell 
                                                            _availabilityLag.cell 
                                                            _currency.cell 
                                                            _ts.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold "Fun.ZeroInflationIndex" 
                                               [| _familyName.source
                                               ;  _region.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _frequency.source
                                               ;  _availabilityLag.source
                                               ;  _currency.source
                                               ;  _ts.source
                                               ;  _evaluationDate.source
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
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
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
    [<ExcelFunction(Name="_ZeroInflationIndex_zeroInflationTermStructure", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".ZeroInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
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
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixing", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixing") 

                                               [| _fixingDate.source
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
        ! The availability lag describes when the index is
<i>available</i>, not how it is used.  Specifically the fixing for, say, January, may only be available in April but the index will always return the index value applicable for January as its January fixing (independent of the lag in availability).
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_availabilityLag", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_currency", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
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
    [<ExcelFunction(Name="_ZeroInflationIndex_familyName", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! Inflation indices do not have fixing calendars.  An inflation index value is valid for every day (including weekends) of a calendar period.  I.e. it uses the NullCalendar as its fixing calendar.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_fixingCalendar", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_frequency", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        ! Forecasting index values using an inflation term structure uses the interpolation of the inflation term structure unless interpolation is set to false.  In this case the extrapolated values are constant within each period taking the mid-period extrapolated value.
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_interpolated", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_isValidFixingDate", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_name", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_region", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ZeroInflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_revised", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_ZeroInflationIndex_update", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).Update
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_ZeroInflationIndex_addFixings1", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_allowsNativeFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_clearFixings", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_registerWith", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_timeSeries", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_unregisterWith", Description="Create a ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZeroInflationIndex",Description = "ZeroInflationIndex")>] 
         zeroinflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZeroInflationIndex = Helper.toCell<ZeroInflationIndex> zeroinflationindex "ZeroInflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ZeroInflationIndexModel.Cast _ZeroInflationIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZeroInflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ZeroInflationIndex.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZeroInflationIndex.cell
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
    [<ExcelFunction(Name="_ZeroInflationIndex_Range", Description="Create a range of ZeroInflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ZeroInflationIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZeroInflationIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ZeroInflationIndex> (c)) :> ICell
                let format (i : Generic.List<ICell<ZeroInflationIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ZeroInflationIndex>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
