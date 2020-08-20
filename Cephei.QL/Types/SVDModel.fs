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
  Refer to Golub and Van Loan: Matrix computation, The Johns Hopkins University Press  the correctness of the returned values is tested by checking their properties.

  </summary> *)
[<AutoSerializable(true)>]
type SVDModel
    ( M                                            : ICell<Matrix>
    ) as this =

    inherit Model<SVD> ()
(*
    Parameters
*)
    let _M                                         = M
(*
    Functions
*)
    let _SVD                                       = cell (fun () -> new SVD (M.Value))
    let _cond                                      = cell (fun () -> _SVD.Value.cond())
    let _norm2                                     = cell (fun () -> _SVD.Value.norm2())
    let _rank                                      = cell (fun () -> _SVD.Value.rank())
    let _S                                         = cell (fun () -> _SVD.Value.S())
    let _singularValues                            = cell (fun () -> _SVD.Value.singularValues())
    let _solveFor                                  (b : ICell<Vector>)   
                                                   = cell (fun () -> _SVD.Value.solveFor(b.Value))
    let _U                                         = cell (fun () -> _SVD.Value.U())
    let _V                                         = cell (fun () -> _SVD.Value.V())
    do this.Bind(_SVD)

(* 
    Externally visible/bindable properties
*)
    member this.M                                  = _M 
    member this.Cond                               = _cond
    member this.Norm2                              = _norm2
    member this.Rank                               = _rank
    member this.S                                  = _S
    member this.SingularValues                     = _singularValues
    member this.SolveFor                           b   
                                                   = _solveFor b 
    member this.U                                  = _U
    member this.V                                  = _V
