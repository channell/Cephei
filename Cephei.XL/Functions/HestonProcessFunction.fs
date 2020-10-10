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
  Square-root stochastic-volatility Heston process This class describes the square root stochastic volatility
  </summary> *)
[<AutoSerializable(true)>]
module HestonProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_apply", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Apply") 
                                               [| _HestonProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_diffusion", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Diffusion") 
                                               [| _HestonProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_dividendYield", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".DividendYield") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_drift", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Drift") 
                                               [| _HestonProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_evolve", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "Reference to dw")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Evolve") 
                                               [| _HestonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_factors", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Factors") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_create
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
        ([<ExcelArgument(Name="kappa",Description = "Reference to kappa")>] 
         kappa : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _riskFreeRate = Helper.toHandle<YieldTermStructure> riskFreeRate "riskFreeRate" 
                let _dividendYield = Helper.toHandle<YieldTermStructure> dividendYield "dividendYield" 
                let _s0 = Helper.toHandle<Quote> s0 "s0" 
                let _v0 = Helper.toCell<double> v0 "v0" 
                let _kappa = Helper.toCell<double> kappa "kappa" 
                let _theta = Helper.toCell<double> theta "theta" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _d = Helper.toDefault<HestonProcess.Discretization> d "d" HestonProcess.Discretization.QuadraticExponentialMartingale
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HestonProcess 
                                                            _riskFreeRate.cell 
                                                            _dividendYield.cell 
                                                            _s0.cell 
                                                            _v0.cell 
                                                            _kappa.cell 
                                                            _theta.cell 
                                                            _sigma.cell 
                                                            _rho.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonProcess>) l

                let source () = Helper.sourceFold "Fun.HestonProcess" 
                                               [| _riskFreeRate.source
                                               ;  _dividendYield.source
                                               ;  _s0.source
                                               ;  _v0.source
                                               ;  _kappa.source
                                               ;  _theta.source
                                               ;  _sigma.source
                                               ;  _rho.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _riskFreeRate.cell
                                ;  _dividendYield.cell
                                ;  _s0.cell
                                ;  _v0.cell
                                ;  _kappa.cell
                                ;  _theta.cell
                                ;  _sigma.cell
                                ;  _rho.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_initialValues", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".InitialValues") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_kappa", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_kappa
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Kappa
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Kappa") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_rho", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Rho
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Rho") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_riskFreeRate", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".RiskFreeRate") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_s0", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_s0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).S0
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".S0") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_sigma", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Sigma") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_size", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Size") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_theta", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Theta") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_time", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Time") 
                                               [| _HestonProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_HestonProcess_v0", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_v0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).V0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".V0") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
        ! returns the covariance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_HestonProcess_covariance", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Covariance") 
                                               [| _HestonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_HestonProcess_expectation", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".Expectation") 
                                               [| _HestonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_registerWith", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".RegisterWith") 
                                               [| _HestonProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
        ! returns the standard deviation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_HestonProcess_stdDeviation", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_HestonProcess.source + ".StdDeviation") 
                                               [| _HestonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HestonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HestonProcess_unregisterWith", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HestonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".UnregisterWith") 
                                               [| _HestonProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_update", Description="Create a HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HestonProcess",Description = "Reference to HestonProcess")>] 
         hestonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HestonProcess = Helper.toCell<HestonProcess> hestonprocess "HestonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HestonProcessModel.Cast _HestonProcess.cell).Update
                                                       ) :> ICell
                let format (o : HestonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HestonProcess.source + ".Update") 
                                               [| _HestonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HestonProcess.cell
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
    [<ExcelFunction(Name="_HestonProcess_Range", Description="Create a range of HestonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HestonProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HestonProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HestonProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HestonProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<HestonProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<HestonProcess>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
