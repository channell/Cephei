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
    [<ExcelFunction(Name="_YYUSCPIr1", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_create1
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYUSCPIr1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUSCPIr>) l

                let source () = Helper.sourceFold "Fun.YYUSCPIr1" 
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
    [<ExcelFunction(Name="_YYUSCPIr", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYUSCPIr
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUSCPIr>) l

                let source () = Helper.sourceFold "Fun.YYUSCPIr" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_clone", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="h",Description = "YoYInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_fixing", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_ratio", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Ratio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_yoyInflationTermStructure", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".YoyInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixing", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".AddFixing") 

                                               [| _fixingDate.source
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
    [<ExcelFunction(Name="_YYUSCPIr_availabilityLag", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_currency", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_familyName", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_fixingCalendar", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_frequency", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_interpolated", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_isValidFixingDate", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_name", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_region", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_YYUSCPIr_revised", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_update", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).Update
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_YYUSCPIr_addFixings1", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_allowsNativeFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_clearFixings", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_registerWith", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_timeSeries", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_unregisterWith", Description="Create a YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUSCPIr",Description = "YYUSCPIr")>] 
         yyuscpir : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUSCPIr = Helper.toCell<YYUSCPIr> yyuscpir "YYUSCPIr"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYUSCPIrModel.Cast _YYUSCPIr.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUSCPIr) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYUSCPIr.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUSCPIr.cell
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
    [<ExcelFunction(Name="_YYUSCPIr_Range", Description="Create a range of YYUSCPIr",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYUSCPIr_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYUSCPIr> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YYUSCPIr> (c)) :> ICell
                let format (i : Cephei.Cell.List<YYUSCPIr>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YYUSCPIr>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
