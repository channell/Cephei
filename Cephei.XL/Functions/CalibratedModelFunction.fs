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
  Calibrated model class
  </summary> *)
[<AutoSerializable(true)>]
module CalibratedModelFunction =

    (*
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_CalibratedModel_calibrate", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "CalibratedModel")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "CalibratedModel")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "CalibratedModel")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toDefault<Constraint> additionalConstraint "additionalConstraint" null
                let _weights = Helper.toDefault<Generic.List<double>> weights "weights" null
                let _fixParameters = Helper.toDefault<Generic.List<bool>> fixParameters "fixParameters" null
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".Calibrate") 

                                               [| _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                ;  _instruments.cell
                                ;  _Method.cell
                                ;  _endCriteria.cell
                                ;  _additionalConstraint.cell
                                ;  _weights.cell
                                ;  _fixParameters.cell
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
    [<ExcelFunction(Name="_CalibratedModel", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="nArguments",Description = "int")>] 
         nArguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _nArguments = Helper.toCell<int> nArguments "nArguments" 
                let builder (current : ICell) = (Fun.CalibratedModel 
                                                            _nArguments.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CalibratedModel>) l

                let source () = Helper.sourceFold "Fun.CalibratedModel" 
                                               [| _nArguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _nArguments.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CalibratedModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CalibratedModel_constraint", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_CalibratedModel.source + ".CONSTRAINT") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CalibratedModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CalibratedModel_endCriteria", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_notifyObservers", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".NotifyObservers") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_CalibratedModel_parameters", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_CalibratedModel.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CalibratedModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CalibratedModel_registerWith", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_setParams", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".SetParams") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_CalibratedModel_unregisterWith", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_update", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).Update
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_value", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = ((CalibratedModelModel.Cast _CalibratedModel.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CalibratedModel.source + ".Value") 

                                               [| _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_CalibratedModel_Range", Description="Create a range of CalibratedModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CalibratedModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CalibratedModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<CalibratedModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<CalibratedModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<CalibratedModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
