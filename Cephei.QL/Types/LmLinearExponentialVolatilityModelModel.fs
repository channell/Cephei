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
  This class describes a linear-exponential volatility model   References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)

  </summary> *)
[<AutoSerializable(true)>]
type LmLinearExponentialVolatilityModelModel
    ( fixingTimes                                  : ICell<Generic.List<double>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    ) as this =

    inherit Model<LmLinearExponentialVolatilityModel> ()
(*
    Parameters
*)
    let _fixingTimes                               = fixingTimes
    let _a                                         = a
    let _b                                         = b
    let _c                                         = c
    let _d                                         = d
(*
    Functions
*)
    let _LmLinearExponentialVolatilityModel        = cell (fun () -> new LmLinearExponentialVolatilityModel (fixingTimes.Value, a.Value, b.Value, c.Value, d.Value))
    let _integratedVariance                        (i : ICell<int>) (j : ICell<int>) (u : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.integratedVariance(i.Value, j.Value, u.Value, x.Value))
    let _volatility                                (i : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.volatility(i.Value, t.Value, x.Value))
    let _volatility1                               (t : ICell<double>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.volatility(t.Value, x.Value))
    let _parameters                                = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.parameters())
    let _setParams                                 (arguments : ICell<Generic.List<Parameter>>)   
                                                   = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.setParams(arguments.Value)
                                                                     _LmLinearExponentialVolatilityModel.Value)
    let _size                                      = cell (fun () -> _LmLinearExponentialVolatilityModel.Value.size())
    do this.Bind(_LmLinearExponentialVolatilityModel)

(* 
    Externally visible/bindable properties
*)
    member this.fixingTimes                        = _fixingTimes 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.IntegratedVariance                 i j u x   
                                                   = _integratedVariance i j u x 
    member this.Volatility                         i t x   
                                                   = _volatility i t x 
    member this.Volatility1                        t x   
                                                   = _volatility1 t x 
    member this.Parameters                         = _parameters
    member this.SetParams                          arguments   
                                                   = _setParams arguments 
    member this.Size                               = _size
