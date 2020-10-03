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
  This class describes a exponential correlation model  References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)

  </summary> *)
[<AutoSerializable(true)>]
type LmExponentialCorrelationModelModel
    ( size                                         : ICell<int>
    , rho                                          : ICell<double>
    ) as this =

    inherit Model<LmExponentialCorrelationModel> ()
(*
    Parameters
*)
    let _size                                      = size
    let _rho                                       = rho
(*
    Functions
*)
    let _LmExponentialCorrelationModel             = cell (fun () -> new LmExponentialCorrelationModel (size.Value, rho.Value))
    let _correlation                               (i : ICell<int>) (j : ICell<int>) (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExponentialCorrelationModel.Value.correlation(i.Value, j.Value, t.Value, x.Value))
    let _correlation1                              (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExponentialCorrelationModel.Value.correlation(t.Value, x.Value))
    let _isTimeIndependent                         = triv (fun () -> _LmExponentialCorrelationModel.Value.isTimeIndependent())
    let _pseudoSqrt                                (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LmExponentialCorrelationModel.Value.pseudoSqrt(t.Value, x.Value))
    let _factors                                   = triv (fun () -> _LmExponentialCorrelationModel.Value.factors())
    let _parameters                                = triv (fun () -> _LmExponentialCorrelationModel.Value.parameters())
    let _setParams                                 (arguments : ICell<Generic.List<Parameter>>)   
                                                   = triv (fun () -> _LmExponentialCorrelationModel.Value.setParams(arguments.Value)
                                                                     _LmExponentialCorrelationModel.Value)
    let _size                                      = triv (fun () -> _LmExponentialCorrelationModel.Value.size())
    do this.Bind(_LmExponentialCorrelationModel)
(* 
    casting 
*)
    internal new () = LmExponentialCorrelationModelModel(null,null)
    member internal this.Inject v = _LmExponentialCorrelationModel.Value <- v
    static member Cast (p : ICell<LmExponentialCorrelationModel>) = 
        if p :? LmExponentialCorrelationModelModel then 
            p :?> LmExponentialCorrelationModelModel
        else
            let o = new LmExponentialCorrelationModelModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.rho                                = _rho 
    member this.Correlation                        i j t x   
                                                   = _correlation i j t x 
    member this.Correlation1                       t x   
                                                   = _correlation1 t x 
    member this.IsTimeIndependent                  = _isTimeIndependent
    member this.PseudoSqrt                         t x   
                                                   = _pseudoSqrt t x 
    member this.Factors                            = _factors
    member this.Parameters                         = _parameters
    member this.SetParams                          arguments   
                                                   = _setParams arguments 
    member this.Size                               = _size
