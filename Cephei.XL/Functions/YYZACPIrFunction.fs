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
  Fake year-on-year South African CPI (i.e. a ratio of South African CPI)
  </summary> *)
[<AutoSerializable(true)>]
module YYZACPIrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr1", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYZACPIr1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYZACPIr>) l

                let source () = Helper.sourceFold "Fun.YYZACPIr1" 
                                               [| _interpolated.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                ;  _ts.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYZACPIr
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYZACPIr>) l

                let source () = Helper.sourceFold "Fun.YYZACPIr" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr_clone", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Clone") 
                                               [| _YYZACPIr.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Index interface The forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_YYZACPIr_fixing", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Fixing") 
                                               [| _YYZACPIr.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_YYZACPIr_ratio", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Ratio") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_yoyInflationTermStructure", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".YoyInflationTermStructure") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
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
    [<ExcelFunction(Name="_YYZACPIr_addFixing", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".AddFixing") 
                                               [| _YYZACPIr.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_availabilityLag", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".AvailabilityLag") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr_currency", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Currency") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
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
    [<ExcelFunction(Name="_YYZACPIr_familyName", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".FamilyName") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_fixingCalendar", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".FixingCalendar") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr_frequency", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Frequency") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_interpolated", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Interpolated") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_isValidFixingDate", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".IsValidFixingDate") 
                                               [| _YYZACPIr.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_name", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Name") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_region", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Region") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYZACPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPIr_revised", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Revised") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_update", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).Update
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".Update") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_addFixings", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".AddFixings") 
                                               [| _YYZACPIr.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_addFixings1", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".AddFixings1") 
                                               [| _YYZACPIr.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_allowsNativeFixings", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".AllowsNativeFixings") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_clearFixings", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".ClearFixings") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_registerWith", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".RegisterWith") 
                                               [| _YYZACPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_timeSeries", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".TimeSeries") 
                                               [| _YYZACPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_unregisterWith", Description="Create a YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPIr",Description = "Reference to YYZACPIr")>] 
         yyzacpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPIr = Helper.toCell<YYZACPIr> yyzacpir "YYZACPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYZACPIrModel.Cast _YYZACPIr.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYZACPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYZACPIr.source + ".UnregisterWith") 
                                               [| _YYZACPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPIr.cell
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
    [<ExcelFunction(Name="_YYZACPIr_Range", Description="Create a range of YYZACPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYZACPIr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYZACPIr")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYZACPIr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYZACPIr>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYZACPIr>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<YYZACPIr>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
