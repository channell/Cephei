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
  This class implements a three factor Heston Hull-White model  This class was not tested enough to guarantee its functionality... work in progress  processes

  </summary> *)
[<AutoSerializable(true)>]
type HybridHestonHullWhiteProcessModel
    ( hestonProcess                                : ICell<HestonProcess>
    , hullWhiteProcess                             : ICell<HullWhiteForwardProcess>
    , corrEquityShortRate                          : ICell<double>
    , discretization                               : ICell<HybridHestonHullWhiteProcess.Discretization>
    ) as this =

    inherit Model<HybridHestonHullWhiteProcess> ()
(*
    Parameters
*)
    let _hestonProcess                             = hestonProcess
    let _hullWhiteProcess                          = hullWhiteProcess
    let _corrEquityShortRate                       = corrEquityShortRate
    let _discretization                            = discretization
(*
    Functions
*)
    let mutable
        _HybridHestonHullWhiteProcess              = cell (fun () -> new HybridHestonHullWhiteProcess (hestonProcess.Value, hullWhiteProcess.Value, corrEquityShortRate.Value, discretization.Value))
    let _apply                                     (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.apply(x0.Value, dx.Value))
    let _diffusion                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.diffusion(t.Value, x.Value))
    let _discretization                            = triv (fun () -> _HybridHestonHullWhiteProcess.Value.discretization())
    let _drift                                     (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.drift(t.Value, x.Value))
    let _eta                                       = triv (fun () -> _HybridHestonHullWhiteProcess.Value.eta())
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _hestonProcess                             = triv (fun () -> _HybridHestonHullWhiteProcess.Value.hestonProcess())
    let _hullWhiteProcess                          = triv (fun () -> _HybridHestonHullWhiteProcess.Value.hullWhiteProcess())
    let _initialValues                             = triv (fun () -> _HybridHestonHullWhiteProcess.Value.initialValues())
    let _numeraire                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.numeraire(t.Value, x.Value))
    let _size                                      = triv (fun () -> _HybridHestonHullWhiteProcess.Value.size())
    let _time                                      (date : ICell<Date>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.time(date.Value))
    let _update                                    = triv (fun () -> _HybridHestonHullWhiteProcess.Value.update()
                                                                     _HybridHestonHullWhiteProcess.Value)
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.registerWith(handler.Value)
                                                                     _HybridHestonHullWhiteProcess.Value)
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HybridHestonHullWhiteProcess.Value.unregisterWith(handler.Value)
                                                                     _HybridHestonHullWhiteProcess.Value)
    do this.Bind(_HybridHestonHullWhiteProcess)
(* 
    casting 
*)
    internal new () = new HybridHestonHullWhiteProcessModel(null,null,null,null)
    member internal this.Inject v = _HybridHestonHullWhiteProcess <- v
    static member Cast (p : ICell<HybridHestonHullWhiteProcess>) = 
        if p :? HybridHestonHullWhiteProcessModel then 
            p :?> HybridHestonHullWhiteProcessModel
        else
            let o = new HybridHestonHullWhiteProcessModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.hestonProcess                      = _hestonProcess 
    member this.hullWhiteProcess                   = _hullWhiteProcess 
    member this.corrEquityShortRate                = _corrEquityShortRate 
    member this.discretization                     = _discretization 
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.Discretization                     = _discretization
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Eta                                = _eta
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.HestonProcess                      = _hestonProcess
    member this.HullWhiteProcess                   = _hullWhiteProcess
    member this.InitialValues                      = _initialValues
    member this.Numeraire                          t x   
                                                   = _numeraire t x 
    member this.Size                               = _size
    member this.Time                               date   
                                                   = _time date 
    member this.Update                             = _update
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.Factors                            = _factors
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
