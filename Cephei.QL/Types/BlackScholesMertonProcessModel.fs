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
  This class describes the stochastic process for a stock or stock index paying a continuous dividend yield given by dS(t, S) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesMertonProcessModel
    ( x0                                           : ICell<Handle<Quote>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , d                                            : ICell<IDiscretization1D>
    ) as this =

    inherit Model<BlackScholesMertonProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _dividendTS                                = dividendTS
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
    let _d                                         = d
(*
    Functions
*)
    let mutable
        _BlackScholesMertonProcess                 = make (fun () -> new BlackScholesMertonProcess (x0.Value, dividendTS.Value, riskFreeTS.Value, blackVolTS.Value, d.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.localVolatility())
    let _riskFreeRate                              = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.riskFreeRate())
    let _stateVariable                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.time(d.Value))
    let _update                                    = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.update()
                                                                                                _BlackScholesMertonProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.x0())
    let _initialValues                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.initialValues())
    let _size                                      = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.registerWith(handler.Value)
                                                                                                _BlackScholesMertonProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.unregisterWith(handler.Value)
                                                                                                _BlackScholesMertonProcess.Value)
    do this.Bind(_BlackScholesMertonProcess)
(* 
    casting 
*)
    internal new () = new BlackScholesMertonProcessModel(null,null,null,null,null)
    member internal this.Inject v = _BlackScholesMertonProcess <- v
    static member Cast (p : ICell<BlackScholesMertonProcess>) = 
        if p :? BlackScholesMertonProcessModel then 
            p :?> BlackScholesMertonProcessModel
        else
            let o = new BlackScholesMertonProcessModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.dividendTS                         = _dividendTS 
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
  This class describes the stochastic process for a stock or stock index paying a continuous dividend yield given by dS(t, S) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesMertonProcessModel1
    ( x0                                           : ICell<Handle<Quote>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    ) as this =

    inherit Model<BlackScholesMertonProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _dividendTS                                = dividendTS
    let _riskFreeTS                                = riskFreeTS
    let _blackVolTS                                = blackVolTS
(*
    Functions
*)
    let mutable
        _BlackScholesMertonProcess                 = make (fun () -> new BlackScholesMertonProcess (x0.Value, dividendTS.Value, riskFreeTS.Value, blackVolTS.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.localVolatility())
    let _riskFreeRate                              = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.riskFreeRate())
    let _stateVariable                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.time(d.Value))
    let _update                                    = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.update()
                                                                                                _BlackScholesMertonProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.x0())
    let _initialValues                             = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.initialValues())
    let _size                                      = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.registerWith(handler.Value)
                                                                                                _BlackScholesMertonProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _BlackScholesMertonProcess (fun () -> _BlackScholesMertonProcess.Value.unregisterWith(handler.Value)
                                                                                                _BlackScholesMertonProcess.Value)
    do this.Bind(_BlackScholesMertonProcess)
(* 
    casting 
*)
    internal new () = new BlackScholesMertonProcessModel1(null,null,null,null)
    member internal this.Inject v = _BlackScholesMertonProcess <- v
    static member Cast (p : ICell<BlackScholesMertonProcess>) = 
        if p :? BlackScholesMertonProcessModel1 then 
            p :?> BlackScholesMertonProcessModel1
        else
            let o = new BlackScholesMertonProcessModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.dividendTS                         = _dividendTS 
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
