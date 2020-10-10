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
this is template version to serve as base for FDAmericanCondition and FDShoutCondition
  </summary> *)
[<AutoSerializable(true)>]
module FDConditionTemplateFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionTemplate", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDConditionTemplate 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDConditionTemplate>) l

                let source () = Helper.sourceFold "Fun.FDConditionTemplate" 
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
                    ; subscriber = Helper.subscriberModel<FDConditionTemplate> format
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
    [<ExcelFunction(Name="_FDConditionTemplate1", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDConditionTemplate1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDConditionTemplate>) l

                let source () = Helper.sourceFold "Fun.FDConditionTemplate1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionTemplate_setStepCondition", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDConditionTemplate) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".SetStepCondition") 
                                               [| _FDConditionTemplate.source
                                               ;  _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
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
    [<ExcelFunction(Name="_FDConditionTemplate_ensureStrikeInGrid", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDConditionTemplate) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".EnsureStrikeInGrid") 
                                               [| _FDConditionTemplate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
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
        this should be defined as new in each deriving class which use template iheritance in order to return a proper class to wrap
    *)
    [<ExcelFunction(Name="_FDConditionTemplate_factory", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
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

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".Factory") 
                                               [| _FDConditionTemplate.source
                                               ;  _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionTemplate_getResidualTime", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".GetResidualTime") 
                                               [| _FDConditionTemplate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
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
    [<ExcelFunction(Name="_FDConditionTemplate_grid", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".Grid") 
                                               [| _FDConditionTemplate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDConditionTemplate_intrinsicValues_", Description="Create a FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDConditionTemplate",Description = "Reference to FDConditionTemplate")>] 
         fdconditiontemplate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDConditionTemplate = Helper.toCell<FDConditionTemplate> fdconditiontemplate "FDConditionTemplate"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDConditionTemplateModel.Cast _FDConditionTemplate.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDConditionTemplate.source + ".IntrinsicValues_") 
                                               [| _FDConditionTemplate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDConditionTemplate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDConditionTemplate> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDConditionTemplate_Range", Description="Create a range of FDConditionTemplate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDConditionTemplate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FDConditionTemplate")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDConditionTemplate> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FDConditionTemplate>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FDConditionTemplate>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FDConditionTemplate>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
