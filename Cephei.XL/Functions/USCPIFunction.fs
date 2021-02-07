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
  US CPI index
  </summary> *)
[<AutoSerializable(true)>]
module USCPIFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_USCPI1", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_create1
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
                let builder (current : ICell) = (Fun.USCPI1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USCPI>) l

                let source () = Helper.sourceFold "Fun.USCPI1" 
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
                    ; subscriber = Helper.subscriberModel<USCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USCPI", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = (Fun.USCPI 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<USCPI>) l

                let source () = Helper.sourceFold "Fun.USCPI" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USCPI_clone", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="h",Description = "ZeroInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_USCPI.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
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
    [<ExcelFunction(Name="_USCPI_fixing", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Date")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Fixing") 

                                               [| _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_zeroInflationTermStructure", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_USCPI.source + ".ZeroInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
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
    [<ExcelFunction(Name="_USCPI_addFixing", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_availabilityLag", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_USCPI.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USCPI_currency", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_USCPI.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
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
    [<ExcelFunction(Name="_USCPI_familyName", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_fixingCalendar", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_USCPI.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USCPI_frequency", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_interpolated", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_isValidFixingDate", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_name", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_region", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_USCPI.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<USCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_USCPI_revised", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_update", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).Update
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_addFixings", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_addFixings1", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_allowsNativeFixings", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_clearFixings", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).ClearFixings
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_registerWith", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_timeSeries", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_unregisterWith", Description="Create a USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="USCPI",Description = "USCPI")>] 
         uscpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _USCPI = Helper.toCell<USCPI> uscpi "USCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((USCPIModel.Cast _USCPI.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : USCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_USCPI.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _USCPI.cell
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
    [<ExcelFunction(Name="_USCPI_Range", Description="Create a range of USCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let USCPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<USCPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<USCPI> (c)) :> ICell
                let format (i : Cephei.Cell.List<USCPI>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<USCPI>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
