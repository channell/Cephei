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
  References:  Wilkinson, J.H. and Reinsch, C. 1971, Linear Algebra, vol. II of Handbook for Automatic Computation (New York: Springer-Verlag)  "Numerical Recipes in C", 2nd edition, Press, Teukolsky, Vetterling, Flannery,  the correctness of the result is tested by checking it against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type TqrEigenDecompositionModel
    ( diag                                         : ICell<Vector>
    , sub                                          : ICell<Vector>
    , calc                                         : ICell<TqrEigenDecomposition.EigenVectorCalculation>
    , strategy                                     : ICell<TqrEigenDecomposition.ShiftStrategy>
    ) as this =

    inherit Model<TqrEigenDecomposition> ()
(*
    Parameters
*)
    let _diag                                      = diag
    let _sub                                       = sub
    let _calc                                      = calc
    let _strategy                                  = strategy
(*
    Functions
*)
    let _TqrEigenDecomposition                     = cell (fun () -> new TqrEigenDecomposition (diag.Value, sub.Value, calc.Value, strategy.Value))
    let _eigenvalues                               = triv (fun () -> _TqrEigenDecomposition.Value.eigenvalues())
    let _eigenvectors                              = triv (fun () -> _TqrEigenDecomposition.Value.eigenvectors())
    let _iterations                                = triv (fun () -> _TqrEigenDecomposition.Value.iterations())
    do this.Bind(_TqrEigenDecomposition)

(* 
    Externally visible/bindable properties
*)
    member this.diag                               = _diag 
    member this.sub                                = _sub 
    member this.calc                               = _calc 
    member this.strategy                           = _strategy 
    member this.Eigenvalues                        = _eigenvalues
    member this.Eigenvectors                       = _eigenvectors
    member this.Iterations                         = _iterations
