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
module FdmBlackScholesSolverFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesSolver_deltaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_deltaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toModelReference<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver"  
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = ((FdmBlackScholesSolverModel.Cast _FdmBlackScholesSolver.cell).DeltaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesSolver.source + ".DeltaAt") 

                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="solverDesc",Description = "FdmSolverDesc")>] 
         solverDesc : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "FdmSchemeDesc or empty")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "bool or empty")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "double")>] 
         illegalLocalVolOverwrite : obj)
        ([<ExcelArgument(Name="quantoHelper",Description = "FdmQuantoHelper")>] 
         quantoHelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toHandle<GeneralizedBlackScholesProcess> Process "Process" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _solverDesc = Helper.toCell<FdmSolverDesc> solverDesc "solverDesc" 
                let _schemeDesc = Helper.toDefault<FdmSchemeDesc> schemeDesc "schemeDesc" null
                let _localVol = Helper.toDefault<bool> localVol "localVol" false
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let _quantoHelper = Helper.toHandle<FdmQuantoHelper> quantoHelper "quantoHelper" 
                let builder (current : ICell) = (Fun.FdmBlackScholesSolver 
                                                            _Process.cell 
                                                            _strike.cell 
                                                            _solverDesc.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                            _quantoHelper.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBlackScholesSolver>) l

                let source () = Helper.sourceFold "Fun.FdmBlackScholesSolver" 
                                               [| _Process.source
                                               ;  _strike.source
                                               ;  _solverDesc.source
                                               ;  _schemeDesc.source
                                               ;  _localVol.source
                                               ;  _illegalLocalVolOverwrite.source
                                               ;  _quantoHelper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _strike.cell
                                ;  _solverDesc.cell
                                ;  _schemeDesc.cell
                                ;  _localVol.cell
                                ;  _illegalLocalVolOverwrite.cell
                                ;  _quantoHelper.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmBlackScholesSolver> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBlackScholesSolver_gammaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_gammaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toModelReference<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver"  
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = ((FdmBlackScholesSolverModel.Cast _FdmBlackScholesSolver.cell).GammaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesSolver.source + ".GammaAt") 

                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_thetaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_thetaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toModelReference<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver"  
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = ((FdmBlackScholesSolverModel.Cast _FdmBlackScholesSolver.cell).ThetaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesSolver.source + ".ThetaAt") 

                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_valueAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_valueAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "double")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toModelReference<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver"  
                let _s = Helper.toCell<double> s "s" 
                let builder (current : ICell) = ((FdmBlackScholesSolverModel.Cast _FdmBlackScholesSolver.cell).ValueAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmBlackScholesSolver.source + ".ValueAt") 

                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
                                ;  _s.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_Range", Description="Create a range of FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBlackScholesSolver> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmBlackScholesSolver> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmBlackScholesSolver>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmBlackScholesSolver>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
