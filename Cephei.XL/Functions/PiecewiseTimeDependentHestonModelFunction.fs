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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Elices, Models with time-dependent parameters using transform methods: application to Heston’s model, http://arxiv.org/pdf/0708.2020
  </summary> *)
[<AutoSerializable(true)>]
module PiecewiseTimeDependentHestonModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_dividendYield", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".DividendYield") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_kappa", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_kappa
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Kappa
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Kappa") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="riskFreeRate",Description = "Reference to riskFreeRate")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="dividendYield",Description = "Reference to dividendYield")>] 
         dividendYield : obj)
        ([<ExcelArgument(Name="s0",Description = "Reference to s0")>] 
         s0 : obj)
        ([<ExcelArgument(Name="v0",Description = "Reference to v0")>] 
         v0 : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="kappa",Description = "Reference to kappa")>] 
         kappa : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "Reference to timeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _riskFreeRate = Helper.toHandle<YieldTermStructure> riskFreeRate "riskFreeRate" 
                let _dividendYield = Helper.toHandle<YieldTermStructure> dividendYield "dividendYield" 
                let _s0 = Helper.toHandle<Quote> s0 "s0" 
                let _v0 = Helper.toCell<double> v0 "v0" 
                let _theta = Helper.toCell<Parameter> theta "theta" 
                let _kappa = Helper.toCell<Parameter> kappa "kappa" 
                let _sigma = Helper.toCell<Parameter> sigma "sigma" 
                let _rho = Helper.toCell<Parameter> rho "rho" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.PiecewiseTimeDependentHestonModel 
                                                            _riskFreeRate.cell 
                                                            _dividendYield.cell 
                                                            _s0.cell 
                                                            _v0.cell 
                                                            _theta.cell 
                                                            _kappa.cell 
                                                            _sigma.cell 
                                                            _rho.cell 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PiecewiseTimeDependentHestonModel>) l

                let source () = Helper.sourceFold "Fun.PiecewiseTimeDependentHestonModel" 
                                               [| _riskFreeRate.source
                                               ;  _dividendYield.source
                                               ;  _s0.source
                                               ;  _v0.source
                                               ;  _theta.source
                                               ;  _kappa.source
                                               ;  _sigma.source
                                               ;  _rho.source
                                               ;  _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _riskFreeRate.cell
                                ;  _dividendYield.cell
                                ;  _s0.cell
                                ;  _v0.cell
                                ;  _theta.cell
                                ;  _kappa.cell
                                ;  _sigma.cell
                                ;  _rho.cell
                                ;  _timeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_rho", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Rho
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Rho") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_riskFreeRate", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".RiskFreeRate") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        spot
    *)
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_s0", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_s0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).S0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".S0") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_sigma", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Sigma
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Sigma") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
        variance mean version level
    *)
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_theta", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Theta
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Theta") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_timeGrid", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".TimeGrid") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_v0", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_v0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).V0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".V0") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_calibrate", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_calibrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
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

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let _Method = Helper.toCell<OptimizationMethod> Method "Method" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let _additionalConstraint = Helper.toCell<Constraint> additionalConstraint "additionalConstraint" 
                let _weights = Helper.toCell<Generic.List<double>> weights "weights" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Calibrate
                                                            _instruments.cell 
                                                            _Method.cell 
                                                            _endCriteria.cell 
                                                            _additionalConstraint.cell 
                                                            _weights.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Calibrate") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _instruments.source
                                               ;  _Method.source
                                               ;  _endCriteria.source
                                               ;  _additionalConstraint.source
                                               ;  _weights.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_constraint", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".CONSTRAINT") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_endCriteria", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".EndCriteria") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_notifyObservers", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_notifyObservers
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).NotifyObservers
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".NotifyObservers") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_parameters", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Parameters
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Parameters") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PiecewiseTimeDependentHestonModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_registerWith", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".RegisterWith") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_setParams", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).SetParams
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".SetParams") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_unregisterWith", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".UnregisterWith") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_update", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Update
                                                       ) :> ICell
                let format (o : PiecewiseTimeDependentHestonModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Update") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_value", Description="Create a PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PiecewiseTimeDependentHestonModel",Description = "Reference to PiecewiseTimeDependentHestonModel")>] 
         piecewisetimedependenthestonmodel : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        ([<ExcelArgument(Name="instruments",Description = "Reference to instruments")>] 
         instruments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PiecewiseTimeDependentHestonModel = Helper.toCell<PiecewiseTimeDependentHestonModel> piecewisetimedependenthestonmodel "PiecewiseTimeDependentHestonModel"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let _instruments = Helper.toCell<Generic.List<CalibrationHelper>> instruments "instruments" 
                let builder (current : ICell) = withMnemonic mnemonic ((PiecewiseTimeDependentHestonModelModel.Cast _PiecewiseTimeDependentHestonModel.cell).Value
                                                            _parameters.cell 
                                                            _instruments.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_PiecewiseTimeDependentHestonModel.source + ".Value") 
                                               [| _PiecewiseTimeDependentHestonModel.source
                                               ;  _parameters.source
                                               ;  _instruments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PiecewiseTimeDependentHestonModel.cell
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
    [<ExcelFunction(Name="_PiecewiseTimeDependentHestonModel_Range", Description="Create a range of PiecewiseTimeDependentHestonModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let PiecewiseTimeDependentHestonModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PiecewiseTimeDependentHestonModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PiecewiseTimeDependentHestonModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PiecewiseTimeDependentHestonModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<PiecewiseTimeDependentHestonModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<PiecewiseTimeDependentHestonModel>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
