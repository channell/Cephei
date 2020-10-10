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
(*!! generic
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module TimeSeriesFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TimeSeries_Add", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="key",Description = "Reference to key")>] 
         key : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _key = Helper.toCell<Date> key "key" 
                let _value = Helper.toCell<'T> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Add
                                                            _key.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : TimeSeries) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Add") 
                                               [| _TimeSeries.source
                                               ;  _key.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _key.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_TimeSeries_Add", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Add
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="item",Description = "Reference to item")>] 
         item : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _item = Helper.toCell<Generic.KeyValuePair<Date,T>> item "item" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Add1
                                                            _item.cell 
                                                       ) :> ICell
                let format (o : TimeSeries) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Add") 
                                               [| _TimeSeries.source
                                               ;  _item.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _item.cell
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
    [<ExcelFunction(Name="_TimeSeries_Clear", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Clear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Clear
                                                       ) :> ICell
                let format (o : TimeSeries) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Clear") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
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
    [<ExcelFunction(Name="_TimeSeries_Contains", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Contains
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="item",Description = "Reference to item")>] 
         item : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _item = Helper.toCell<Generic.KeyValuePair<Date,T>> item "item" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Contains
                                                            _item.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Contains") 
                                               [| _TimeSeries.source
                                               ;  _item.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _item.cell
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
    [<ExcelFunction(Name="_TimeSeries_ContainsKey", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_ContainsKey
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="key",Description = "Reference to key")>] 
         key : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _key = Helper.toCell<Date> key "key" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).ContainsKey
                                                            _key.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".ContainsKey") 
                                               [| _TimeSeries.source
                                               ;  _key.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _key.cell
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
    [<ExcelFunction(Name="_TimeSeries_CopyTo", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_CopyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="array",Description = "Reference to array")>] 
         array : obj)
        ([<ExcelArgument(Name="arrayIndex",Description = "Reference to arrayIndex")>] 
         arrayIndex : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _array = Helper.toCell<Generic.KeyValuePair<Date,T>[]> array "array" 
                let _arrayIndex = Helper.toCell<int> arrayIndex "arrayIndex" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).CopyTo
                                                            _array.cell 
                                                            _arrayIndex.cell 
                                                       ) :> ICell
                let format (o : TimeSeries) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".CopyTo") 
                                               [| _TimeSeries.source
                                               ;  _array.source
                                               ;  _arrayIndex.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _array.cell
                                ;  _arrayIndex.cell
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
    [<ExcelFunction(Name="_TimeSeries_Count", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Count
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Count
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Count") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
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
    [<ExcelFunction(Name="_TimeSeries_GetEnumerator", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_GetEnumerator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).GetEnumerator
                                                       ) :> ICell
                let format (o : IEnumerator<Generic.KeyValuePair<Date,T>>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".GetEnumerator") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
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
    [<ExcelFunction(Name="_TimeSeries_IsReadOnly", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_IsReadOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).IsReadOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".IsReadOnly") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
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
    [<ExcelFunction(Name="_TimeSeries_Keys", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Keys
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Keys
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ICollection<Date>>) l

                let source () = Helper.sourceFold (_TimeSeries.source + ".Keys") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeSeries> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeSeries_Remove", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Remove
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="item",Description = "Reference to item")>] 
         item : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _item = Helper.toCell<Generic.KeyValuePair<Date,T>> item "item" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Remove
                                                            _item.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Remove") 
                                               [| _TimeSeries.source
                                               ;  _item.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _item.cell
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
    [<ExcelFunction(Name="_TimeSeries_Remove", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Remove
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="key",Description = "Reference to key")>] 
         key : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _key = Helper.toCell<Date> key "key" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Remove1
                                                            _key.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Remove") 
                                               [| _TimeSeries.source
                                               ;  _key.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _key.cell
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
    [<ExcelFunction(Name="_TimeSeries_this", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="key",Description = "Reference to key")>] 
         key : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _key = Helper.toCell<Date> key "key" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).This
                                                            _key.cell 
                                                       ) :> ICell
                let format (o : T) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".This") 
                                               [| _TimeSeries.source
                                               ;  _key.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _key.cell
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
    [<ExcelFunction(Name="_TimeSeries", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TimeSeries 
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeSeries>) l

                let source () = Helper.sourceFold "Fun.TimeSeries" 
                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeSeries> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructors
    *)
    [<ExcelFunction(Name="_TimeSeries1", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.TimeSeries1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeSeries>) l

                let source () = Helper.sourceFold "Fun.TimeSeries1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TimeSeries> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TimeSeries_TryGetValue", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_TryGetValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        ([<ExcelArgument(Name="key",Description = "Reference to key")>] 
         key : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let _key = Helper.toCell<Date> key "key" 
                let _value = Helper.toCell<'T> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).TryGetValue
                                                            _key.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".TryGetValue") 
                                               [| _TimeSeries.source
                                               ;  _key.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
                                ;  _key.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_TimeSeries_Values", Description="Create a TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TimeSeries",Description = "Reference to TimeSeries")>] 
         timeseries : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TimeSeries = Helper.toCell<TimeSeries> timeseries "TimeSeries"  
                let builder (current : ICell) = withMnemonic mnemonic ((TimeSeriesModel.Cast _TimeSeries.cell).Values
                                                       ) :> ICell
                let format (o : ICollection<T>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TimeSeries.source + ".Values") 
                                               [| _TimeSeries.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TimeSeries.cell
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
    [<ExcelFunction(Name="_TimeSeries_Range", Description="Create a range of TimeSeries",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TimeSeries_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TimeSeries")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TimeSeries> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TimeSeries>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TimeSeries>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TimeSeries>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
