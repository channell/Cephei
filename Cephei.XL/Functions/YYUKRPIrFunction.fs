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
  Fake year-on-year UK RPI (i.e. a ratio of UK RPI)
  </summary> *)
[<AutoSerializable(true)>]
module YYUKRPIrFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPIr1", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.YYUKRPIr1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUKRPIr>) l

                let source = Helper.sourceFold "Fun.YYUKRPIr1" 
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
    [<ExcelFunction(Name="_YYUKRPIr", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.YYUKRPIr
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUKRPIr>) l

                let source = Helper.sourceFold "Fun.YYUKRPIr" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_clone", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Clone") 
                                               [| _YYUKRPIr.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
        Index interface The forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_YYUKRPIr_fixing", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Fixing") 
                                               [| _YYUKRPIr.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_ratio", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Ratio") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_yoyInflationTermStructure", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".YoyInflationTermStructure") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_addFixing", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".AddFixing") 
                                               [| _YYUKRPIr.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_availabilityLag", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".AvailabilityLag") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_currency", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Currency") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_familyName", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".FamilyName") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_fixingCalendar", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".FixingCalendar") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_frequency", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Frequency") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_interpolated", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Interpolated") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_isValidFixingDate", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".IsValidFixingDate") 
                                               [| _YYUKRPIr.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_name", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Name") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_region", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Region") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_revised", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Revised") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_update", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).Update
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".Update") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_addFixings", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".AddFixings") 
                                               [| _YYUKRPIr.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_addFixings1", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".AddFixings1") 
                                               [| _YYUKRPIr.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_allowsNativeFixings", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".AllowsNativeFixings") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_clearFixings", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".ClearFixings") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_registerWith", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".RegisterWith") 
                                               [| _YYUKRPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_timeSeries", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".TimeSeries") 
                                               [| _YYUKRPIr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_unregisterWith", Description="Create a YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPIr",Description = "Reference to YYUKRPIr")>] 
         yyukrpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPIr = Helper.toCell<YYUKRPIr> yyukrpir "YYUKRPIr" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYUKRPIr.cell :?> YYUKRPIrModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUKRPIr) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPIr.source + ".UnregisterWith") 
                                               [| _YYUKRPIr.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPIr.cell
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
    [<ExcelFunction(Name="_YYUKRPIr_Range", Description="Create a range of YYUKRPIr",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPIr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYUKRPIr")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYUKRPIr> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYUKRPIr>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYUKRPIr>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYUKRPIr>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
