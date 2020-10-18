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
  This class describes the stochastic process S for a stock given by dS(t, S) = (r(t) - S)^2}{2}) dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module BlackScholesProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackScholesProcess")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Quote")>] 
         x0 : obj)
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
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<BlackVolTermStructure> blackVolTS "blackVolTS" 
                let _d = Helper.toCell<IDiscretization1D> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackScholesProcess 
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesProcess>) l

                let source () = Helper.sourceFold "Fun.BlackScholesProcess" 
                                               [| _x0.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess1", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackScholesProcess")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Quote")>] 
         x0 : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "YieldTermStructure")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "BlackVolTermStructure")>] 
         blackVolTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Quote> x0 "x0" 
                let _riskFreeTS = Helper.toHandle<YieldTermStructure> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<BlackVolTermStructure> blackVolTS "blackVolTS" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackScholesProcess1 
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesProcess>) l

                let source () = Helper.sourceFold "Fun.BlackScholesProcess1" 
                                               [| _x0.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess_apply", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Apply") 
                                               [| _BlackScholesProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_blackVolatility", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "BlackVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".BlackVolatility") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
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
    [<ExcelFunction(Name="_BlackScholesProcess_diffusion", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Diffusion") 
                                               [| _BlackScholesProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_dividendYield", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".DividendYield") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
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
    [<ExcelFunction(Name="_BlackScholesProcess_drift", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Drift") 
                                               [| _BlackScholesProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_evolve", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
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

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Evolve") 
                                               [| _BlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_expectation", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Expectation") 
                                               [| _BlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_localVolatility", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "LocalVolTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".LocalVolatility") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess_riskFreeRate", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "YieldTermStructure")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".RiskFreeRate") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess_stateVariable", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Quote")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".StateVariable") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess_stdDeviation", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".StdDeviation") 
                                               [| _BlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_time", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Time") 
                                               [| _BlackScholesProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_update", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Update
                                                       ) :> ICell
                let format (o : BlackScholesProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Update") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_variance", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Variance") 
                                               [| _BlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_x0", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".X0") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_initialValues", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".InitialValues") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesProcess_size", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Size") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_covariance", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Covariance") 
                                               [| _BlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesProcess> format
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
    [<ExcelFunction(Name="_BlackScholesProcess_factors", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".Factors") 
                                               [| _BlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_registerWith", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackScholesProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".RegisterWith") 
                                               [| _BlackScholesProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_unregisterWith", Description="Create a BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesProcess",Description = "BlackScholesProcess")>] 
         blackscholesprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesProcess = Helper.toCell<BlackScholesProcess> blackscholesprocess "BlackScholesProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackScholesProcessModel.Cast _BlackScholesProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackScholesProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackScholesProcess.source + ".UnregisterWith") 
                                               [| _BlackScholesProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesProcess.cell
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
    [<ExcelFunction(Name="_BlackScholesProcess_Range", Description="Create a range of BlackScholesProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackScholesProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackScholesProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackScholesProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BlackScholesProcess>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
