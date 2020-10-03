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
  References: http://en.wikipedia.org/wiki/Richardson_extrapolation

  </summary> *)
[<AutoSerializable(true)>]
type RichardsonEqnModel
    ( fh                                           : ICell<double>
    , ft                                           : ICell<double>
    , fs                                           : ICell<double>
    , t                                            : ICell<double>
    , s                                            : ICell<double>
    ) as this =

    inherit Model<RichardsonEqn> ()
(*
    Parameters
*)
    let _fh                                        = fh
    let _ft                                        = ft
    let _fs                                        = fs
    let _t                                         = t
    let _s                                         = s
(*
    Functions
*)
    let _RichardsonEqn                             = cell (fun () -> new RichardsonEqn (fh.Value, ft.Value, fs.Value, t.Value, s.Value))
    let _value                                     (k : ICell<double>)   
                                                   = triv (fun () -> _RichardsonEqn.Value.value(k.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _RichardsonEqn.Value.derivative(x.Value))
    do this.Bind(_RichardsonEqn)
(* 
    casting 
*)
    internal new () = RichardsonEqnModel(null,null,null,null,null)
    member internal this.Inject v = _RichardsonEqn.Value <- v
    static member Cast (p : ICell<RichardsonEqn>) = 
        if p :? RichardsonEqnModel then 
            p :?> RichardsonEqnModel
        else
            let o = new RichardsonEqnModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.fh                                 = _fh 
    member this.ft                                 = _ft 
    member this.fs                                 = _fs 
    member this.t                                  = _t 
    member this.s                                  = _s 
    member this.Value                              k   
                                                   = _value k 
    member this.Derivative                         x   
                                                   = _derivative x 
