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
type ImplicitEulerSchemeModel
    ( map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    , relTol                                       : ICell<double>
    , solverType                                   : ICell<ImplicitEulerScheme.SolverType>
    ) as this =

    inherit Model<ImplicitEulerScheme> ()
(*
    Parameters
*)
    let _map                                       = map
    let _bcSet                                     = bcSet
    let _relTol                                    = relTol
    let _solverType                                = solverType
(*
    Functions
*)
    let mutable
        _ImplicitEulerScheme                       = make (fun () -> new ImplicitEulerScheme (map.Value, bcSet.Value, relTol.Value, solverType.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _numberOfIterations                        = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.setStep(dt.Value)
                                                                                          _ImplicitEulerScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                                          _ImplicitEulerScheme.Value)
    do this.Bind(_ImplicitEulerScheme)
(* 
    casting 
*)
    internal new () = new ImplicitEulerSchemeModel(null,null,null,null)
    member internal this.Inject v = _ImplicitEulerScheme <- v
    static member Cast (p : ICell<ImplicitEulerScheme>) = 
        if p :? ImplicitEulerSchemeModel then 
            p :?> ImplicitEulerSchemeModel
        else
            let o = new ImplicitEulerSchemeModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.relTol                             = _relTol 
    member this.solverType                         = _solverType 
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.NumberOfIterations                 = _numberOfIterations
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ImplicitEulerSchemeModel1
    () as this =
    inherit Model<ImplicitEulerScheme> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ImplicitEulerScheme                       = make (fun () -> new ImplicitEulerScheme ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _numberOfIterations                        = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.setStep(dt.Value)
                                                                                          _ImplicitEulerScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ImplicitEulerScheme (fun () -> _ImplicitEulerScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                                          _ImplicitEulerScheme.Value)
    do this.Bind(_ImplicitEulerScheme)
(* 
    casting 
*)
    
    member internal this.Inject v = _ImplicitEulerScheme <- v
    static member Cast (p : ICell<ImplicitEulerScheme>) = 
        if p :? ImplicitEulerSchemeModel1 then 
            p :?> ImplicitEulerSchemeModel1
        else
            let o = new ImplicitEulerSchemeModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.NumberOfIterations                 = _numberOfIterations
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
