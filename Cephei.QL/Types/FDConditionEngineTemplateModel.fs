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
this is template version to serve as base for FDStepConditionEngine and FDMultiPeriodEngine
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type FDConditionEngineTemplateModel
    () as this =
    inherit Model<FDConditionEngineTemplate> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FDConditionEngineTemplate                 = cell (fun () -> new FDConditionEngineTemplate ())
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.setStepCondition(impl.Value)
                                                                     _FDConditionEngineTemplate.Value)
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.calculate(r.Value)
                                                                     _FDConditionEngineTemplate.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDConditionEngineTemplate.Value.ensureStrikeInGrid()
                                                                     _FDConditionEngineTemplate.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv (fun () -> _FDConditionEngineTemplate.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDConditionEngineTemplate.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDConditionEngineTemplate.Value.intrinsicValues_)
    do this.Bind(_FDConditionEngineTemplate)
(* 
    casting 
*)
    
    member internal this.Inject v = _FDConditionEngineTemplate.Value <- v
    static member Cast (p : ICell<FDConditionEngineTemplate>) = 
        if p :? FDConditionEngineTemplateModel then 
            p :?> FDConditionEngineTemplateModel
        else
            let o = new FDConditionEngineTemplateModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
(* <summary>
this is template version to serve as base for FDStepConditionEngine and FDMultiPeriodEngine

  </summary> *)
[<AutoSerializable(true)>]
type FDConditionEngineTemplateModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDConditionEngineTemplate> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
    let _timeDependent                             = timeDependent
(*
    Functions
*)
    let _FDConditionEngineTemplate                 = cell (fun () -> new FDConditionEngineTemplate (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.setStepCondition(impl.Value)
                                                                     _FDConditionEngineTemplate.Value)
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.calculate(r.Value)
                                                                     _FDConditionEngineTemplate.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDConditionEngineTemplate.Value.ensureStrikeInGrid()
                                                                     _FDConditionEngineTemplate.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDConditionEngineTemplate.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv (fun () -> _FDConditionEngineTemplate.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDConditionEngineTemplate.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDConditionEngineTemplate.Value.intrinsicValues_)
    do this.Bind(_FDConditionEngineTemplate)
(* 
    casting 
*)
    internal new () = FDConditionEngineTemplateModel1(null,null,null,null)
    member internal this.Inject v = _FDConditionEngineTemplate.Value <- v
    static member Cast (p : ICell<FDConditionEngineTemplate>) = 
        if p :? FDConditionEngineTemplateModel1 then 
            p :?> FDConditionEngineTemplateModel1
        else
            let o = new FDConditionEngineTemplateModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
    member this.timeDependent                      = _timeDependent 
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
