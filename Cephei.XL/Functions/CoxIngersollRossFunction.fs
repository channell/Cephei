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
module CoxIngersollRossFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r0",Description = "Reference to r0")>] 
         r0 : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="k",Description = "Reference to k")>] 
         k : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r0 = Helper.toCell<double> r0 "r0" true
                let _theta = Helper.toCell<double> theta "theta" true
                let _k = Helper.toCell<double> k "k" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.CoxIngersollRoss 
                                                            _r0.cell 
                                                            _theta.cell 
                                                            _k.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CoxIngersollRoss>) l

                let source = Helper.sourceFold "Fun.CoxIngersollRoss" 
                                               [| _r0.source
                                               ;  _theta.source
                                               ;  _k.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r0.cell
                                ;  _theta.cell
                                ;  _k.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBondOption", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
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

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _Type = Helper.toCell<Option.Type> Type "Type" true
                let _strike = Helper.toCell<double> strike "strike" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBondOption") 
                                               [| _CoxIngersollRoss.source
                                               ;  _Type.source
                                               ;  _strike.source
                                               ;  _maturity.source
                                               ;  _bondMaturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_dynamics", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Dynamics") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_tree", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _grid = Helper.toCell<TimeGrid> grid "grid" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Tree") 
                                               [| _CoxIngersollRoss.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                ;  _grid.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discount", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Discount") 
                                               [| _CoxIngersollRoss.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBond1", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="rate",Description = "Reference to rate")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _now = Helper.toCell<double> now "now" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _rate = Helper.toCell<double> rate "rate" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).DiscountBond1
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBond1") 
                                               [| _CoxIngersollRoss.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _rate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _rate.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBond", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="now",Description = "Reference to now")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _now = Helper.toCell<double> now "now" true
                let _maturity = Helper.toCell<double> maturity "maturity" true
                let _factors = Helper.toCell<Vector> factors "factors" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBond") 
                                               [| _CoxIngersollRoss.source
                                               ;  _now.source
                                               ;  _maturity.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                ;  _now.cell
                                ;  _maturity.cell
                                ;  _factors.cell
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
        ! An additional constraint can be passed which must be satisfied in addition to the constraints of the model.
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_calibrate", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
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

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" true
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" true
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" true
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" true
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Calibrate") 
                                               [| _CoxIngersollRoss.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_constraint", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".CONSTRAINT") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_endCriteria", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".EndCriteria") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_notifyObservers", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).NotifyObservers
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".NotifyObservers") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_parameters", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Parameters") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_registerWith", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".RegisterWith") 
                                               [| _CoxIngersollRoss.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_setParams", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".SetParams") 
                                               [| _CoxIngersollRoss.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_unregisterWith", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".UnregisterWith") 
                                               [| _CoxIngersollRoss.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_update", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Update
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Update") 
                                               [| _CoxIngersollRoss.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_value", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "Reference to CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss" true 
                let _parameters = Helper.toCell<Vector> parameters "parameters" true
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" true
                let builder () = withMnemonic mnemonic ((_CoxIngersollRoss.cell :?> CoxIngersollRossModel).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CoxIngersollRoss.source + ".Value") 
                                               [| _CoxIngersollRoss.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_Range", Description="Create a range of CoxIngersollRoss",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CoxIngersollRoss_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CoxIngersollRoss")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CoxIngersollRoss> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CoxIngersollRoss>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CoxIngersollRoss>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CoxIngersollRoss>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
