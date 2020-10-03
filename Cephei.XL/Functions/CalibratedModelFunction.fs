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
    [<ExcelFunction(Name="_CalibratedModel_calibrate", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Reference to additionalConstraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "Reference to weights")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "Reference to fixParameters")>] 
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
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".Calibrate") 
                                               [| _CalibratedModel.source
                                               ;  _instruments.source
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
    [<ExcelFunction(Name="_CalibratedModel", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="nArguments",Description = "Reference to nArguments")>] 
         nArguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _nArguments = Helper.toCell<int> nArguments "nArguments" 
                let builder () = withMnemonic mnemonic (Fun.CalibratedModel 
                                                            _nArguments.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CalibratedModel>) l

                let source = Helper.sourceFold "Fun.CalibratedModel" 
                                               [| _nArguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _nArguments.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CalibratedModel_constraint", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_CalibratedModel.source + ".CONSTRAINT") 
                                               [| _CalibratedModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CalibratedModel_endCriteria", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".EndCriteria") 
                                               [| _CalibratedModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_notifyObservers", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).NotifyObservers
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".NotifyObservers") 
                                               [| _CalibratedModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
        ! Returns array of arguments on which calibration is done
    *)
    [<ExcelFunction(Name="_CalibratedModel_parameters", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_CalibratedModel.source + ".Parameters") 
                                               [| _CalibratedModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_CalibratedModel_registerWith", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".RegisterWith") 
                                               [| _CalibratedModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_setParams", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".SetParams") 
                                               [| _CalibratedModel.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                ;  _parameters.cell
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
    [<ExcelFunction(Name="_CalibratedModel_unregisterWith", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".UnregisterWith") 
                                               [| _CalibratedModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_update", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).Update
                                                       ) :> ICell
                let format (o : CalibratedModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".Update") 
                                               [| _CalibratedModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
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
    [<ExcelFunction(Name="_CalibratedModel_value", Description="Create a CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CalibratedModel",Description = "Reference to CalibratedModel")>] 
         calibratedmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CalibratedModel = Helper.toCell<CalibratedModel> calibratedmodel "CalibratedModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder () = withMnemonic mnemonic ((_CalibratedModel.cell :?> CalibratedModelModel).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CalibratedModel.source + ".Value") 
                                               [| _CalibratedModel.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CalibratedModel.cell
                                ;  _parameters.cell
                                ;  _instruments.cell
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
    [<ExcelFunction(Name="_CalibratedModel_Range", Description="Create a range of CalibratedModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CalibratedModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CalibratedModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CalibratedModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CalibratedModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CalibratedModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CalibratedModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
