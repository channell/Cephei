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
  This class describes the stochastic process for a stock or stock index paying a continuous dividend yield given by dS(t, S) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module BlackScholesMertonProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackScholesMertonProcess")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Quote")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "YieldTermStructure")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "YieldTermStructure")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "BlackVolTermStructure")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="d",Description = "IDiscretization1D")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Quote> x0 "x0" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<BlackVolTermStructure> blackVolTS "blackVolTS" 
                let _d = Helper.toCell<IDiscretization1D> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackScholesMertonProcess 
                                                            _x0.cell 
                                                            _dividendTS.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesMertonProcess>) l

                let source () = Helper.sourceFold "Fun.BlackScholesMertonProcess" 
                                               [| _x0.source
                                               ;  _dividendTS.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _dividendTS.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess1", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackScholesMertonProcess")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Quote")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "YieldTermStructure")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "YieldTermStructure")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "BlackVolTermStructure")>] 
         blackVolTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Quote> x0 "x0" 
                let _dividendTS = Helper.toHandle<YieldTermStructure> dividendTS "dividendTS" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<BlackVolTermStructure> blackVolTS "blackVolTS" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackScholesMertonProcess1 
                                                            _x0.cell 
                                                            _dividendTS.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesMertonProcess>) l

                let source () = Helper.sourceFold "Fun.BlackScholesMertonProcess1" 
                                               [| _x0.source
                                               ;  _dividendTS.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _dividendTS.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_apply", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Apply") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_blackVolatility", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".BlackVolatility") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \todo revise extrapolation
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_diffusion", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Diffusion") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_dividendYield", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".DividendYield") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \todo revise extrapolation
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_drift", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Drift") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_evolve", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "double")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Evolve") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
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
        ! \warning raises a "not implemented" exception.  It should be rewritten to return the expectation E(S) of the process, not exp(E(log S)).
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_expectation", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Expectation") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_localVolatility", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".LocalVolatility") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_riskFreeRate", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".RiskFreeRate") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_stateVariable", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".StateVariable") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_stdDeviation", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".StdDeviation") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_time", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Time") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_update", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Update
                                                       ) :> ICell
                let format (o : BlackScholesMertonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Update") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_variance", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Variance") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_x0", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".X0") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
        ! returns the initial values of the state variables
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_initialValues", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".InitialValues") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_size", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Size") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_covariance", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Covariance") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesMertonProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the number of independent factors of the process
    *)
    [<ExcelFunction(Name="_BlackScholesMertonProcess_factors", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".Factors") 
                                               [| _BlackScholesMertonProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_registerWith", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackScholesMertonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".RegisterWith") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_unregisterWith", Description="Create a BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesMertonProcess",Description = "BlackScholesMertonProcess")>] 
         blackscholesmertonprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesMertonProcess = Helper.toCell<BlackScholesMertonProcess> blackscholesmertonprocess "BlackScholesMertonProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesMertonProcessModel.Cast _BlackScholesMertonProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackScholesMertonProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesMertonProcess.source + ".UnregisterWith") 
                                               [| _BlackScholesMertonProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesMertonProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesMertonProcess_Range", Description="Create a range of BlackScholesMertonProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesMertonProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackScholesMertonProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackScholesMertonProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackScholesMertonProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BlackScholesMertonProcess>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
