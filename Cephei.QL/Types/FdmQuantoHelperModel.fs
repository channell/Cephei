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
type FdmQuantoHelperModel
    ( rTS                                          : ICell<YieldTermStructure>
    , fTS                                          : ICell<YieldTermStructure>
    , fxVolTS                                      : ICell<BlackVolTermStructure>
    , equityFxCorrelation                          : ICell<double>
    , exchRateATMlevel                             : ICell<double>
    ) as this =

    inherit Model<FdmQuantoHelper> ()
(*
    Parameters
*)
    let _rTS                                       = rTS
    let _fTS                                       = fTS
    let _fxVolTS                                   = fxVolTS
    let _equityFxCorrelation                       = equityFxCorrelation
    let _exchRateATMlevel                          = exchRateATMlevel
(*
    Functions
*)
    let _FdmQuantoHelper                           = cell (fun () -> new FdmQuantoHelper (rTS.Value, fTS.Value, fxVolTS.Value, equityFxCorrelation.Value, exchRateATMlevel.Value))
    let _equityFxCorrelation                       = triv (fun () -> _FdmQuantoHelper.Value.equityFxCorrelation())
    let _exchRateATMlevel                          = triv (fun () -> _FdmQuantoHelper.Value.exchRateATMlevel())
    let _foreignTermStructure                      = triv (fun () -> _FdmQuantoHelper.Value.foreignTermStructure())
    let _fxVolatilityTermStructure                 = triv (fun () -> _FdmQuantoHelper.Value.fxVolatilityTermStructure())
    let _quantoAdjustment                          (equityVol : ICell<double>) (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _FdmQuantoHelper.Value.quantoAdjustment(equityVol.Value, t1.Value, t2.Value))
    let _quantoAdjustment1                         (equityVol : ICell<Vector>) (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _FdmQuantoHelper.Value.quantoAdjustment(equityVol.Value, t1.Value, t2.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FdmQuantoHelper.Value.registerWith(handler.Value)
                                                                     _FdmQuantoHelper.Value)
    let _riskFreeTermStructure                     = triv (fun () -> _FdmQuantoHelper.Value.riskFreeTermStructure())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FdmQuantoHelper.Value.unregisterWith(handler.Value)
                                                                     _FdmQuantoHelper.Value)
    let _update                                    = triv (fun () -> _FdmQuantoHelper.Value.update()
                                                                     _FdmQuantoHelper.Value)
    do this.Bind(_FdmQuantoHelper)

(* 
    Externally visible/bindable properties
*)
    member this.rTS                                = _rTS 
    member this.fTS                                = _fTS 
    member this.fxVolTS                            = _fxVolTS 
    member this.equityFxCorrelation                = _equityFxCorrelation 
    member this.exchRateATMlevel                   = _exchRateATMlevel 
    member this.EquityFxCorrelation                = _equityFxCorrelation
    member this.ExchRateATMlevel                   = _exchRateATMlevel
    member this.ForeignTermStructure               = _foreignTermStructure
    member this.FxVolatilityTermStructure          = _fxVolatilityTermStructure
    member this.QuantoAdjustment                   equityVol t1 t2   
                                                   = _quantoAdjustment equityVol t1 t2 
    member this.QuantoAdjustment1                  equityVol t1 t2   
                                                   = _quantoAdjustment1 equityVol t1 t2 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.RiskFreeTermStructure              = _riskFreeTermStructure
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
