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
module FDAmericanConditionFunction =

    (*
        required for template inheritance
    *)
    [<ExcelFunction(Name="_FDAmericanCondition_factory", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanCondition", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDAmericanCondition 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDAmericanCondition>) l

                let source () = Helper.sourceFold "Fun.FDAmericanCondition" 
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
                    ; subscriber = Helper.subscriberModel<FDAmericanCondition> format
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
    [<ExcelFunction(Name="_FDAmericanCondition1", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDAmericanCondition1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDAmericanCondition>) l

                let source () = Helper.sourceFold "Fun.FDAmericanCondition1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanCondition_setStepCondition", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDAmericanCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
                                ;  _impl.cell
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
    [<ExcelFunction(Name="_FDAmericanCondition_ensureStrikeInGrid", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDAmericanCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
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
    [<ExcelFunction(Name="_FDAmericanCondition_getResidualTime", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
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
    [<ExcelFunction(Name="_FDAmericanCondition_grid", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDAmericanCondition_intrinsicValues_", Description="Create a FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDAmericanCondition",Description = "FDAmericanCondition")>] 
         fdamericancondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDAmericanCondition = Helper.toCell<FDAmericanCondition> fdamericancondition "FDAmericanCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDAmericanConditionModel.Cast _FDAmericanCondition.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDAmericanCondition.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDAmericanCondition.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDAmericanCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDAmericanCondition_Range", Description="Create a range of FDAmericanCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDAmericanCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDAmericanCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDAmericanCondition> (c)) :> ICell
                let format (i : Generic.List<ICell<FDAmericanCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDAmericanCondition>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
