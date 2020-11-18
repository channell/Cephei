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
  UK Retail Price Inflation Index
  </summary> *)
[<AutoSerializable(true)>]
module UKRPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "ZeroInflationTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<ZeroInflationTermStructure> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UKRPI 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UKRPI>) l

                let source () = Helper.sourceFold "Fun.UKRPI" 
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
                    ; subscriber = Helper.subscriberModel<UKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI1", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.UKRPI1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<UKRPI>) l

                let source () = Helper.sourceFold "Fun.UKRPI1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI_clone", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="h",Description = "ZeroInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
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
    [<ExcelFunction(Name="_UKRPI_fixing", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Date")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Fixing") 

                                               [| _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                ;  _aFixingDate.cell
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
    [<ExcelFunction(Name="_UKRPI_zeroInflationTermStructure", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".ZeroInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
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
    [<ExcelFunction(Name="_UKRPI_addFixing", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_availabilityLag", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI_currency", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
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
    [<ExcelFunction(Name="_UKRPI_familyName", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_fixingCalendar", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI_frequency", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_interpolated", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_isValidFixingDate", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_name", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_region", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_UKRPI.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<UKRPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_UKRPI_revised", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_update", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).Update
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_addFixings", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_addFixings1", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_allowsNativeFixings", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_clearFixings", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).ClearFixings
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_registerWith", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_timeSeries", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_unregisterWith", Description="Create a UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="UKRPI",Description = "UKRPI")>] 
         ukrpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _UKRPI = Helper.toCell<UKRPI> ukrpi "UKRPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((UKRPIModel.Cast _UKRPI.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : UKRPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_UKRPI.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _UKRPI.cell
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
    [<ExcelFunction(Name="_UKRPI_Range", Description="Create a range of UKRPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let UKRPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<UKRPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<UKRPI> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<UKRPI>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<UKRPI>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
