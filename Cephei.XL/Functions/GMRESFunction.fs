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
module GMRESFunction =

    (*
        
    *)
    (*!! ommited 
    [<ExcelFunction(Name="_GMRES", Description="Create a GMRES",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GMRES_create
        ([<ExcelArgument(Name="Mnemonic",Description = "GMRES")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="A",Description = "MatrixMult")>] 
         A : obj)
        ([<ExcelArgument(Name="maxIter",Description = "int")>] 
         maxIter : obj)
        ([<ExcelArgument(Name="relTol",Description = "double")>] 
         relTol : obj)
        ([<ExcelArgument(Name="preConditioner",Description = "GMRES")>] 
         preConditioner : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _A = Helper.toCell<MatrixMult> A "A" 
                let _maxIter = Helper.toCell<int> maxIter "maxIter" 
                let _relTol = Helper.toCell<double> relTol "relTol" 
                let _preConditioner = Helper.toDefault<MatrixMult> preConditioner "preConditioner" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GMRES 
                                                            _A.cell 
                                                            _maxIter.cell 
                                                            _relTol.cell 
                                                            _preConditioner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRES>) l

                let source () = Helper.sourceFold "Fun.GMRES" 
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
                    ; subscriber = Helper.subscriberModel<GMRES> format
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
    (*!! ommitted
    [<ExcelFunction(Name="_GMRES_MatrixMult", Description="Create a GMRES",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GMRES_MatrixMult
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES"  
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((GMRESModel.Cast _GMRES.cell).MatrixMult
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_GMRES.source + ".MatrixMult") 
                                               [| _GMRES.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRES.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GMRES> format
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
    [<ExcelFunction(Name="_GMRES_solve", Description="Create a GMRES",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GMRES_solve
        ([<ExcelArgument(Name="Mnemonic",Description = "GMRESResult")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="b",Description = "Vector")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "GMRESResult")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES"  
                let _b = Helper.toCell<Vector> b "b" 
                let _x0 = Helper.toDefault<Vector> x0 "x0" null
                let builder (current : ICell) = withMnemonic mnemonic ((GMRESModel.Cast _GMRES.cell).Solve
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRESResult>) l

                let source () = Helper.sourceFold (_GMRES.source + ".Solve") 
                                               [| _GMRES.source
                                               ;  _b.source
                                               ;  _x0.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRES.cell
                                ;  _b.cell
                                ;  _x0.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GMRES> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GMRES_solveWithRestart", Description="Create a GMRES",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GMRES_solveWithRestart
        ([<ExcelArgument(Name="Mnemonic",Description = "GMRESResult")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="restart",Description = "int")>] 
         restart : obj)
        ([<ExcelArgument(Name="b",Description = "Vector")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "GMRESResult")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES"  
                let _restart = Helper.toCell<int> restart "restart" 
                let _b = Helper.toCell<Vector> b "b" 
                let _x0 = Helper.toDefault<Vector> x0 "x0" null
                let builder (current : ICell) = withMnemonic mnemonic ((GMRESModel.Cast _GMRES.cell).SolveWithRestart
                                                            _restart.cell 
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRESResult>) l

                let source () = Helper.sourceFold (_GMRES.source + ".SolveWithRestart") 
                                               [| _GMRES.source
                                               ;  _restart.source
                                               ;  _b.source
                                               ;  _x0.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRES.cell
                                ;  _restart.cell
                                ;  _b.cell
                                ;  _x0.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GMRES> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GMRES_Range", Description="Create a range of GMRES",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GMRES_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GMRES> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GMRES>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GMRES>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GMRES>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
