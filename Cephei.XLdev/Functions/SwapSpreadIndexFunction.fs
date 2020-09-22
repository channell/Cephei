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
    [<ExcelFunction(Name="_SwapSpreadIndex_allowsNativeFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".AllowsNativeFixings") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_forecastFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".ForecastFixing") 
                                               [| _SwapSpreadIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_gearing1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_gearing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Gearing1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Gearing1") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_gearing2", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_gearing2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Gearing2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Gearing2") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_maturityDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".MaturityDate") 
                                               [| _SwapSpreadIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_pastFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".PastFixing") 
                                               [| _SwapSpreadIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        ! \name Inspectors
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_swapIndex1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_swapIndex1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).SwapIndex1
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".SwapIndex1") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_swapIndex2", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_swapIndex2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).SwapIndex2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".SwapIndex2") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        need by CashFlowVectors
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SwapSpreadIndex 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapSpreadIndex>) l

                let source = Helper.sourceFold "Fun.SwapSpreadIndex" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_SwapSpreadIndex1", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="familyName",Description = "Reference to familyName")>] 
         familyName : obj)
        ([<ExcelArgument(Name="swapIndex1",Description = "Reference to swapIndex1")>] 
         swapIndex1 : obj)
        ([<ExcelArgument(Name="swapIndex2",Description = "Reference to swapIndex2")>] 
         swapIndex2 : obj)
        ([<ExcelArgument(Name="gearing1",Description = "Reference to gearing1")>] 
         gearing1 : obj)
        ([<ExcelArgument(Name="gearing2",Description = "Reference to gearing2")>] 
         gearing2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _familyName = Helper.toCell<String> familyName "familyName" true
                let _swapIndex1 = Helper.toCell<SwapIndex> swapIndex1 "swapIndex1" true
                let _swapIndex2 = Helper.toCell<SwapIndex> swapIndex2 "swapIndex2" true
                let _gearing1 = Helper.toCell<double> gearing1 "gearing1" true
                let _gearing2 = Helper.toCell<double> gearing2 "gearing2" true
                let builder () = withMnemonic mnemonic (Fun.SwapSpreadIndex1 
                                                            _familyName.cell 
                                                            _swapIndex1.cell 
                                                            _swapIndex2.cell 
                                                            _gearing1.cell 
                                                            _gearing2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapSpreadIndex>) l

                let source = Helper.sourceFold "Fun.SwapSpreadIndex1" 
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
    [<ExcelFunction(Name="_SwapSpreadIndex_currency", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Currency") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_dayCounter", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".DayCounter") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_familyName", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".FamilyName") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_fixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Fixing") 
                                               [| _SwapSpreadIndex.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingCalendar", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingCalendar") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingDate") 
                                               [| _SwapSpreadIndex.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_fixingDays", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".FixingDays") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_isValidFixingDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".IsValidFixingDate") 
                                               [| _SwapSpreadIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_name", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Name") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_tenor", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Tenor") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Observer interface
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_update", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).Update
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".Update") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_valueDate", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".ValueDate") 
                                               [| _SwapSpreadIndex.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixing", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _d = Helper.toCell<Date> d "d" true
                let _v = Helper.toCell<double> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixing") 
                                               [| _SwapSpreadIndex.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _d = Helper.toCell<Generic.List<Date>> d "d" true
                let _v = Helper.toCell<Generic.List<double>> v "v" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixings") 
                                               [| _SwapSpreadIndex.source
                                               ;  _d.source
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
    [<ExcelFunction(Name="_SwapSpreadIndex_addFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" true
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".AddFixings1") 
                                               [| _SwapSpreadIndex.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_SwapSpreadIndex_clearFixings", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).ClearFixings
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".ClearFixings") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_registerWith", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".RegisterWith") 
                                               [| _SwapSpreadIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_timeSeries", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".TimeSeries") 
                                               [| _SwapSpreadIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_unregisterWith", Description="Create a SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwapSpreadIndex",Description = "Reference to SwapSpreadIndex")>] 
         swapspreadindex : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwapSpreadIndex = Helper.toCell<SwapSpreadIndex> swapspreadindex "SwapSpreadIndex" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_SwapSpreadIndex.cell :?> SwapSpreadIndexModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SwapSpreadIndex) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwapSpreadIndex.source + ".UnregisterWith") 
                                               [| _SwapSpreadIndex.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwapSpreadIndex.cell
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
    [<ExcelFunction(Name="_SwapSpreadIndex_Range", Description="Create a range of SwapSpreadIndex",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwapSpreadIndex_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SwapSpreadIndex")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwapSpreadIndex> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SwapSpreadIndex>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SwapSpreadIndex>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SwapSpreadIndex>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
