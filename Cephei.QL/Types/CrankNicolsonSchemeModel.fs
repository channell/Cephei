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
  In one dimension the Crank-Nicolson scheme is equivalent to the Douglas scheme and in higher dimensions it is usually inferior to operator splitting methods like Craig-Sneyd or Hundsdorfer-Verwer.

  </summary> *)
[<AutoSerializable(true)>]
type CrankNicolsonSchemeModel
    ( theta                                        : ICell<double>
    , map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    , relTol                                       : ICell<double>
    , solverType                                   : ICell<ImplicitEulerScheme.SolverType>
    ) as this =

    inherit Model<CrankNicolsonScheme> ()
(*
    Parameters
*)
    let _theta                                     = theta
    let _map                                       = map
    let _bcSet                                     = bcSet
    let _relTol                                    = relTol
    let _solverType                                = solverType
(*
    Functions
*)
    let mutable
        _CrankNicolsonScheme                       = cell (fun () -> new CrankNicolsonScheme (theta.Value, map.Value, bcSet.Value, relTol.Value, solverType.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _numberOfIterations                        = triv (fun () -> _CrankNicolsonScheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.setStep(dt.Value)
                                                                     _CrankNicolsonScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                     _CrankNicolsonScheme.Value)
    do this.Bind(_CrankNicolsonScheme)
(* 
    casting 
*)
    internal new () = new CrankNicolsonSchemeModel(null,null,null,null,null)
    member internal this.Inject v = _CrankNicolsonScheme <- v
    static member Cast (p : ICell<CrankNicolsonScheme>) = 
        if p :? CrankNicolsonSchemeModel then 
            p :?> CrankNicolsonSchemeModel
        else
            let o = new CrankNicolsonSchemeModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.theta                              = _theta 
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.relTol                             = _relTol 
    member this.solverType                         = _solverType 
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.NumberOfIterations                 = _numberOfIterations
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>
  In one dimension the Crank-Nicolson scheme is equivalent to the Douglas scheme and in higher dimensions it is usually inferior to operator splitting methods like Craig-Sneyd or Hundsdorfer-Verwer.

  </summary> *)
[<AutoSerializable(true)>]
type CrankNicolsonSchemeModel1
    () as this =
    inherit Model<CrankNicolsonScheme> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _CrankNicolsonScheme                       = cell (fun () -> new CrankNicolsonScheme ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _numberOfIterations                        = triv (fun () -> _CrankNicolsonScheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.setStep(dt.Value)
                                                                     _CrankNicolsonScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolsonScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                     _CrankNicolsonScheme.Value)
    do this.Bind(_CrankNicolsonScheme)
(* 
    casting 
*)
    
    member internal this.Inject v = _CrankNicolsonScheme <- v
    static member Cast (p : ICell<CrankNicolsonScheme>) = 
        if p :? CrankNicolsonSchemeModel1 then 
            p :?> CrankNicolsonSchemeModel1
        else
            let o = new CrankNicolsonSchemeModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.NumberOfIterations                 = _numberOfIterations
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
