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
type rStarFinderModel
    ( model                                        : ICell<OneFactorAffineModel>
    , nominal                                      : ICell<double>
    , maturity                                     : ICell<double>
    , fixedPayTimes                                : ICell<Generic.List<double>>
    , amounts                                      : ICell<Generic.List<double>>
    ) as this =

    inherit Model<rStarFinder> ()
(*
    Parameters
*)
    let _model                                     = model
    let _nominal                                   = nominal
    let _maturity                                  = maturity
    let _fixedPayTimes                             = fixedPayTimes
    let _amounts                                   = amounts
(*
    Functions
*)
    let _rStarFinder                               = cell (fun () -> new rStarFinder (model.Value, nominal.Value, maturity.Value, fixedPayTimes.Value, amounts.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _rStarFinder.Value.value(x.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _rStarFinder.Value.derivative(x.Value))
    do this.Bind(_rStarFinder)
(* 
    casting 
*)
    internal new () = rStarFinderModel(null,null,null,null,null)
    member internal this.Inject v = _rStarFinder.Value <- v
    static member Cast (p : ICell<rStarFinder>) = 
        if p :? rStarFinderModel then 
            p :?> rStarFinderModel
        else
            let o = new rStarFinderModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = rStarFinderModel(null,null,null,null,null)
    static member Cast (p : ICell<rStarFinder>) = 
        if p :? rStarFinderModel then 
            p :?> rStarFinderModel
        else
            let o = new rStarFinderModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.nominal                            = _nominal 
    member this.maturity                           = _maturity 
    member this.fixedPayTimes                      = _fixedPayTimes 
    member this.amounts                            = _amounts 
    member this.Value                              x   
                                                   = _value x 
    member this.Derivative                         x   
                                                   = _derivative x 
