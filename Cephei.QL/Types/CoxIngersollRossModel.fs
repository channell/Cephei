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
type CoxIngersollRossModel
    ( r0                                           : ICell<double>
    , theta                                        : ICell<double>
    , k                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<CoxIngersollRoss> ()
(*
    Parameters
*)
    let _r0                                        = r0
    let _theta                                     = theta
    let _k                                         = k
    let _sigma                                     = sigma
(*
    Functions
*)
    let _CoxIngersollRoss                          = cell (fun () -> new CoxIngersollRoss (r0.Value, theta.Value, k.Value, sigma.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = cell (fun () -> _CoxIngersollRoss.Value.dynamics())
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.tree(grid.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (now : ICell<double>) (maturity : ICell<double>) (rate : ICell<double>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.discountBond(now.Value, maturity.Value, rate.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _CoxIngersollRoss.Value)
    let _constraint                                = cell (fun () -> _CoxIngersollRoss.Value.CONSTRAINT())
    let _endCriteria                               = cell (fun () -> _CoxIngersollRoss.Value.endCriteria())
    let _notifyObservers                           = cell (fun () -> _CoxIngersollRoss.Value.notifyObservers()
                                                                     _CoxIngersollRoss.Value)
    let _parameters                                = cell (fun () -> _CoxIngersollRoss.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.registerWith(handler.Value)
                                                                     _CoxIngersollRoss.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.setParams(parameters.Value)
                                                                     _CoxIngersollRoss.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.unregisterWith(handler.Value)
                                                                     _CoxIngersollRoss.Value)
    let _update                                    = cell (fun () -> _CoxIngersollRoss.Value.update()
                                                                     _CoxIngersollRoss.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = cell (fun () -> _CoxIngersollRoss.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_CoxIngersollRoss)

(* 
    Externally visible/bindable properties
*)
    member this.r0                                 = _r0 
    member this.theta                              = _theta 
    member this.k                                  = _k 
    member this.sigma                              = _sigma 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Tree                               grid   
                                                   = _tree grid 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      now maturity rate   
                                                   = _discountBond1 now maturity rate 
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
