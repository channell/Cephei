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
  Uses the Brownian-bridge correction for the barrier found in
<i> Going to Extremes: Correcting Simulation Bias in Exotic Option Valuation - D.R. Beaglehole, P.H. Dybvig and G. Zhou Financial Analysts Journal; Jan/Feb 1997; 53, 1. pg. 62-68
</i> and
<i> Simulating path-dependent options: A new approach - M. El Babsiri and G. Noel Journal of Derivatives; Winter 1998; 6, 2; pg. 65-83
</i>  barrierengines  the correctness of the returned value is tested by reproducing results available in literature.
  </summary> *)
[<AutoSerializable(true)>]
module MCBarrierEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_MCBarrierEngine", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="timeStepsPerYear",Description = "int")>] 
         timeStepsPerYear : obj)
        ([<ExcelArgument(Name="brownianBridge",Description = "bool")>] 
         brownianBridge : obj)
        ([<ExcelArgument(Name="antitheticVariate",Description = "bool")>] 
         antitheticVariate : obj)
        ([<ExcelArgument(Name="requiredSamples",Description = "int")>] 
         requiredSamples : obj)
        ([<ExcelArgument(Name="requiredTolerance",Description = "double")>] 
         requiredTolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="isBiased",Description = "bool")>] 
         isBiased : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toNullable<int> timeSteps "timeSteps"
                let _timeStepsPerYear = Helper.toNullable<int> timeStepsPerYear "timeStepsPerYear"
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" 
                let _requiredSamples = Helper.toNullable<int> requiredSamples "requiredSamples"
                let _requiredTolerance = Helper.toNullable<double> requiredTolerance "requiredTolerance"
                let _maxSamples = Helper.toNullable<int> maxSamples "maxSamples"
                let _isBiased = Helper.toCell<bool> isBiased "isBiased" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MCBarrierEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _timeStepsPerYear.cell 
                                                            _brownianBridge.cell 
                                                            _antitheticVariate.cell 
                                                            _requiredSamples.cell 
                                                            _requiredTolerance.cell 
                                                            _maxSamples.cell 
                                                            _isBiased.cell 
                                                            _seed.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MCBarrierEngine>) l

                let source () = Helper.sourceFold "Fun.MCBarrierEngine" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _timeStepsPerYear.source
                                               ;  _brownianBridge.source
                                               ;  _antitheticVariate.source
                                               ;  _requiredSamples.source
                                               ;  _requiredTolerance.source
                                               ;  _maxSamples.source
                                               ;  _isBiased.source
                                               ;  _seed.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _timeStepsPerYear.cell
                                ;  _brownianBridge.cell
                                ;  _antitheticVariate.cell
                                ;  _requiredSamples.cell
                                ;  _requiredTolerance.cell
                                ;  _maxSamples.cell
                                ;  _isBiased.cell
                                ;  _seed.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MCBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MCBarrierEngine_registerWith", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_reset", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).Reset
                                                       ) :> ICell
                let format (o : MCBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_unregisterWith", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_update", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).Update
                                                       ) :> ICell
                let format (o : MCBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_errorEstimate", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_sampleAccumulator", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_sampleAccumulator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).SampleAccumulator
                                                       ) :> ICell
                let format (o : S) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".SampleAccumulator") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_value", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        ([<ExcelArgument(Name="tolerance",Description = "double")>] 
         tolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="minSamples",Description = "int")>] 
         minSamples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let _tolerance = Helper.toCell<double> tolerance "tolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _minSamples = Helper.toCell<int> minSamples "minSamples" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).Value
                                                            _tolerance.cell 
                                                            _maxSamples.cell 
                                                            _minSamples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".Value") 

                                               [| _tolerance.source
                                               ;  _maxSamples.source
                                               ;  _minSamples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_valueWithSamples", Description="Create a MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_valueWithSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCBarrierEngine",Description = "MCBarrierEngine")>] 
         mcbarrierengine : obj)
        ([<ExcelArgument(Name="samples",Description = "int")>] 
         samples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCBarrierEngine = Helper.toCell<MCBarrierEngine> mcbarrierengine "MCBarrierEngine"  
                let _samples = Helper.toCell<int> samples "samples" 
                let builder (current : ICell) = withMnemonic mnemonic ((MCBarrierEngineModel.Cast _MCBarrierEngine.cell).ValueWithSamples
                                                            _samples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCBarrierEngine.source + ".ValueWithSamples") 

                                               [| _samples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCBarrierEngine.cell
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
    [<ExcelFunction(Name="_MCBarrierEngine_Range", Description="Create a range of MCBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MCBarrierEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MCBarrierEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<MCBarrierEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MCBarrierEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
