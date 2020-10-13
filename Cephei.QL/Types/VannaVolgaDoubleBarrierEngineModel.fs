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
type VannaVolgaDoubleBarrierEngineModel
    ( atmVol                                       : ICell<Handle<DeltaVolQuote>>
    , vol25Put                                     : ICell<Handle<DeltaVolQuote>>
    , vol25Call                                    : ICell<Handle<DeltaVolQuote>>
    , spotFX                                       : ICell<Handle<Quote>>
    , domesticTS                                   : ICell<Handle<YieldTermStructure>>
    , foreignTS                                    : ICell<Handle<YieldTermStructure>>
    , getEngine                                    : ICell<VannaVolgaDoubleBarrierEngine.GetOriginalEngine>
    , adaptVanDelta                                : ICell<bool>
    , bsPriceWithSmile                             : ICell<double>
    , series                                       : ICell<int>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<VannaVolgaDoubleBarrierEngine> ()
(*
    Parameters
*)
    let _atmVol                                    = atmVol
    let _vol25Put                                  = vol25Put
    let _vol25Call                                 = vol25Call
    let _spotFX                                    = spotFX
    let _domesticTS                                = domesticTS
    let _foreignTS                                 = foreignTS
    let _getEngine                                 = getEngine
    let _adaptVanDelta                             = adaptVanDelta
    let _bsPriceWithSmile                          = bsPriceWithSmile
    let _series                                    = series
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _VannaVolgaDoubleBarrierEngine             = cell (fun () -> new VannaVolgaDoubleBarrierEngine (atmVol.Value, vol25Put.Value, vol25Call.Value, spotFX.Value, domesticTS.Value, foreignTS.Value, getEngine.Value, adaptVanDelta.Value, bsPriceWithSmile.Value, series.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _VannaVolgaDoubleBarrierEngine.Value.registerWith(handler.Value)
                                                                     _VannaVolgaDoubleBarrierEngine.Value)
    let _reset                                     = triv (fun () -> _VannaVolgaDoubleBarrierEngine.Value.reset()
                                                                     _VannaVolgaDoubleBarrierEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _VannaVolgaDoubleBarrierEngine.Value.unregisterWith(handler.Value)
                                                                     _VannaVolgaDoubleBarrierEngine.Value)
    let _update                                    = triv (fun () -> _VannaVolgaDoubleBarrierEngine.Value.update()
                                                                     _VannaVolgaDoubleBarrierEngine.Value)
    do this.Bind(_VannaVolgaDoubleBarrierEngine)
(* 
    casting 
*)
    internal new () = new VannaVolgaDoubleBarrierEngineModel(null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _VannaVolgaDoubleBarrierEngine.Value <- v
    static member Cast (p : ICell<VannaVolgaDoubleBarrierEngine>) = 
        if p :? VannaVolgaDoubleBarrierEngineModel then 
            p :?> VannaVolgaDoubleBarrierEngineModel
        else
            let o = new VannaVolgaDoubleBarrierEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.atmVol                             = _atmVol 
    member this.vol25Put                           = _vol25Put 
    member this.vol25Call                          = _vol25Call 
    member this.spotFX                             = _spotFX 
    member this.domesticTS                         = _domesticTS 
    member this.foreignTS                          = _foreignTS 
    member this.getEngine                          = _getEngine 
    member this.adaptVanDelta                      = _adaptVanDelta 
    member this.bsPriceWithSmile                   = _bsPriceWithSmile 
    member this.series                             = _series 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
