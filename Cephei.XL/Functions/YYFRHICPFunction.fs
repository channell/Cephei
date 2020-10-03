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
  Genuine year-on-year FR HICP (i.e. not a ratio)
  </summary> *)
[<AutoSerializable(true)>]
module YYFRHICPFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP1", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "Reference to interpolated")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder () = withMnemonic mnemonic (Fun.YYFRHICP1 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICP>) l

                let source = Helper.sourceFold "Fun.YYFRHICP1" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_create
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
                let builder () = withMnemonic mnemonic (Fun.YYFRHICP
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYFRHICP>) l

                let source = Helper.sourceFold "Fun.YYFRHICP" 
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
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP_clone", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".Clone") 
                                               [| _YYFRHICP.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
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
    [<ExcelFunction(Name="_YYFRHICP_fixing", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Fixing") 
                                               [| _YYFRHICP.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_ratio", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Ratio") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_yoyInflationTermStructure", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".YoyInflationTermStructure") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
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
    [<ExcelFunction(Name="_YYFRHICP_addFixing", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "Reference to fixing")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".AddFixing") 
                                               [| _YYFRHICP.source
                                               ;  _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_availabilityLag", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".AvailabilityLag") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP_currency", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".Currency") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
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
    [<ExcelFunction(Name="_YYFRHICP_familyName", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".FamilyName") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_fixingCalendar", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".FixingCalendar") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP_frequency", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Frequency") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_interpolated", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Interpolated") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_isValidFixingDate", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".IsValidFixingDate") 
                                               [| _YYFRHICP.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_name", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Name") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_region", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source = Helper.sourceFold (_YYFRHICP.source + ".Region") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYFRHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYFRHICP_revised", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Revised") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_update", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).Update
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".Update") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_addFixings", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".AddFixings") 
                                               [| _YYFRHICP.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_addFixings1", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".AddFixings1") 
                                               [| _YYFRHICP.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_allowsNativeFixings", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".AllowsNativeFixings") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_clearFixings", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".ClearFixings") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_registerWith", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".RegisterWith") 
                                               [| _YYFRHICP.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_timeSeries", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".TimeSeries") 
                                               [| _YYFRHICP.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_unregisterWith", Description="Create a YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYFRHICP",Description = "Reference to YYFRHICP")>] 
         yyfrhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYFRHICP = Helper.toCell<YYFRHICP> yyfrhicp "YYFRHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((YYFRHICPModel.Cast _YYFRHICP.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYFRHICP) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YYFRHICP.source + ".UnregisterWith") 
                                               [| _YYFRHICP.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYFRHICP.cell
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
    [<ExcelFunction(Name="_YYFRHICP_Range", Description="Create a range of YYFRHICP",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YYFRHICP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YYFRHICP")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYFRHICP> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YYFRHICP>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YYFRHICP>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YYFRHICP>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
