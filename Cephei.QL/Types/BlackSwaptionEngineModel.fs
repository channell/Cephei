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
type BlackSwaptionEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<SwaptionVolatilityStructure>>
    , displacement                                 : ICell<Nullable<double>>
    , model                                        : ICell<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel>
    ) as this =

    inherit Model<BlackSwaptionEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _displacement                              = displacement
    let _model                                     = model
(*
    Functions
*)
    let _BlackSwaptionEngine                       = cell (fun () -> new BlackSwaptionEngine (discountCurve.Value, vol.Value, displacement.Value, model.Value))
    let _termStructure                             = triv (fun () -> _BlackSwaptionEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackSwaptionEngine.Value.volatility())
    do this.Bind(_BlackSwaptionEngine)
(* 
    casting 
*)
    internal new () = BlackSwaptionEngineModel(null,null,null,null)
    member internal this.Inject v = _BlackSwaptionEngine.Value <- v
    static member Cast (p : ICell<BlackSwaptionEngine>) = 
        if p :? BlackSwaptionEngineModel then 
            p :?> BlackSwaptionEngineModel
        else
            let o = new BlackSwaptionEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.displacement                       = _displacement 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BlackSwaptionEngineModel1
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , displacement                                 : ICell<Nullable<double>>
    , model                                        : ICell<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel>
    ) as this =

    inherit Model<BlackSwaptionEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _displacement                              = displacement
    let _model                                     = model
(*
    Functions
*)
    let _BlackSwaptionEngine                       = cell (fun () -> new BlackSwaptionEngine (discountCurve.Value, vol.Value, dc.Value, displacement.Value, model.Value))
    let _termStructure                             = triv (fun () -> _BlackSwaptionEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackSwaptionEngine.Value.volatility())
    do this.Bind(_BlackSwaptionEngine)
(* 
    casting 
*)
    internal new () = BlackSwaptionEngineModel1(null,null,null,null,null)
    member internal this.Inject v = _BlackSwaptionEngine.Value <- v
    static member Cast (p : ICell<BlackSwaptionEngine>) = 
        if p :? BlackSwaptionEngineModel1 then 
            p :?> BlackSwaptionEngineModel1
        else
            let o = new BlackSwaptionEngineModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.displacement                       = _displacement 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BlackSwaptionEngineModel2
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , displacement                                 : ICell<Nullable<double>>
    , model                                        : ICell<BlackStyleSwaptionEngine<Black76Spec>.CashAnnuityModel>
    ) as this =

    inherit Model<BlackSwaptionEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _displacement                              = displacement
    let _model                                     = model
(*
    Functions
*)
    let _BlackSwaptionEngine                       = cell (fun () -> new BlackSwaptionEngine (discountCurve.Value, vol.Value, dc.Value, displacement.Value, model.Value))
    let _termStructure                             = triv (fun () -> _BlackSwaptionEngine.Value.termStructure())
    let _volatility                                = triv (fun () -> _BlackSwaptionEngine.Value.volatility())
    do this.Bind(_BlackSwaptionEngine)
(* 
    casting 
*)
    internal new () = BlackSwaptionEngineModel2(null,null,null,null,null)
    member internal this.Inject v = _BlackSwaptionEngine.Value <- v
    static member Cast (p : ICell<BlackSwaptionEngine>) = 
        if p :? BlackSwaptionEngineModel2 then 
            p :?> BlackSwaptionEngineModel2
        else
            let o = new BlackSwaptionEngineModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.displacement                       = _displacement 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
