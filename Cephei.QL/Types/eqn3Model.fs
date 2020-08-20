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

Relates to eqn3 Genz 2004
  </summary> *)
[<AutoSerializable(true)>]
type eqn3Model
    ( h                                            : ICell<double>
    , k                                            : ICell<double>
    , Asr                                          : ICell<double>
    ) as this =

    inherit Model<eqn3> ()
(*
    Parameters
*)
    let _h                                         = h
    let _k                                         = k
    let _Asr                                       = Asr
(*
    Functions
*)
    let _eqn3                                      = cell (fun () -> new eqn3 (h.Value, k.Value, Asr.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _eqn3.Value.value(x.Value))
    do this.Bind(_eqn3)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.k                                  = _k 
    member this.Asr                                = _Asr 
    member this.Value                              x   
                                                   = _value x 
