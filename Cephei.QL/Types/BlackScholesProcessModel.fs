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
  This class describes the stochastic process S for a stock given by dS(t, S) = (r(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesProcessModel
    ( x0                                           : ICell<Handle<Quote>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , d                                            : ICell<IDiscretization1D>
    ) as this =

    inherit Model<BlackScholesProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
    let _d                                         = d
(*
    Functions
*)
    let _BlackScholesProcess                       = cell (fun () -> new BlackScholesProcess (x0.Value, riskFreeTS.Value, blackVolTS.Value, d.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _BlackScholesProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _BlackScholesProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _BlackScholesProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _BlackScholesProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _BlackScholesProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _BlackScholesProcess.Value.update()
                                                                     _BlackScholesProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _BlackScholesProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _BlackScholesProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _BlackScholesProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _BlackScholesProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.registerWith(handler.Value)
                                                                     _BlackScholesProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.unregisterWith(handler.Value)
                                                                     _BlackScholesProcess.Value)
    do this.Bind(_BlackScholesProcess)
(* 
    casting 
*)
    internal new () = BlackScholesProcessModel(null,null,null,null)
    member internal this.Inject v = _BlackScholesProcess.Value <- v
    static member Cast (p : ICell<BlackScholesProcess>) = 
        if p :? BlackScholesProcessModel then 
            p :?> BlackScholesProcessModel
        else
            let o = new BlackScholesProcessModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.blackVolTS                         = _blackVolTS 
    member this.d                                  = _d 
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
  This class describes the stochastic process S for a stock given by dS(t, S) = (r(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesProcessModel1
    ( x0                                           : ICell<Handle<Quote>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    ) as this =

    inherit Model<BlackScholesProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
(*
    Functions
*)
    let _BlackScholesProcess                       = cell (fun () -> new BlackScholesProcess (x0.Value, riskFreeTS.Value, blackVolTS.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _BlackScholesProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _BlackScholesProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _BlackScholesProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _BlackScholesProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _BlackScholesProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _BlackScholesProcess.Value.update()
                                                                     _BlackScholesProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _BlackScholesProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _BlackScholesProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _BlackScholesProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _BlackScholesProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.registerWith(handler.Value)
                                                                     _BlackScholesProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackScholesProcess.Value.unregisterWith(handler.Value)
                                                                     _BlackScholesProcess.Value)
    do this.Bind(_BlackScholesProcess)
(* 
    casting 
*)
    internal new () = BlackScholesProcessModel1(null,null,null)
    member internal this.Inject v = _BlackScholesProcess.Value <- v
    static member Cast (p : ICell<BlackScholesProcess>) = 
        if p :? BlackScholesProcessModel1 then 
            p :?> BlackScholesProcessModel1
        else
            let o = new BlackScholesProcessModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.blackVolTS                         = _blackVolTS 
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
