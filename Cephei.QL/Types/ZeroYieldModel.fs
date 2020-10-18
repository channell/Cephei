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
  Zero-curve traits
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type ZeroYieldModel
    () as this =
    inherit Model<ZeroYield> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ZeroYield                                 = cell (fun () -> new ZeroYield ())
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _ZeroYield.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _ZeroYield.Value.forwardImpl(i.Value, t.Value))
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _ZeroYield.Value.guess(i.Value, c.Value, validData.Value, f.Value))
    let _initialDate                               (c : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _ZeroYield.Value.initialDate(c.Value))
    let _initialValue                              (c : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _ZeroYield.Value.initialValue(c.Value))
    let _maxIterations                             = triv (fun () -> _ZeroYield.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _ZeroYield.Value.maxValueAfter(i.Value, c.Value, validData.Value, f.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (f : ICell<int>)   
                                                   = triv (fun () -> _ZeroYield.Value.minValueAfter(i.Value, c.Value, validData.Value, f.Value))
    let _updateGuess                               (data : ICell<Generic.List<double>>) (rate : ICell<double>) (i : ICell<int>)   
                                                   = triv (fun () -> _ZeroYield.Value.updateGuess(data.Value, rate.Value, i.Value)
                                                                     _ZeroYield.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _ZeroYield.Value.zeroYieldImpl(i.Value, t.Value))
    do this.Bind(_ZeroYield)
(* 
    casting 
*)
    
    member internal this.Inject v = _ZeroYield <- v
    static member Cast (p : ICell<ZeroYield>) = 
        if p :? ZeroYieldModel then 
            p :?> ZeroYieldModel
        else
            let o = new ZeroYieldModel ()
            o.Inject p
            o.Bind p
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
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialValue                       c   
                                                   = _initialValue c 
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData f   
                                                   = _maxValueAfter i c validData f 
    member this.MinValueAfter                      i c validData f   
                                                   = _minValueAfter i c validData f 
    member this.UpdateGuess                        data rate i   
                                                   = _updateGuess data rate i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
