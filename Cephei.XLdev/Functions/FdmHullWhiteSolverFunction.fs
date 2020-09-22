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
module FdmHullWhiteSolverFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmHullWhiteSolver_deltaAt", Description="Create a FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_deltaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteSolver",Description = "Reference to FdmHullWhiteSolver")>] 
         fdmhullwhitesolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteSolver = Helper.toCell<FdmHullWhiteSolver> fdmhullwhitesolver "FdmHullWhiteSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmHullWhiteSolver.cell :?> FdmHullWhiteSolverModel).DeltaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmHullWhiteSolver.source + ".DeltaAt") 
                                               [| _FdmHullWhiteSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteSolver", Description="Create a FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="solverDesc",Description = "Reference to solverDesc")>] 
         solverDesc : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toHandle<Handle<HullWhite>> model "model" 
                let _solverDesc = Helper.toCell<FdmSolverDesc> solverDesc "solverDesc" true
                let _schemeDesc = Helper.toCell<FdmSchemeDesc> schemeDesc "schemeDesc" true
                let builder () = withMnemonic mnemonic (Fun.FdmHullWhiteSolver 
                                                            _model.cell 
                                                            _solverDesc.cell 
                                                            _schemeDesc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmHullWhiteSolver>) l

                let source = Helper.sourceFold "Fun.FdmHullWhiteSolver" 
                                               [| _model.source
                                               ;  _solverDesc.source
                                               ;  _schemeDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _solverDesc.cell
                                ;  _schemeDesc.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteSolver_gammaAt", Description="Create a FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_gammaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteSolver",Description = "Reference to FdmHullWhiteSolver")>] 
         fdmhullwhitesolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteSolver = Helper.toCell<FdmHullWhiteSolver> fdmhullwhitesolver "FdmHullWhiteSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmHullWhiteSolver.cell :?> FdmHullWhiteSolverModel).GammaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmHullWhiteSolver.source + ".GammaAt") 
                                               [| _FdmHullWhiteSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteSolver_thetaAt", Description="Create a FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_thetaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteSolver",Description = "Reference to FdmHullWhiteSolver")>] 
         fdmhullwhitesolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteSolver = Helper.toCell<FdmHullWhiteSolver> fdmhullwhitesolver "FdmHullWhiteSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmHullWhiteSolver.cell :?> FdmHullWhiteSolverModel).ThetaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmHullWhiteSolver.source + ".ThetaAt") 
                                               [| _FdmHullWhiteSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteSolver_valueAt", Description="Create a FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_valueAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmHullWhiteSolver",Description = "Reference to FdmHullWhiteSolver")>] 
         fdmhullwhitesolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmHullWhiteSolver = Helper.toCell<FdmHullWhiteSolver> fdmhullwhitesolver "FdmHullWhiteSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmHullWhiteSolver.cell :?> FdmHullWhiteSolverModel).ValueAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmHullWhiteSolver.source + ".ValueAt") 
                                               [| _FdmHullWhiteSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmHullWhiteSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmHullWhiteSolver_Range", Description="Create a range of FdmHullWhiteSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmHullWhiteSolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmHullWhiteSolver")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmHullWhiteSolver> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmHullWhiteSolver>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmHullWhiteSolver>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmHullWhiteSolver>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
