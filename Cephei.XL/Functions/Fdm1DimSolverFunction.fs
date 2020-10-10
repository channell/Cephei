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
module Fdm1DimSolverFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Fdm1DimSolver_derivativeX", Description="Create a Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_derivativeX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1DimSolver",Description = "Reference to Fdm1DimSolver")>] 
         fdm1dimsolver : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1DimSolver = Helper.toCell<Fdm1DimSolver> fdm1dimsolver "Fdm1DimSolver"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((Fdm1DimSolverModel.Cast _Fdm1DimSolver.cell).DerivativeX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Fdm1DimSolver.source + ".DerivativeX") 
                                               [| _Fdm1DimSolver.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1DimSolver.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Fdm1DimSolver_derivativeXX", Description="Create a Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_derivativeXX
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1DimSolver",Description = "Reference to Fdm1DimSolver")>] 
         fdm1dimsolver : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1DimSolver = Helper.toCell<Fdm1DimSolver> fdm1dimsolver "Fdm1DimSolver"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((Fdm1DimSolverModel.Cast _Fdm1DimSolver.cell).DerivativeXX
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Fdm1DimSolver.source + ".DerivativeXX") 
                                               [| _Fdm1DimSolver.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1DimSolver.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Fdm1DimSolver", Description="Create a Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="solverDesc",Description = "Reference to solverDesc")>] 
         solverDesc : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="op",Description = "Reference to op")>] 
         op : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _solverDesc = Helper.toCell<FdmSolverDesc> solverDesc "solverDesc" 
                let _schemeDesc = Helper.toCell<FdmSchemeDesc> schemeDesc "schemeDesc" 
                let _op = Helper.toCell<FdmLinearOpComposite> op "op" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Fdm1DimSolver 
                                                            _solverDesc.cell 
                                                            _schemeDesc.cell 
                                                            _op.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Fdm1DimSolver>) l

                let source () = Helper.sourceFold "Fun.Fdm1DimSolver" 
                                               [| _solverDesc.source
                                               ;  _schemeDesc.source
                                               ;  _op.source
                                               |]
                let hash = Helper.hashFold 
                                [| _solverDesc.cell
                                ;  _schemeDesc.cell
                                ;  _op.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Fdm1DimSolver> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Fdm1DimSolver_interpolateAt", Description="Create a Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_interpolateAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1DimSolver",Description = "Reference to Fdm1DimSolver")>] 
         fdm1dimsolver : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1DimSolver = Helper.toCell<Fdm1DimSolver> fdm1dimsolver "Fdm1DimSolver"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((Fdm1DimSolverModel.Cast _Fdm1DimSolver.cell).InterpolateAt
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Fdm1DimSolver.source + ".InterpolateAt") 
                                               [| _Fdm1DimSolver.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1DimSolver.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_Fdm1DimSolver_thetaAt", Description="Create a Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_thetaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Fdm1DimSolver",Description = "Reference to Fdm1DimSolver")>] 
         fdm1dimsolver : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Fdm1DimSolver = Helper.toCell<Fdm1DimSolver> fdm1dimsolver "Fdm1DimSolver"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((Fdm1DimSolverModel.Cast _Fdm1DimSolver.cell).ThetaAt
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Fdm1DimSolver.source + ".ThetaAt") 
                                               [| _Fdm1DimSolver.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Fdm1DimSolver.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Fdm1DimSolver_Range", Description="Create a range of Fdm1DimSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Fdm1DimSolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Fdm1DimSolver")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Fdm1DimSolver> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Fdm1DimSolver>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Fdm1DimSolver>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Fdm1DimSolver>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
