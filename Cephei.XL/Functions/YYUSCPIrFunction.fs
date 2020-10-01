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
  Fake year-on-year US CPI (i.e. a ratio of US CPI)
  </summary> *)
[<AutoSerializable(true)>]
module YYUSCPIrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr1", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_create1
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
                let builder () = withMnemonic mnemonic (Fun.YYUSCPIr1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUSCPIr>) l

                let source = Helper.sourceFold "Fun.YYUSCPIr1" 
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
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder () = withMnemonic mnemonic (Fun.YYUSCPIr
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUSCPIr>) l

                let source = Helper.sourceFold "Fun.YYUSCPIr" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr_clone", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Clone") 
                                               [| _YYUSCPIr.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
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
    [<ExcelFunction(Name="_YYUSCPIr_fixing", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Fixing") 
                                               [| _YYUSCPIr.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_ratio", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Ratio") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_yoyInflationTermStructure", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".YoyInflationTermStructure") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixing", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".AddFixing") 
                                               [| _YYUSCPIr.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_availabilityLag", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".AvailabilityLag") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr_currency", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Currency") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
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
    [<ExcelFunction(Name="_YYUSCPIr_familyName", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".FamilyName") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_fixingCalendar", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".FixingCalendar") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr_frequency", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Frequency") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_interpolated", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Interpolated") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_isValidFixingDate", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".IsValidFixingDate") 
                                               [| _YYUSCPIr.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_name", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Name") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_region", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Region") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUSCPIr> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUSCPIr_revised", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Revised") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_update", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).Update
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".Update") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".AddFixings") 
                                               [| _YYUSCPIr.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixings1", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".AddFixings1") 
                                               [| _YYUSCPIr.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_allowsNativeFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".AllowsNativeFixings") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_clearFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".ClearFixings") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_registerWith", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".RegisterWith") 
                                               [| _YYUSCPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_timeSeries", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".TimeSeries") 
                                               [| _YYUSCPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_unregisterWith", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "Reference to YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYUSCPIr.cell :?> YYUSCPIrModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUSCPIr.source + ".UnregisterWith") 
                                               [| _YYUSCPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_Range", Description="Create a range of YYUSCPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUSCPIr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYUSCPIr")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYUSCPIr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYUSCPIr>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYUSCPIr>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYUSCPIr>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
