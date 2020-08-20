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
type FittingParameterModel
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , b                                            : ICell<double>
    , eta                                          : ICell<double>
    , rho                                          : ICell<double>
    ) as this =

    inherit Model<FittingParameter> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
    let _b                                         = b
    let _eta                                       = eta
    let _rho                                       = rho
(*
    Functions
*)
    let _FittingParameter                          = cell (fun () -> new FittingParameter (termStructure.Value, a.Value, sigma.Value, b.Value, eta.Value, rho.Value))
    let _constraint                                = cell (fun () -> _FittingParameter.Value.CONSTRAINT())
    let _implementation                            = cell (fun () -> _FittingParameter.Value.implementation())
    let _parameters                                = cell (fun () -> _FittingParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = cell (fun () -> _FittingParameter.Value.setParam(i.Value, x.Value)
                                                                     _FittingParameter.Value)
    let _size                                      = cell (fun () -> _FittingParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = cell (fun () -> _FittingParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = cell (fun () -> _FittingParameter.Value.value(t.Value))
    do this.Bind(_FittingParameter)

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.b                                  = _b 
    member this.eta                                = _eta 
    member this.rho                                = _rho 
    member this.Constraint                         = _constraint
    member this.Implementation                     = _implementation
    member this.Parameters                         = _parameters
    member this.SetParam                           i x   
                                                   = _setParam i x 
    member this.Size                               = _size
    member this.TestParams                         p   
                                                   = _testParams p 
    member this.Value                              t   
                                                   = _value t 
