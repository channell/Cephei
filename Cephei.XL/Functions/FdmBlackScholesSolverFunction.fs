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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_deltaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_deltaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "Reference to FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toCell<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmBlackScholesSolver.cell :?> FdmBlackScholesSolverModel).DeltaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmBlackScholesSolver.source + ".DeltaAt") 
                                               [| _FdmBlackScholesSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="solverDesc",Description = "Reference to solverDesc")>] 
         solverDesc : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "Reference to localVol")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "Reference to illegalLocalVolOverwrite")>] 
         illegalLocalVolOverwrite : obj)
        ([<ExcelArgument(Name="quantoHelper",Description = "Reference to quantoHelper")>] 
         quantoHelper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toHandle<GeneralizedBlackScholesProcess> Process "Process" 
                let _strike = Helper.toCell<double> strike "strike" true
                let _solverDesc = Helper.toCell<FdmSolverDesc> solverDesc "solverDesc" true
                let _schemeDesc = Helper.toCell<FdmSchemeDesc> schemeDesc "schemeDesc" true
                let _localVol = Helper.toCell<bool> localVol "localVol" true
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let _quantoHelper = Helper.toHandle<FdmQuantoHelper> quantoHelper "quantoHelper" 
                let builder () = withMnemonic mnemonic (Fun.FdmBlackScholesSolver 
                                                            _Process.cell 
                                                            _strike.cell 
                                                            _solverDesc.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                            _quantoHelper.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBlackScholesSolver>) l

                let source = Helper.sourceFold "Fun.FdmBlackScholesSolver" 
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_gammaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_gammaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "Reference to FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toCell<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmBlackScholesSolver.cell :?> FdmBlackScholesSolverModel).GammaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmBlackScholesSolver.source + ".GammaAt") 
                                               [| _FdmBlackScholesSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_thetaAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_thetaAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "Reference to FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toCell<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmBlackScholesSolver.cell :?> FdmBlackScholesSolverModel).ThetaAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmBlackScholesSolver.source + ".ThetaAt") 
                                               [| _FdmBlackScholesSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_valueAt", Description="Create a FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_valueAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBlackScholesSolver",Description = "Reference to FdmBlackScholesSolver")>] 
         fdmblackscholessolver : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBlackScholesSolver = Helper.toCell<FdmBlackScholesSolver> fdmblackscholessolver "FdmBlackScholesSolver" true 
                let _s = Helper.toCell<double> s "s" true
                let builder () = withMnemonic mnemonic ((_FdmBlackScholesSolver.cell :?> FdmBlackScholesSolverModel).ValueAt
                                                            _s.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmBlackScholesSolver.source + ".ValueAt") 
                                               [| _FdmBlackScholesSolver.source
                                               ;  _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBlackScholesSolver.cell
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
    [<ExcelFunction(Name="_FdmBlackScholesSolver_Range", Description="Create a range of FdmBlackScholesSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBlackScholesSolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmBlackScholesSolver")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBlackScholesSolver> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmBlackScholesSolver>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmBlackScholesSolver>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmBlackScholesSolver>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
