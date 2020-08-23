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
type FdmStepConditionCompositeModel
    () as this =
    inherit Model<FdmStepConditionComposite> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FdmStepConditionComposite                 = cell (fun () -> new FdmStepConditionComposite ())
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmStepConditionComposite.Value.applyTo(o.Value, t.Value)
                                                                     _FdmStepConditionComposite.Value)
    let _conditions                                = triv (fun () -> _FdmStepConditionComposite.Value.conditions())
    let _stoppingTimes                             = triv (fun () -> _FdmStepConditionComposite.Value.stoppingTimes())
    do this.Bind(_FdmStepConditionComposite)

(* 
    Externally visible/bindable properties
*)
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
    member this.Conditions                         = _conditions
    member this.StoppingTimes                      = _stoppingTimes
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmStepConditionCompositeModel1
    ( stoppingTimes                                : ICell<Generic.List<Generic.List<double>>>
    , conditions                                   : ICell<Generic.List<IStepCondition<Vector>>>
    ) as this =

    inherit Model<FdmStepConditionComposite> ()
(*
    Parameters
*)
    let _stoppingTimes                             = stoppingTimes
    let _conditions                                = conditions
(*
    Functions
*)
    let _FdmStepConditionComposite                 = cell (fun () -> new FdmStepConditionComposite (stoppingTimes.Value, conditions.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmStepConditionComposite.Value.applyTo(o.Value, t.Value)
                                                                     _FdmStepConditionComposite.Value)
    let _conditions                                = triv (fun () -> _FdmStepConditionComposite.Value.conditions())
    let _stoppingTimes                             = triv (fun () -> _FdmStepConditionComposite.Value.stoppingTimes())
    do this.Bind(_FdmStepConditionComposite)

(* 
    Externally visible/bindable properties
*)
    member this.stoppingTimes                      = _stoppingTimes 
    member this.conditions                         = _conditions 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
    member this.Conditions                         = _conditions
    member this.StoppingTimes                      = _stoppingTimes
