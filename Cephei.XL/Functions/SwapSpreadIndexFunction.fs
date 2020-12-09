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

  </summary> *)
[<AutoSerializable(true)>]
module SwapSpreadIndexFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_allowsNativeFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".AllowsNativeFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_forecastFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".ForecastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_gearing1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_gearing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Gearing1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Gearing1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_gearing2", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_gearing2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Gearing2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Gearing2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_maturityDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".MaturityDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_pastFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".PastFixing") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        ! \name Inspectors
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_swapIndex1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_swapIndex1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).SwapIndex1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".SwapIndex1") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_swapIndex2", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_swapIndex2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).SwapIndex2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".SwapIndex2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapSpreadIndex1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapSpreadIndex>) l

                let source () = Helper.sourceFold "Fun.SwapSpreadIndex1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "String")>] 
         familyName : obj)
        ([<ExcelArgument(Name="swapIndex1",Description = "SwapIndex")>] 
         swapIndex1 : obj)
        ([<ExcelArgument(Name="swapIndex2",Description = "SwapIndex")>] 
         swapIndex2 : obj)
        ([<ExcelArgument(Name="gearing1",Description = "double or empty")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "double or empty")>] 
         gearing2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<String> familyName "familyName" 
                let _swapIndex1 = Helper.toCell<SwapIndex> swapIndex1 "swapIndex1" 
                let _swapIndex2 = Helper.toCell<SwapIndex> swapIndex2 "swapIndex2" 
                let _gearing1 = Helper.toDefault<double> gearing1 "gearing1" 1.0
                let _gearing2 = Helper.toDefault<double> gearing2 "gearing2" -1.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SwapSpreadIndex
                                                            _familyName.cell 
                                                            _swapIndex1.cell 
                                                            _swapIndex2.cell 
                                                            _gearing1.cell 
                                                            _gearing2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapSpreadIndex>) l

                let source () = Helper.sourceFold "Fun.SwapSpreadIndex1" 
                                               [| _familyName.source
                                               ;  _swapIndex1.source
                                               ;  _swapIndex2.source
                                               ;  _gearing1.source
                                               ;  _gearing2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _familyName.cell
                                ;  _swapIndex1.cell
                                ;  _swapIndex2.cell
                                ;  _gearing1.cell
                                ;  _gearing2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_currency", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Currency") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_dayCounter", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".DayCounter") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
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
    [<ExcelFunction(Name="_SwapSpreadIndex_familyName", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".FamilyName") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_fixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "bool")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Fixing") 

                                               [| _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingCalendar", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingCalendar") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Date")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingDate") 

                                               [| _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingDays", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingDays") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_isValidFixingDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".IsValidFixingDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_name", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Name") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_tenor", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Tenor") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwapSpreadIndex> format
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
    [<ExcelFunction(Name="_SwapSpreadIndex_update", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).Update
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_valueDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Date")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".ValueDate") 

                                               [| _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixing") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="d",Description = "Date range")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "double range")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixings") 

                                               [| _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixings1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="source",Description = "double")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "bool")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixings1") 

                                               [| _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_clearFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).ClearFixings
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".ClearFixings") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_registerWith", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_timeSeries", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".TimeSeries") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_unregisterWith", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((SwapSpreadIndexModel.Cast _SwapSpreadIndex.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SwapSpreadIndex.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_Range", Description="Create a range of SwapSpreadIndex",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SwapSpreadIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwapSpreadIndex> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SwapSpreadIndex> (c)) :> ICell
                let format (i : Generic.List<ICell<SwapSpreadIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SwapSpreadIndex>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
