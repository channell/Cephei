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
This engine uses the same algorithm that was used in quantlib in versions 0.3.11 and earlier.  It produces results that are different from the Merton 73 engine.  Review literature to see whether this is described
  </summary> *)
[<AutoSerializable(true)>]
module FDDividendEngineShiftScaleFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_factory2", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_factory2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
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

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" true
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).Factory2
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".Factory2") 
                                               [| _FDDividendEngineShiftScale.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_create
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
                let builder () = withMnemonic mnemonic (Fun.FDDividendEngineShiftScale 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngineShiftScale>) l

                let source = Helper.sourceFold "Fun.FDDividendEngineShiftScale" 
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_factory", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
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

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" true
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" true
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".Factory") 
                                               [| _FDDividendEngineShiftScale.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_setStepCondition", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" true
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDDividendEngineShiftScale) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".SetStepCondition") 
                                               [| _FDDividendEngineShiftScale.source
                                               ;  _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
                                ;  _impl.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_ensureStrikeInGrid", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendEngineShiftScale) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".EnsureStrikeInGrid") 
                                               [| _FDDividendEngineShiftScale.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_getResidualTime", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".GetResidualTime") 
                                               [| _FDDividendEngineShiftScale.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_grid", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".Grid") 
                                               [| _FDDividendEngineShiftScale.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_intrinsicValues_", Description="Create a FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngineShiftScale",Description = "Reference to FDDividendEngineShiftScale")>] 
         fddividendengineshiftscale : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngineShiftScale = Helper.toCell<FDDividendEngineShiftScale> fddividendengineshiftscale "FDDividendEngineShiftScale" true 
                let builder () = withMnemonic mnemonic ((_FDDividendEngineShiftScale.cell :?> FDDividendEngineShiftScaleModel).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDDividendEngineShiftScale.source + ".IntrinsicValues_") 
                                               [| _FDDividendEngineShiftScale.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngineShiftScale.cell
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
    [<ExcelFunction(Name="_FDDividendEngineShiftScale_Range", Description="Create a range of FDDividendEngineShiftScale",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDDividendEngineShiftScale_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDDividendEngineShiftScale")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendEngineShiftScale> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDDividendEngineShiftScale>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDDividendEngineShiftScale>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDDividendEngineShiftScale>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
