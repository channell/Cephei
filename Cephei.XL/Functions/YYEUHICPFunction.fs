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
  Genuine year-on-year EU HICP (i.e. not a ratio of EU HICP)
  </summary> *)
[<AutoSerializable(true)>]
module YYEUHICPFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP1", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "YoYInflationTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYEUHICP1 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYEUHICP>) l

                let source () = Helper.sourceFold "Fun.YYEUHICP1" 
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
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYEUHICP
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYEUHICP>) l

                let source () = Helper.sourceFold "Fun.YYEUHICP" 
                                               [| _interpolated.source
                                               |]
                let hash = Helper.hashFold 
                                [| _interpolated.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP_clone", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="h",Description = "YoYInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
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
    [<ExcelFunction(Name="_YYEUHICP_fixing", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_YYEUHICP_ratio", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Ratio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_yoyInflationTermStructure", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".YoyInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
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
    [<ExcelFunction(Name="_YYEUHICP_addFixing", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".AddFixing") 

                                               [| _fixingDate.source
                                               ;  _fixing.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_availabilityLag", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP_currency", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
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
    [<ExcelFunction(Name="_YYEUHICP_familyName", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_fixingCalendar", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP_frequency", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_interpolated", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_isValidFixingDate", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_name", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_region", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYEUHICP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYEUHICP_revised", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_update", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).Update
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_addFixings", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_addFixings1", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_allowsNativeFixings", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_clearFixings", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_registerWith", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_timeSeries", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_unregisterWith", Description="Create a YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYEUHICP",Description = "YYEUHICP")>] 
         yyeuhicp : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYEUHICP = Helper.toCell<YYEUHICP> yyeuhicp "YYEUHICP"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYEUHICPModel.Cast _YYEUHICP.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYEUHICP) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYEUHICP.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYEUHICP.cell
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
    [<ExcelFunction(Name="_YYEUHICP_Range", Description="Create a range of YYEUHICP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYEUHICP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYEUHICP> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<YYEUHICP> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<YYEUHICP>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<YYEUHICP>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
