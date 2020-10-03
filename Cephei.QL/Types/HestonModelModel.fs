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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  calibration is tested against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type HestonModelModel
    ( Process                                      : ICell<HestonProcess>
    ) as this =

    inherit Model<HestonModel> ()
(*
    Parameters
*)
    let _Process                                   = Process
(*
    Functions
*)
    let _HestonModel                               = cell (fun () -> new HestonModel (Process.Value))
    let _kappa                                     = triv (fun () -> _HestonModel.Value.kappa())
    let _process                                   = triv (fun () -> _HestonModel.Value.PROCESS())
    let _rho                                       = triv (fun () -> _HestonModel.Value.rho())
    let _sigma                                     = triv (fun () -> _HestonModel.Value.sigma())
    let _theta                                     = triv (fun () -> _HestonModel.Value.theta())
    let _v0                                        = triv (fun () -> _HestonModel.Value.v0())
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _HestonModel.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _HestonModel.Value)
    let _constraint                                = triv (fun () -> _HestonModel.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _HestonModel.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _HestonModel.Value.notifyObservers()
                                                                     _HestonModel.Value)
    let _parameters                                = triv (fun () -> _HestonModel.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HestonModel.Value.registerWith(handler.Value)
                                                                     _HestonModel.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _HestonModel.Value.setParams(parameters.Value)
                                                                     _HestonModel.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HestonModel.Value.unregisterWith(handler.Value)
                                                                     _HestonModel.Value)
    let _update                                    = triv (fun () -> _HestonModel.Value.update()
                                                                     _HestonModel.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _HestonModel.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_HestonModel)
(* 
    casting 
*)
    internal new () = HestonModelModel(null)
    member internal this.Inject v = _HestonModel.Value <- v
    static member Cast (p : ICell<HestonModel>) = 
        if p :? HestonModelModel then 
            p :?> HestonModelModel
        else
            let o = new HestonModelModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.Kappa                              = _kappa
    member this.Process1                           = _process
    member this.Rho                                = _rho
    member this.Sigma                              = _sigma
    member this.Theta                              = _theta
    member this.V0                                 = _v0
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
