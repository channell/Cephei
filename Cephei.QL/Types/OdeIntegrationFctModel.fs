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
type OdeIntegrationFctModel
    ( points                                       : ICell<List<Nullable<double>>>
    , betas                                        : ICell<List<Nullable<double>>>
    , tol                                          : ICell<double>
    ) as this =

    inherit Model<OdeIntegrationFct> ()
(*
    Parameters
*)
    let _points                                    = points
    let _betas                                     = betas
    let _tol                                       = tol
(*
    Functions
*)
    let _OdeIntegrationFct                         = cell (fun () -> new OdeIntegrationFct (points.Value, betas.Value, tol.Value))
    let _solve                                     (a : ICell<double>) (y0 : ICell<double>) (x0 : ICell<double>) (x1 : ICell<double>)   
                                                   = cell (fun () -> _OdeIntegrationFct.Value.solve(a.Value, y0.Value, x0.Value, x1.Value))
    do this.Bind(_OdeIntegrationFct)

(* 
    Externally visible/bindable properties
*)
    member this.points                             = _points 
    member this.betas                              = _betas 
    member this.tol                                = _tol 
    member this.Solve                              a y0 x0 x1   
                                                   = _solve a y0 x0 x1 
