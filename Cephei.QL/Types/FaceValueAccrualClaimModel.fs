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
  Claim on the notional of a reference security, including accrual

  </summary> *)
[<AutoSerializable(true)>]
type FaceValueAccrualClaimModel
    ( referenceSecurity                            : ICell<Bond>
    ) as this =

    inherit Model<FaceValueAccrualClaim> ()
(*
    Parameters
*)
    let _referenceSecurity                         = referenceSecurity
(*
    Functions
*)
    let _FaceValueAccrualClaim                     = cell (fun () -> new FaceValueAccrualClaim (referenceSecurity.Value))
    let _amount                                    (d : ICell<Date>) (notional : ICell<double>) (recoveryRate : ICell<double>)   
                                                   = triv (fun () -> _FaceValueAccrualClaim.Value.amount(d.Value, notional.Value, recoveryRate.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FaceValueAccrualClaim.Value.registerWith(handler.Value)
                                                                     _FaceValueAccrualClaim.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FaceValueAccrualClaim.Value.unregisterWith(handler.Value)
                                                                     _FaceValueAccrualClaim.Value)
    let _update                                    = triv (fun () -> _FaceValueAccrualClaim.Value.update()
                                                                     _FaceValueAccrualClaim.Value)
    do this.Bind(_FaceValueAccrualClaim)

(* 
    Externally visible/bindable properties
*)
    member this.referenceSecurity                  = _referenceSecurity 
    member this.Amount                             d notional recoveryRate   
                                                   = _amount d notional recoveryRate 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
