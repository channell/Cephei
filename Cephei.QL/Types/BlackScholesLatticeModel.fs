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
this is just a wrapper for QL compatibility

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesLatticeModel<'T when 'T :> ITree>
    ( tree                                         : ICell<ITree>
    , riskFreeRate                                 : ICell<double>
    , End                                          : ICell<double>
    , steps                                        : ICell<int>
    ) as this =

    inherit Model<BlackScholesLattice<'T>> ()
(*
    Parameters
*)
    let _tree                                      = tree
    let _riskFreeRate                              = riskFreeRate
    let _End                                       = End
    let _steps                                     = steps
(*
    Functions
*)
    let _BlackScholesLattice                       = cell (fun () -> new BlackScholesLattice<'T> (tree.Value, riskFreeRate.Value, End.Value, steps.Value))
    do this.Bind(_BlackScholesLattice)

(* 
    Externally visible/bindable properties
*)
    member this.tree                               = _tree 
    member this.riskFreeRate                       = _riskFreeRate 
    member this.End                                = _End 
    member this.steps                              = _steps 
