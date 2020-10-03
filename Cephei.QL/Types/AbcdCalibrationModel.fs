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
type AbcdCalibrationModel
    () as this =
    inherit Model<AbcdCalibration> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _AbcdCalibration                           = cell (fun () -> new AbcdCalibration ())
    let _a                                         = triv (fun () -> _AbcdCalibration.Value.a())
    let _abcdBlackVolatility                       (u : ICell<double>) (a : ICell<double>) (b : ICell<double>) (c : ICell<double>) (d : ICell<double>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.abcdBlackVolatility(u.Value, a.Value, b.Value, c.Value, d.Value))
    let _aIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.aIsFixed_)
    let _b                                         = triv (fun () -> _AbcdCalibration.Value.b())
    let _bIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.bIsFixed_)
    let _c                                         = triv (fun () -> _AbcdCalibration.Value.c())
    let _cIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.cIsFixed_)
    let _compute                                   = triv (fun () -> _AbcdCalibration.Value.compute()
                                                                     _AbcdCalibration.Value)
    let _d                                         = triv (fun () -> _AbcdCalibration.Value.d())
    let _dIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.dIsFixed_)
    let _endCriteria                               = triv (fun () -> _AbcdCalibration.Value.endCriteria())
    let _error                                     = triv (fun () -> _AbcdCalibration.Value.error())
    let _errors                                    = triv (fun () -> _AbcdCalibration.Value.errors())
    let _k                                         (t : ICell<Generic.List<double>>) (blackVols : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.k(t.Value, blackVols.Value))
    let _maxError                                  = triv (fun () -> _AbcdCalibration.Value.maxError())
    let _transformation_                           = triv (fun () -> _AbcdCalibration.Value.transformation_)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.value(x.Value))
    do this.Bind(_AbcdCalibration)
(* 
    casting 
*)
    
    member internal this.Inject v = _AbcdCalibration.Value <- v
    static member Cast (p : ICell<AbcdCalibration>) = 
        if p :? AbcdCalibrationModel then 
            p :?> AbcdCalibrationModel
        else
            let o = new AbcdCalibrationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.A                                  = _a
    member this.AbcdBlackVolatility                u a b c d   
                                                   = _abcdBlackVolatility u a b c d 
    member this.AIsFixed_                          = _aIsFixed_
    member this.B                                  = _b
    member this.BIsFixed_                          = _bIsFixed_
    member this.C                                  = _c
    member this.CIsFixed_                          = _cIsFixed_
    member this.Compute                            = _compute
    member this.D                                  = _d
    member this.DIsFixed_                          = _dIsFixed_
    member this.EndCriteria                        = _endCriteria
    member this.Error                              = _error
    member this.Errors                             = _errors
    member this.K                                  t blackVols   
                                                   = _k t blackVols 
    member this.MaxError                           = _maxError
    member this.Transformation_                    = _transformation_
    member this.Value                              x   
                                                   = _value x 
(* <summary>

to constrained <- from unconstrained
  </summary> *)
[<AutoSerializable(true)>]
type AbcdCalibrationModel1
    ( t                                            : ICell<Generic.List<double>>
    , blackVols                                    : ICell<Generic.List<double>>
    , aGuess                                       : ICell<double>
    , bGuess                                       : ICell<double>
    , cGuess                                       : ICell<double>
    , dGuess                                       : ICell<double>
    , aIsFixed                                     : ICell<bool>
    , bIsFixed                                     : ICell<bool>
    , cIsFixed                                     : ICell<bool>
    , dIsFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , Method                                       : ICell<OptimizationMethod>
    ) as this =

    inherit Model<AbcdCalibration> ()
(*
    Parameters
*)
    let _t                                         = t
    let _blackVols                                 = blackVols
    let _aGuess                                    = aGuess
    let _bGuess                                    = bGuess
    let _cGuess                                    = cGuess
    let _dGuess                                    = dGuess
    let _aIsFixed                                  = aIsFixed
    let _bIsFixed                                  = bIsFixed
    let _cIsFixed                                  = cIsFixed
    let _dIsFixed                                  = dIsFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _Method                                    = Method
