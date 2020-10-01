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
module FDDividendEuropeanEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_factory", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IFDEngine>) l

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".Factory") 
                                               [| _FDDividendEuropeanEngine.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEuropeanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEuropeanEngine1", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_create1
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
                let builder () = withMnemonic mnemonic (Fun.FDDividendEuropeanEngine1
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEuropeanEngine>) l

                let source = Helper.sourceFold "Fun.FDDividendEuropeanEngine" 
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
                    ; subscriber = Helper.subscriberModel<FDDividendEuropeanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEuropeanEngine", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FDDividendEuropeanEngine ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEuropeanEngine>) l

                let source = Helper.sourceFold "Fun.FDDividendEuropeanEngine1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEuropeanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_registerWith", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDDividendEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".RegisterWith") 
                                               [| _FDDividendEuropeanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_reset", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).Reset
                                                       ) :> ICell
                let format (o : FDDividendEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".Reset") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_unregisterWith", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDDividendEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".UnregisterWith") 
                                               [| _FDDividendEuropeanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_update", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).Update
                                                       ) :> ICell
                let format (o : FDDividendEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".Update") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_ensureStrikeInGrid", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".EnsureStrikeInGrid") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_getResidualTime", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".GetResidualTime") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_grid", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".Grid") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEuropeanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_intrinsicValues_", Description="Create a FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEuropeanEngine",Description = "Reference to FDDividendEuropeanEngine")>] 
         fddividendeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEuropeanEngine = Helper.toCell<FDDividendEuropeanEngine> fddividendeuropeanengine "FDDividendEuropeanEngine"  
                let builder () = withMnemonic mnemonic ((_FDDividendEuropeanEngine.cell :?> FDDividendEuropeanEngineModel).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDDividendEuropeanEngine.source + ".IntrinsicValues_") 
                                               [| _FDDividendEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEuropeanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEuropeanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDDividendEuropeanEngine_Range", Description="Create a range of FDDividendEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEuropeanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDDividendEuropeanEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendEuropeanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDDividendEuropeanEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDDividendEuropeanEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDDividendEuropeanEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
