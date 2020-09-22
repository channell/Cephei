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
  Genuine year-on-year AU CPI (i.e. not a ratio)
  </summary> *)
[<AutoSerializable(true)>]
module YYAUCPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "Reference to revised")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "Reference to ts")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _revised = Helper.toCell<bool> revised "revised" true
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let _ts = Helper.toHandle<Handle<YoYInflationTermStructure>> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.YYAUCPI 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPI>) l

                let source = Helper.sourceFold "Fun.YYAUCPI" 
                                               [| _frequency.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               ;  _ts.source
                                               |]
                let hash = Helper.hashFold 
                                [| _frequency.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
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
    [<ExcelFunction(Name="_YYAUCPI1", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "Reference to revised")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" true
                let _revised = Helper.toCell<bool> revised "revised" true
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.YYAUCPI1 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPI>) l

                let source = Helper.sourceFold "Fun.YYAUCPI1" 
                                               [| _frequency.source
                                               ;  _revised.source
                                               ;  _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _frequency.cell
                                ;  _revised.cell
                                ;  _interpolated.cell
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
    [<ExcelFunction(Name="_YYAUCPI_clone", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _h = Helper.toHandle<Handle<YoYInflationTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".Clone") 
                                               [| _YYAUCPI.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_fixing", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Fixing") 
                                               [| _YYAUCPI.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_ratio", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Ratio") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_yoyInflationTermStructure", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".YoyInflationTermStructure") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_addFixing", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".AddFixing") 
                                               [| _YYAUCPI.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_availabilityLag", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".AvailabilityLag") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_currency", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".Currency") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_familyName", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".FamilyName") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_fixingCalendar", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".FixingCalendar") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_frequency", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Frequency") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_interpolated", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Interpolated") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_isValidFixingDate", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".IsValidFixingDate") 
                                               [| _YYAUCPI.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_name", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Name") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_region", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYAUCPI.source + ".Region") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_revised", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Revised") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_update", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).Update
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".Update") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_addFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".AddFixings") 
                                               [| _YYAUCPI.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_addFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".AddFixings1") 
                                               [| _YYAUCPI.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_allowsNativeFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".AllowsNativeFixings") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_clearFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".ClearFixings") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_registerWith", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".RegisterWith") 
                                               [| _YYAUCPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_timeSeries", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".TimeSeries") 
                                               [| _YYAUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_unregisterWith", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "Reference to YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_YYAUCPI.cell :?> YYAUCPIModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYAUCPI.source + ".UnregisterWith") 
                                               [| _YYAUCPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_Range", Description="Create a range of YYAUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYAUCPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYAUCPI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYAUCPI> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYAUCPI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYAUCPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYAUCPI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
