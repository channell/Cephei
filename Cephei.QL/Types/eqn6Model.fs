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

Relates to eqn6 Genz 2004
  </summary> *)
[<AutoSerializable(true)>]
type eqn6Model
    ( a                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    , bs                                           : ICell<double>
    , hk                                           : ICell<double>
    ) as this =

    inherit Model<eqn6> ()
(*
    Parameters
*)
    let _a                                         = a
    let _c                                         = c
    let _d                                         = d
    let _bs                                        = bs
    let _hk                                        = hk
(*
    Functions
*)
    let _eqn6                                      = cell (fun () -> new eqn6 (a.Value, c.Value, d.Value, bs.Value, hk.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _eqn6.Value.value(x.Value))
    do this.Bind(_eqn6)

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.bs                                 = _bs 
    member this.hk                                 = _hk 
    member this.Value                              x   
                                                   = _value x 
