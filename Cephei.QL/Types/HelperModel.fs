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
Private function used by solver to determine time-dependent parameter

  </summary> *)
[<AutoSerializable(true)>]
type HelperModel
    ( i                                            : ICell<int>
    , xMin                                         : ICell<double>
    , dx                                           : ICell<double>
    , discountBondPrice                            : ICell<double>
    , tree                                         : ICell<OneFactorModel.ShortRateTree>
    ) as this =

    inherit Model<Helper> ()
(*
    Parameters
*)
    let _i                                         = i
    let _xMin                                      = xMin
    let _dx                                        = dx
    let _discountBondPrice                         = discountBondPrice
    let _tree                                      = tree
(*
    Functions
*)
    let _Helper                                    = cell (fun () -> new Helper (i.Value, xMin.Value, dx.Value, discountBondPrice.Value, tree.Value))
    let _value                                     (theta : ICell<double>)   
                                                   = triv (fun () -> _Helper.Value.value(theta.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _Helper.Value.derivative(x.Value))
    do this.Bind(_Helper)

(* 
    Externally visible/bindable properties
*)
    member this.i                                  = _i 
    member this.xMin                               = _xMin 
    member this.dx                                 = _dx 
    member this.discountBondPrice                  = _discountBondPrice 
    member this.tree                               = _tree 
    member this.Value                              theta   
                                                   = _value theta 
    member this.Derivative                         x   
                                                   = _derivative x 
