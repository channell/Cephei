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
type FDMultiPeriodEngineModel
    () as this =
    inherit Model<FDMultiPeriodEngine> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FDMultiPeriodEngine                       = cell (fun () -> new FDMultiPeriodEngine ())
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDMultiPeriodEngine.Value.calculate(r.Value)
                                                                     _FDMultiPeriodEngine.Value)
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDMultiPeriodEngine.Value.setStepCondition(impl.Value)
                                                                     _FDMultiPeriodEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDMultiPeriodEngine.Value.ensureStrikeInGrid()
                                                                     _FDMultiPeriodEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDMultiPeriodEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv (fun () -> _FDMultiPeriodEngine.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDMultiPeriodEngine.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDMultiPeriodEngine.Value.intrinsicValues_)
    do this.Bind(_FDMultiPeriodEngine)
(* 
    casting 
*)
    
    member internal this.Inject v = _FDMultiPeriodEngine.Value <- v
    static member Cast (p : ICell<FDMultiPeriodEngine>) = 
        if p :? FDMultiPeriodEngineModel then 
            p :?> FDMultiPeriodEngineModel
        else
            let o = new FDMultiPeriodEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
