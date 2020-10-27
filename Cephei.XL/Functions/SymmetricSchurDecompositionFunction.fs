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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  Given a real symmetric matrix S, the Schur decomposition finds the eigenvalues and eigenvectors of S. If D is the diagonal matrix formed by the eigenvalues and U the unitarian matrix of the eigenvectors we can write the Schur decomposition as S = U D U^T  where is the standard matrix product and  ^T  is the transpose operator. This class implements the Schur decomposition using the symmetric threshold Jacobi algorithm. For details on the different Jacobi transfomations see "Matrix computation," second edition, by Golub and Van Loan, The Johns Hopkins University Press  the correctness of the returned values is tested by checking their properties.
  </summary> *)
[<AutoSerializable(true)>]
module SymmetricSchurDecompositionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SymmetricSchurDecomposition_eigenvalues", Description="Create a SymmetricSchurDecomposition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SymmetricSchurDecomposition_eigenvalues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SymmetricSchurDecomposition",Description = "SymmetricSchurDecomposition")>] 
         symmetricschurdecomposition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SymmetricSchurDecomposition = Helper.toCell<SymmetricSchurDecomposition> symmetricschurdecomposition "SymmetricSchurDecomposition"  
                let builder (current : ICell) = withMnemonic mnemonic ((SymmetricSchurDecompositionModel.Cast _SymmetricSchurDecomposition.cell).Eigenvalues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SymmetricSchurDecomposition.source + ".Eigenvalues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SymmetricSchurDecomposition.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SymmetricSchurDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SymmetricSchurDecomposition_eigenvectors", Description="Create a SymmetricSchurDecomposition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SymmetricSchurDecomposition_eigenvectors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SymmetricSchurDecomposition",Description = "SymmetricSchurDecomposition")>] 
         symmetricschurdecomposition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SymmetricSchurDecomposition = Helper.toCell<SymmetricSchurDecomposition> symmetricschurdecomposition "SymmetricSchurDecomposition"  
                let builder (current : ICell) = withMnemonic mnemonic ((SymmetricSchurDecompositionModel.Cast _SymmetricSchurDecomposition.cell).Eigenvectors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_SymmetricSchurDecomposition.source + ".Eigenvectors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SymmetricSchurDecomposition.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SymmetricSchurDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \pre s must be symmetric
    *)
    [<ExcelFunction(Name="_SymmetricSchurDecomposition", Description="Create a SymmetricSchurDecomposition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SymmetricSchurDecomposition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="s",Description = "Matrix")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _s = Helper.toCell<Matrix> s "s" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SymmetricSchurDecomposition 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SymmetricSchurDecomposition>) l

                let source () = Helper.sourceFold "Fun.SymmetricSchurDecomposition" 
                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _s.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SymmetricSchurDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SymmetricSchurDecomposition_Range", Description="Create a range of SymmetricSchurDecomposition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SymmetricSchurDecomposition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SymmetricSchurDecomposition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SymmetricSchurDecomposition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SymmetricSchurDecomposition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SymmetricSchurDecomposition>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
