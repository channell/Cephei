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
  Piecewise-constant parameter   a(t) = a_i if t_{i-1} t < t_i This kind of parameter is usually used to enhance the fitting of a model

  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseConstantParameterModel
    ( times                                        : ICell<Generic.List<double>>
    , Constraint                                   : ICell<Constraint>
    ) as this =

    inherit Model<PiecewiseConstantParameter> ()
(*
    Parameters
*)
    let _times                                     = times
    let _Constraint                                = Constraint
(*
    Functions
*)
    let _PiecewiseConstantParameter                = cell (fun () -> new PiecewiseConstantParameter (times.Value, Constraint.Value))
    let _constraint                                = triv (fun () -> _PiecewiseConstantParameter.Value.CONSTRAINT())
    let _implementation                            = triv (fun () -> _PiecewiseConstantParameter.Value.implementation())
    let _parameters                                = triv (fun () -> _PiecewiseConstantParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _PiecewiseConstantParameter.Value.setParam(i.Value, x.Value)
                                                                     _PiecewiseConstantParameter.Value)
    let _size                                      = triv (fun () -> _PiecewiseConstantParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = triv (fun () -> _PiecewiseConstantParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _PiecewiseConstantParameter.Value.value(t.Value))
    do this.Bind(_PiecewiseConstantParameter)
(* 
    casting 
*)
    internal new () = PiecewiseConstantParameterModel(null,null)
    member internal this.Inject v = _PiecewiseConstantParameter.Value <- v
    static member Cast (p : ICell<PiecewiseConstantParameter>) = 
        if p :? PiecewiseConstantParameterModel then 
            p :?> PiecewiseConstantParameterModel
        else
            let o = new PiecewiseConstantParameterModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.Constraint                         = _Constraint 
    member this.Constraint1                        = _constraint
    member this.Implementation                     = _implementation
    member this.Parameters                         = _parameters
    member this.SetParam                           i x   
                                                   = _setParam i x 
    member this.Size                               = _size
    member this.TestParams                         p   
                                                   = _testParams p 
    member this.Value                              t   
                                                   = _value t 
