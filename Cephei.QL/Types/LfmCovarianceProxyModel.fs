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
type LfmCovarianceProxyModel
    ( volaModel                                    : ICell<LmVolatilityModel>
    , corrModel                                    : ICell<LmCorrelationModel>
    ) as this =

    inherit Model<LfmCovarianceProxy> ()
(*
    Parameters
*)
    let _volaModel                                 = volaModel
    let _corrModel                                 = corrModel
(*
    Functions
*)
    let _LfmCovarianceProxy                        = cell (fun () -> new LfmCovarianceProxy (volaModel.Value, corrModel.Value))
    let _correlationModel                          = cell (fun () -> _LfmCovarianceProxy.Value.correlationModel())
    let _corrModel                                 = cell (fun () -> _LfmCovarianceProxy.Value.corrModel)
    let _corrModel_                                = cell (fun () -> _LfmCovarianceProxy.Value.corrModel_)
    let _covariance                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LfmCovarianceProxy.Value.covariance(t.Value, x.Value))
    let _diffusion                                 (t : ICell<double>)   
                                                   = cell (fun () -> _LfmCovarianceProxy.Value.diffusion(t.Value))
    let _diffusion1                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LfmCovarianceProxy.Value.diffusion(t.Value, x.Value))
    let _integratedCovariance                      (i : ICell<int>) (j : ICell<int>) (t : ICell<double>)   
                                                   = cell (fun () -> _LfmCovarianceProxy.Value.integratedCovariance(i.Value, j.Value, t.Value))
    let _integratedCovariance1                     (i : ICell<int>) (j : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LfmCovarianceProxy.Value.integratedCovariance(i.Value, j.Value, t.Value, x.Value))
    let _volaModel                                 = cell (fun () -> _LfmCovarianceProxy.Value.volaModel)
    let _volaModel_                                = cell (fun () -> _LfmCovarianceProxy.Value.volaModel_)
    let _volatilityModel                           = cell (fun () -> _LfmCovarianceProxy.Value.volatilityModel())
    let _factors                                   = cell (fun () -> _LfmCovarianceProxy.Value.factors())
    let _size                                      = cell (fun () -> _LfmCovarianceProxy.Value.size())
    do this.Bind(_LfmCovarianceProxy)

(* 
    Externally visible/bindable properties
*)
    member this.volaModel                          = _volaModel 
    member this.corrModel                          = _corrModel 
    member this.CorrelationModel                   = _correlationModel
    member this.CorrModel                          = _corrModel
    member this.CorrModel_                         = _corrModel_
    member this.Covariance                         t x   
                                                   = _covariance t x 
    member this.Diffusion                          t   
                                                   = _diffusion t 
    member this.Diffusion1                         t x   
                                                   = _diffusion1 t x 
    member this.IntegratedCovariance               i j t   
                                                   = _integratedCovariance i j t 
    member this.IntegratedCovariance1              i j t x   
                                                   = _integratedCovariance1 i j t x 
    member this.VolaModel                          = _volaModel
    member this.VolaModel_                         = _volaModel_
    member this.VolatilityModel                    = _volatilityModel
    member this.Factors                            = _factors
    member this.Size                               = _size
