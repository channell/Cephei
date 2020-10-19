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
  Base class for inflation-rate indexes,
  </summary> *)
[<AutoSerializable(true)>]
module InflationIndexFunction =

    (*
        ! this method creates all the "fixings" for the relevant period of the index.  E.g. for monthly indices it will put the same value in every calendar day in the month.
    *)
    [<ExcelFunction(Name="_InflationIndex_addFixing", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Period")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toDefault<bool> forceOverwrite "forceOverwrite" false
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".AddFixing") 
                                               [| _InflationIndex.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_availabilityLag", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Period")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_InflationIndex.source + ".AvailabilityLag") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InflationIndex_currency", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Currency")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_InflationIndex.source + ".Currency") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationIndex> format
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
    [<ExcelFunction(Name="_InflationIndex_familyName", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".FamilyName") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
        ! Forecasting index values requires an inflation term structure.  The inflation term structure (ITS) defines the usual lag (not the index).  I.e.  an ITS is always relatve to a base date that is earlier than its asof date.  This must be so because indices are available only with a lag. However, the index availability lag only sets a minimum lag for the ITS.  An ITS may be relative to an earlier date, e.g. an index may have a 2-month delay in publication but the inflation swaps may take as their base the index 3 months before.
    *)
    [<ExcelFunction(Name="_InflationIndex_fixing", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Calendar")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toDefault<bool> forecastTodaysFixing "forecastTodaysFixing" false
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Fixing") 
                                               [| _InflationIndex.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
        ! Inflation indices do not have fixing calendars.  An inflation index value is valid for every day (including weekends) of a calendar period.  I.e. it uses the NullCalendar as its fixing calendar.
    *)
    [<ExcelFunction(Name="_InflationIndex_fixingCalendar", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Calendar")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_InflationIndex.source + ".FixingCalendar") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InflationIndex_frequency", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Frequency") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
        ! An inflation index may return interpolated values.  These are linearly interpolated values with act/act convention within a period. Note that stored "fixings" are always flat (constant) within a period and interpolated as needed.  This is because interpolation adds an addional availability lag (because you always need the next period to give the previous period's value) and enables storage of the most recent uninterpolated value.
    *)
    [<ExcelFunction(Name="_InflationIndex", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "InflationIndex")>] 
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
        ([<ExcelArgument(Name="availabilitiyLag",Description = "Period")>] 
         availabilitiyLag : obj)
        ([<ExcelArgument(Name="currency",Description = "Currency")>] 
         currency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<string> familyName "familyName" 
                let _region = Helper.toCell<Region> region "region" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _availabilitiyLag = Helper.toCell<Period> availabilitiyLag "availabilitiyLag" 
                let _currency = Helper.toCell<Currency> currency "currency" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.InflationIndex 
                                                            _familyName.cell 
                                                            _region.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _frequency.cell 
                                                            _availabilitiyLag.cell 
                                                            _currency.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source () = Helper.sourceFold "Fun.InflationIndex" 
                                               [| _familyName.source
                                               ;  _region.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _frequency.source
                                               ;  _availabilitiyLag.source
                                               ;  _currency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _region.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
                                ;  _frequency.cell
                                ;  _availabilitiyLag.cell
                                ;  _currency.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationIndex> format
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
    [<ExcelFunction(Name="_InflationIndex_interpolated", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Region")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Interpolated") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_isValidFixingDate", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Region")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".IsValidFixingDate") 
                                               [| _InflationIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_name", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Region")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Name") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_region", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Region")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_InflationIndex.source + ".Region") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InflationIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InflationIndex_revised", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Revised") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_update", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).Update
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".Update") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_addFixings", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Helper.Range.fromModelList")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toDefault<bool> forceOverwrite "forceOverwrite" false
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".AddFixings") 
                                               [| _InflationIndex.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_addFixings1", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Helper.Range.fromModelList")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toDefault<bool> forceOverwrite "forceOverwrite" false
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".AddFixings1") 
                                               [| _InflationIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_allowsNativeFixings", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".AllowsNativeFixings") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_clearFixings", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".ClearFixings") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_registerWith", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".RegisterWith") 
                                               [| _InflationIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_timeSeries", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".TimeSeries") 
                                               [| _InflationIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_unregisterWith", Description="Create a InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InflationIndex",Description = "InflationIndex")>] 
         inflationindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InflationIndex = Helper.toCell<InflationIndex> inflationindex "InflationIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((InflationIndexModel.Cast _InflationIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : InflationIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_InflationIndex.source + ".UnregisterWith") 
                                               [| _InflationIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InflationIndex.cell
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
    [<ExcelFunction(Name="_InflationIndex_Range", Description="Create a range of InflationIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let InflationIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InflationIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InflationIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<InflationIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<InflationIndex>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
