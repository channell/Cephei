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
type TrBDF2SchemeModel<'TrapezoidalScheme when 'TrapezoidalScheme : not struct and 'TrapezoidalScheme :> IMixedScheme>
    ( alpha                                        : ICell<double>
    , map                                          : ICell<FdmLinearOpComposite>
    , trapezoidalScheme                            : ICell<'TrapezoidalScheme>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    , relTol                                       : ICell<double>
    , solverType                                   : ICell<TrBDF2Scheme<'TrapezoidalScheme>.SolverType>
    ) as this =

    inherit Model<TrBDF2Scheme<'TrapezoidalScheme>> ()
(*
    Parameters
*)
    let _alpha                                     = alpha
    let _map                                       = map
    let _trapezoidalScheme                         = trapezoidalScheme
    let _bcSet                                     = bcSet
    let _relTol                                    = relTol
    let _solverType                                = solverType
(*
    Functions
*)
    let _TrBDF2Scheme                              = cell (fun () -> new TrBDF2Scheme<'TrapezoidalScheme> (alpha.Value, map.Value, trapezoidalScheme.Value, bcSet.Value, relTol.Value, solverType.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.apply(r.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _numberOfIterations                        = cell (fun () -> _TrBDF2Scheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.setStep(dt.Value)
                                                                     _TrBDF2Scheme.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.step(a.Value, t.Value, theta.Value)
                                                                     _TrBDF2Scheme.Value)
    do this.Bind(_TrBDF2Scheme)

(* 
    Externally visible/bindable properties
*)
    member this.alpha                              = _alpha 
    member this.map                                = _map 
    member this.trapezoidalScheme                  = _trapezoidalScheme 
    member this.bcSet                              = _bcSet 
    member this.relTol                             = _relTol 
    member this.solverType                         = _solverType 
    member this.Apply                              r   
                                                   = _apply r 
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
type TrBDF2SchemeModel1<'TrapezoidalScheme when 'TrapezoidalScheme : not struct and 'TrapezoidalScheme :> IMixedScheme>
    () as this =
    inherit Model<TrBDF2Scheme<'TrapezoidalScheme>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _TrBDF2Scheme                              = cell (fun () -> new TrBDF2Scheme<'TrapezoidalScheme> ())
    let _apply                                     (r : ICell<Vector>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.apply(r.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _numberOfIterations                        = cell (fun () -> _TrBDF2Scheme.Value.numberOfIterations())
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.setStep(dt.Value)
                                                                     _TrBDF2Scheme.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _TrBDF2Scheme.Value.step(a.Value, t.Value, theta.Value)
                                                                     _TrBDF2Scheme.Value)
    do this.Bind(_TrBDF2Scheme)

(* 
    Externally visible/bindable properties
*)
    member this.Apply                              r   
                                                   = _apply r 
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.NumberOfIterations                 = _numberOfIterations
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
