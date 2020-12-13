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
  FR HICP index
  </summary> *)
[<AutoSerializable(true)>]
module FRHICPFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FRHICP 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FRHICP>) l

                let source () = Helper.sourceFold "Fun.FRHICP" 
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
                    ; subscriber = Helper.subscriberModel<FRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP1", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FRHICP1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FRHICP>) l

                let source () = Helper.sourceFold "Fun.FRHICP1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP_clone", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="h",Description = "ZeroInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _h = Helper.toHandle<ZeroInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
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
    [<ExcelFunction(Name="_FRHICP_fixing", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Date")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Fixing") 

                                               [| _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_zeroInflationTermStructure", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".ZeroInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
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
    [<ExcelFunction(Name="_FRHICP_addFixing", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_availabilityLag", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP_currency", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
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
    [<ExcelFunction(Name="_FRHICP_familyName", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_fixingCalendar", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP_frequency", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_interpolated", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_isValidFixingDate", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_name", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_region", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_FRHICP.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FRHICP_revised", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_update", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).Update
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_addFixings", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_addFixings1", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_allowsNativeFixings", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_clearFixings", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).ClearFixings
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_registerWith", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_timeSeries", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_unregisterWith", Description="Create a FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FRHICP",Description = "FRHICP")>] 
         frhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FRHICP = Helper.toCell<FRHICP> frhicp "FRHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FRHICPModel.Cast _FRHICP.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FRHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FRHICP.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FRHICP.cell
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
    [<ExcelFunction(Name="_FRHICP_Range", Description="Create a range of FRHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FRHICP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FRHICP> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FRHICP> (c)) :> ICell
                let format (i : Cephei.Cell.List<FRHICP>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FRHICP>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
