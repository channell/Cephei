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
type LiborForwardModelProcessModel
    ( size                                         : ICell<int>
    , index                                        : ICell<IborIndex>
    , disc                                         : ICell<IDiscretization>
    ) as this =

    inherit Model<LiborForwardModelProcess> ()
(*
    Parameters
*)
    let _size                                      = size
    let _index                                     = index
    let _disc                                      = disc
(*
    Functions
*)
    let _LiborForwardModelProcess                  = cell (fun () -> new LiborForwardModelProcess (size.Value, index.Value, disc.Value))
    let _accrualEndTimes                           = triv (fun () -> _LiborForwardModelProcess.Value.accrualEndTimes())
    let _accrualPeriod_                            = triv (fun () -> _LiborForwardModelProcess.Value.accrualPeriod_)
    let _accrualStartTimes                         = triv (fun () -> _LiborForwardModelProcess.Value.accrualStartTimes())
    let _accrualStartTimes_                        = triv (fun () -> _LiborForwardModelProcess.Value.accrualStartTimes_)
    let _apply                                     (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.apply(x0.Value, dx.Value))
    let _cashFlows                                 (amount : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.cashFlows(amount.Value))
    let _cashFlows1                                = triv (fun () -> _LiborForwardModelProcess.Value.cashFlows())
    let _covariance                                (t : ICell<double>) (x : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.covariance(t.Value, x.Value, dt.Value))
    let _covarParam                                = triv (fun () -> _LiborForwardModelProcess.Value.covarParam())
    let _diffusion                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.diffusion(t.Value, x.Value))
    let _discountBond                              (rates : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.discountBond(rates.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _factors                                   = triv (fun () -> _LiborForwardModelProcess.Value.factors())
    let _fixingDates                               = triv (fun () -> _LiborForwardModelProcess.Value.fixingDates())
    let _fixingDates_                              = triv (fun () -> _LiborForwardModelProcess.Value.fixingDates_)
    let _fixingTimes                               = triv (fun () -> _LiborForwardModelProcess.Value.fixingTimes())
    let _fixingTimes_                              = triv (fun () -> _LiborForwardModelProcess.Value.fixingTimes_)
    let _index                                     = triv (fun () -> _LiborForwardModelProcess.Value.index())
    let _index_                                    = triv (fun () -> _LiborForwardModelProcess.Value.index_)
    let _initialValues                             = triv (fun () -> _LiborForwardModelProcess.Value.initialValues())
    let _initialValues_                            = triv (fun () -> _LiborForwardModelProcess.Value.initialValues_)
    let _lfmParam_                                 = triv (fun () -> _LiborForwardModelProcess.Value.lfmParam_)
    let _nextIndexReset                            (t : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.nextIndexReset(t.Value))
    let _setCovarParam                             (param : ICell<LfmCovarianceParameterization>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.setCovarParam(param.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _size                                      = triv (fun () -> _LiborForwardModelProcess.Value.size())
    let _size_                                     = triv (fun () -> _LiborForwardModelProcess.Value.size_)
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.registerWith(handler.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.unregisterWith(handler.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _update                                    = triv (fun () -> _LiborForwardModelProcess.Value.update()
                                                                     _LiborForwardModelProcess.Value)
    do this.Bind(_LiborForwardModelProcess)
(* 
    casting 
*)
    internal new () = new LiborForwardModelProcessModel(null,null,null)
    member internal this.Inject v = _LiborForwardModelProcess.Value <- v
    static member Cast (p : ICell<LiborForwardModelProcess>) = 
        if p :? LiborForwardModelProcessModel then 
            p :?> LiborForwardModelProcessModel
        else
            let o = new LiborForwardModelProcessModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.index                              = _index 
    member this.disc                               = _disc 
    member this.AccrualEndTimes                    = _accrualEndTimes
    member this.AccrualPeriod_                     = _accrualPeriod_
    member this.AccrualStartTimes                  = _accrualStartTimes
    member this.AccrualStartTimes_                 = _accrualStartTimes_
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.CashFlows                          amount   
                                                   = _cashFlows amount 
    member this.CashFlows1                         = _cashFlows1
    member this.Covariance                         t x dt   
                                                   = _covariance t x dt 
    member this.CovarParam                         = _covarParam
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.DiscountBond                       rates   
                                                   = _discountBond rates 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Factors                            = _factors
    member this.FixingDates                        = _fixingDates
    member this.FixingDates_                       = _fixingDates_
    member this.FixingTimes                        = _fixingTimes
    member this.FixingTimes_                       = _fixingTimes_
    member this.Index                              = _index
    member this.Index_                             = _index_
    member this.InitialValues                      = _initialValues
    member this.InitialValues_                     = _initialValues_
    member this.LfmParam_                          = _lfmParam_
    member this.NextIndexReset                     t   
                                                   = _nextIndexReset t 
    member this.SetCovarParam                      param   
                                                   = _setCovarParam param 
    member this.Size                               = _size
    member this.Size_                              = _size_
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Time                               d   
                                                   = _time d 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type LiborForwardModelProcessModel1
    ( size                                         : ICell<int>
    , index                                        : ICell<IborIndex>
    ) as this =

    inherit Model<LiborForwardModelProcess> ()
(*
    Parameters
*)
    let _size                                      = size
    let _index                                     = index
(*
    Functions
*)
    let _LiborForwardModelProcess                  = cell (fun () -> new LiborForwardModelProcess (size.Value, index.Value))
    let _accrualEndTimes                           = triv (fun () -> _LiborForwardModelProcess.Value.accrualEndTimes())
    let _accrualPeriod_                            = triv (fun () -> _LiborForwardModelProcess.Value.accrualPeriod_)
    let _accrualStartTimes                         = triv (fun () -> _LiborForwardModelProcess.Value.accrualStartTimes())
    let _accrualStartTimes_                        = triv (fun () -> _LiborForwardModelProcess.Value.accrualStartTimes_)
    let _apply                                     (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.apply(x0.Value, dx.Value))
    let _cashFlows                                 (amount : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.cashFlows(amount.Value))
    let _cashFlows1                                = triv (fun () -> _LiborForwardModelProcess.Value.cashFlows())
    let _covariance                                (t : ICell<double>) (x : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.covariance(t.Value, x.Value, dt.Value))
    let _covarParam                                = triv (fun () -> _LiborForwardModelProcess.Value.covarParam())
    let _diffusion                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.diffusion(t.Value, x.Value))
    let _discountBond                              (rates : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.discountBond(rates.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _factors                                   = triv (fun () -> _LiborForwardModelProcess.Value.factors())
    let _fixingDates                               = triv (fun () -> _LiborForwardModelProcess.Value.fixingDates())
    let _fixingDates_                              = triv (fun () -> _LiborForwardModelProcess.Value.fixingDates_)
    let _fixingTimes                               = triv (fun () -> _LiborForwardModelProcess.Value.fixingTimes())
    let _fixingTimes_                              = triv (fun () -> _LiborForwardModelProcess.Value.fixingTimes_)
    let _index                                     = triv (fun () -> _LiborForwardModelProcess.Value.index())
    let _index_                                    = triv (fun () -> _LiborForwardModelProcess.Value.index_)
    let _initialValues                             = triv (fun () -> _LiborForwardModelProcess.Value.initialValues())
    let _initialValues_                            = triv (fun () -> _LiborForwardModelProcess.Value.initialValues_)
    let _lfmParam_                                 = triv (fun () -> _LiborForwardModelProcess.Value.lfmParam_)
    let _nextIndexReset                            (t : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.nextIndexReset(t.Value))
    let _setCovarParam                             (param : ICell<LfmCovarianceParameterization>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.setCovarParam(param.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _size                                      = triv (fun () -> _LiborForwardModelProcess.Value.size())
    let _size_                                     = triv (fun () -> _LiborForwardModelProcess.Value.size_)
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.registerWith(handler.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LiborForwardModelProcess.Value.unregisterWith(handler.Value)
                                                                     _LiborForwardModelProcess.Value)
    let _update                                    = triv (fun () -> _LiborForwardModelProcess.Value.update()
                                                                     _LiborForwardModelProcess.Value)
    do this.Bind(_LiborForwardModelProcess)
(* 
    casting 
*)
    internal new () = new LiborForwardModelProcessModel1(null,null)
    member internal this.Inject v = _LiborForwardModelProcess.Value <- v
    static member Cast (p : ICell<LiborForwardModelProcess>) = 
        if p :? LiborForwardModelProcessModel1 then 
            p :?> LiborForwardModelProcessModel1
        else
            let o = new LiborForwardModelProcessModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.index                              = _index 
    member this.AccrualEndTimes                    = _accrualEndTimes
    member this.AccrualPeriod_                     = _accrualPeriod_
    member this.AccrualStartTimes                  = _accrualStartTimes
    member this.AccrualStartTimes_                 = _accrualStartTimes_
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.CashFlows                          amount   
                                                   = _cashFlows amount 
    member this.CashFlows1                         = _cashFlows1
    member this.Covariance                         t x dt   
                                                   = _covariance t x dt 
    member this.CovarParam                         = _covarParam
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.DiscountBond                       rates   
                                                   = _discountBond rates 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Factors                            = _factors
    member this.FixingDates                        = _fixingDates
    member this.FixingDates_                       = _fixingDates_
    member this.FixingTimes                        = _fixingTimes
    member this.FixingTimes_                       = _fixingTimes_
    member this.Index                              = _index
    member this.Index_                             = _index_
    member this.InitialValues                      = _initialValues
    member this.InitialValues_                     = _initialValues_
    member this.LfmParam_                          = _lfmParam_
    member this.NextIndexReset                     t   
                                                   = _nextIndexReset t 
    member this.SetCovarParam                      param   
                                                   = _setCovarParam param 
    member this.Size                               = _size
    member this.Size_                              = _size_
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Time                               d   
                                                   = _time d 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
