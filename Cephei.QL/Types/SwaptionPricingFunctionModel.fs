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
type SwaptionPricingFunctionModel
    ( a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , b                                            : ICell<double>
    , eta                                          : ICell<double>
    , rho                                          : ICell<double>
    , w                                            : ICell<double>
    , start                                        : ICell<double>
    , payTimes                                     : ICell<Generic.List<double>>
    , fixedRate                                    : ICell<double>
    , model                                        : ICell<G2>
    ) as this =

    inherit Model<SwaptionPricingFunction> ()
(*
    Parameters
*)
    let _a                                         = a
    let _sigma                                     = sigma
    let _b                                         = b
    let _eta                                       = eta
    let _rho                                       = rho
    let _w                                         = w
    let _start                                     = start
    let _payTimes                                  = payTimes
    let _fixedRate                                 = fixedRate
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _SwaptionPricingFunction                   = cell (fun () -> new SwaptionPricingFunction (a.Value, sigma.Value, b.Value, eta.Value, rho.Value, w.Value, start.Value, payTimes.Value, fixedRate.Value, model.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _SwaptionPricingFunction.Value.value(x.Value))
    do this.Bind(_SwaptionPricingFunction)
(* 
    casting 
*)
    internal new () = SwaptionPricingFunctionModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwaptionPricingFunction <- v
    static member Cast (p : ICell<SwaptionPricingFunction>) = 
        if p :? SwaptionPricingFunctionModel then 
            p :?> SwaptionPricingFunctionModel
        else
            let o = new SwaptionPricingFunctionModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = SwaptionPricingFunctionModel(null,null,null,null,null,null,null,null,null,null)
    static member Cast (p : ICell<SwaptionPricingFunction>) = 
        if p :? SwaptionPricingFunctionModel then 
            p :?> SwaptionPricingFunctionModel
        else
            let o = new SwaptionPricingFunctionModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.b                                  = _b 
    member this.eta                                = _eta 
    member this.rho                                = _rho 
    member this.w                                  = _w 
    member this.start                              = _start 
    member this.payTimes                           = _payTimes 
    member this.fixedRate                          = _fixedRate 
    member this.model                              = _model 
    member this.Value                              x   
                                                   = _value x 
