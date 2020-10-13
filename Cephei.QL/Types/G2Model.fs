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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , b                                            : ICell<double>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
    let _b                                         = b
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value, a.Value, sigma.Value, b.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model(null,null,null,null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model then 
            p :?> G2Model
        else
            let o = new G2Model ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.b                                  = _b 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model1
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model1(null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model1 then 
            p :?> G2Model1
        else
            let o = new G2Model1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model2
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value, a.Value, sigma.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model2(null,null,null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model2 then 
            p :?> G2Model2
        else
            let o = new G2Model2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model3
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , b                                            : ICell<double>
    , eta                                          : ICell<double>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
    let _b                                         = b
    let _eta                                       = eta
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value, a.Value, sigma.Value, b.Value, eta.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model3(null,null,null,null,null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model3 then 
            p :?> G2Model3
        else
            let o = new G2Model3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.b                                  = _b 
    member this.eta                                = _eta 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model4
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , b                                            : ICell<double>
    , eta                                          : ICell<double>
    , rho                                          : ICell<double>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
    let _sigma                                     = sigma
    let _b                                         = b
    let _eta                                       = eta
    let _rho                                       = rho
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value, a.Value, sigma.Value, b.Value, eta.Value, rho.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model4(null,null,null,null,null,null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model4 then 
            p :?> G2Model4
        else
            let o = new G2Model4 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.b                                  = _b 
    member this.eta                                = _eta 
    member this.rho                                = _rho 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
  This class implements a two-additive-factor model defined by dr_t = + x_t + y_t where x_t and y_t are defined by dx_t = -a x_t dt + dW^1_t, x_0 = 0 dy_t = -b y_t dt + dW^2_t, y_0 = 0 and dW^1_t dW^2_t = dt  This class was not tested enough to guarantee its functionality.  shortrate

  </summary> *)
[<AutoSerializable(true)>]
type G2Model5
    ( termStructure                                : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    ) as this =

    inherit Model<G2> ()
(*
    Parameters
*)
    let _termStructure                             = termStructure
    let _a                                         = a
(*
    Functions
*)
    let _G2                                        = cell (fun () -> new G2 (termStructure.Value, a.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discount(t.Value))
    let _discountBond                              (now : ICell<double>) (maturity : ICell<double>) (factors : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.discountBond(now.Value, maturity.Value, factors.Value))
    let _discountBond1                             (t : ICell<double>) (T2 : ICell<double>) (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBond(t.Value, T2.Value, x.Value, y.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _G2.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _dynamics                                  = triv (fun () -> _G2.Value.dynamics())
    let _swaption                                  (arguments : ICell<Swaption.Arguments>) (fixedRate : ICell<double>) (range : ICell<double>) (intervals : ICell<int>)   
                                                   = triv (fun () -> _G2.Value.swaption(arguments.Value, fixedRate.Value, range.Value, intervals.Value))
    let _termStructure                             = triv (fun () -> _G2.Value.termStructure())
    let _termStructure_                            = triv (fun () -> _G2.Value.termStructure_)
    let _tree                                      (grid : ICell<TimeGrid>)   
                                                   = triv (fun () -> _G2.Value.tree(grid.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _G2.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _G2.Value)
    let _constraint                                = triv (fun () -> _G2.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _G2.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _G2.Value.notifyObservers()
                                                                     _G2.Value)
    let _parameters                                = triv (fun () -> _G2.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.registerWith(handler.Value)
                                                                     _G2.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _G2.Value.setParams(parameters.Value)
                                                                     _G2.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _G2.Value.unregisterWith(handler.Value)
                                                                     _G2.Value)
    let _update                                    = triv (fun () -> _G2.Value.update()
                                                                     _G2.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _G2.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_G2)
(* 
    casting 
*)
    internal new () = new G2Model5(null,null)
    member internal this.Inject v = _G2.Value <- v
    static member Cast (p : ICell<G2>) = 
        if p :? G2Model5 then 
            p :?> G2Model5
        else
            let o = new G2Model5 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termStructure                      = _termStructure 
    member this.a                                  = _a 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       now maturity factors   
                                                   = _discountBond now maturity factors 
    member this.DiscountBond1                      t T2 x y   
                                                   = _discountBond1 t T2 x y 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.Dynamics                           = _dynamics
    member this.Swaption                           arguments fixedRate range intervals   
                                                   = _swaption arguments fixedRate range intervals 
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
