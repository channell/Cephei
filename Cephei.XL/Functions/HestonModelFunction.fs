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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  calibration is tested against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module HestonModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HestonModel", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "HestonProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<HestonProcess> Process "Process" 
                let builder (current : ICell) = (Fun.HestonModel 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonModel>) l

                let source () = Helper.sourceFold "Fun.HestonModel" 
                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        variance mean reversion speed
    *)
    [<ExcelFunction(Name="_HestonModel_kappa", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_kappa
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Kappa
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Kappa") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
        underlying process
    *)
    [<ExcelFunction(Name="_HestonModel_process", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_process
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Process
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonProcess>) l

                let source () = Helper.sourceFold (_HestonModel.source + ".PROCESS") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        correlation
    *)
    [<ExcelFunction(Name="_HestonModel_rho", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Rho") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
        volatility of the volatility
    *)
    [<ExcelFunction(Name="_HestonModel_sigma", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Sigma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
        variance mean version level
    *)
    [<ExcelFunction(Name="_HestonModel_theta", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
        spot variance
    *)
    [<ExcelFunction(Name="_HestonModel_v0", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_v0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).V0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".V0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_HestonModel_calibrate", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Constraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "double range")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "bool range")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Calibrate") 

                                               [| _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_constraint", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_HestonModel.source + ".CONSTRAINT") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonModel_endCriteria", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_notifyObservers", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".NotifyObservers") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_parameters", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonModel.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonModel_registerWith", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_setParams", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".SetParams") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_unregisterWith", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_update", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Update
                                                       ) :> ICell
                let format (o : HestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_value", Description="Create a HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonModel",Description = "HestonModel")>] 
         hestonmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper range")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonModel = Helper.toModelReference<HestonModel> hestonmodel "HestonModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = ((HestonModelModel.Cast _HestonModel.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonModel.source + ".Value") 

                                               [| _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonModel.cell
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
    [<ExcelFunction(Name="_HestonModel_Range", Description="Create a range of HestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<HestonModel> (c)) :> ICell
                let format (i : Cephei.Cell.List<HestonModel>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<HestonModel>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
