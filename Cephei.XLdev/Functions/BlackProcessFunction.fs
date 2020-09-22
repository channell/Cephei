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
  This class describes the stochastic process for a forward or futures contract given by dS(t, S) = S)^2}{2} dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module BlackProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _riskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let builder () = withMnemonic mnemonic (Fun.BlackProcess 
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackProcess>) l

                let source = Helper.sourceFold "Fun.BlackProcess" 
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
    [<ExcelFunction(Name="_BlackProcess1", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _riskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let _d = Helper.toCell<IDiscretization1D> d "d" true
                let builder () = withMnemonic mnemonic (Fun.BlackProcess1 
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackProcess>) l

                let source = Helper.sourceFold "Fun.BlackProcess1" 
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
    [<ExcelFunction(Name="_BlackProcess_apply", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Apply") 
                                               [| _BlackProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
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
    [<ExcelFunction(Name="_BlackProcess_blackVolatility", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".BlackVolatility") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
        ! \todo revise extrapolation
    *)
    [<ExcelFunction(Name="_BlackProcess_diffusion", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Diffusion") 
                                               [| _BlackProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackProcess_dividendYield", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".DividendYield") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
        ! \todo revise extrapolation
    *)
    [<ExcelFunction(Name="_BlackProcess_drift", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Drift") 
                                               [| _BlackProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_BlackProcess_evolve", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
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

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Evolve") 
                                               [| _BlackProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
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
        ! \warning raises a "not implemented" exception.  It should be rewritten to return the expectation E(S) of the process, not exp(E(log S)).
    *)
    [<ExcelFunction(Name="_BlackProcess_expectation", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Expectation") 
                                               [| _BlackProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackProcess_localVolatility", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".LocalVolatility") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_riskFreeRate", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".RiskFreeRate") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_stateVariable", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".StateVariable") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_stdDeviation", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".StdDeviation") 
                                               [| _BlackProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackProcess_time", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Time") 
                                               [| _BlackProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_BlackProcess_update", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Update
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Update") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_variance", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Variance") 
                                               [| _BlackProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
    [<ExcelFunction(Name="_BlackProcess_x0", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".X0") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
        ! returns the initial values of the state variables
    *)
    [<ExcelFunction(Name="_BlackProcess_initialValues", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".InitialValues") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_size", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Size") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
        ! returns the covariance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_BlackProcess_covariance", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_BlackProcess.source + ".Covariance") 
                                               [| _BlackProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
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
        ! returns the number of independent factors of the process
    *)
    [<ExcelFunction(Name="_BlackProcess_factors", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".Factors") 
                                               [| _BlackProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_registerWith", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".RegisterWith") 
                                               [| _BlackProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_unregisterWith", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "Reference to BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_BlackProcess.cell :?> BlackProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackProcess.source + ".UnregisterWith") 
                                               [| _BlackProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_Range", Description="Create a range of BlackProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
