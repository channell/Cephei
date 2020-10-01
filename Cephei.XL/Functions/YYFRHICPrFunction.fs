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
    [<ExcelFunction(Name="_YYFRHICPr1", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder () = withMnemonic mnemonic (Fun.YYFRHICPr1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICPr>) l

                let source = Helper.sourceFold "Fun.YYFRHICPr1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_create
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
                let builder () = withMnemonic mnemonic (Fun.YYFRHICPr 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICPr>) l

                let source = Helper.sourceFold "Fun.YYFRHICPr" 
                                               [| _interpolated.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                ;  _ts.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_clone", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Clone") 
                                               [| _YYFRHICPr.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_fixing", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Fixing") 
                                               [| _YYFRHICPr.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
        Other methods
    *)
    [<ExcelFunction(Name="_YYFRHICPr_ratio", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Ratio") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_yoyInflationTermStructure", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".YoyInflationTermStructure") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixing", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".AddFixing") 
                                               [| _YYFRHICPr.source
                                               ;  _fixingDate.source
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
    [<ExcelFunction(Name="_YYFRHICPr_availabilityLag", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".AvailabilityLag") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_currency", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Currency") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_familyName", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".FamilyName") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_fixingCalendar", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".FixingCalendar") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_frequency", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Frequency") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_interpolated", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Interpolated") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_isValidFixingDate", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".IsValidFixingDate") 
                                               [| _YYFRHICPr.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_name", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Name") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_region", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Region") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_YYFRHICPr_revised", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Revised") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_update", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).Update
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".Update") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".AddFixings") 
                                               [| _YYFRHICPr.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_YYFRHICPr_addFixings1", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".AddFixings1") 
                                               [| _YYFRHICPr.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_allowsNativeFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".AllowsNativeFixings") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_clearFixings", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".ClearFixings") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_registerWith", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".RegisterWith") 
                                               [| _YYFRHICPr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_timeSeries", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".TimeSeries") 
                                               [| _YYFRHICPr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_unregisterWith", Description="Create a YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICPr",Description = "Reference to YYFRHICPr")>] 
         yyfrhicpr : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICPr = Helper.toCell<YYFRHICPr> yyfrhicpr "YYFRHICPr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYFRHICPr.cell :?> YYFRHICPrModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICPr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICPr.source + ".UnregisterWith") 
                                               [| _YYFRHICPr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICPr.cell
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
    [<ExcelFunction(Name="_YYFRHICPr_Range", Description="Create a range of YYFRHICPr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICPr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYFRHICPr")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYFRHICPr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYFRHICPr>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYFRHICPr>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYFRHICPr>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
