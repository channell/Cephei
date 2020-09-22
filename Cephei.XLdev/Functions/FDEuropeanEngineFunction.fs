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
  vanillaengines  the correctness of the returned value is tested by checking it against analytic results.
  </summary> *)
[<AutoSerializable(true)>]
module FDEuropeanEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDEuropeanEngine_calculate", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).Calculate
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".Calculate") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_create
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

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" true
                let builder () = withMnemonic mnemonic (Fun.FDEuropeanEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDEuropeanEngine>) l

                let source = Helper.sourceFold "Fun.FDEuropeanEngine" 
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
    [<ExcelFunction(Name="_FDEuropeanEngine1", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "Reference to gridPoints")>] 
         gridPoints : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let builder () = withMnemonic mnemonic (Fun.FDEuropeanEngine1 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDEuropeanEngine>) l

                let source = Helper.sourceFold "Fun.FDEuropeanEngine1" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_registerWith", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".RegisterWith") 
                                               [| _FDEuropeanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_reset", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).Reset
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".Reset") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_unregisterWith", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".UnregisterWith") 
                                               [| _FDEuropeanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_update", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).Update
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".Update") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_ensureStrikeInGrid", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDEuropeanEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".EnsureStrikeInGrid") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_factory", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
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

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" true
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".Factory") 
                                               [| _FDEuropeanEngine.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_getResidualTime", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".GetResidualTime") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_grid", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".Grid") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_intrinsicValues_", Description="Create a FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDEuropeanEngine",Description = "Reference to FDEuropeanEngine")>] 
         fdeuropeanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDEuropeanEngine = Helper.toCell<FDEuropeanEngine> fdeuropeanengine "FDEuropeanEngine" true 
                let builder () = withMnemonic mnemonic ((_FDEuropeanEngine.cell :?> FDEuropeanEngineModel).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDEuropeanEngine.source + ".IntrinsicValues_") 
                                               [| _FDEuropeanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDEuropeanEngine.cell
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
    [<ExcelFunction(Name="_FDEuropeanEngine_Range", Description="Create a range of FDEuropeanEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDEuropeanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDEuropeanEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDEuropeanEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDEuropeanEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDEuropeanEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDEuropeanEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
