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
(*!!
(* <summary>
  control-variate calculation is disabled under VC++6.  asianengines
  </summary> *)
[<AutoSerializable(true)>]
module MCDiscreteAveragingAsianEngineFunction =


    (*
        constructor
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="maxTimeStepsPerYear",Description = "int")>] 
         maxTimeStepsPerYear : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "bool")>] 
         brownianBridge : obj)
        ([<ExcelArgument(Name="antitheticVariate",Description = "bool")>] 
         antitheticVariate : obj)
        ([<ExcelArgument(Name="controlVariate",Description = "bool")>] 
         controlVariate : obj)
        ([<ExcelArgument(Name="requiredSamples",Description = "int")>] 
         requiredSamples : obj)
        ([<ExcelArgument(Name="requiredTolerance",Description = "double")>] 
         requiredTolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _maxTimeStepsPerYear = Helper.toCell<int> maxTimeStepsPerYear "maxTimeStepsPerYear" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" 
                let _controlVariate = Helper.toCell<bool> controlVariate "controlVariate" 
                let _requiredSamples = Helper.toCell<int> requiredSamples "requiredSamples" 
                let _requiredTolerance = Helper.toCell<double> requiredTolerance "requiredTolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MCDiscreteAveragingAsianEngine 
                                                            _Process.cell 
                                                            _maxTimeStepsPerYear.cell 
                                                            _brownianBridge.cell 
                                                            _antitheticVariate.cell 
                                                            _controlVariate.cell 
                                                            _requiredSamples.cell 
                                                            _requiredTolerance.cell 
                                                            _maxSamples.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MCDiscreteAveragingAsianEngine>) l

                let source () = Helper.sourceFold "Fun.MCDiscreteAveragingAsianEngine" 
                                               [| _Process.source
                                               ;  _maxTimeStepsPerYear.source
                                               ;  _brownianBridge.source
                                               ;  _antitheticVariate.source
                                               ;  _controlVariate.source
                                               ;  _requiredSamples.source
                                               ;  _requiredTolerance.source
                                               ;  _maxSamples.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _maxTimeStepsPerYear.cell
                                ;  _brownianBridge.cell
                                ;  _antitheticVariate.cell
                                ;  _controlVariate.cell
                                ;  _requiredSamples.cell
                                ;  _requiredTolerance.cell
                                ;  _maxSamples.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MCDiscreteAveragingAsianEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_registerWith", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteAveragingAsianEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_reset", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).Reset
                                                       ) :> ICell
                let format (o : MCDiscreteAveragingAsianEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_unregisterWith", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteAveragingAsianEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_update", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).Update
                                                       ) :> ICell
                let format (o : MCDiscreteAveragingAsianEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
        ! error estimated using the samples simulated so far
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_errorEstimate", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
        ! access to the sample accumulator for richer statistics
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_sampleAccumulator", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_sampleAccumulator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).SampleAccumulator
                                                       ) :> ICell
                let format (o : S) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".SampleAccumulator") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
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
        ! add samples until the required absolute tolerance is reached
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_value", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        ([<ExcelArgument(Name="tolerance",Description = "double")>] 
         tolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="minSamples",Description = "int")>] 
         minSamples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let _tolerance = Helper.toCell<double> tolerance "tolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _minSamples = Helper.toCell<int> minSamples "minSamples" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).Value
                                                            _tolerance.cell 
                                                            _maxSamples.cell 
                                                            _minSamples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".Value") 

                                               [| _tolerance.source
                                               ;  _maxSamples.source
                                               ;  _minSamples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
                                ;  _tolerance.cell
                                ;  _maxSamples.cell
                                ;  _minSamples.cell
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
        ! simulate a fixed number of samples
    *)
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_valueWithSamples", Description="Create a MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_valueWithSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteAveragingAsianEngine",Description = "MCDiscreteAveragingAsianEngine")>] 
         mcdiscreteaveragingasianengine : obj)
        ([<ExcelArgument(Name="samples",Description = "int")>] 
         samples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteAveragingAsianEngine = Helper.toCell<MCDiscreteAveragingAsianEngine> mcdiscreteaveragingasianengine "MCDiscreteAveragingAsianEngine"  
                let _samples = Helper.toCell<int> samples "samples" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCDiscreteAveragingAsianEngineModel.Cast _MCDiscreteAveragingAsianEngine.cell).ValueWithSamples
                                                            _samples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteAveragingAsianEngine.source + ".ValueWithSamples") 

                                               [| _samples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteAveragingAsianEngine.cell
                                ;  _samples.cell
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
    [<ExcelFunction(Name="_MCDiscreteAveragingAsianEngine_Range", Description="Create a range of MCDiscreteAveragingAsianEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteAveragingAsianEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MCDiscreteAveragingAsianEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MCDiscreteAveragingAsianEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MCDiscreteAveragingAsianEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MCDiscreteAveragingAsianEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
