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
    [<ExcelFunction(Name="_CoxIngersollRoss", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_create
        ([<ExcelArgument(Name="Mnemonic",Description = "CoxIngersollRoss")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r0",Description = "CoxIngersollRoss")>] 
         r0 : obj)
        ([<ExcelArgument(Name="theta",Description = "CoxIngersollRoss")>] 
         theta : obj)
        ([<ExcelArgument(Name="k",Description = "CoxIngersollRoss")>] 
         k : obj)
        ([<ExcelArgument(Name="sigma",Description = "CoxIngersollRoss")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r0 = Helper.toDefault<double> r0 "r0" 0.05
                let _theta = Helper.toDefault<double> theta "theta" 0.1
                let _k = Helper.toDefault<double> k "k" 0.1
                let _sigma = Helper.toDefault<double> sigma "sigma" 0.1
                let builder (current : ICell) = withMnemonic mnemonic (Fun.CoxIngersollRoss 
                                                            _r0.cell 
                                                            _theta.cell 
                                                            _k.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CoxIngersollRoss>) l

                let source () = Helper.sourceFold "Fun.CoxIngersollRoss" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxIngersollRoss> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBondOption", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBondOption
        ([<ExcelArgument(Name="Mnemonic",Description = "Lattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="Type",Description = "Option.Type: Put, Call")>] 
         Type : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="bondMaturity",Description = "double")>] 
         bondMaturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _Type = Helper.toCell<Option.Type> Type "Type" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _bondMaturity = Helper.toCell<double> bondMaturity "bondMaturity" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).DiscountBondOption
                                                            _Type.cell 
                                                            _strike.cell 
                                                            _maturity.cell 
                                                            _bondMaturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBondOption") 

                                               [| _Type.source
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
    [<ExcelFunction(Name="_CoxIngersollRoss_dynamics", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_dynamics
        ([<ExcelArgument(Name="Mnemonic",Description = "Lattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Dynamics
                                                       ) :> ICell
                let format (o : OneFactorModel.ShortRateDynamics) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Dynamics") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_tree", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_tree
        ([<ExcelArgument(Name="Mnemonic",Description = "Lattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="grid",Description = "TimeGrid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _grid = Helper.toCell<TimeGrid> grid "grid" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Tree
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Tree") 

                                               [| _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxIngersollRoss> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_discount", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Constraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Discount
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Discount") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBond1", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBond1
        ([<ExcelArgument(Name="Mnemonic",Description = "Constraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="now",Description = "double")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="rate",Description = "double")>] 
         rate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _rate = Helper.toCell<double> rate "rate" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).DiscountBond1
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _rate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBond1") 

                                               [| _now.source
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
    [<ExcelFunction(Name="_CoxIngersollRoss_discountBond", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Constraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="now",Description = "double")>] 
         now : obj)
        ([<ExcelArgument(Name="maturity",Description = "double")>] 
         maturity : obj)
        ([<ExcelArgument(Name="factors",Description = "Vector")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _now = Helper.toCell<double> now "now" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let _factors = Helper.toCell<Vector> factors "factors" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).DiscountBond
                                                            _now.cell 
                                                            _maturity.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".DiscountBond") 

                                               [| _now.source
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
    [<ExcelFunction(Name="_CoxIngersollRoss_calibrate", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Constraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper")>] 
         instruments : obj)
        ([<ExcelArgument(Name="Method",Description = "OptimizationMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "EndCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="additionalConstraint",Description = "Constraint")>] 
         additionalConstraint : obj)
        ([<ExcelArgument(Name="weights",Description = "double")>] 
         weights : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "bool")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Calibrate") 

                                               [| _instruments.source
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
    [<ExcelFunction(Name="_CoxIngersollRoss_constraint", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Constraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".CONSTRAINT") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxIngersollRoss> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_endCriteria", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".EndCriteria") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_notifyObservers", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".NotifyObservers") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_parameters", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CoxIngersollRoss> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CoxIngersollRoss_registerWith", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_setParams", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".SetParams") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_unregisterWith", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_update", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Update
                                                       ) :> ICell
                let format (o : CoxIngersollRoss) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_value", Description="Create a CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CoxIngersollRoss",Description = "CoxIngersollRoss")>] 
         coxingersollross : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "CalibrationHelper")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CoxIngersollRoss = Helper.toCell<CoxIngersollRoss> coxingersollross "CoxIngersollRoss"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = withMnemonic mnemonic ((CoxIngersollRossModel.Cast _CoxIngersollRoss.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_CoxIngersollRoss.source + ".Value") 

                                               [| _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CoxIngersollRoss.cell
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
    [<ExcelFunction(Name="_CoxIngersollRoss_Range", Description="Create a range of CoxIngersollRoss",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CoxIngersollRoss_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CoxIngersollRoss> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CoxIngersollRoss>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CoxIngersollRoss>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CoxIngersollRoss>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
