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
  bootstrap error

  </summary> *)
[<AutoSerializable(true)>]
type BootstrapErrorModel<'T, 'U when 'T :> Curve<'U> and 'U :> TermStructure>
    ( curve                                        : ICell<'T>
    , helper                                       : ICell<BootstrapHelper<'U>>
    , segment                                      : ICell<int>
    ) as this =

    inherit Model<BootstrapError<'T,'U>> ()
(*
    Parameters
*)
    let _curve                                     = curve
    let _helper                                    = helper
    let _segment                                   = segment
(*
    Functions
*)
    let _BootstrapError                            = cell (fun () -> new BootstrapError<'T,'U> (curve.Value, helper.Value, segment.Value))
    let _value                                     (guess : ICell<double>)   
                                                   = triv (fun () -> _BootstrapError.Value.value(guess.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _BootstrapError.Value.derivative(x.Value))
    do this.Bind(_BootstrapError)

(* 
    Externally visible/bindable properties
*)
    member this.curve                              = _curve 
    member this.helper                             = _helper 
    member this.segment                            = _segment 
    member this.Value                              guess   
                                                   = _value guess 
    member this.Derivative                         x   
                                                   = _derivative x 
