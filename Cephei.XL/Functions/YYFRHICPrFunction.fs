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
  Fake year-on-year FR HICP (i.e. a ratio)
  </summary> *)
[<AutoSerializable(true)>]
module YYFRHICPrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr1", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = (Fun.YYFRHICPr1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICPr>) l

                let source () = Helper.sourceFold "Fun.YYFRHICPr1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "YoYInflationTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder (current : ICell) = (Fun.YYFRHICPr 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICPr>) l

                let source () = Helper.sourceFold "Fun.YYFRHICPr" 
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
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr_clone", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="h",Description = "YoYInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
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
    [<ExcelFunction(Name="_YYFRHICPr_fixing", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_ratio", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Ratio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_yoyInflationTermStructure", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".YoyInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixing", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_availabilityLag", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr_currency", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
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
    [<ExcelFunction(Name="_YYFRHICPr_familyName", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_fixingCalendar", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr_frequency", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_interpolated", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_isValidFixingDate", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_name", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_region", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICPr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICPr_revised", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_update", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).Update
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixings1", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_allowsNativeFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_clearFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_registerWith", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_timeSeries", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_unregisterWith", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toModelReference<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((YYFRHICPrModel.Cast _YYFRHICPr.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYFRHICPr.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_Range", Description="Create a range of YYFRHICPr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYFRHICPr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYFRHICPr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YYFRHICPr> (c)) :> ICell
                let format (i : Cephei.Cell.List<YYFRHICPr>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YYFRHICPr>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
