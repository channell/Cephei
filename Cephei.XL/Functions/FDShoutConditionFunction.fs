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

  </summary> *)
[<AutoSerializable(true)>]
module FDShoutConditionFunction =

    (*
        required for template inheritance
    *)
    [<ExcelFunction(Name="_FDShoutCondition_factory", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
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

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source = Helper.sourceFold (_FDShoutCondition.source + ".Factory") 
                                               [| _FDShoutCondition.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutCondition", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_create
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
                let builder () = withMnemonic mnemonic (Fun.FDShoutCondition 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDShoutCondition>) l

                let source = Helper.sourceFold "Fun.FDShoutCondition" 
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
                    ; subscriber = Helper.subscriberModel<FDShoutCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_FDShoutCondition1", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.FDShoutCondition1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDShoutCondition>) l

                let source = Helper.sourceFold "Fun.FDShoutCondition1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutCondition_setStepCondition", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDShoutCondition) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDShoutCondition.source + ".SetStepCondition") 
                                               [| _FDShoutCondition.source
                                               ;  _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
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
    [<ExcelFunction(Name="_FDShoutCondition_ensureStrikeInGrid", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDShoutCondition) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FDShoutCondition.source + ".EnsureStrikeInGrid") 
                                               [| _FDShoutCondition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
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
    [<ExcelFunction(Name="_FDShoutCondition_getResidualTime", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FDShoutCondition.source + ".GetResidualTime") 
                                               [| _FDShoutCondition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
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
    [<ExcelFunction(Name="_FDShoutCondition_grid", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_FDShoutCondition.source + ".Grid") 
                                               [| _FDShoutCondition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutCondition_intrinsicValues_", Description="Create a FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutCondition",Description = "Reference to FDShoutCondition")>] 
         fdshoutcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutCondition = Helper.toCell<FDShoutCondition> fdshoutcondition "FDShoutCondition"  
                let builder () = withMnemonic mnemonic ((_FDShoutCondition.cell :?> FDShoutConditionModel).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source = Helper.sourceFold (_FDShoutCondition.source + ".IntrinsicValues_") 
                                               [| _FDShoutCondition.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutCondition.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDShoutCondition_Range", Description="Create a range of FDShoutCondition",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FDShoutCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDShoutCondition")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDShoutCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDShoutCondition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDShoutCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FDShoutCondition>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
