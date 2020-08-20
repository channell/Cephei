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
type AbcdCoeffHolderModel
    ( a                                            : ICell<Nullable<double>>
    , b                                            : ICell<Nullable<double>>
    , c                                            : ICell<Nullable<double>>
    , d                                            : ICell<Nullable<double>>
    , aIsFixed                                     : ICell<bool>
    , bIsFixed                                     : ICell<bool>
    , cIsFixed                                     : ICell<bool>
    , dIsFixed                                     : ICell<bool>
    ) as this =

    inherit Model<AbcdCoeffHolder> ()
(*
    Parameters
*)
    let _a                                         = a
    let _b                                         = b
    let _c                                         = c
    let _d                                         = d
    let _aIsFixed                                  = aIsFixed
    let _bIsFixed                                  = bIsFixed
    let _cIsFixed                                  = cIsFixed
    let _dIsFixed                                  = dIsFixed
(*
    Functions
*)
    let _AbcdCoeffHolder                           = cell (fun () -> new AbcdCoeffHolder (a.Value, b.Value, c.Value, d.Value, aIsFixed.Value, bIsFixed.Value, cIsFixed.Value, dIsFixed.Value))
    let _a_                                        = cell (fun () -> _AbcdCoeffHolder.Value.a_)
    let _abcdEndCriteria_                          = cell (fun () -> _AbcdCoeffHolder.Value.abcdEndCriteria_)
    let _aIsFixed_                                 = cell (fun () -> _AbcdCoeffHolder.Value.aIsFixed_)
    let _b_                                        = cell (fun () -> _AbcdCoeffHolder.Value.b_)
    let _bIsFixed_                                 = cell (fun () -> _AbcdCoeffHolder.Value.bIsFixed_)
    let _c_                                        = cell (fun () -> _AbcdCoeffHolder.Value.c_)
    let _cIsFixed_                                 = cell (fun () -> _AbcdCoeffHolder.Value.cIsFixed_)
    let _d_                                        = cell (fun () -> _AbcdCoeffHolder.Value.d_)
    let _dIsFixed_                                 = cell (fun () -> _AbcdCoeffHolder.Value.dIsFixed_)
    let _error_                                    = cell (fun () -> _AbcdCoeffHolder.Value.error_)
    let _k_                                        = cell (fun () -> _AbcdCoeffHolder.Value.k_)
    let _maxError_                                 = cell (fun () -> _AbcdCoeffHolder.Value.maxError_)
    do this.Bind(_AbcdCoeffHolder)

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.aIsFixed                           = _aIsFixed 
    member this.bIsFixed                           = _bIsFixed 
    member this.cIsFixed                           = _cIsFixed 
    member this.dIsFixed                           = _dIsFixed 
    member this.A_                                 = _a_
    member this.AbcdEndCriteria_                   = _abcdEndCriteria_
    member this.AIsFixed_                          = _aIsFixed_
    member this.B_                                 = _b_
    member this.BIsFixed_                          = _bIsFixed_
    member this.C_                                 = _c_
    member this.CIsFixed_                          = _cIsFixed_
    member this.D_                                 = _d_
    member this.DIsFixed_                          = _dIsFixed_
    member this.Error_                             = _error_
    member this.K_                                 = _k_
    member this.MaxError_                          = _maxError_
