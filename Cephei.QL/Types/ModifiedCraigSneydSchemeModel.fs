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
  References: K. J. in ’t Hout and S. Foulon, ADI finite difference schemes for option pricing in the Heston model with correlation, http://arxiv.org/pdf/0811.3427

  </summary> *)
[<AutoSerializable(true)>]
type ModifiedCraigSneydSchemeModel
    () as this =
    inherit Model<ModifiedCraigSneydScheme> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ModifiedCraigSneydScheme                  = cell (fun () -> new ModifiedCraigSneydScheme ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.setStep(dt.Value)
                                                                     _ModifiedCraigSneydScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                     _ModifiedCraigSneydScheme.Value)
    do this.Bind(_ModifiedCraigSneydScheme)
(* 
    casting 
*)
    
    member internal this.Inject v = _ModifiedCraigSneydScheme <- v
    static member Cast (p : ICell<ModifiedCraigSneydScheme>) = 
        if p :? ModifiedCraigSneydSchemeModel then 
            p :?> ModifiedCraigSneydSchemeModel
        else
            let o = new ModifiedCraigSneydSchemeModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>
  References: K. J. in ’t Hout and S. Foulon, ADI finite difference schemes for option pricing in the Heston model with correlation, http://arxiv.org/pdf/0811.3427

  </summary> *)
[<AutoSerializable(true)>]
type ModifiedCraigSneydSchemeModel1
    ( theta                                        : ICell<double>
    , mu                                           : ICell<double>
    , map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    ) as this =

    inherit Model<ModifiedCraigSneydScheme> ()
(*
    Parameters
*)
    let _theta                                     = theta
    let _mu                                        = mu
    let _map                                       = map
    let _bcSet                                     = bcSet
(*
    Functions
*)
    let mutable
        _ModifiedCraigSneydScheme                  = cell (fun () -> new ModifiedCraigSneydScheme (theta.Value, mu.Value, map.Value, bcSet.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.setStep(dt.Value)
                                                                     _ModifiedCraigSneydScheme.Value)
    let _step                                      (a : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ModifiedCraigSneydScheme.Value.step(ref a.Value, t.Value, theta.Value)
                                                                     _ModifiedCraigSneydScheme.Value)
    do this.Bind(_ModifiedCraigSneydScheme)
(* 
    casting 
*)
    internal new () = new ModifiedCraigSneydSchemeModel1(null,null,null,null)
    member internal this.Inject v = _ModifiedCraigSneydScheme <- v
    static member Cast (p : ICell<ModifiedCraigSneydScheme>) = 
        if p :? ModifiedCraigSneydSchemeModel1 then 
            p :?> ModifiedCraigSneydSchemeModel1
        else
            let o = new ModifiedCraigSneydSchemeModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.theta                              = _theta 
    member this.mu                                 = _mu 
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
