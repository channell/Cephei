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

  </summary> *)
[<AutoSerializable(true)>]
module LiborForwardModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModel_discount", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".Discount") 
                                               [| _LiborForwardModel.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_discountBond", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _t = Helper.toCell<double> t "t" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _v = Helper.toCell<Vector> v "v" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).DiscountBond
                                                            _t.cell 
                                                            _maturity.cell 
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".DiscountBond") 
                                               [| _LiborForwardModel.source
                                               ;  _t.source
                                               ;  _maturity.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
                                ;  _t.cell
                                ;  _maturity.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_discountBondOption", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="bondMaturity",Description = "Reference to bondMaturity")>] 
         bondMaturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".DiscountBondOption") 
                                               [| _LiborForwardModel.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
                                ;  _Type.cell
                                ;  _strike.cell
                                ;  _maturity.cell
                                ;  _bondMaturity.cell
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
        calculating swaption volatility matrix using Rebonatos approx. formula. Be aware that this matrix is valid only for regular fixings and assumes that the fix and floating leg have the same frequency
    *)
    [<ExcelFunction(Name="_LiborForwardModel_getSwaptionVolatilityMatrix", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_getSwaptionVolatilityMatrix
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).GetSwaptionVolatilityMatrix
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolatilityMatrix>) l

                let source = Helper.sourceFold (_LiborForwardModel.source + ".GetSwaptionVolatilityMatrix") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="volaModel",Description = "Reference to volaModel")>] 
         volaModel : obj)
        ([<ExcelArgument(Name="corrModel",Description = "Reference to corrModel")>] 
         corrModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<LiborForwardModelProcess> Process "Process" true
                let _volaModel = Helper.toCell<LmVolatilityModel> volaModel "volaModel" true
                let _corrModel = Helper.toCell<LmCorrelationModel> corrModel "corrModel" true
                let builder () = withMnemonic mnemonic (Fun.LiborForwardModel 
                                                            _Process.cell 
                                                            _volaModel.cell 
                                                            _corrModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LiborForwardModel>) l

                let source = Helper.sourceFold "Fun.LiborForwardModel" 
                                               [| _Process.source
                                               ;  _volaModel.source
                                               ;  _corrModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _volaModel.cell
                                ;  _corrModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_S_0", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_S_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _alpha = Helper.toCell<int> alpha "alpha" true
                let _beta = Helper.toCell<int> beta "beta" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).S_0
                                                            _alpha.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".S_0") 
                                               [| _LiborForwardModel.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
                                ;  _alpha.cell
                                ;  _beta.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_setParams", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".SetParams") 
                                               [| _LiborForwardModel.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_w_0", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_w_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _alpha = Helper.toCell<int> alpha "alpha" true
                let _beta = Helper.toCell<int> beta "beta" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).W_0
                                                            _alpha.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModel.source + ".W_0") 
                                               [| _LiborForwardModel.source
                                               ;  _alpha.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
                                ;  _alpha.cell
                                ;  _beta.cell
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
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_LiborForwardModel_calibrate", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
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

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" true
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" true
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".Calibrate") 
                                               [| _LiborForwardModel.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_constraint", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_LiborForwardModel.source + ".CONSTRAINT") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_endCriteria", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".EndCriteria") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_notifyObservers", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).NotifyObservers
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".NotifyObservers") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_parameters", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModel.source + ".Parameters") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_registerWith", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".RegisterWith") 
                                               [| _LiborForwardModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_unregisterWith", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".UnregisterWith") 
                                               [| _LiborForwardModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_update", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Update
                                                       ) :> ICell
                let format (o : LiborForwardModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".Update") 
                                               [| _LiborForwardModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_value", Description="Create a LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModel",Description = "Reference to LiborForwardModel")>] 
         liborforwardmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModel = Helper.toCell<LiborForwardModel> liborforwardmodel "LiborForwardModel" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModel.cell :?> LiborForwardModelModel).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModel.source + ".Value") 
                                               [| _LiborForwardModel.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModel.cell
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
    [<ExcelFunction(Name="_LiborForwardModel_Range", Description="Create a range of LiborForwardModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LiborForwardModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LiborForwardModel> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LiborForwardModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LiborForwardModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LiborForwardModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
