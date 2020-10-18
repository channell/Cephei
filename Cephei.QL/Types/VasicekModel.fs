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
type VasicekModel
    ( r0                                           : ICell<double>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , sigma                                        : ICell<double>
    , lambda                                       : ICell<double>
    ) as this =

    inherit Model<Vasicek> ()
(*
    Parameters
*)
    let _r0                                        = r0
    let _a                                         = a
    let _b                                         = b
    let _sigma                                     = sigma
    let _lambda                                    = lambda
(*
    Functions
*)
    let mutable
        _Vasicek                                   = cell (fun () -> new Vasicek (r0.Value, a.Value, b.Value, sigma.Value, lambda.Value))
    let _a                                         = triv (fun () -> _Vasicek.Value.a())
    let _b                                         = triv (fun () -> _Vasicek.Value.b())
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _Vasicek.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _Vasicek.Value.dynamics())
    let _lambda                                    = triv (fun () -> _Vasicek.Value.lambda())
    let _sigma                                     = triv (fun () -> _Vasicek.Value.sigma())
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _Vasicek.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _Vasicek.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (now : ICell<double>) (maturity : ICell<double>) (rate : ICell<double>)   
                                                   = triv (fun () -> _Vasicek.Value.discountBond(now.Value, maturity.Value, rate.Value))
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _Vasicek.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _Vasicek.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _Vasicek.Value)
    let _constraint                                = triv (fun () -> _Vasicek.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _Vasicek.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _Vasicek.Value.notifyObservers()
                                                                     _Vasicek.Value)
    let _parameters                                = triv (fun () -> _Vasicek.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Vasicek.Value.registerWith(handler.Value)
                                                                     _Vasicek.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Vasicek.Value.setParams(parameters.Value)
                                                                     _Vasicek.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Vasicek.Value.unregisterWith(handler.Value)
                                                                     _Vasicek.Value)
    let _update                                    = triv (fun () -> _Vasicek.Value.update()
                                                                     _Vasicek.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _Vasicek.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_Vasicek)
(* 
    casting 
*)
    internal new () = new VasicekModel(null,null,null,null,null)
    member internal this.Inject v = _Vasicek <- v
    static member Cast (p : ICell<Vasicek>) = 
        if p :? VasicekModel then 
            p :?> VasicekModel
        else
            let o = new VasicekModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.r0                                 = _r0 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.sigma                              = _sigma 
    member this.lambda                             = _lambda 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Lambda                             = _lambda
    member this.Sigma                              = _sigma
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      now maturity rate   
                                                   = _discountBond1 now maturity rate 
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
