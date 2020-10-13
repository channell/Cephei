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
type BlackCapFloorEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , displacement                                 : ICell<double>
    ) as this =

    inherit Model<BlackCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _displacement                              = displacement
(*
    Functions
*)
    let _BlackCapFloorEngine                       = cell (fun () -> new BlackCapFloorEngine (discountCurve.Value, vol.Value, dc.Value, displacement.Value))
    let _displacement                              = triv (fun () -> _BlackCapFloorEngine.Value.displacement())
    let _termStructure                             = triv (fun () -> _BlackCapFloorEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackCapFloorEngine.Value.volatility())
    do this.Bind(_BlackCapFloorEngine)
(* 
    casting 
*)
    internal new () = new BlackCapFloorEngineModel(null,null,null,null)
    member internal this.Inject v = _BlackCapFloorEngine.Value <- v
    static member Cast (p : ICell<BlackCapFloorEngine>) = 
        if p :? BlackCapFloorEngineModel then 
            p :?> BlackCapFloorEngineModel
        else
            let o = new BlackCapFloorEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.displacement                       = _displacement 
    member this.Displacement                       = _displacement
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BlackCapFloorEngineModel1
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<OptionletVolatilityStructure>>
    , displacement                                 : ICell<double>
    ) as this =

    inherit Model<BlackCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _displacement                              = displacement
(*
    Functions
*)
    let _BlackCapFloorEngine                       = cell (fun () -> new BlackCapFloorEngine (discountCurve.Value, vol.Value, displacement.Value))
    let _displacement                              = triv (fun () -> _BlackCapFloorEngine.Value.displacement())
    let _termStructure                             = triv (fun () -> _BlackCapFloorEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackCapFloorEngine.Value.volatility())
    do this.Bind(_BlackCapFloorEngine)
(* 
    casting 
*)
    internal new () = new BlackCapFloorEngineModel1(null,null,null)
    member internal this.Inject v = _BlackCapFloorEngine.Value <- v
    static member Cast (p : ICell<BlackCapFloorEngine>) = 
        if p :? BlackCapFloorEngineModel1 then 
            p :?> BlackCapFloorEngineModel1
        else
            let o = new BlackCapFloorEngineModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.displacement                       = _displacement 
    member this.Displacement                       = _displacement
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BlackCapFloorEngineModel2
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , displacement                                 : ICell<double>
    ) as this =

    inherit Model<BlackCapFloorEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _displacement                              = displacement
(*
    Functions
*)
    let _BlackCapFloorEngine                       = cell (fun () -> new BlackCapFloorEngine (discountCurve.Value, vol.Value, dc.Value, displacement.Value))
    let _displacement                              = triv (fun () -> _BlackCapFloorEngine.Value.displacement())
    let _termStructure                             = triv (fun () -> _BlackCapFloorEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackCapFloorEngine.Value.volatility())
    do this.Bind(_BlackCapFloorEngine)
(* 
    casting 
*)
    internal new () = new BlackCapFloorEngineModel2(null,null,null,null)
    member internal this.Inject v = _BlackCapFloorEngine.Value <- v
    static member Cast (p : ICell<BlackCapFloorEngine>) = 
        if p :? BlackCapFloorEngineModel2 then 
            p :?> BlackCapFloorEngineModel2
        else
            let o = new BlackCapFloorEngineModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.displacement                       = _displacement 
    member this.Displacement                       = _displacement
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
