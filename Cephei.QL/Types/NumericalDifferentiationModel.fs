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
type NumericalDifferentiationModel
    ( f                                            : ICell<Func<double,double>>
    , orderOfDerivative                            : ICell<int>
    , stepSize                                     : ICell<double>
    , steps                                        : ICell<int>
    , scheme                                       : ICell<NumericalDifferentiation.Scheme>
    ) as this =

    inherit Model<NumericalDifferentiation> ()
(*
    Parameters
*)
    let _f                                         = f
    let _orderOfDerivative                         = orderOfDerivative
    let _stepSize                                  = stepSize
    let _steps                                     = steps
    let _scheme                                    = scheme
(*
    Functions
*)
    let _NumericalDifferentiation                  = cell (fun () -> new NumericalDifferentiation (f.Value, orderOfDerivative.Value, stepSize.Value, steps.Value, scheme.Value))
    let _offsets                                   = triv (fun () -> _NumericalDifferentiation.Value.offsets())
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _NumericalDifferentiation.Value.value(x.Value))
    let _weights                                   = triv (fun () -> _NumericalDifferentiation.Value.weights())
    do this.Bind(_NumericalDifferentiation)
(* 
    casting 
*)
    internal new () = NumericalDifferentiationModel(null,null,null,null,null)
    member internal this.Inject v = _NumericalDifferentiation.Value <- v
    static member Cast (p : ICell<NumericalDifferentiation>) = 
        if p :? NumericalDifferentiationModel then 
            p :?> NumericalDifferentiationModel
        else
            let o = new NumericalDifferentiationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.f                                  = _f 
    member this.orderOfDerivative                  = _orderOfDerivative 
    member this.stepSize                           = _stepSize 
    member this.steps                              = _steps 
    member this.scheme                             = _scheme 
    member this.Offsets                            = _offsets
    member this.Value                              x   
                                                   = _value x 
    member this.Weights                            = _weights
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type NumericalDifferentiationModel1
    ( f                                            : ICell<Func<double,double>>
    , orderOfDerivative                            : ICell<int>
    , x_offsets                                    : ICell<Vector>
    ) as this =

    inherit Model<NumericalDifferentiation> ()
(*
    Parameters
*)
    let _f                                         = f
    let _orderOfDerivative                         = orderOfDerivative
    let _x_offsets                                 = x_offsets
(*
    Functions
*)
    let _NumericalDifferentiation                  = cell (fun () -> new NumericalDifferentiation (f.Value, orderOfDerivative.Value, x_offsets.Value))
    let _offsets                                   = triv (fun () -> _NumericalDifferentiation.Value.offsets())
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _NumericalDifferentiation.Value.value(x.Value))
    let _weights                                   = triv (fun () -> _NumericalDifferentiation.Value.weights())
    do this.Bind(_NumericalDifferentiation)
(* 
    casting 
*)
    internal new () = NumericalDifferentiationModel1(null,null,null)
    member internal this.Inject v = _NumericalDifferentiation.Value <- v
    static member Cast (p : ICell<NumericalDifferentiation>) = 
        if p :? NumericalDifferentiationModel1 then 
            p :?> NumericalDifferentiationModel1
        else
            let o = new NumericalDifferentiationModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.f                                  = _f 
    member this.orderOfDerivative                  = _orderOfDerivative 
    member this.x_offsets                          = _x_offsets 
    member this.Offsets                            = _offsets
    member this.Value                              x   
                                                   = _value x 
    member this.Weights                            = _weights
