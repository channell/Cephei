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
  Calibrated model class

  </summary> *)
[<AutoSerializable(true)>]
type CalibratedModelModel
    ( nArguments                                   : ICell<int>
    ) as this =

    inherit Model<CalibratedModel> ()
(*
    Parameters
*)
    let _nArguments                                = nArguments
(*
    Functions
*)
    let _CalibratedModel                           = cell (fun () -> new CalibratedModel (nArguments.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _CalibratedModel.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _CalibratedModel.Value)
    let _constraint                                = triv (fun () -> _CalibratedModel.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _CalibratedModel.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _CalibratedModel.Value.notifyObservers()
                                                                     _CalibratedModel.Value)
    let _parameters                                = triv (fun () -> _CalibratedModel.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CalibratedModel.Value.registerWith(handler.Value)
                                                                     _CalibratedModel.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _CalibratedModel.Value.setParams(parameters.Value)
                                                                     _CalibratedModel.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CalibratedModel.Value.unregisterWith(handler.Value)
                                                                     _CalibratedModel.Value)
    let _update                                    = triv (fun () -> _CalibratedModel.Value.update()
                                                                     _CalibratedModel.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _CalibratedModel.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_CalibratedModel)

(* 
    Externally visible/bindable properties
*)
    member this.nArguments                         = _nArguments 
    member this.Calibrate                          instruments Method endCriteria additionalConstraint weights fixParameters   
                                                   = _calibrate instruments Method endCriteria additionalConstraint weights fixParameters 
    member this.Constraint                         = _constraint
    member this.EndCriteria                        = _endCriteria
    member this.NotifyObservers                    = _notifyObservers
    member this.Parameters                         = _parameters
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.SetParams                          parameters   
                                                   = _setParams parameters 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.Value                              parameters instruments   
                                                   = _value parameters instruments 
