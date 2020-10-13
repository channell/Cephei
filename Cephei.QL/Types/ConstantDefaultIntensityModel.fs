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
type ConstantDefaultIntensityModel
    ( constant                                     : ICell<double>
    , recovery                                     : ICell<double>
    ) as this =

    inherit Model<ConstantDefaultIntensity> ()
(*
    Parameters
*)
    let _constant                                  = constant
    let _recovery                                  = recovery
(*
    Functions
*)
    let _ConstantDefaultIntensity                  = cell (fun () -> new ConstantDefaultIntensity (constant.Value, recovery.Value))
    let _defaultRecovery                           (t : ICell<double>) (s : ICell<double>)   
                                                   = triv (fun () -> _ConstantDefaultIntensity.Value.defaultRecovery(t.Value, s.Value))
    let _hazardRate                                (t : ICell<double>) (s : ICell<double>)   
                                                   = triv (fun () -> _ConstantDefaultIntensity.Value.hazardRate(t.Value, s.Value))
    do this.Bind(_ConstantDefaultIntensity)
(* 
    casting 
*)
    internal new () = new ConstantDefaultIntensityModel(null,null)
    member internal this.Inject v = _ConstantDefaultIntensity.Value <- v
    static member Cast (p : ICell<ConstantDefaultIntensity>) = 
        if p :? ConstantDefaultIntensityModel then 
            p :?> ConstantDefaultIntensityModel
        else
            let o = new ConstantDefaultIntensityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.constant                           = _constant 
    member this.recovery                           = _recovery 
    member this.DefaultRecovery                    t s   
                                                   = _defaultRecovery t s 
    member this.HazardRate                         t s   
                                                   = _hazardRate t s 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ConstantDefaultIntensityModel1
    ( constant                                     : ICell<double>
    ) as this =

    inherit Model<ConstantDefaultIntensity> ()
(*
    Parameters
*)
    let _constant                                  = constant
(*
    Functions
*)
    let _ConstantDefaultIntensity                  = cell (fun () -> new ConstantDefaultIntensity (constant.Value))
    let _defaultRecovery                           (t : ICell<double>) (s : ICell<double>)   
                                                   = triv (fun () -> _ConstantDefaultIntensity.Value.defaultRecovery(t.Value, s.Value))
    let _hazardRate                                (t : ICell<double>) (s : ICell<double>)   
                                                   = triv (fun () -> _ConstantDefaultIntensity.Value.hazardRate(t.Value, s.Value))
    do this.Bind(_ConstantDefaultIntensity)
(* 
    casting 
*)
    internal new () = new ConstantDefaultIntensityModel1(null)
    member internal this.Inject v = _ConstantDefaultIntensity.Value <- v
    static member Cast (p : ICell<ConstantDefaultIntensity>) = 
        if p :? ConstantDefaultIntensityModel1 then 
            p :?> ConstantDefaultIntensityModel1
        else
            let o = new ConstantDefaultIntensityModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.constant                           = _constant 
    member this.DefaultRecovery                    t s   
                                                   = _defaultRecovery t s 
    member this.HazardRate                         t s   
                                                   = _hazardRate t s 
