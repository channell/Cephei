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
type LfmHullWhiteParameterizationModel
    ( Process                                      : ICell<LiborForwardModelProcess>
    , capletVol                                    : ICell<OptionletVolatilityStructure>
    , correlation                                  : ICell<Matrix>
    , factors                                      : ICell<int>
    ) as this =

    inherit Model<LfmHullWhiteParameterization> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _capletVol                                 = capletVol
    let _correlation                               = correlation
    let _factors                                   = factors
(*
    Functions
*)
    let mutable
        _LfmHullWhiteParameterization              = make (fun () -> new LfmHullWhiteParameterization (Process.Value, capletVol.Value, correlation.Value, factors.Value))
    let _covariance                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.covariance(t.Value, x.Value))
    let _covariance1                               (t : ICell<double>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.covariance(t.Value))
    let _diffusion                                 (t : ICell<double>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.diffusion(t.Value))
    let _diffusion1                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.diffusion(t.Value, x.Value))
    let _integratedCovariance                      (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.integratedCovariance(t.Value, x.Value))
    let _factors                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.factors())
    let _size                                      = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.size())
    do this.Bind(_LfmHullWhiteParameterization)
(* 
    casting 
*)
    internal new () = new LfmHullWhiteParameterizationModel(null,null,null,null)
    member internal this.Inject v = _LfmHullWhiteParameterization <- v
    static member Cast (p : ICell<LfmHullWhiteParameterization>) = 
        if p :? LfmHullWhiteParameterizationModel then 
            p :?> LfmHullWhiteParameterizationModel
        else
            let o = new LfmHullWhiteParameterizationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.capletVol                          = _capletVol 
    member this.correlation                        = _correlation 
    member this.factors                            = _factors 
    member this.Covariance                         t x   
                                                   = _covariance t x 
    member this.Covariance1                        t   
                                                   = _covariance1 t 
    member this.Diffusion                          t   
                                                   = _diffusion t 
    member this.Diffusion1                         t x   
                                                   = _diffusion1 t x 
    member this.IntegratedCovariance               t x   
                                                   = _integratedCovariance t x 
    member this.Factors                            = _factors
    member this.Size                               = _size
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type LfmHullWhiteParameterizationModel1
    ( Process                                      : ICell<LiborForwardModelProcess>
    , capletVol                                    : ICell<OptionletVolatilityStructure>
    ) as this =

    inherit Model<LfmHullWhiteParameterization> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _capletVol                                 = capletVol
(*
    Functions
*)
    let mutable
        _LfmHullWhiteParameterization              = make (fun () -> new LfmHullWhiteParameterization (Process.Value, capletVol.Value))
    let _covariance                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.covariance(t.Value, x.Value))
    let _covariance1                               (t : ICell<double>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.covariance(t.Value))
    let _diffusion                                 (t : ICell<double>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.diffusion(t.Value))
    let _diffusion1                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.diffusion(t.Value, x.Value))
    let _integratedCovariance                      (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.integratedCovariance(t.Value, x.Value))
    let _factors                                   = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.factors())
    let _size                                      = triv _LfmHullWhiteParameterization (fun () -> _LfmHullWhiteParameterization.Value.size())
    do this.Bind(_LfmHullWhiteParameterization)
(* 
    casting 
*)
    internal new () = new LfmHullWhiteParameterizationModel1(null,null)
    member internal this.Inject v = _LfmHullWhiteParameterization <- v
    static member Cast (p : ICell<LfmHullWhiteParameterization>) = 
        if p :? LfmHullWhiteParameterizationModel1 then 
            p :?> LfmHullWhiteParameterizationModel1
        else
            let o = new LfmHullWhiteParameterizationModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.capletVol                          = _capletVol 
    member this.Covariance                         t x   
                                                   = _covariance t x 
    member this.Covariance1                        t   
                                                   = _covariance1 t 
    member this.Diffusion                          t   
                                                   = _diffusion t 
    member this.Diffusion1                         t x   
                                                   = _diffusion1 t x 
    member this.IntegratedCovariance               t x   
                                                   = _integratedCovariance t x 
    member this.Factors                            = _factors
    member this.Size                               = _size
