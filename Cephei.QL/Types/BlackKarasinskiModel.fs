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
type BlackKarasinskiModel
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<BlackKarasinski> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let _BlackKarasinski                           = cell (fun () -> new BlackKarasinski (termStructure.Value, a.Value, sigma.Value))
    let _dynamics                                  = triv (fun () -> _BlackKarasinski.Value.dynamics())
    let _termStructure                             = triv (fun () -> _BlackKarasinski.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _BlackKarasinski.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _BlackKarasinski.Value)
    let _constraint                                = triv (fun () -> _BlackKarasinski.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _BlackKarasinski.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _BlackKarasinski.Value.notifyObservers()
                                                                     _BlackKarasinski.Value)
    let _parameters                                = triv (fun () -> _BlackKarasinski.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.registerWith(handler.Value)
                                                                     _BlackKarasinski.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.setParams(parameters.Value)
                                                                     _BlackKarasinski.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.unregisterWith(handler.Value)
                                                                     _BlackKarasinski.Value)
    let _update                                    = triv (fun () -> _BlackKarasinski.Value.update()
                                                                     _BlackKarasinski.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_BlackKarasinski)
(* 
    casting 
*)
    internal new () = new BlackKarasinskiModel(null,null,null)
    member internal this.Inject v = _BlackKarasinski.Value <- v
    static member Cast (p : ICell<BlackKarasinski>) = 
        if p :? BlackKarasinskiModel then 
            p :?> BlackKarasinskiModel
        else
            let o = new BlackKarasinskiModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.Dynamics                           = _dynamics
    member this.TermStructure                      = _termStructure
    member this.TermStructure_                     = _termStructure_
    member this.Tree                               grid   
                                                   = _tree grid 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BlackKarasinskiModel1
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<BlackKarasinski> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _BlackKarasinski                           = cell (fun () -> new BlackKarasinski (termStructure.Value))
    let _dynamics                                  = triv (fun () -> _BlackKarasinski.Value.dynamics())
    let _termStructure                             = triv (fun () -> _BlackKarasinski.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _BlackKarasinski.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _BlackKarasinski.Value)
    let _constraint                                = triv (fun () -> _BlackKarasinski.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _BlackKarasinski.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _BlackKarasinski.Value.notifyObservers()
                                                                     _BlackKarasinski.Value)
    let _parameters                                = triv (fun () -> _BlackKarasinski.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.registerWith(handler.Value)
                                                                     _BlackKarasinski.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.setParams(parameters.Value)
                                                                     _BlackKarasinski.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.unregisterWith(handler.Value)
                                                                     _BlackKarasinski.Value)
    let _update                                    = triv (fun () -> _BlackKarasinski.Value.update()
                                                                     _BlackKarasinski.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _BlackKarasinski.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_BlackKarasinski)
(* 
    casting 
*)
    internal new () = new BlackKarasinskiModel1(null)
    member internal this.Inject v = _BlackKarasinski.Value <- v
    static member Cast (p : ICell<BlackKarasinski>) = 
        if p :? BlackKarasinskiModel1 then 
            p :?> BlackKarasinskiModel1
        else
            let o = new BlackKarasinskiModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.Dynamics                           = _dynamics
    member this.TermStructure                      = _termStructure
    member this.TermStructure_                     = _termStructure_
    member this.Tree                               grid   
                                                   = _tree grid 
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
