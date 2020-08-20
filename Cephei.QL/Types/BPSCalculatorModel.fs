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
type BPSCalculatorModel
    ( discountCurve                                : ICell<YieldTermStructure>
    ) as this =

    inherit Model<BPSCalculator> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let _BPSCalculator                             = cell (fun () -> new BPSCalculator (discountCurve.Value))
    let _bps                                       = cell (fun () -> _BPSCalculator.Value.bps())
    let _nonSensNPV                                = cell (fun () -> _BPSCalculator.Value.nonSensNPV())
    let _visit                                     (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(cf.Value)
                                                                     _BPSCalculator.Value)
    let _visit1                                    (c : ICell<Coupon>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(c.Value)
                                                                     _BPSCalculator.Value)
    let _visit2                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(o.Value)
                                                                     _BPSCalculator.Value)
    do this.Bind(_BPSCalculator)

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.Bps                                = _bps
    member this.NonSensNPV                         = _nonSensNPV
    member this.Visit                              cf   
                                                   = _visit cf 
    member this.Visit1                             c   
                                                   = _visit1 c 
    member this.Visit2                             o   
                                                   = _visit2 o 
