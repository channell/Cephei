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
  Genuine year-on-year UK RPI (i.e. not a ratio of UK RPI)
  </summary> *)
[<AutoSerializable(true)>]
module YYUKRPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_create
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
                let builder () = withMnemonic mnemonic (Fun.YYUKRPI 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUKRPI>) l

                let source = Helper.sourceFold "Fun.YYUKRPI" 
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
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI1", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder () = withMnemonic mnemonic (Fun.YYUKRPI1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYUKRPI>) l

                let source = Helper.sourceFold "Fun.YYUKRPI1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI_clone", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".Clone") 
                                               [| _YYUKRPI.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
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
    [<ExcelFunction(Name="_YYUKRPI_fixing", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Fixing") 
                                               [| _YYUKRPI.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_ratio", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Ratio") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_yoyInflationTermStructure", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".YoyInflationTermStructure") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
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
    [<ExcelFunction(Name="_YYUKRPI_addFixing", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".AddFixing") 
                                               [| _YYUKRPI.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_availabilityLag", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".AvailabilityLag") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI_currency", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".Currency") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
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
    [<ExcelFunction(Name="_YYUKRPI_familyName", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".FamilyName") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_fixingCalendar", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".FixingCalendar") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI_frequency", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Frequency") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_interpolated", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Interpolated") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_isValidFixingDate", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".IsValidFixingDate") 
                                               [| _YYUKRPI.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_name", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Name") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_region", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYUKRPI.source + ".Region") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYUKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYUKRPI_revised", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Revised") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_update", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).Update
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".Update") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_addFixings", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".AddFixings") 
                                               [| _YYUKRPI.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_addFixings1", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".AddFixings1") 
                                               [| _YYUKRPI.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_allowsNativeFixings", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".AllowsNativeFixings") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_clearFixings", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).ClearFixings
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".ClearFixings") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_registerWith", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".RegisterWith") 
                                               [| _YYUKRPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_timeSeries", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".TimeSeries") 
                                               [| _YYUKRPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_unregisterWith", Description="Create a YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYUKRPI",Description = "Reference to YYUKRPI")>] 
         yyukrpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYUKRPI = Helper.toCell<YYUKRPI> yyukrpi "YYUKRPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_YYUKRPI.cell :?> YYUKRPIModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYUKRPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYUKRPI.source + ".UnregisterWith") 
                                               [| _YYUKRPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYUKRPI.cell
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
    [<ExcelFunction(Name="_YYUKRPI_Range", Description="Create a range of YYUKRPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYUKRPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYUKRPI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYUKRPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYUKRPI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYUKRPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYUKRPI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
