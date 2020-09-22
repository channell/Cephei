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
  EU HICP index
  </summary> *)
[<AutoSerializable(true)>]
module EUHICPFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EUHICP", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_create
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
                let builder () = withMnemonic mnemonic (Fun.EUHICP 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EUHICP>) l

                let source = Helper.sourceFold "Fun.EUHICP" 
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
    [<ExcelFunction(Name="_EUHICP1", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" true
                let builder () = withMnemonic mnemonic (Fun.EUHICP1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EUHICP>) l

                let source = Helper.sourceFold "Fun.EUHICP1" 
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
    [<ExcelFunction(Name="_EUHICP_clone", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _h = Helper.toHandle<Handle<ZeroInflationTermStructure>> h "h" 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_EUHICP.source + ".Clone") 
                                               [| _EUHICP.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_fixing", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="aFixingDate",Description = "Reference to aFixingDate")>] 
         aFixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _aFixingDate = Helper.toCell<Date> aFixingDate "aFixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Fixing
                                                            _aFixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Fixing") 
                                               [| _EUHICP.source
                                               ;  _aFixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_zeroInflationTermStructure", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_zeroInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).ZeroInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<ZeroInflationTermStructure>>) l

                let source = Helper.sourceFold (_EUHICP.source + ".ZeroInflationTermStructure") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_addFixing", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _fixing = Helper.toCell<double> fixing "fixing" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".AddFixing") 
                                               [| _EUHICP.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_availabilityLag", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_EUHICP.source + ".AvailabilityLag") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_currency", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_EUHICP.source + ".Currency") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_familyName", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".FamilyName") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_fixingCalendar", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_EUHICP.source + ".FixingCalendar") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_frequency", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Frequency") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_interpolated", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Interpolated") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_isValidFixingDate", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".IsValidFixingDate") 
                                               [| _EUHICP.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_name", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Name") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_region", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_EUHICP.source + ".Region") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_revised", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Revised") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_update", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).Update
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".Update") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_addFixings", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".AddFixings") 
                                               [| _EUHICP.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_addFixings", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".AddFixings1") 
                                               [| _EUHICP.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_allowsNativeFixings", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".AllowsNativeFixings") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_clearFixings", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).ClearFixings
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".ClearFixings") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_registerWith", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".RegisterWith") 
                                               [| _EUHICP.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_timeSeries", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".TimeSeries") 
                                               [| _EUHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_unregisterWith", Description="Create a EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EUHICP",Description = "Reference to EUHICP")>] 
         euhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EUHICP = Helper.toCell<EUHICP> euhicp "EUHICP" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_EUHICP.cell :?> EUHICPModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : EUHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_EUHICP.source + ".UnregisterWith") 
                                               [| _EUHICP.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EUHICP.cell
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
    [<ExcelFunction(Name="_EUHICP_Range", Description="Create a range of EUHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EUHICP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EUHICP")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EUHICP> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EUHICP>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EUHICP>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EUHICP>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
