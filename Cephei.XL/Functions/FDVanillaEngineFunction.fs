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
  The name is a misnomer as this is a base class for any finite difference scheme.  Its main job is to handle grid layout.  vanillaengines
  </summary> *)
[<AutoSerializable(true)>]
module FDVanillaEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_FDVanillaEngine_ensureStrikeInGrid", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDVanillaEngine",Description = "Reference to FDVanillaEngine")>] 
         fdvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDVanillaEngine = Helper.toCell<FDVanillaEngine> fdvanillaengine "FDVanillaEngine"  
                let builder () = withMnemonic mnemonic ((FDVanillaEngineModel.Cast _FDVanillaEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDVanillaEngine.source + ".EnsureStrikeInGrid") 
                                               [| _FDVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDVanillaEngine.cell
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
        this should be defined as new in each deriving class which use template iheritance in order to return a proper class to wrap
    *)
    [<ExcelFunction(Name="_FDVanillaEngine_factory", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDVanillaEngine",Description = "Reference to FDVanillaEngine")>] 
         fdvanillaengine : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "Reference to timeDependent")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDVanillaEngine = Helper.toCell<FDVanillaEngine> fdvanillaengine "FDVanillaEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic ((FDVanillaEngineModel.Cast _FDVanillaEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDVanillaEngine.source + ".Factory") 
                                               [| _FDVanillaEngine.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDVanillaEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics and template iheritance
    *)
    [<ExcelFunction(Name="_FDVanillaEngine1", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FDVanillaEngine1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold "Fun.FDVanillaEngine1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDVanillaEngine", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "Reference to timeDependent")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic (Fun.FDVanillaEngine
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold "Fun.FDVanillaEngine" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDVanillaEngine_getResidualTime", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDVanillaEngine",Description = "Reference to FDVanillaEngine")>] 
         fdvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDVanillaEngine = Helper.toCell<FDVanillaEngine> fdvanillaengine "FDVanillaEngine"  
                let builder () = withMnemonic mnemonic ((FDVanillaEngineModel.Cast _FDVanillaEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDVanillaEngine.source + ".GetResidualTime") 
                                               [| _FDVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDVanillaEngine.cell
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
    [<ExcelFunction(Name="_FDVanillaEngine_grid", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDVanillaEngine",Description = "Reference to FDVanillaEngine")>] 
         fdvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDVanillaEngine = Helper.toCell<FDVanillaEngine> fdvanillaengine "FDVanillaEngine"  
                let builder () = withMnemonic mnemonic ((FDVanillaEngineModel.Cast _FDVanillaEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDVanillaEngine.source + ".Grid") 
                                               [| _FDVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDVanillaEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDVanillaEngine_intrinsicValues_", Description="Create a FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDVanillaEngine",Description = "Reference to FDVanillaEngine")>] 
         fdvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDVanillaEngine = Helper.toCell<FDVanillaEngine> fdvanillaengine "FDVanillaEngine"  
                let builder () = withMnemonic mnemonic ((FDVanillaEngineModel.Cast _FDVanillaEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDVanillaEngine.source + ".IntrinsicValues_") 
                                               [| _FDVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDVanillaEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDVanillaEngine_Range", Description="Create a range of FDVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDVanillaEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDVanillaEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDVanillaEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDVanillaEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDVanillaEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDVanillaEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
