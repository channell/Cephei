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
  References: Levy, D. Numerical Integration http://www2.math.umd.edu/~dlevy/classes/amsc466/lecture-notes/integration-chap.pdf
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type DiscreteTrapezoidIntegralModel
    () as this =
    inherit Model<DiscreteTrapezoidIntegral> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _DiscreteTrapezoidIntegral                 = cell (fun () -> new DiscreteTrapezoidIntegral ())
    let _value                                     (x : ICell<Vector>) (f : ICell<Vector>)   
                                                   = triv (fun () -> _DiscreteTrapezoidIntegral.Value.value(x.Value, f.Value))
    do this.Bind(_DiscreteTrapezoidIntegral)
(* 
    casting 
*)
    
    member internal this.Inject v = _DiscreteTrapezoidIntegral <- v
    static member Cast (p : ICell<DiscreteTrapezoidIntegral>) = 
        if p :? DiscreteTrapezoidIntegralModel then 
            p :?> DiscreteTrapezoidIntegralModel
        else
            let o = new DiscreteTrapezoidIntegralModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Value                              x f   
                                                   = _value x f 
