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

  </summary> *)
[<AutoSerializable(true)>]
module BiCGStabFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BiCGStab", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStab_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="A",Description = "Reference to A")>] 
         A : obj)
        ([<ExcelArgument(Name="maxIter",Description = "Reference to maxIter")>] 
         maxIter : obj)
        ([<ExcelArgument(Name="relTol",Description = "Reference to relTol")>] 
         relTol : obj)
        ([<ExcelArgument(Name="preConditioner",Description = "Reference to preConditioner")>] 
         preConditioner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _A = Helper.toCell<BiCGStab.MatrixMult> A "A" 
                let _maxIter = Helper.toCell<int> maxIter "maxIter" 
                let _relTol = Helper.toCell<double> relTol "relTol" 
                let _preConditioner = Helper.toCell<BiCGStab.MatrixMult> preConditioner "preConditioner" 
                let builder () = withMnemonic mnemonic (Fun.BiCGStab 
                                                            _A.cell 
                                                            _maxIter.cell 
                                                            _relTol.cell 
                                                            _preConditioner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiCGStab>) l

                let source = Helper.sourceFold "Fun.BiCGStab" 
                                               [| _A.source
                                               ;  _maxIter.source
                                               ;  _relTol.source
                                               ;  _preConditioner.source
                                               |]
                let hash = Helper.hashFold 
                                [| _A.cell
                                ;  _maxIter.cell
                                ;  _relTol.cell
                                ;  _preConditioner.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStab> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_BiCGStab_MatrixMult", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStab_MatrixMult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStab",Description = "Reference to BiCGStab")>] 
         bicgstab : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStab = Helper.toCell<BiCGStab> bicgstab "BiCGStab"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_BiCGStab.cell :?> BiCGStabModel).MatrixMult
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BiCGStab.source + ".MatrixMult") 
                                               [| _BiCGStab.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStab.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStab> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_BiCGStab_solve", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStab_solve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStab",Description = "Reference to BiCGStab")>] 
         bicgstab : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStab = Helper.toCell<BiCGStab> bicgstab "BiCGStab"  
                let _b = Helper.toCell<Vector> b "b" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let builder () = withMnemonic mnemonic ((_BiCGStab.cell :?> BiCGStabModel).Solve
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiCGStabResult>) l

                let source = Helper.sourceFold (_BiCGStab.source + ".Solve") 
                                               [| _BiCGStab.source
                                               ;  _b.source
                                               ;  _x0.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStab.cell
                                ;  _b.cell
                                ;  _x0.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStab> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BiCGStab_Range", Description="Create a range of BiCGStab",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BiCGStab_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BiCGStab")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BiCGStab> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BiCGStab>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BiCGStab>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BiCGStab>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
