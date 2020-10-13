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
  Unit Displaced Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationBachelierCapFloorEngineModel
    ( index                                        : ICell<YoYInflationIndex>
    , vol                                          : ICell<Handle<YoYOptionletVolatilitySurface>>
    ) as this =

    inherit Model<YoYInflationBachelierCapFloorEngine> ()
(*
    Parameters
*)
    let _index                                     = index
    let _vol                                       = vol
(*
    Functions
*)
    let _YoYInflationBachelierCapFloorEngine       = cell (fun () -> new YoYInflationBachelierCapFloorEngine (index.Value, vol.Value))
    let _index                                     = triv (fun () -> _YoYInflationBachelierCapFloorEngine.Value.index())
    let _setVolatility                             (vol : ICell<Handle<YoYOptionletVolatilitySurface>>)   
                                                   = triv (fun () -> _YoYInflationBachelierCapFloorEngine.Value.setVolatility(vol.Value)
                                                                     _YoYInflationBachelierCapFloorEngine.Value)
    let _volatility                                = triv (fun () -> _YoYInflationBachelierCapFloorEngine.Value.volatility())
    do this.Bind(_YoYInflationBachelierCapFloorEngine)
(* 
    casting 
*)
    internal new () = new YoYInflationBachelierCapFloorEngineModel(null,null)
    member internal this.Inject v = _YoYInflationBachelierCapFloorEngine.Value <- v
    static member Cast (p : ICell<YoYInflationBachelierCapFloorEngine>) = 
        if p :? YoYInflationBachelierCapFloorEngineModel then 
            p :?> YoYInflationBachelierCapFloorEngineModel
        else
            let o = new YoYInflationBachelierCapFloorEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.index                              = _index 
    member this.vol                                = _vol 
    member this.Index                              = _index
    member this.SetVolatility                      vol   
                                                   = _setVolatility vol 
    member this.Volatility                         = _volatility
