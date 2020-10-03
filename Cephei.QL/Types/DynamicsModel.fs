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
  Short-rate dynamics in the Hull-White model

  </summary> *)
[<AutoSerializable(true)>]
type DynamicsModel
    ( fitting                                      : ICell<Parameter>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<Dynamics> ()
(*
    Parameters
*)
    let _fitting                                   = fitting
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let _Dynamics                                  = cell (fun () -> new Dynamics (fitting.Value, a.Value, sigma.Value))
    let _shortRate                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = cell (fun () -> _Dynamics.Value.shortRate(t.Value, x.Value))
    let _variable                                  (t : ICell<double>) (r : ICell<double>)   
                                                   = cell (fun () -> _Dynamics.Value.variable(t.Value, r.Value))
    let _process                                   = cell (fun () -> _Dynamics.Value.PROCESS())
    do this.Bind(_Dynamics)
(* 
    casting 
*)
    internal new () = DynamicsModel(null,null,null)
    member internal this.Inject v = _Dynamics.Value <- v
    static member Cast (p : ICell<Dynamics>) = 
        if p :? DynamicsModel then 
            p :?> DynamicsModel
        else
            let o = new DynamicsModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = DynamicsModel(null,null,null)
    static member Cast (p : ICell<Dynamics>) = 
        if p :? DynamicsModel then 
            p :?> DynamicsModel
        else
            let o = new DynamicsModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.fitting                            = _fitting 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.ShortRate                          t x   
                                                   = _shortRate t x 
    member this.Variable                           t r   
                                                   = _variable t r 
    member this.Process                            = _process
