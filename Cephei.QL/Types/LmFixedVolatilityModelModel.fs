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
type LmFixedVolatilityModelModel
    ( volatilities                                 : ICell<Vector>
    , startTimes                                   : ICell<Generic.List<double>>
    ) as this =

    inherit Model<LmFixedVolatilityModel> ()
(*
    Parameters
*)
    let _volatilities                              = volatilities
    let _startTimes                                = startTimes
(*
    Functions
*)
    let _LmFixedVolatilityModel                    = cell (fun () -> new LmFixedVolatilityModel (volatilities.Value, startTimes.Value))
    let _volatility                                (i : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmFixedVolatilityModel.Value.volatility(i.Value, t.Value, x.Value))
    let _volatility1                               (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmFixedVolatilityModel.Value.volatility(t.Value, x.Value))
    let _integratedVariance                        (i : ICell<int>) (j : ICell<int>) (u : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmFixedVolatilityModel.Value.integratedVariance(i.Value, j.Value, u.Value, x.Value))
    let _parameters                                = triv (fun () -> _LmFixedVolatilityModel.Value.parameters())
    let _setParams                                 (arguments : ICell<Generic.List<Parameter>>)   
                                                   = triv (fun () -> _LmFixedVolatilityModel.Value.setParams(arguments.Value)
                                                                     _LmFixedVolatilityModel.Value)
    let _size                                      = triv (fun () -> _LmFixedVolatilityModel.Value.size())
    do this.Bind(_LmFixedVolatilityModel)

(* 
    Externally visible/bindable properties
*)
    member this.volatilities                       = _volatilities 
    member this.startTimes                         = _startTimes 
    member this.Volatility                         i t x   
                                                   = _volatility i t x 
    member this.Volatility1                        t x   
                                                   = _volatility1 t x 
    member this.IntegratedVariance                 i j u x   
                                                   = _integratedVariance i j u x 
    member this.Parameters                         = _parameters
    member this.SetParams                          arguments   
                                                   = _setParams arguments 
    member this.Size                               = _size
