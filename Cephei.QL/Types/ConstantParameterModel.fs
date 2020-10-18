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
  Standard constant parameter a(t) = a

  </summary> *)
[<AutoSerializable(true)>]
type ConstantParameterModel
    ( Constraint                                   : ICell<Constraint>
    ) as this =

    inherit Model<ConstantParameter> ()
(*
    Parameters
*)
    let _Constraint                                = Constraint
(*
    Functions
*)
    let mutable
        _ConstantParameter                         = cell (fun () -> new ConstantParameter (Constraint.Value))
    let _constraint                                = triv (fun () -> _ConstantParameter.Value.CONSTRAINT())
    let _implementation                            = triv (fun () -> _ConstantParameter.Value.implementation())
    let _parameters                                = triv (fun () -> _ConstantParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _ConstantParameter.Value.setParam(i.Value, x.Value)
                                                                     _ConstantParameter.Value)
    let _size                                      = triv (fun () -> _ConstantParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = triv (fun () -> _ConstantParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _ConstantParameter.Value.value(t.Value))
    do this.Bind(_ConstantParameter)
(* 
    casting 
*)
    internal new () = new ConstantParameterModel(null)
    member internal this.Inject v = _ConstantParameter <- v
    static member Cast (p : ICell<ConstantParameter>) = 
        if p :? ConstantParameterModel then 
            p :?> ConstantParameterModel
        else
            let o = new ConstantParameterModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
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
(* <summary>
  Standard constant parameter a(t) = a

  </summary> *)
[<AutoSerializable(true)>]
type ConstantParameterModel1
    ( value                                        : ICell<double>
    , Constraint                                   : ICell<Constraint>
    ) as this =

    inherit Model<ConstantParameter> ()
(*
    Parameters
*)
    let _value                                     = value
    let _Constraint                                = Constraint
(*
    Functions
*)
    let mutable
        _ConstantParameter                         = cell (fun () -> new ConstantParameter (value.Value, Constraint.Value))
    let _constraint                                = triv (fun () -> _ConstantParameter.Value.CONSTRAINT())
    let _implementation                            = triv (fun () -> _ConstantParameter.Value.implementation())
    let _parameters                                = triv (fun () -> _ConstantParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _ConstantParameter.Value.setParam(i.Value, x.Value)
                                                                     _ConstantParameter.Value)
    let _size                                      = triv (fun () -> _ConstantParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = triv (fun () -> _ConstantParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _ConstantParameter.Value.value(t.Value))
    do this.Bind(_ConstantParameter)
(* 
    casting 
*)
    internal new () = new ConstantParameterModel1(null,null)
    member internal this.Inject v = _ConstantParameter <- v
    static member Cast (p : ICell<ConstantParameter>) = 
        if p :? ConstantParameterModel1 then 
            p :?> ConstantParameterModel1
        else
            let o = new ConstantParameterModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.value                              = _value 
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
