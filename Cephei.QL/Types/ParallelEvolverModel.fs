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

required for generics
  </summary> *)
[<AutoSerializable(true)>]
type ParallelEvolverModel<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)>
    () as this =
    inherit Model<ParallelEvolver<'Evolver>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ParallelEvolver                           = cell (fun () -> new ParallelEvolver<'Evolver> ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.setStep(dt.Value)
                                                                     _ParallelEvolver.Value)
    let _step                                      (o : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.step(o.Value, t.Value, theta.Value)
                                                                     _ParallelEvolver.Value)
    do this.Bind(_ParallelEvolver)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ParallelEvolverModel1<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)>
    ( L                                            : ICell<Generic.List<IOperator>>
    , bcs                                          : ICell<BoundaryConditionSet>
    ) as this =

    inherit Model<ParallelEvolver<'Evolver>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let _ParallelEvolver                           = cell (fun () -> new ParallelEvolver<'Evolver> (L.Value, bcs.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.setStep(dt.Value)
                                                                     _ParallelEvolver.Value)
    let _step                                      (o : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ParallelEvolver.Value.step(o.Value, t.Value, theta.Value)
                                                                     _ParallelEvolver.Value)
    do this.Bind(_ParallelEvolver)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
