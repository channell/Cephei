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
  References:  Wilkinson, J.H. and Reinsch, C. 1971, Linear Algebra, vol. II of Handbook for Automatic Computation (New York: Springer-Verlag)  "Numerical Recipes in C", 2nd edition, Press, Teukolsky, Vetterling, Flannery,  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module TqrEigenDecompositionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TqrEigenDecomposition_eigenvalues", Description="Create a TqrEigenDecomposition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TqrEigenDecomposition_eigenvalues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TqrEigenDecomposition",Description = "Reference to TqrEigenDecomposition")>] 
         tqreigendecomposition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TqrEigenDecomposition = Helper.toCell<TqrEigenDecomposition> tqreigendecomposition "TqrEigenDecomposition"  
                let builder () = withMnemonic mnemonic ((_TqrEigenDecomposition.cell :?> TqrEigenDecompositionModel).Eigenvalues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_TqrEigenDecomposition.source + ".Eigenvalues") 
                                               [| _TqrEigenDecomposition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TqrEigenDecomposition.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TqrEigenDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TqrEigenDecomposition_eigenvectors", Description="Create a TqrEigenDecomposition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TqrEigenDecomposition_eigenvectors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TqrEigenDecomposition",Description = "Reference to TqrEigenDecomposition")>] 
         tqreigendecomposition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TqrEigenDecomposition = Helper.toCell<TqrEigenDecomposition> tqreigendecomposition "TqrEigenDecomposition"  
                let builder () = withMnemonic mnemonic ((_TqrEigenDecomposition.cell :?> TqrEigenDecompositionModel).Eigenvectors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_TqrEigenDecomposition.source + ".Eigenvectors") 
                                               [| _TqrEigenDecomposition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TqrEigenDecomposition.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TqrEigenDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TqrEigenDecomposition_iterations", Description="Create a TqrEigenDecomposition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TqrEigenDecomposition_iterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TqrEigenDecomposition",Description = "Reference to TqrEigenDecomposition")>] 
         tqreigendecomposition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TqrEigenDecomposition = Helper.toCell<TqrEigenDecomposition> tqreigendecomposition "TqrEigenDecomposition"  
                let builder () = withMnemonic mnemonic ((_TqrEigenDecomposition.cell :?> TqrEigenDecompositionModel).Iterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_TqrEigenDecomposition.source + ".Iterations") 
                                               [| _TqrEigenDecomposition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TqrEigenDecomposition.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TqrEigenDecomposition", Description="Create a TqrEigenDecomposition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TqrEigenDecomposition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="diag",Description = "Reference to diag")>] 
         diag : obj)
        ([<ExcelArgument(Name="sub",Description = "Reference to sub")>] 
         sub : obj)
        ([<ExcelArgument(Name="calc",Description = "Reference to calc")>] 
         calc : obj)
        ([<ExcelArgument(Name="strategy",Description = "Reference to strategy")>] 
         strategy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _diag = Helper.toCell<Vector> diag "diag" 
                let _sub = Helper.toCell<Vector> sub "sub" 
                let _calc = Helper.toCell<TqrEigenDecomposition.EigenVectorCalculation> calc "calc" 
                let _strategy = Helper.toCell<TqrEigenDecomposition.ShiftStrategy> strategy "strategy" 
                let builder () = withMnemonic mnemonic (Fun.TqrEigenDecomposition 
                                                            _diag.cell 
                                                            _sub.cell 
                                                            _calc.cell 
                                                            _strategy.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TqrEigenDecomposition>) l

                let source = Helper.sourceFold "Fun.TqrEigenDecomposition" 
                                               [| _diag.source
                                               ;  _sub.source
                                               ;  _calc.source
                                               ;  _strategy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _diag.cell
                                ;  _sub.cell
                                ;  _calc.cell
                                ;  _strategy.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TqrEigenDecomposition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TqrEigenDecomposition_Range", Description="Create a range of TqrEigenDecomposition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TqrEigenDecomposition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TqrEigenDecomposition")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TqrEigenDecomposition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TqrEigenDecomposition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TqrEigenDecomposition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TqrEigenDecomposition>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
