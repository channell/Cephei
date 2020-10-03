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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationTraitsModel
    () as this =
    inherit Model<YoYInflationTraits> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _YoYInflationTraits                        = cell (fun () -> new YoYInflationTraits ())
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.forwardImpl(i.Value, t.Value))
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.guess(i.Value, c.Value, validData.Value, f.Value))
    let _initialDate                               (t : ICell<YoYInflationTermStructure>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.initialDate(t.Value))
    let _initialValue                              (t : ICell<YoYInflationTermStructure>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.initialValue(t.Value))
    let _maxIterations                             = triv (fun () -> _YoYInflationTraits.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.maxValueAfter(i.Value, c.Value, validData.Value, f.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.minValueAfter(i.Value, c.Value, validData.Value, f.Value))
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _YoYInflationTraits.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _YoYInflationTraits.Value.zeroYieldImpl(i.Value, t.Value))
    do this.Bind(_YoYInflationTraits)
(* 
    casting 
*)
    
    member internal this.Inject v = _YoYInflationTraits.Value <- v
    static member Cast (p : ICell<YoYInflationTraits>) = 
        if p :? YoYInflationTraitsModel then 
            p :?> YoYInflationTraitsModel
        else
            let o = new YoYInflationTraitsModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Guess                              i c validData f   
                                                   = _guess i c validData f 
    member this.InitialDate                        t   
                                                   = _initialDate t 
    member this.InitialValue                       t   
                                                   = _initialValue t 
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData f   
                                                   = _maxValueAfter i c validData f 
    member this.MinValueAfter                      i c validData f   
                                                   = _minValueAfter i c validData f 
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
