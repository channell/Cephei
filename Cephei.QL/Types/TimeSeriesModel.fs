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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>

constructors
  </summary> *)
[<AutoSerializable(true)>]
type TimeSeriesModel<'T>
    () as this =
    inherit Model<TimeSeries<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _TimeSeries                                = make (fun () -> new TimeSeries<'T> ())
    let _Add                                       (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Add(item.Value)
                                                                                 _TimeSeries.Value)
    let _Add1                                      (key : ICell<Date>) (value : ICell<'T>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Add(key.Value, value.Value)
                                                                                 _TimeSeries.Value)
    let _Clear                                     = triv _TimeSeries (fun () -> _TimeSeries.Value.Clear()
                                                                                 _TimeSeries.Value)
    let _Contains                                  (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Contains(item.Value))
    let _ContainsKey                               (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.ContainsKey(key.Value))
    let _CopyTo                                    (array : ICell<KeyValuePair<Date,'T>[]>) (arrayIndex : ICell<int>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.CopyTo(array.Value, arrayIndex.Value)
                                                                                 _TimeSeries.Value)
    let _Count                                     = triv _TimeSeries (fun () -> _TimeSeries.Value.Count)
    let _GetEnumerator                             = triv _TimeSeries (fun () -> _TimeSeries.Value.GetEnumerator())
    let _IsReadOnly                                = triv _TimeSeries (fun () -> _TimeSeries.Value.IsReadOnly)
    let _Keys                                      = triv _TimeSeries (fun () -> _TimeSeries.Value.Keys)
    let _Remove                                    (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Remove(item.Value))
    let _Remove1                                   (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Remove(key.Value))
    let _this                                      (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.[key.Value])
    let _TryGetValue                               (key : ICell<Date>) (value : ICell<'T>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.TryGetValue(key.Value, ref value.Value))
    let _Values                                    = triv _TimeSeries (fun () -> _TimeSeries.Value.Values)
    do this.Bind(_TimeSeries)

(* 
    Externally visible/bindable properties
*)
    member this.Add                                item   
                                                   = _Add item 
    member this.Add1                               key value   
                                                   = _Add1 key value 
    member this.Clear                              = _Clear
    member this.Contains                           item   
                                                   = _Contains item 
    member this.ContainsKey                        key   
                                                   = _ContainsKey key 
    member this.CopyTo                             array arrayIndex   
                                                   = _CopyTo array arrayIndex 
    member this.Count                              = _Count
    member this.GetEnumerator                      = _GetEnumerator
    member this.IsReadOnly                         = _IsReadOnly
    member this.Keys                               = _Keys
    member this.Remove                             item   
                                                   = _Remove item 
    member this.Remove1                            key   
                                                   = _Remove1 key 
    member this.This                               key   
                                                   = _this key 
    member this.TryGetValue                        key value   
                                                   = _TryGetValue key value 
    member this.Values                             = _Values
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TimeSeriesModel1<'T>
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<TimeSeries<'T>> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let mutable
        _TimeSeries                                = make (fun () -> new TimeSeries<'T> (size.Value))
    let _Add                                       (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Add(item.Value)
                                                                                 _TimeSeries.Value)
    let _Add1                                      (key : ICell<Date>) (value : ICell<'T>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Add(key.Value, value.Value)
                                                                                 _TimeSeries.Value)
    let _Clear                                     = triv _TimeSeries (fun () -> _TimeSeries.Value.Clear()
                                                                                 _TimeSeries.Value)
    let _Contains                                  (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Contains(item.Value))
    let _ContainsKey                               (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.ContainsKey(key.Value))
    let _CopyTo                                    (array : ICell<KeyValuePair<Date,'T>[]>) (arrayIndex : ICell<int>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.CopyTo(array.Value, arrayIndex.Value)
                                                                                 _TimeSeries.Value)
    let _Count                                     = triv _TimeSeries (fun () -> _TimeSeries.Value.Count)
    let _GetEnumerator                             = triv _TimeSeries (fun () -> _TimeSeries.Value.GetEnumerator())
    let _IsReadOnly                                = triv _TimeSeries (fun () -> _TimeSeries.Value.IsReadOnly)
    let _Keys                                      = triv _TimeSeries (fun () -> _TimeSeries.Value.Keys)
    let _Remove                                    (item : ICell<KeyValuePair<Date,'T>>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Remove(item.Value))
    let _Remove1                                   (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.Remove(key.Value))
    let _this                                      (key : ICell<Date>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.[key.Value])
    let _TryGetValue                               (key : ICell<Date>) (value : ICell<'T>)   
                                                   = triv _TimeSeries (fun () -> _TimeSeries.Value.TryGetValue(key.Value, ref value.Value))
    let _Values                                    = triv _TimeSeries (fun () -> _TimeSeries.Value.Values)
    do this.Bind(_TimeSeries)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Add                                item   
                                                   = _Add item 
    member this.Add1                               key value   
                                                   = _Add1 key value 
    member this.Clear                              = _Clear
    member this.Contains                           item   
                                                   = _Contains item 
    member this.ContainsKey                        key   
                                                   = _ContainsKey key 
    member this.CopyTo                             array arrayIndex   
                                                   = _CopyTo array arrayIndex 
    member this.Count                              = _Count
    member this.GetEnumerator                      = _GetEnumerator
    member this.IsReadOnly                         = _IsReadOnly
    member this.Keys                               = _Keys
    member this.Remove                             item   
                                                   = _Remove item 
    member this.Remove1                            key   
                                                   = _Remove1 key 
    member this.This                               key   
                                                   = _this key 
    member this.TryGetValue                        key value   
                                                   = _TryGetValue key value 
    member this.Values                             = _Values
