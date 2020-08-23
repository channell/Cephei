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
  Given a real symmetric matrix S, the Schur decomposition finds the eigenvalues and eigenvectors of S. If D is the diagonal matrix formed by the eigenvalues and U the unitarian matrix of the eigenvectors we can write the Schur decomposition as S = U D U^T  where is the standard matrix product and  ^T  is the transpose operator. This class implements the Schur decomposition using the symmetric threshold Jacobi algorithm. For details on the different Jacobi transfomations see "Matrix computation," second edition, by Golub and Van Loan, The Johns Hopkins University Press  the correctness of the returned values is tested by checking their properties.
! \pre s must be symmetric
  </summary> *)
[<AutoSerializable(true)>]
type SymmetricSchurDecompositionModel
    ( s                                            : ICell<Matrix>
    ) as this =

    inherit Model<SymmetricSchurDecomposition> ()
(*
    Parameters
*)
    let _s                                         = s
(*
    Functions
*)
    let _SymmetricSchurDecomposition               = cell (fun () -> new SymmetricSchurDecomposition (s.Value))
    let _eigenvalues                               = triv (fun () -> _SymmetricSchurDecomposition.Value.eigenvalues())
    let _eigenvectors                              = triv (fun () -> _SymmetricSchurDecomposition.Value.eigenvectors())
    do this.Bind(_SymmetricSchurDecomposition)

(* 
    Externally visible/bindable properties
*)
    member this.s                                  = _s 
    member this.Eigenvalues                        = _eigenvalues
    member this.Eigenvectors                       = _eigenvectors
