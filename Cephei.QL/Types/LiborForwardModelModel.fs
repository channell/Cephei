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
type LiborForwardModelModel
    ( Process                                      : ICell<LiborForwardModelProcess>
    , volaModel                                    : ICell<LmVolatilityModel>
    , corrModel                                    : ICell<LmCorrelationModel>
    ) as this =

    inherit Model<LiborForwardModel> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _volaModel                                 = volaModel
    let _corrModel                                 = corrModel
(*
    Functions
*)
    let _LiborForwardModel                         = cell (fun () -> new LiborForwardModel (Process.Value, volaModel.Value, corrModel.Value))
    let _discount                                  (t : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.discount(t.Value))
    let _discountBond                              (t : ICell<double>) (maturity : ICell<double>) (v : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.discountBond(t.Value, maturity.Value, v.Value))
    let _discountBondOption                        (Type : ICell<Option.Type>) (strike : ICell<double>) (maturity : ICell<double>) (bondMaturity : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.discountBondOption(Type.Value, strike.Value, maturity.Value, bondMaturity.Value))
    let _getSwaptionVolatilityMatrix               = triv (fun () -> _LiborForwardModel.Value.getSwaptionVolatilityMatrix())
    let _S_0                                       (alpha : ICell<int>) (beta : ICell<int>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.S_0(alpha.Value, beta.Value))
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.setParams(parameters.Value)
                                                                     _LiborForwardModel.Value)
    let _w_0                                       (alpha : ICell<int>) (beta : ICell<int>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.w_0(alpha.Value, beta.Value))
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _LiborForwardModel.Value)
    let _constraint                                = triv (fun () -> _LiborForwardModel.Value.CONSTRAINT())
    let _endCriteria                               = triv (fun () -> _LiborForwardModel.Value.endCriteria())
    let _notifyObservers                           = triv (fun () -> _LiborForwardModel.Value.notifyObservers()
                                                                     _LiborForwardModel.Value)
    let _parameters                                = triv (fun () -> _LiborForwardModel.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.registerWith(handler.Value)
                                                                     _LiborForwardModel.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.unregisterWith(handler.Value)
                                                                     _LiborForwardModel.Value)
    let _update                                    = triv (fun () -> _LiborForwardModel.Value.update()
                                                                     _LiborForwardModel.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = triv (fun () -> _LiborForwardModel.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_LiborForwardModel)
(* 
    casting 
*)
    internal new () = LiborForwardModelModel(null,null,null)
    member internal this.Inject v = _LiborForwardModel.Value <- v
    static member Cast (p : ICell<LiborForwardModel>) = 
        if p :? LiborForwardModelModel then 
            p :?> LiborForwardModelModel
        else
            let o = new LiborForwardModelModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.volaModel                          = _volaModel 
    member this.corrModel                          = _corrModel 
    member this.Discount                           t   
                                                   = _discount t 
    member this.DiscountBond                       t maturity v   
                                                   = _discountBond t maturity v 
    member this.DiscountBondOption                 Type strike maturity bondMaturity   
                                                   = _discountBondOption Type strike maturity bondMaturity 
    member this.GetSwaptionVolatilityMatrix        = _getSwaptionVolatilityMatrix
    member this.S_0                                alpha beta   
                                                   = _S_0 alpha beta 
    member this.SetParams                          parameters   
                                                   = _setParams parameters 
    member this.W_0                                alpha beta   
                                                   = _w_0 alpha beta 
    member this.Calibrate                          instruments Method endCriteria additionalConstraint weights fixParameters   
                                                   = _calibrate instruments Method endCriteria additionalConstraint weights fixParameters 
    member this.Constraint                         = _constraint
    member this.EndCriteria                        = _endCriteria
    member this.NotifyObservers                    = _notifyObservers
    member this.Parameters                         = _parameters
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.Value                              parameters instruments   
                                                   = _value parameters instruments 
