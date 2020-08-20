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
type DouglasSchemeModel
    ( theta                                        : ICell<double>
    , map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    ) as this =

    inherit Model<DouglasScheme> ()
(*
    Parameters
*)
    let _theta                                     = theta
    let _map                                       = map
    let _bcSet                                     = bcSet
(*
    Functions
*)
    let _DouglasScheme                             = cell (fun () -> new DouglasScheme (theta.Value, map.Value, bcSet.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = cell (fun () -> _DouglasScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _DouglasScheme.Value.setStep(dt.Value)
                                                                     _DouglasScheme.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _DouglasScheme.Value.step(a.Value, t.Value, theta.Value)
                                                                     _DouglasScheme.Value)
    do this.Bind(_DouglasScheme)

(* 
    Externally visible/bindable properties
*)
    member this.theta                              = _theta 
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type DouglasSchemeModel1
    () as this =
    inherit Model<DouglasScheme> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _DouglasScheme                             = cell (fun () -> new DouglasScheme ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalInputs : ICell<Object[]>)   
                                                   = cell (fun () -> _DouglasScheme.Value.factory(L.Value, bcs.Value, additionalInputs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _DouglasScheme.Value.setStep(dt.Value)
                                                                     _DouglasScheme.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _DouglasScheme.Value.step(a.Value, t.Value, theta.Value)
                                                                     _DouglasScheme.Value)
    do this.Bind(_DouglasScheme)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalInputs   
                                                   = _factory L bcs additionalInputs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
