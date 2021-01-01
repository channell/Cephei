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
  interpolations

  </summary> *)
[<AutoSerializable(true)>]
type AbcdModel
    ( a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    , aIsFixed                                     : ICell<bool>
    , bIsFixed                                     : ICell<bool>
    , cIsFixed                                     : ICell<bool>
    , dIsFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , optMethod                                    : ICell<OptimizationMethod>
    ) as this =

    inherit Model<Abcd> ()
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
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _optMethod                                 = optMethod
(*
    Functions
*)
    let mutable
        _Abcd                                      = make (fun () -> new Abcd (a.Value, b.Value, c.Value, d.Value, aIsFixed.Value, bIsFixed.Value, cIsFixed.Value, dIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value))
    let _global                                    = triv _Abcd (fun () -> _Abcd.Value.GLOBAL)
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv _Abcd (fun () -> _Abcd.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    do this.Bind(_Abcd)
(* 
    casting 
*)
    internal new () = new AbcdModel(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _Abcd <- v
    static member Cast (p : ICell<Abcd>) = 
        if p :? AbcdModel then 
            p :?> AbcdModel
        else
            let o = new AbcdModel ()
            o.Inject p
            o.Bind p
            o
                            

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
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.optMethod                          = _optMethod 
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
