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
type FiniteDifferenceModelModel<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)>
    ( L                                            : ICell<Object>
    , bcs                                          : ICell<Object>
    , stoppingTimes                                : ICell<Generic.List<double>>
    ) as this =

    inherit Model<FiniteDifferenceModel<'Evolver>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
    let _stoppingTimes                             = stoppingTimes
(*
    Functions
*)
    let _FiniteDifferenceModel                     = cell (fun () -> new FiniteDifferenceModel<'Evolver> (L.Value, bcs.Value, stoppingTimes.Value))
    let _evolver                                   = triv (fun () -> _FiniteDifferenceModel.Value.evolver())
    let _rollback                                  (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value)
                                                                     _FiniteDifferenceModel.Value)
    let _rollback1                                 (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>) (condition : ICell<IStepCondition<Vector>>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value, condition.Value)
                                                                     _FiniteDifferenceModel.Value)
    do this.Bind(_FiniteDifferenceModel)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.stoppingTimes                      = _stoppingTimes 
    member this.Evolver                            = _evolver
    member this.Rollback                           a from To steps   
                                                   = _rollback a from To steps 
    member this.Rollback1                          a from To steps condition   
                                                   = _rollback1 a from To steps condition 
(* <summary>

constructors
  </summary> *)
[<AutoSerializable(true)>]
type FiniteDifferenceModelModel1<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)>
    ( L                                            : ICell<Object>
    , bcs                                          : ICell<Object>
    ) as this =

    inherit Model<FiniteDifferenceModel<'Evolver>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let _FiniteDifferenceModel                     = cell (fun () -> new FiniteDifferenceModel<'Evolver> (L.Value, bcs.Value))
    let _evolver                                   = triv (fun () -> _FiniteDifferenceModel.Value.evolver())
    let _rollback                                  (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value)
                                                                     _FiniteDifferenceModel.Value)
    let _rollback1                                 (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>) (condition : ICell<IStepCondition<Vector>>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value, condition.Value)
                                                                     _FiniteDifferenceModel.Value)
    do this.Bind(_FiniteDifferenceModel)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.Evolver                            = _evolver
    member this.Rollback                           a from To steps   
                                                   = _rollback a from To steps 
    member this.Rollback1                          a from To steps condition   
                                                   = _rollback1 a from To steps condition 
(* <summary>

public FiniteDifferenceModel(Evolver evolver, List<double> stoppingTimes = List<double>())
  </summary> *)
[<AutoSerializable(true)>]
type FiniteDifferenceModelModel2<'Evolver when 'Evolver :> IMixedScheme and 'Evolver :> ISchemeFactory and 'Evolver : (new : unit -> 'Evolver)>
    ( evolver                                      : ICell<'Evolver>
    , stoppingTimes                                : ICell<Generic.List<double>>
    ) as this =

    inherit Model<FiniteDifferenceModel<'Evolver>> ()
(*
    Parameters
*)
    let _evolver                                   = evolver
    let _stoppingTimes                             = stoppingTimes
(*
    Functions
*)
    let _FiniteDifferenceModel                     = cell (fun () -> new FiniteDifferenceModel<'Evolver> (evolver.Value, stoppingTimes.Value))
    let _evolver                                   = triv (fun () -> _FiniteDifferenceModel.Value.evolver())
    let _rollback                                  (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value)
                                                                     _FiniteDifferenceModel.Value)
    let _rollback1                                 (a : ICell<Object>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>) (condition : ICell<IStepCondition<Vector>>)   
                                                   = triv (fun () -> _FiniteDifferenceModel.Value.rollback(ref a.Value, from.Value, To.Value, steps.Value, condition.Value)
                                                                     _FiniteDifferenceModel.Value)
    do this.Bind(_FiniteDifferenceModel)

(* 
    Externally visible/bindable properties
*)
    member this.evolver                            = _evolver 
    member this.stoppingTimes                      = _stoppingTimes 
    member this.Evolver                            = _evolver
    member this.Rollback                           a from To steps   
                                                   = _rollback a from To steps 
    member this.Rollback1                          a from To steps condition   
                                                   = _rollback1 a from To steps condition 
