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
  AU CPI index (either quarterly or annual)
  </summary> *)
[<AutoSerializable(true)>]
module AUCPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_create
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

                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<ZeroInflationTermStructure> ts "ts" 
                let builder () = withMnemonic mnemonic (Fun.AUCPI 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AUCPI>) l

                let source = Helper.sourceFold "Fun.AUCPI" 
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
                    ; subscriber = Helper.subscriberModel<AUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI1", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_create1
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

                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder () = withMnemonic mnemonic (Fun.AUCPI1 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AUCPI>) l

                let source = Helper.sourceFold "Fun.AUCPI1" 
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
                    ; subscriber = Helper.subscriberModel<AUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI_clone", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_AUCPI.source + ".Clone") 
                                               [| _AUCPI.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
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
    [<ExcelFunction(Name="_AUCPI_fixing", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Reference to aFixingDate")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Fixing") 
                                               [| _AUCPI.source
                                               ;  _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_zeroInflationTermStructure", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source = Helper.sourceFold (_AUCPI.source + ".ZeroInflationTermStructure") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
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
    [<ExcelFunction(Name="_AUCPI_addFixing", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".AddFixing") 
                                               [| _AUCPI.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_availabilityLag", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_AUCPI.source + ".AvailabilityLag") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI_currency", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_AUCPI.source + ".Currency") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
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
    [<ExcelFunction(Name="_AUCPI_familyName", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".FamilyName") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_fixingCalendar", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_AUCPI.source + ".FixingCalendar") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI_frequency", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Frequency") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_interpolated", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Interpolated") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_isValidFixingDate", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".IsValidFixingDate") 
                                               [| _AUCPI.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_name", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Name") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_region", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_AUCPI.source + ".Region") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AUCPI_revised", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Revised") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_update", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).Update
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".Update") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_addFixings", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".AddFixings") 
                                               [| _AUCPI.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_addFixings1", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".AddFixings") 
                                               [| _AUCPI.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_allowsNativeFixings", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".AllowsNativeFixings") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_clearFixings", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).ClearFixings
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".ClearFixings") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_registerWith", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".RegisterWith") 
                                               [| _AUCPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_timeSeries", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".TimeSeries") 
                                               [| _AUCPI.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_unregisterWith", Description="Create a AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AUCPI",Description = "Reference to AUCPI")>] 
         aucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AUCPI = Helper.toCell<AUCPI> aucpi "AUCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AUCPI.cell :?> AUCPIModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AUCPI) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AUCPI.source + ".UnregisterWith") 
                                               [| _AUCPI.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AUCPI.cell
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
    [<ExcelFunction(Name="_AUCPI_Range", Description="Create a range of AUCPI",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AUCPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AUCPI")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AUCPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AUCPI>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AUCPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AUCPI>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
