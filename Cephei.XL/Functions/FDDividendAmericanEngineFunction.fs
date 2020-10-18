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
  vanillaengines  - the correctness of the returned greeks is tested by reproducing numerical derivatives. - the invariance of the results upon addition of null dividends is tested.
  </summary> *)
[<AutoSerializable(true)>]
module FDDividendAmericanEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendAmericanEngine_factory", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "IFDEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "IFDEngine")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "IFDEngine")>] 
         gridPoints : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IFDEngine>) l

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".Factory") 
                                               [| _FDDividendAmericanEngine.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendAmericanEngine", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FDDividendAmericanEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "FDDividendAmericanEngine")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "FDDividendAmericanEngine")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "FDDividendAmericanEngine")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendAmericanEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendAmericanEngine>) l

                let source () = Helper.sourceFold "Fun.FDDividendAmericanEngine" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendAmericanEngine1", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FDDividendAmericanEngine")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendAmericanEngine1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendAmericanEngine>) l

                let source () = Helper.sourceFold "Fun.FDDividendAmericanEngine1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendAmericanEngine_registerWith", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDDividendAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".RegisterWith") 
                                               [| _FDDividendAmericanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_reset", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).Reset
                                                       ) :> ICell
                let format (o : FDDividendAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".Reset") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_unregisterWith", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDDividendAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".UnregisterWith") 
                                               [| _FDDividendAmericanEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_update", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).Update
                                                       ) :> ICell
                let format (o : FDDividendAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".Update") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_ensureStrikeInGrid", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendAmericanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".EnsureStrikeInGrid") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_getResidualTime", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".GetResidualTime") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
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
    [<ExcelFunction(Name="_FDDividendAmericanEngine_grid", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".Grid") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendAmericanEngine_intrinsicValues_", Description="Create a FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "SampledCurve")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendAmericanEngine",Description = "FDDividendAmericanEngine")>] 
         fddividendamericanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendAmericanEngine = Helper.toCell<FDDividendAmericanEngine> fddividendamericanengine "FDDividendAmericanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendAmericanEngineModel.Cast _FDDividendAmericanEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDDividendAmericanEngine.source + ".IntrinsicValues_") 
                                               [| _FDDividendAmericanEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendAmericanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendAmericanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDDividendAmericanEngine_Range", Description="Create a range of FDDividendAmericanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendAmericanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendAmericanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDDividendAmericanEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDDividendAmericanEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FDDividendAmericanEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
