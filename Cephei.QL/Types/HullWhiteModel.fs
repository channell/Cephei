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
type HullWhiteModel
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<HullWhite> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _HullWhite                                 = make (fun () -> new HullWhite (termStructure.Value, a.Value, sigma.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv _HullWhite (fun () -> _HullWhite.Value.dynamics())
    let _termStructure                             = triv _HullWhite (fun () -> _HullWhite.Value.termStructure())
    let _termStructure_                            = triv _HullWhite (fun () -> _HullWhite.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.tree(grid.Value))
    let _a                                         = triv _HullWhite (fun () -> _HullWhite.Value.a())
    let _b                                         = triv _HullWhite (fun () -> _HullWhite.Value.b())
    let _lambda                                    = triv _HullWhite (fun () -> _HullWhite.Value.lambda())
    let _sigma                                     = triv _HullWhite (fun () -> _HullWhite.Value.sigma())
    let _discount                                  (t : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (now : ICell<double>) (maturity : ICell<double>) (rate : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, rate.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                                _HullWhite.Value)
    let _constraint                                = triv _HullWhite (fun () -> _HullWhite.Value.CONSTRAINT())
    let _endCriteria                               = triv _HullWhite (fun () -> _HullWhite.Value.endCriteria())
    let _notifyObservers                           = triv _HullWhite (fun () -> _HullWhite.Value.notifyObservers()
                                                                                _HullWhite.Value)
    let _parameters                                = triv _HullWhite (fun () -> _HullWhite.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.registerWith(handler.Value)
                                                                                _HullWhite.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.setParams(parameters.Value)
                                                                                _HullWhite.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.unregisterWith(handler.Value)
                                                                                _HullWhite.Value)
    let _update                                    = triv _HullWhite (fun () -> _HullWhite.Value.update()
                                                                                _HullWhite.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_HullWhite)
(* 
    casting 
*)
    internal new () = new HullWhiteModel(null,null,null)
    member internal this.Inject v = _HullWhite <- v
    static member Cast (p : ICell<HullWhite>) = 
        if p :? HullWhiteModel then 
            p :?> HullWhiteModel
        else
            let o = new HullWhiteModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.TermStructure                      = _termStructure
    member this.TermStructure_                     = _termStructure_
    member this.Tree                               grid   
                                                   = _tree grid 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.Lambda                             = _lambda
    member this.Sigma                              = _sigma
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type HullWhiteModel1
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<HullWhite> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
(*
    Functions
*)
    let mutable
        _HullWhite                                 = make (fun () -> new HullWhite (termStructure.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv _HullWhite (fun () -> _HullWhite.Value.dynamics())
    let _termStructure                             = triv _HullWhite (fun () -> _HullWhite.Value.termStructure())
    let _termStructure_                            = triv _HullWhite (fun () -> _HullWhite.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.tree(grid.Value))
    let _a                                         = triv _HullWhite (fun () -> _HullWhite.Value.a())
    let _b                                         = triv _HullWhite (fun () -> _HullWhite.Value.b())
    let _lambda                                    = triv _HullWhite (fun () -> _HullWhite.Value.lambda())
    let _sigma                                     = triv _HullWhite (fun () -> _HullWhite.Value.sigma())
    let _discount                                  (t : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (now : ICell<double>) (maturity : ICell<double>) (rate : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, rate.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                                _HullWhite.Value)
    let _constraint                                = triv _HullWhite (fun () -> _HullWhite.Value.CONSTRAINT())
    let _endCriteria                               = triv _HullWhite (fun () -> _HullWhite.Value.endCriteria())
    let _notifyObservers                           = triv _HullWhite (fun () -> _HullWhite.Value.notifyObservers()
                                                                                _HullWhite.Value)
    let _parameters                                = triv _HullWhite (fun () -> _HullWhite.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.registerWith(handler.Value)
                                                                                _HullWhite.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.setParams(parameters.Value)
                                                                                _HullWhite.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.unregisterWith(handler.Value)
                                                                                _HullWhite.Value)
    let _update                                    = triv _HullWhite (fun () -> _HullWhite.Value.update()
                                                                                _HullWhite.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_HullWhite)
(* 
    casting 
*)
    internal new () = new HullWhiteModel1(null)
    member internal this.Inject v = _HullWhite <- v
    static member Cast (p : ICell<HullWhite>) = 
        if p :? HullWhiteModel1 then 
            p :?> HullWhiteModel1
        else
            let o = new HullWhiteModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.TermStructure                      = _termStructure
    member this.TermStructure_                     = _termStructure_
    member this.Tree                               grid   
                                                   = _tree grid 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.Lambda                             = _lambda
    member this.Sigma                              = _sigma
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type HullWhiteModel2
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    ) as this =

    inherit Model<HullWhite> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
(*
    Functions
*)
    let mutable
        _HullWhite                                 = make (fun () -> new HullWhite (termStructure.Value, a.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv _HullWhite (fun () -> _HullWhite.Value.dynamics())
    let _termStructure                             = triv _HullWhite (fun () -> _HullWhite.Value.termStructure())
    let _termStructure_                            = triv _HullWhite (fun () -> _HullWhite.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.tree(grid.Value))
    let _a                                         = triv _HullWhite (fun () -> _HullWhite.Value.a())
    let _b                                         = triv _HullWhite (fun () -> _HullWhite.Value.b())
    let _lambda                                    = triv _HullWhite (fun () -> _HullWhite.Value.lambda())
    let _sigma                                     = triv _HullWhite (fun () -> _HullWhite.Value.sigma())
    let _discount                                  (t : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (now : ICell<double>) (maturity : ICell<double>) (rate : ICell<double>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.discountBond(now.Value, maturity.Value, rate.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                                _HullWhite.Value)
    let _constraint                                = triv _HullWhite (fun () -> _HullWhite.Value.CONSTRAINT())
    let _endCriteria                               = triv _HullWhite (fun () -> _HullWhite.Value.endCriteria())
    let _notifyObservers                           = triv _HullWhite (fun () -> _HullWhite.Value.notifyObservers()
                                                                                _HullWhite.Value)
    let _parameters                                = triv _HullWhite (fun () -> _HullWhite.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.registerWith(handler.Value)
                                                                                _HullWhite.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.setParams(parameters.Value)
                                                                                _HullWhite.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.unregisterWith(handler.Value)
                                                                                _HullWhite.Value)
    let _update                                    = triv _HullWhite (fun () -> _HullWhite.Value.update()
                                                                                _HullWhite.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv _HullWhite (fun () -> _HullWhite.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_HullWhite)
(* 
    casting 
*)
    internal new () = new HullWhiteModel2(null,null)
    member internal this.Inject v = _HullWhite <- v
    static member Cast (p : ICell<HullWhite>) = 
        if p :? HullWhiteModel2 then 
            p :?> HullWhiteModel2
        else
            let o = new HullWhiteModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.TermStructure                      = _termStructure
    member this.TermStructure_                     = _termStructure_
    member this.Tree                               grid   
                                                   = _tree grid 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.Lambda                             = _lambda
    member this.Sigma                              = _sigma
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
