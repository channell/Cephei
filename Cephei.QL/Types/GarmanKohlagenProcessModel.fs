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
  This class describes the stochastic process for an exchange rate given by dS(t, S) = (r(t) - r_f(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type GarmanKohlagenProcessModel
    ( x0                                           : ICell<Handle<Quote>>
    , foreignRiskFreeTS                            : ICell<Handle<YieldTermStructure>>
    , domesticRiskFreeTS                           : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , localVolTS                                   : ICell<RelinkableHandle<LocalVolTermStructure>>
    , d                                            : ICell<IDiscretization1D>
    ) as this =

    inherit Model<GarmanKohlagenProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _foreignRiskFreeTS                         = foreignRiskFreeTS
    let _domesticRiskFreeTS                        = domesticRiskFreeTS
    let _blackVolTS                                = blackVolTS
    let _localVolTS                                = localVolTS
    let _d                                         = d
(*
    Functions
*)
    let _GarmanKohlagenProcess                     = cell (fun () -> new GarmanKohlagenProcess (x0.Value, foreignRiskFreeTS.Value, domesticRiskFreeTS.Value, blackVolTS.Value, localVolTS.Value, d.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _GarmanKohlagenProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _GarmanKohlagenProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _GarmanKohlagenProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _GarmanKohlagenProcess.Value.update()
                                                                     _GarmanKohlagenProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _GarmanKohlagenProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _GarmanKohlagenProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _GarmanKohlagenProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _GarmanKohlagenProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.registerWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.unregisterWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    do this.Bind(_GarmanKohlagenProcess)
(* 
    casting 
*)
    internal new () = GarmanKohlagenProcessModel(null,null,null,null,null,null)
    member internal this.Inject v = _GarmanKohlagenProcess.Value <- v
    static member Cast (p : ICell<GarmanKohlagenProcess>) = 
        if p :? GarmanKohlagenProcessModel then 
            p :?> GarmanKohlagenProcessModel
        else
            let o = new GarmanKohlagenProcessModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.foreignRiskFreeTS                  = _foreignRiskFreeTS 
    member this.domesticRiskFreeTS                 = _domesticRiskFreeTS 
    member this.blackVolTS                         = _blackVolTS 
    member this.localVolTS                         = _localVolTS 
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
  This class describes the stochastic process for an exchange rate given by dS(t, S) = (r(t) - r_f(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type GarmanKohlagenProcessModel1
    ( x0                                           : ICell<Handle<Quote>>
    , foreignRiskFreeTS                            : ICell<Handle<YieldTermStructure>>
    , domesticRiskFreeTS                           : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    , d                                            : ICell<IDiscretization1D>
    ) as this =

    inherit Model<GarmanKohlagenProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _foreignRiskFreeTS                         = foreignRiskFreeTS
    let _domesticRiskFreeTS                        = domesticRiskFreeTS
    let _blackVolTS                                = blackVolTS
    let _d                                         = d
(*
    Functions
*)
    let _GarmanKohlagenProcess                     = cell (fun () -> new GarmanKohlagenProcess (x0.Value, foreignRiskFreeTS.Value, domesticRiskFreeTS.Value, blackVolTS.Value, d.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _GarmanKohlagenProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _GarmanKohlagenProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _GarmanKohlagenProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _GarmanKohlagenProcess.Value.update()
                                                                     _GarmanKohlagenProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _GarmanKohlagenProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _GarmanKohlagenProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _GarmanKohlagenProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _GarmanKohlagenProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.registerWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.unregisterWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    do this.Bind(_GarmanKohlagenProcess)
(* 
    casting 
*)
    internal new () = GarmanKohlagenProcessModel1(null,null,null,null,null)
    member internal this.Inject v = _GarmanKohlagenProcess.Value <- v
    static member Cast (p : ICell<GarmanKohlagenProcess>) = 
        if p :? GarmanKohlagenProcessModel1 then 
            p :?> GarmanKohlagenProcessModel1
        else
            let o = new GarmanKohlagenProcessModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.foreignRiskFreeTS                  = _foreignRiskFreeTS 
    member this.domesticRiskFreeTS                 = _domesticRiskFreeTS 
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
  This class describes the stochastic process for an exchange rate given by dS(t, S) = (r(t) - r_f(t) - S)^2}{2}) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type GarmanKohlagenProcessModel2
    ( x0                                           : ICell<Handle<Quote>>
    , foreignRiskFreeTS                            : ICell<Handle<YieldTermStructure>>
    , domesticRiskFreeTS                           : ICell<Handle<YieldTermStructure>>
    , blackVolTS                                   : ICell<Handle<BlackVolTermStructure>>
    ) as this =

    inherit Model<GarmanKohlagenProcess> ()
(*
    Parameters
*)
    let _x0                                        = x0
    let _foreignRiskFreeTS                         = foreignRiskFreeTS
    let _domesticRiskFreeTS                        = domesticRiskFreeTS
    let _blackVolTS                                = blackVolTS
(*
    Functions
*)
    let _GarmanKohlagenProcess                     = cell (fun () -> new GarmanKohlagenProcess (x0.Value, foreignRiskFreeTS.Value, domesticRiskFreeTS.Value, blackVolTS.Value))
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.apply(x0.Value, dx.Value))
    let _blackVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.blackVolatility())
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _GarmanKohlagenProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _localVolatility                           = triv (fun () -> _GarmanKohlagenProcess.Value.localVolatility())
    let _riskFreeRate                              = triv (fun () -> _GarmanKohlagenProcess.Value.riskFreeRate())
    let _stateVariable                             = triv (fun () -> _GarmanKohlagenProcess.Value.stateVariable())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.time(d.Value))
    let _update                                    = triv (fun () -> _GarmanKohlagenProcess.Value.update()
                                                                     _GarmanKohlagenProcess.Value)
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _GarmanKohlagenProcess.Value.x0())
    let _initialValues                             = triv (fun () -> _GarmanKohlagenProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _GarmanKohlagenProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _GarmanKohlagenProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.registerWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _GarmanKohlagenProcess.Value.unregisterWith(handler.Value)
                                                                     _GarmanKohlagenProcess.Value)
    do this.Bind(_GarmanKohlagenProcess)
(* 
    casting 
*)
    internal new () = GarmanKohlagenProcessModel2(null,null,null,null)
    member internal this.Inject v = _GarmanKohlagenProcess.Value <- v
    static member Cast (p : ICell<GarmanKohlagenProcess>) = 
        if p :? GarmanKohlagenProcessModel2 then 
            p :?> GarmanKohlagenProcessModel2
        else
            let o = new GarmanKohlagenProcessModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x0                                 = _x0 
    member this.foreignRiskFreeTS                  = _foreignRiskFreeTS 
    member this.domesticRiskFreeTS                 = _domesticRiskFreeTS 
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