(*
    Functions
*)
    let _AbcdCalibration                           = cell (fun () -> new AbcdCalibration (t.Value, blackVols.Value, aGuess.Value, bGuess.Value, cGuess.Value, dGuess.Value, aIsFixed.Value, bIsFixed.Value, cIsFixed.Value, dIsFixed.Value, vegaWeighted.Value, endCriteria.Value, Method.Value))
    let _a                                         = triv (fun () -> _AbcdCalibration.Value.a())
    let _abcdBlackVolatility                       (u : ICell<double>) (a : ICell<double>) (b : ICell<double>) (c : ICell<double>) (d : ICell<double>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.abcdBlackVolatility(u.Value, a.Value, b.Value, c.Value, d.Value))
    let _aIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.aIsFixed_)
    let _b                                         = triv (fun () -> _AbcdCalibration.Value.b())
    let _bIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.bIsFixed_)
    let _c                                         = triv (fun () -> _AbcdCalibration.Value.c())
    let _cIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.cIsFixed_)
    let _compute                                   = triv (fun () -> _AbcdCalibration.Value.compute()
                                                                     _AbcdCalibration.Value)
    let _d                                         = triv (fun () -> _AbcdCalibration.Value.d())
    let _dIsFixed_                                 = triv (fun () -> _AbcdCalibration.Value.dIsFixed_)
    let _endCriteria                               = triv (fun () -> _AbcdCalibration.Value.endCriteria())
    let _error                                     = triv (fun () -> _AbcdCalibration.Value.error())
    let _errors                                    = triv (fun () -> _AbcdCalibration.Value.errors())
    let _k                                         (t : ICell<Generic.List<double>>) (blackVols : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.k(t.Value, blackVols.Value))
    let _maxError                                  = triv (fun () -> _AbcdCalibration.Value.maxError())
    let _transformation_                           = triv (fun () -> _AbcdCalibration.Value.transformation_)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _AbcdCalibration.Value.value(x.Value))
    do this.Bind(_AbcdCalibration)
(* 
    casting 
*)
    internal new () = AbcdCalibrationModel1(null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _AbcdCalibration.Value <- v
    static member Cast (p : ICell<AbcdCalibration>) = 
        if p :? AbcdCalibrationModel1 then 
            p :?> AbcdCalibrationModel1
        else
            let o = new AbcdCalibrationModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.blackVols                          = _blackVols 
    member this.aGuess                             = _aGuess 
    member this.bGuess                             = _bGuess 
    member this.cGuess                             = _cGuess 
    member this.dGuess                             = _dGuess 
    member this.aIsFixed                           = _aIsFixed 
    member this.bIsFixed                           = _bIsFixed 
    member this.cIsFixed                           = _cIsFixed 
    member this.dIsFixed                           = _dIsFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.Method                             = _Method 
    member this.A                                  = _a
    member this.AbcdBlackVolatility                u a b c d   
                                                   = _abcdBlackVolatility u a b c d 
    member this.AIsFixed_                          = _aIsFixed_
    member this.B                                  = _b
    member this.BIsFixed_                          = _bIsFixed_
    member this.C                                  = _c
    member this.CIsFixed_                          = _cIsFixed_
    member this.Compute                            = _compute
    member this.D                                  = _d
    member this.DIsFixed_                          = _dIsFixed_
    member this.EndCriteria                        = _endCriteria
    member this.Error                              = _error
    member this.Errors                             = _errors
    member this.K                                  t blackVols   
                                                   = _k t blackVols 
    member this.MaxError                           = _maxError
    member this.Transformation_                    = _transformation_
    member this.Value                              x   
                                                   = _value x 
