﻿(*
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

  </summary> *)
[<AutoSerializable(true)>]
module MCDiscreteGeometricAPEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="maxTimeStepPerYear",Description = "int")>] 
         maxTimeStepPerYear : obj)
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
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _maxTimeStepPerYear = Helper.toCell<int> maxTimeStepPerYear "maxTimeStepPerYear" 
                let _brownianBridge = Helper.toCell<bool> brownianBridge "brownianBridge" 
                let _antitheticVariate = Helper.toCell<bool> antitheticVariate "antitheticVariate" 
                let _controlVariate = Helper.toCell<bool> controlVariate "controlVariate" 
                let _requiredSamples = Helper.toCell<int> requiredSamples "requiredSamples" 
                let _requiredTolerance = Helper.toCell<double> requiredTolerance "requiredTolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.MCDiscreteGeometricAPEngine 
                                                            _Process.cell 
                                                            _maxTimeStepPerYear.cell 
                                                            _brownianBridge.cell 
                                                            _antitheticVariate.cell 
                                                            _controlVariate.cell 
                                                            _requiredSamples.cell 
                                                            _requiredTolerance.cell 
                                                            _maxSamples.cell 
                                                            _seed.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MCDiscreteGeometricAPEngine>) l

                let source () = Helper.sourceFold "Fun.MCDiscreteGeometricAPEngine" 
                                               [| _Process.source
                                               ;  _maxTimeStepPerYear.source
                                               ;  _brownianBridge.source
                                               ;  _antitheticVariate.source
                                               ;  _controlVariate.source
                                               ;  _requiredSamples.source
                                               ;  _requiredTolerance.source
                                               ;  _maxSamples.source
                                               ;  _seed.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _maxTimeStepPerYear.cell
                                ;  _brownianBridge.cell
                                ;  _antitheticVariate.cell
                                ;  _controlVariate.cell
                                ;  _requiredSamples.cell
                                ;  _requiredTolerance.cell
                                ;  _maxSamples.cell
                                ;  _seed.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MCDiscreteGeometricAPEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
 
    (*
        
    *)
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_registerWith", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteGeometricAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_reset", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).Reset
                                                       ) :> ICell
                let format (o : MCDiscreteGeometricAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_unregisterWith", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : MCDiscreteGeometricAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_update", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).Update
                                                       ) :> ICell
                let format (o : MCDiscreteGeometricAPEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_errorEstimate", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".ErrorEstimate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_sampleAccumulator", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_sampleAccumulator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).SampleAccumulator
                                                       ) :> ICell
                let format (o : S) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".SampleAccumulator") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_value", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        ([<ExcelArgument(Name="tolerance",Description = "double")>] 
         tolerance : obj)
        ([<ExcelArgument(Name="maxSamples",Description = "int")>] 
         maxSamples : obj)
        ([<ExcelArgument(Name="minSamples",Description = "int")>] 
         minSamples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let _tolerance = Helper.toCell<double> tolerance "tolerance" 
                let _maxSamples = Helper.toCell<int> maxSamples "maxSamples" 
                let _minSamples = Helper.toCell<int> minSamples "minSamples" 
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).Value
                                                            _tolerance.cell 
                                                            _maxSamples.cell 
                                                            _minSamples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".Value") 

                                               [| _tolerance.source
                                               ;  _maxSamples.source
                                               ;  _minSamples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_valueWithSamples", Description="Create a MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_valueWithSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MCDiscreteGeometricAPEngine",Description = "MCDiscreteGeometricAPEngine")>] 
         mcdiscretegeometricapengine : obj)
        ([<ExcelArgument(Name="samples",Description = "int")>] 
         samples : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MCDiscreteGeometricAPEngine = Helper.toCell<MCDiscreteGeometricAPEngine> mcdiscretegeometricapengine "MCDiscreteGeometricAPEngine"  
                let _samples = Helper.toCell<int> samples "samples" 
                let builder (current : ICell) = ((MCDiscreteGeometricAPEngineModel.Cast _MCDiscreteGeometricAPEngine.cell).ValueWithSamples
                                                            _samples.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MCDiscreteGeometricAPEngine.source + ".ValueWithSamples") 

                                               [| _samples.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MCDiscreteGeometricAPEngine.cell
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
    [<ExcelFunction(Name="_MCDiscreteGeometricAPEngine_Range", Description="Create a range of MCDiscreteGeometricAPEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MCDiscreteGeometricAPEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MCDiscreteGeometricAPEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<MCDiscreteGeometricAPEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<MCDiscreteGeometricAPEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<MCDiscreteGeometricAPEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
