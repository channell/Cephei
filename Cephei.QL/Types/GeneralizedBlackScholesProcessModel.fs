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
  This class describes the stochastic process S governed by  S(t) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  while the interface is expressed in terms of S the internal calculations work on ln S  processes

  </summary> *)
[<AutoSerializable(true)>]
type GeneralizedBlackScholesProcessModel
    ( x0                                           : ICell<Handle<Quote>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , localVolTS                                   : ICell<RelinkableHandle<LocalVolTermStructure>>
    , disc                                         : ICell<IDiscretization1D>
    ) as this =

    inherit Model<GeneralizedBlackScholesProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _dividendTS                                = dividendTS
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
    let _localVolTS                                = localVolTS
    let _disc                                      = disc
(*
    Functions
*)
    let _GeneralizedBlackScholesProcess            = cell (fun () -> new GeneralizedBlackScholesProcess (x0.Value, dividendTS.Value, riskFreeTS.Value, blackVolTS.Value, localVolTS.Value, disc.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _GeneralizedBlackScholesProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _GeneralizedBlackScholesProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _GeneralizedBlackScholesProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _GeneralizedBlackScholesProcess.Value.update()
                                                                     _GeneralizedBlackScholesProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _GeneralizedBlackScholesProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _GeneralizedBlackScholesProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.registerWith(handler.Value)
                                                                     _GeneralizedBlackScholesProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.unregisterWith(handler.Value)
                                                                     _GeneralizedBlackScholesProcess.Value)
    do this.Bind(_GeneralizedBlackScholesProcess)
(* 
    casting 
*)
    internal new () = GeneralizedBlackScholesProcessModel(null,null,null,null,null,null)
    member internal this.Inject v = _GeneralizedBlackScholesProcess.Value <- v
    static member Cast (p : ICell<GeneralizedBlackScholesProcess>) = 
        if p :? GeneralizedBlackScholesProcessModel then 
            p :?> GeneralizedBlackScholesProcessModel
        else
            let o = new GeneralizedBlackScholesProcessModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.dividendTS                         = _dividendTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.blackVolTS                         = _blackVolTS 
    member this.localVolTS                         = _localVolTS 
    member this.disc                               = _disc 
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.BlackVolatility                    = _blackVolatility
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.DividendYield                      = _dividendYield
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.LocalVolatility                    = _localVolatility
    member this.RiskFreeRate                       = _riskFreeRate
    member this.StateVariable                      = _stateVariable
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Time                               d   
                                                   = _time d 
    member this.Update                             = _update
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
    member this.X0                                 = _x0
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Factors                            = _factors
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  This class describes the stochastic process S governed by  S(t) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  while the interface is expressed in terms of S the internal calculations work on ln S  processes

  </summary> *)
[<AutoSerializable(true)>]
type GeneralizedBlackScholesProcessModel1
    ( x0                                           : ICell<Handle<Quote>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , disc                                         : ICell<IDiscretization1D>
    ) as this =

    inherit Model<GeneralizedBlackScholesProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _dividendTS                                = dividendTS
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
    let _disc                                      = disc
(*
    Functions
*)
    let _GeneralizedBlackScholesProcess            = cell (fun () -> new GeneralizedBlackScholesProcess (x0.Value, dividendTS.Value, riskFreeTS.Value, blackVolTS.Value, disc.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _GeneralizedBlackScholesProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _GeneralizedBlackScholesProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _GeneralizedBlackScholesProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _GeneralizedBlackScholesProcess.Value.update()
                                                                     _GeneralizedBlackScholesProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _GeneralizedBlackScholesProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _GeneralizedBlackScholesProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _GeneralizedBlackScholesProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.registerWith(handler.Value)
                                                                     _GeneralizedBlackScholesProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GeneralizedBlackScholesProcess.Value.unregisterWith(handler.Value)
                                                                     _GeneralizedBlackScholesProcess.Value)
    do this.Bind(_GeneralizedBlackScholesProcess)
(* 
    casting 
*)
    internal new () = GeneralizedBlackScholesProcessModel1(null,null,null,null,null)
    member internal this.Inject v = _GeneralizedBlackScholesProcess.Value <- v
    static member Cast (p : ICell<GeneralizedBlackScholesProcess>) = 
        if p :? GeneralizedBlackScholesProcessModel1 then 
            p :?> GeneralizedBlackScholesProcessModel1
        else
            let o = new GeneralizedBlackScholesProcessModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.dividendTS                         = _dividendTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.blackVolTS                         = _blackVolTS 
    member this.disc                               = _disc 
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.BlackVolatility                    = _blackVolatility
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.DividendYield                      = _dividendYield
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.LocalVolatility                    = _localVolatility
    member this.RiskFreeRate                       = _riskFreeRate
    member this.StateVariable                      = _stateVariable
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Time                               d   
                                                   = _time d 
    member this.Update                             = _update
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
    member this.X0                                 = _x0
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Factors                            = _factors
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
