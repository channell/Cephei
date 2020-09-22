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
  Genuine year-on-year South African CPI (i.e. not a ratio of South African CPI)
  </summary> *)
[<AutoSerializable(true)>]
module YYZACPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYZACPI", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_create
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
                let builder () = withMnemonic mnemonic (Fun.YYZACPI 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYZACPI>) l

                let source = Helper.sourceFold "Fun.YYZACPI" 
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
    [<ExcelFunction(Name="_YYZACPI1", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.YYZACPI1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYZACPI>) l

                let source = Helper.sourceFold "Fun.YYZACPI1" 
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
    [<ExcelFunction(Name="_YYZACPI_clone", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".Clone") 
                                               [| _YYZACPI.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_fixing", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Fixing") 
                                               [| _YYZACPI.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_ratio", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Ratio") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_yoyInflationTermStructure", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".YoyInflationTermStructure") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_addFixing", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".AddFixing") 
                                               [| _YYZACPI.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_availabilityLag", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".AvailabilityLag") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_currency", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".Currency") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_familyName", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".FamilyName") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_fixingCalendar", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".FixingCalendar") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_frequency", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Frequency") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_interpolated", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Interpolated") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_isValidFixingDate", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".IsValidFixingDate") 
                                               [| _YYZACPI.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_name", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Name") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_region", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYZACPI.source + ".Region") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_revised", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Revised") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_update", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).Update
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".Update") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_addFixings", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".AddFixings") 
                                               [| _YYZACPI.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_addFixings1", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".AddFixings1") 
                                               [| _YYZACPI.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_allowsNativeFixings", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".AllowsNativeFixings") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_clearFixings", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".ClearFixings") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_registerWith", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".RegisterWith") 
                                               [| _YYZACPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_timeSeries", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".TimeSeries") 
                                               [| _YYZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_unregisterWith", Description="Create a YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYZACPI",Description = "Reference to YYZACPI")>] 
         yyzacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYZACPI = Helper.toCell<YYZACPI> yyzacpi "YYZACPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYZACPI.cell :?> YYZACPIModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYZACPI.source + ".UnregisterWith") 
                                               [| _YYZACPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYZACPI.cell
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
    [<ExcelFunction(Name="_YYZACPI_Range", Description="Create a range of YYZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYZACPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYZACPI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYZACPI> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYZACPI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYZACPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYZACPI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
