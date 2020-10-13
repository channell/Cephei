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
  This class describes an extended linear-exponential volatility model   References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)

  </summary> *)
[<AutoSerializable(true)>]
type LmExtLinearExponentialVolModelModel
    ( fixingTimes                                  : ICell<Generic.List<double>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    ) as this =

    inherit Model<LmExtLinearExponentialVolModel> ()
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
    let _LmExtLinearExponentialVolModel            = cell (fun () -> new LmExtLinearExponentialVolModel (fixingTimes.Value, a.Value, b.Value, c.Value, d.Value))
    let _integratedVariance                        (i : ICell<int>) (j : ICell<int>) (u : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExtLinearExponentialVolModel.Value.integratedVariance(i.Value, j.Value, u.Value, x.Value))
    let _volatility                                (i : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExtLinearExponentialVolModel.Value.volatility(i.Value, t.Value, x.Value))
    let _volatility1                               (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExtLinearExponentialVolModel.Value.volatility(t.Value, x.Value))
    let _parameters                                = triv (fun () -> _LmExtLinearExponentialVolModel.Value.parameters())
    let _setParams                                 (arguments : ICell<Generic.List<Parameter>>)   
                                                   = triv (fun () -> _LmExtLinearExponentialVolModel.Value.setParams(arguments.Value)
                                                                     _LmExtLinearExponentialVolModel.Value)
    let _size                                      = triv (fun () -> _LmExtLinearExponentialVolModel.Value.size())
    do this.Bind(_LmExtLinearExponentialVolModel)
(* 
    casting 
*)
    internal new () = new LmExtLinearExponentialVolModelModel(null,null,null,null,null)
    member internal this.Inject v = _LmExtLinearExponentialVolModel.Value <- v
    static member Cast (p : ICell<LmExtLinearExponentialVolModel>) = 
        if p :? LmExtLinearExponentialVolModelModel then 
            p :?> LmExtLinearExponentialVolModelModel
        else
            let o = new LmExtLinearExponentialVolModelModel ()
            o.Inject p.Value
            o
                            

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
