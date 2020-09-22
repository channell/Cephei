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
    [<ExcelFunction(Name="_GMRES", Description="Create a GMRES",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRES_create
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

                let _A = Helper.toCell<MatrixMult> A "A" true
                let _maxIter = Helper.toCell<int> maxIter "maxIter" true
                let _relTol = Helper.toCell<double> relTol "relTol" true
                let _preConditioner = Helper.toCell<MatrixMult> preConditioner "preConditioner" true
                let builder () = withMnemonic mnemonic (Fun.GMRES 
                                                            _A.cell 
                                                            _maxIter.cell 
                                                            _relTol.cell 
                                                            _preConditioner.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRES>) l

                let source = Helper.sourceFold "Fun.GMRES" 
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
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GMRES_MatrixMult", Description="Create a GMRES",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRES_MatrixMult
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "Reference to GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES" true 
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_GMRES.cell :?> GMRESModel).MatrixMult
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GMRES.source + ".MatrixMult") 
                                               [| _GMRES.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GMRES.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GMRES_solve", Description="Create a GMRES",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRES_solve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "Reference to GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES" true 
                let _b = Helper.toCell<Vector> b "b" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let builder () = withMnemonic mnemonic ((_GMRES.cell :?> GMRESModel).Solve
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRESResult>) l

                let source = Helper.sourceFold (_GMRES.source + ".Solve") 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GMRES_solveWithRestart", Description="Create a GMRES",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRES_solveWithRestart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GMRES",Description = "Reference to GMRES")>] 
         gmres : obj)
        ([<ExcelArgument(Name="restart",Description = "Reference to restart")>] 
         restart : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GMRES = Helper.toCell<GMRES> gmres "GMRES" true 
                let _restart = Helper.toCell<int> restart "restart" true
                let _b = Helper.toCell<Vector> b "b" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let builder () = withMnemonic mnemonic ((_GMRES.cell :?> GMRESModel).SolveWithRestart
                                                            _restart.cell 
                                                            _b.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GMRESResult>) l

                let source = Helper.sourceFold (_GMRES.source + ".SolveWithRestart") 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GMRES_Range", Description="Create a range of GMRES",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GMRES_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GMRES")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GMRES> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GMRES>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GMRES>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GMRES>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
