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
  Criteria to end optimization process:   - maximum number of iterations AND minimum number of iterations around stationary point - x (independent variable) stationary point - y=f(x) (dependent variable) stationary point - stationary gradient
! Initialization constructor
  </summary> *)
[<AutoSerializable(true)>]
type EndCriteriaModel
    ( maxIterations                                : ICell<int>
    , maxStationaryStateIterations                 : ICell<Nullable<int>>
    , rootEpsilon                                  : ICell<double>
    , functionEpsilon                              : ICell<double>
    , gradientNormEpsilon                          : ICell<Nullable<double>>
    ) as this =

    inherit Model<EndCriteria> ()
(*
    Parameters
*)
    let _maxIterations                             = maxIterations
    let _maxStationaryStateIterations              = maxStationaryStateIterations
    let _rootEpsilon                               = rootEpsilon
    let _functionEpsilon                           = functionEpsilon
    let _gradientNormEpsilon                       = gradientNormEpsilon
(*
    Functions
*)
    let _EndCriteria                               = cell (fun () -> new EndCriteria (maxIterations.Value, maxStationaryStateIterations.Value, rootEpsilon.Value, functionEpsilon.Value, gradientNormEpsilon.Value))
    let _checkMaxIterations                        (iteration : ICell<int>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.checkMaxIterations(iteration.Value, ecType.Value))
    let _checkStationaryFunctionAccuracy           (f : ICell<double>) (positiveOptimization : ICell<bool>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.checkStationaryFunctionAccuracy(f.Value, positiveOptimization.Value, ecType.Value))
    let _checkStationaryFunctionValue              (fxOld : ICell<double>) (fxNew : ICell<double>) (statStateIterations : ICell<int>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.checkStationaryFunctionValue(fxOld.Value, fxNew.Value, ref statStateIterations.Value, ecType.Value))
    let _checkStationaryPoint                      (xOld : ICell<double>) (xNew : ICell<double>) (statStateIterations : ICell<int ref>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.checkStationaryPoint(xOld.Value, xNew.Value, statStateIterations.Value, ecType.Value))
    let _checkZeroGradientNorm                     (gradientNorm : ICell<double>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.checkZeroGradientNorm(gradientNorm.Value, ecType.Value))
    let _functionEpsilon                           = triv (fun () -> _EndCriteria.Value.functionEpsilon())
    let _gradientNormEpsilon                       = triv (fun () -> _EndCriteria.Value.gradientNormEpsilon())
    let _maxIterations                             = triv (fun () -> _EndCriteria.Value.maxIterations())
    let _maxStationaryStateIterations              = triv (fun () -> _EndCriteria.Value.maxStationaryStateIterations())
    let _rootEpsilon                               = triv (fun () -> _EndCriteria.Value.rootEpsilon())
    let _value                                     (iteration : ICell<int>) (statStateIterations : ICell<int ref>) (positiveOptimization : ICell<bool>) (fold : ICell<double>) (UnnamedParameter1 : ICell<double>) (fnew : ICell<double>) (normgnew : ICell<double>) (ecType : ICell<EndCriteria.Type ref>)   
                                                   = triv (fun () -> _EndCriteria.Value.value(iteration.Value, statStateIterations.Value, positiveOptimization.Value, fold.Value, UnnamedParameter1.Value, fnew.Value, normgnew.Value, ecType.Value))
    do this.Bind(_EndCriteria)

(* 
    Externally visible/bindable properties
*)
    member this.maxIterations                      = _maxIterations 
    member this.maxStationaryStateIterations       = _maxStationaryStateIterations 
    member this.rootEpsilon                        = _rootEpsilon 
    member this.functionEpsilon                    = _functionEpsilon 
    member this.gradientNormEpsilon                = _gradientNormEpsilon 
    member this.CheckMaxIterations                 iteration ecType   
                                                   = _checkMaxIterations iteration ecType 
    member this.CheckStationaryFunctionAccuracy    f positiveOptimization ecType   
                                                   = _checkStationaryFunctionAccuracy f positiveOptimization ecType 
    member this.CheckStationaryFunctionValue       fxOld fxNew statStateIterations ecType   
                                                   = _checkStationaryFunctionValue fxOld fxNew statStateIterations ecType 
    member this.CheckStationaryPoint               xOld xNew statStateIterations ecType   
                                                   = _checkStationaryPoint xOld xNew statStateIterations ecType 
    member this.CheckZeroGradientNorm              gradientNorm ecType   
                                                   = _checkZeroGradientNorm gradientNorm ecType 
    member this.FunctionEpsilon                    = _functionEpsilon
    member this.GradientNormEpsilon                = _gradientNormEpsilon
    member this.MaxIterations                      = _maxIterations
    member this.MaxStationaryStateIterations       = _maxStationaryStateIterations
    member this.RootEpsilon                        = _rootEpsilon
    member this.Value                              iteration statStateIterations positiveOptimization fold UnnamedParameter1 fnew normgnew ecType   
                                                   = _value iteration statStateIterations positiveOptimization fold UnnamedParameter1 fnew normgnew ecType 
