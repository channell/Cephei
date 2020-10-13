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
  Deterministic time-dependent parameter used for yield-curve fitting

  </summary> *)
[<AutoSerializable(true)>]
type TermStructureFittingParameterModel
    ( impl                                         : ICell<Parameter.Impl>
    ) as this =

    inherit Model<TermStructureFittingParameter> ()
(*
    Parameters
*)
    let _impl                                      = impl
(*
    Functions
*)
    let _TermStructureFittingParameter             = cell (fun () -> new TermStructureFittingParameter (impl.Value))
    let _constraint                                = triv (fun () -> _TermStructureFittingParameter.Value.CONSTRAINT())
    let _implementation                            = triv (fun () -> _TermStructureFittingParameter.Value.implementation())
    let _parameters                                = triv (fun () -> _TermStructureFittingParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.setParam(i.Value, x.Value)
                                                                     _TermStructureFittingParameter.Value)
    let _size                                      = triv (fun () -> _TermStructureFittingParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.value(t.Value))
    do this.Bind(_TermStructureFittingParameter)
(* 
    casting 
*)
    internal new () = new TermStructureFittingParameterModel(null)
    member internal this.Inject v = _TermStructureFittingParameter.Value <- v
    static member Cast (p : ICell<TermStructureFittingParameter>) = 
        if p :? TermStructureFittingParameterModel then 
            p :?> TermStructureFittingParameterModel
        else
            let o = new TermStructureFittingParameterModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.impl                               = _impl 
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
(* <summary>
  Deterministic time-dependent parameter used for yield-curve fitting

  </summary> *)
[<AutoSerializable(true)>]
type TermStructureFittingParameterModel1
    ( term                                         : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TermStructureFittingParameter> ()
(*
    Parameters
*)
    let _term                                      = term
(*
    Functions
*)
    let _TermStructureFittingParameter             = cell (fun () -> new TermStructureFittingParameter (term.Value))
    let _constraint                                = triv (fun () -> _TermStructureFittingParameter.Value.CONSTRAINT())
    let _implementation                            = triv (fun () -> _TermStructureFittingParameter.Value.implementation())
    let _parameters                                = triv (fun () -> _TermStructureFittingParameter.Value.parameters())
    let _setParam                                  (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.setParam(i.Value, x.Value)
                                                                     _TermStructureFittingParameter.Value)
    let _size                                      = triv (fun () -> _TermStructureFittingParameter.Value.size())
    let _testParams                                (p : ICell<Vector>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.testParams(p.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _TermStructureFittingParameter.Value.value(t.Value))
    do this.Bind(_TermStructureFittingParameter)
(* 
    casting 
*)
    internal new () = new TermStructureFittingParameterModel1(null)
    member internal this.Inject v = _TermStructureFittingParameter.Value <- v
    static member Cast (p : ICell<TermStructureFittingParameter>) = 
        if p :? TermStructureFittingParameterModel1 then 
            p :?> TermStructureFittingParameterModel1
        else
            let o = new TermStructureFittingParameterModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.term                               = _term 
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
