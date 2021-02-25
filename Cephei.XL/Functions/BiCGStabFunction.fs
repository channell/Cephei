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
    [<ExcelFunction(Name="_BiCGStab", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiCGStab_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="A",Description = "BiCGStab.MatrixMult")>] 
         A : obj)
        ([<ExcelArgument(Name="maxIter",Description = "int")>] 
         maxIter : obj)
        ([<ExcelArgument(Name="relTol",Description = "double")>] 
         relTol : obj)
        ([<ExcelArgument(Name="preConditioner",Description = "BiCGStab.MatrixMult or empty")>] 
         preConditioner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _A = Helper.toCell<BiCGStab.MatrixMult> A "A" 
                let _maxIter = Helper.toCell<int> maxIter "maxIter" 
                let _relTol = Helper.toCell<double> relTol "relTol" 
                let _preConditioner = Helper.toDefault<BiCGStab.MatrixMult> preConditioner "preConditioner" null
                let builder (current : ICell) = (Fun.BiCGStab 
                                                            _A.cell 
                                                            _maxIter.cell 
                                                            _relTol.cell 
                                                            _preConditioner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiCGStab>) l

                let source () = Helper.sourceFold "Fun.BiCGStab" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BiCGStab_MatrixMult", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiCGStab_MatrixMult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStab",Description = "BiCGStab")>] 
         bicgstab : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStab = Helper.toModelReference<BiCGStab> bicgstab "BiCGStab"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((BiCGStabModel.Cast _BiCGStab.cell).MatrixMult
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BiCGStab.source + ".MatrixMult") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStab.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_BiCGStab_solve", Description="Create a BiCGStab",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiCGStab_solve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BiCGStab",Description = "BiCGStab")>] 
         bicgstab : obj)
        ([<ExcelArgument(Name="b",Description = "Vector")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector or empty")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BiCGStab = Helper.toModelReference<BiCGStab> bicgstab "BiCGStab"  
                let _b = Helper.toCell<Vector> b "b" 
                let _x0 = Helper.toDefault<Vector> x0 "x0" null
                let builder (current : ICell) = ((BiCGStabModel.Cast _BiCGStab.cell).Solve
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BiCGStabResult>) l

                let source () = Helper.sourceFold (_BiCGStab.source + ".Solve") 

                                               [| _b.source
                                               ;  _x0.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BiCGStab.cell
                                ;  _b.cell
                                ;  _x0.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BiCGStab> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BiCGStab_Range", Description="Create a range of BiCGStab",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BiCGStab_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BiCGStab> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BiCGStab> (c)) :> ICell
                let format (i : Cephei.Cell.List<BiCGStab>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BiCGStab>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
