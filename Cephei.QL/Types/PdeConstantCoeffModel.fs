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
type PdeConstantCoeffModel<'PdeClass when 'PdeClass :> PdeSecondOrderParabolic and 'PdeClass : (new : unit -> 'PdeClass)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , t                                            : ICell<double>
    , x                                            : ICell<double>
    ) as this =

    inherit Model<PdeConstantCoeff<'PdeClass>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _t                                         = t
    let _x                                         = x
(*
    Functions
*)
    let mutable
        _PdeConstantCoeff                          = cell (fun () -> new PdeConstantCoeff<'PdeClass> (Process.Value, t.Value, x.Value))
    let _diffusion                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _PdeConstantCoeff.Value.diffusion(x.Value, y.Value))
    let _discount                                  (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _PdeConstantCoeff.Value.discount(x.Value, y.Value))
    let _drift                                     (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _PdeConstantCoeff.Value.drift(x.Value, y.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>)   
                                                   = triv (fun () -> _PdeConstantCoeff.Value.factory(Process.Value))
    let _generateOperator                          (t : ICell<double>) (tg : ICell<TransformedGrid>) (L : ICell<TridiagonalOperator>)   
                                                   = triv (fun () -> _PdeConstantCoeff.Value.generateOperator(t.Value, tg.Value, L.Value)
                                                                     _PdeConstantCoeff.Value)
    do this.Bind(_PdeConstantCoeff)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.t                                  = _t 
    member this.x                                  = _x 
    member this.Diffusion                          x y   
                                                   = _diffusion x y 
    member this.Discount                           x y   
                                                   = _discount x y 
    member this.Drift                              x y   
                                                   = _drift x y 
    member this.Factory                            Process   
                                                   = _factory Process 
    member this.GenerateOperator                   t tg L   
                                                   = _generateOperator t tg L 
