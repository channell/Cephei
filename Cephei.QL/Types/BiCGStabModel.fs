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


  </summary> *)
[<AutoSerializable(true)>]
type BiCGStabModel
    ( A                                            : ICell<BiCGStab.MatrixMult>
    , maxIter                                      : ICell<int>
    , relTol                                       : ICell<double>
    , preConditioner                               : ICell<BiCGStab.MatrixMult>
    ) as this =

    inherit Model<BiCGStab> ()
(*
    Parameters
*)
    let _A                                         = A
    let _maxIter                                   = maxIter
    let _relTol                                    = relTol
    let _preConditioner                            = preConditioner
(*
    Functions
*)
    let _BiCGStab                                  = cell (fun () -> new BiCGStab (A.Value, maxIter.Value, relTol.Value, preConditioner.Value))
    let _solve                                     (b : ICell<Vector>) (x0 : ICell<Vector>)   
                                                   = triv (fun () -> _BiCGStab.Value.solve(b.Value, x0.Value))
    do this.Bind(_BiCGStab)
(* 
    casting 
*)
    internal new () = BiCGStabModel(null,null,null,null)
    member internal this.Inject v = _BiCGStab.Value <- v
    static member Cast (p : ICell<BiCGStab>) = 
        if p :? BiCGStabModel then 
            p :?> BiCGStabModel
        else
            let o = new BiCGStabModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.A                                  = _A 
    member this.maxIter                            = _maxIter 
    member this.relTol                             = _relTol 
    member this.preConditioner                     = _preConditioner 
    member this.Solve                              b x0   
                                                   = _solve b x0 
