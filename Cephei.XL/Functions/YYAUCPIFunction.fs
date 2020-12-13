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
    [<ExcelFunction(Name="_YYAUCPI1", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "bool")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        ([<ExcelArgument(Name="ts",Description = "YoYInflationTermStructure")>] 
         ts : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let _ts = Helper.toHandle<YoYInflationTermStructure> ts "ts" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYAUCPI1 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                            _ts.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPI>) l

                let source () = Helper.sourceFold "Fun.YYAUCPI1" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="frequency",Description = "Frequency: NoFrequency, Once, Annual, Semiannual, EveryFourthMonth, Quarterly, Bimonthly, Monthly, EveryFourthWeek, Biweekly, Weekly, Daily, OtherFrequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="revised",Description = "bool")>] 
         revised : obj)
        ([<ExcelArgument(Name="interpolated",Description = "bool")>] 
         interpolated : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _revised = Helper.toCell<bool> revised "revised" 
                let _interpolated = Helper.toCell<bool> interpolated "interpolated" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YYAUCPI 
                                                            _frequency.cell 
                                                            _revised.cell 
                                                            _interpolated.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YYAUCPI>) l

                let source () = Helper.sourceFold "Fun.YYAUCPI" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI_clone", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="h",Description = "YoYInflationTermStructure")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _h = Helper.toHandle<YoYInflationTermStructure> h "h" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Clone
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Clone") 

                                               [| _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
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
    [<ExcelFunction(Name="_YYAUCPI_fixing", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_ratio", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_ratio
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Ratio
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Ratio") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_yoyInflationTermStructure", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_yoyInflationTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).YoyInflationTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYInflationTermStructure>>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".YoyInflationTermStructure") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
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
    [<ExcelFunction(Name="_YYAUCPI_addFixing", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="fixing",Description = "double")>] 
         fixing : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _fixing = Helper.toCell<double> fixing "fixing" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).AddFixing
                                                            _fixingDate.cell 
                                                            _fixing.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".AddFixing") 

                                               [| _fixingDate.source
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
    [<ExcelFunction(Name="_YYAUCPI_availabilityLag", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_availabilityLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).AvailabilityLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".AvailabilityLag") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI_currency", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
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
    [<ExcelFunction(Name="_YYAUCPI_familyName", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_fixingCalendar", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI_frequency", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Frequency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_interpolated", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_interpolated
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Interpolated
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Interpolated") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_isValidFixingDate", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_name", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_region", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_region
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Region
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Region>) l

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Region") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YYAUCPI> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YYAUCPI_revised", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_revised
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Revised
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Revised") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_update", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).Update
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_addFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".AddFixings") 

                                               [| _d.source
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
    [<ExcelFunction(Name="_YYAUCPI_addFixings1", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_allowsNativeFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_clearFixings", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).ClearFixings
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_registerWith", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_timeSeries", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_unregisterWith", Description="Create a YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YYAUCPI",Description = "YYAUCPI")>] 
         yyaucpi : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YYAUCPI = Helper.toCell<YYAUCPI> yyaucpi "YYAUCPI"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((YYAUCPIModel.Cast _YYAUCPI.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : YYAUCPI) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YYAUCPI.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YYAUCPI.cell
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
    [<ExcelFunction(Name="_YYAUCPI_Range", Description="Create a range of YYAUCPI",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YYAUCPI_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YYAUCPI> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<YYAUCPI> (c)) :> ICell
                let format (i : Cephei.Cell.List<YYAUCPI>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<YYAUCPI>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
