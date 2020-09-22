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
  South African CPI index
  </summary> *)
[<AutoSerializable(true)>]
module ZACPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ZACPI", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_create
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
                let _ts = Helper.toHandle<Handle<ZeroInflationTermStructure>> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.ZACPI 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZACPI>) l

                let source = Helper.sourceFold "Fun.ZACPI" 
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
    [<ExcelFunction(Name="_ZACPI1", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.ZACPI1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZACPI>) l

                let source = Helper.sourceFold "Fun.ZACPI1" 
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
    [<ExcelFunction(Name="_ZACPI_clone", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _h = Helper.toHandle<Handle<ZeroInflationTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_ZACPI.source + ".Clone") 
                                               [| _ZACPI.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
        ! \warning the forecastTodaysFixing parameter (required by the Index interface) is currently ignored.
    *)
    [<ExcelFunction(Name="_ZACPI_fixing", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Reference to aFixingDate")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Fixing") 
                                               [| _ZACPI.source
                                               ;  _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
                                ;  _aFixingDate.cell
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
    [<ExcelFunction(Name="_ZACPI_zeroInflationTermStructure", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source = Helper.sourceFold (_ZACPI.source + ".ZeroInflationTermStructure") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_addFixing", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".AddFixing") 
                                               [| _ZACPI.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_availabilityLag", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_ZACPI.source + ".AvailabilityLag") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_currency", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_ZACPI.source + ".Currency") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_familyName", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".FamilyName") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_fixingCalendar", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_ZACPI.source + ".FixingCalendar") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_frequency", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Frequency") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_interpolated", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Interpolated") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_isValidFixingDate", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".IsValidFixingDate") 
                                               [| _ZACPI.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_name", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Name") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_region", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_ZACPI.source + ".Region") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_revised", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Revised") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_update", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).Update
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".Update") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_addFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".AddFixings") 
                                               [| _ZACPI.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_addFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".AddFixings1") 
                                               [| _ZACPI.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_allowsNativeFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".AllowsNativeFixings") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_clearFixings", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).ClearFixings
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".ClearFixings") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_registerWith", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".RegisterWith") 
                                               [| _ZACPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_timeSeries", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".TimeSeries") 
                                               [| _ZACPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_unregisterWith", Description="Create a ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ZACPI",Description = "Reference to ZACPI")>] 
         zacpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ZACPI = Helper.toCell<ZACPI> zacpi "ZACPI" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ZACPI.cell :?> ZACPIModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ZACPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ZACPI.source + ".UnregisterWith") 
                                               [| _ZACPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ZACPI.cell
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
    [<ExcelFunction(Name="_ZACPI_Range", Description="Create a range of ZACPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ZACPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ZACPI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ZACPI> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ZACPI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ZACPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ZACPI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
