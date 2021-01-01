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
type NegativePowerDefaultIntensityModel
    ( alpha                                        : ICell<double>
    , p                                            : ICell<double>
    ) as this =

    inherit Model<NegativePowerDefaultIntensity> ()
(*
    Parameters
*)
    let _alpha                                     = alpha
    let _p                                         = p
(*
    Functions
*)
    let mutable
        _NegativePowerDefaultIntensity             = make (fun () -> new NegativePowerDefaultIntensity (alpha.Value, p.Value))
    let _defaultRecovery                           (t : ICell<double>) (s : ICell<double>)   
                                                   = triv _NegativePowerDefaultIntensity (fun () -> _NegativePowerDefaultIntensity.Value.defaultRecovery(t.Value, s.Value))
    let _hazardRate                                (t : ICell<double>) (s : ICell<double>)   
                                                   = triv _NegativePowerDefaultIntensity (fun () -> _NegativePowerDefaultIntensity.Value.hazardRate(t.Value, s.Value))
    do this.Bind(_NegativePowerDefaultIntensity)
(* 
    casting 
*)
    internal new () = new NegativePowerDefaultIntensityModel(null,null)
    member internal this.Inject v = _NegativePowerDefaultIntensity <- v
    static member Cast (p : ICell<NegativePowerDefaultIntensity>) = 
        if p :? NegativePowerDefaultIntensityModel then 
            p :?> NegativePowerDefaultIntensityModel
        else
            let o = new NegativePowerDefaultIntensityModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.alpha                              = _alpha 
    member this.p                                  = _p 
    member this.DefaultRecovery                    t s   
                                                   = _defaultRecovery t s 
    member this.HazardRate                         t s   
                                                   = _hazardRate t s 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type NegativePowerDefaultIntensityModel1
    ( alpha                                        : ICell<double>
    , p                                            : ICell<double>
    , recovery                                     : ICell<double>
    ) as this =

    inherit Model<NegativePowerDefaultIntensity> ()
(*
    Parameters
*)
    let _alpha                                     = alpha
    let _p                                         = p
    let _recovery                                  = recovery
(*
    Functions
*)
    let mutable
        _NegativePowerDefaultIntensity             = make (fun () -> new NegativePowerDefaultIntensity (alpha.Value, p.Value, recovery.Value))
    let _defaultRecovery                           (t : ICell<double>) (s : ICell<double>)   
                                                   = triv _NegativePowerDefaultIntensity (fun () -> _NegativePowerDefaultIntensity.Value.defaultRecovery(t.Value, s.Value))
    let _hazardRate                                (t : ICell<double>) (s : ICell<double>)   
                                                   = triv _NegativePowerDefaultIntensity (fun () -> _NegativePowerDefaultIntensity.Value.hazardRate(t.Value, s.Value))
    do this.Bind(_NegativePowerDefaultIntensity)
(* 
    casting 
*)
    internal new () = new NegativePowerDefaultIntensityModel1(null,null,null)
    member internal this.Inject v = _NegativePowerDefaultIntensity <- v
    static member Cast (p : ICell<NegativePowerDefaultIntensity>) = 
        if p :? NegativePowerDefaultIntensityModel1 then 
            p :?> NegativePowerDefaultIntensityModel1
        else
            let o = new NegativePowerDefaultIntensityModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.alpha                              = _alpha 
    member this.p                                  = _p 
    member this.recovery                           = _recovery 
    member this.DefaultRecovery                    t s   
                                                   = _defaultRecovery t s 
    member this.HazardRate                         t s   
                                                   = _hazardRate t s 
