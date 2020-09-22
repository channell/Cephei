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
  This class describes the stochastic process S governed by  S(t) = (r(t) - q(t) - S)^2}{2}) dt + dW_t.  while the interface is expressed in terms of S the internal calculations work on ln S  processes
  </summary> *)
[<AutoSerializable(true)>]
module GeneralizedBlackScholesProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_apply", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Apply") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_blackVolatility", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".BlackVolatility") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_diffusion", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Diffusion") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_dividendYield", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".DividendYield") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_drift", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Drift") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_evolve", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
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

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Evolve") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_expectation", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Expectation") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "Reference to dividendTS")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="disc",Description = "Reference to disc")>] 
         disc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _dividendTS = Helper.toHandle<Handle<YieldTermStructure>> dividendTS "dividendTS" 
                let _riskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let _disc = Helper.toCell<IDiscretization1D> disc "disc" true
                let builder () = withMnemonic mnemonic (Fun.GeneralizedBlackScholesProcess 
                                                            _x0.cell 
                                                            _dividendTS.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _disc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeneralizedBlackScholesProcess>) l

                let source = Helper.sourceFold "Fun.GeneralizedBlackScholesProcess" 
                                               [| _x0.source
                                               ;  _dividendTS.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _disc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _dividendTS.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                ;  _disc.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess1", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dividendTS",Description = "Reference to dividendTS")>] 
         dividendTS : obj)
        ([<ExcelArgument(Name="riskFreeTS",Description = "Reference to riskFreeTS")>] 
         riskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="localVolTS",Description = "Reference to localVolTS")>] 
         localVolTS : obj)
        ([<ExcelArgument(Name="disc",Description = "Reference to disc")>] 
         disc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _dividendTS = Helper.toHandle<Handle<YieldTermStructure>> dividendTS "dividendTS" 
                let _riskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> riskFreeTS "riskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let _localVolTS = Helper.toCell<RelinkableHandle<LocalVolTermStructure>> localVolTS "localVolTS" true
                let _disc = Helper.toCell<IDiscretization1D> disc "disc" true
                let builder () = withMnemonic mnemonic (Fun.GeneralizedBlackScholesProcess1 
                                                            _x0.cell 
                                                            _dividendTS.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _localVolTS.cell 
                                                            _disc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeneralizedBlackScholesProcess>) l

                let source = Helper.sourceFold "Fun.GeneralizedBlackScholesProcess1" 
                                               [| _x0.source
                                               ;  _dividendTS.source
                                               ;  _riskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _localVolTS.source
                                               ;  _disc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _dividendTS.cell
                                ;  _riskFreeTS.cell
                                ;  _blackVolTS.cell
                                ;  _localVolTS.cell
                                ;  _disc.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_localVolatility", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".LocalVolatility") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_riskFreeRate", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".RiskFreeRate") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_stateVariable", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".StateVariable") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_stdDeviation", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".StdDeviation") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_time", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Time") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_update", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Update
                                                       ) :> ICell
                let format (o : GeneralizedBlackScholesProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Update") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_variance", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Variance") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_x0", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".X0") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_initialValues", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".InitialValues") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_size", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Size") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_covariance", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Covariance") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_factors", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".Factors") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_registerWith", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GeneralizedBlackScholesProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".RegisterWith") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_unregisterWith", Description="Create a GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeneralizedBlackScholesProcess",Description = "Reference to GeneralizedBlackScholesProcess")>] 
         generalizedblackscholesprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeneralizedBlackScholesProcess = Helper.toCell<GeneralizedBlackScholesProcess> generalizedblackscholesprocess "GeneralizedBlackScholesProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GeneralizedBlackScholesProcess.cell :?> GeneralizedBlackScholesProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GeneralizedBlackScholesProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeneralizedBlackScholesProcess.source + ".UnregisterWith") 
                                               [| _GeneralizedBlackScholesProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeneralizedBlackScholesProcess.cell
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
    [<ExcelFunction(Name="_GeneralizedBlackScholesProcess_Range", Description="Create a range of GeneralizedBlackScholesProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeneralizedBlackScholesProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GeneralizedBlackScholesProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GeneralizedBlackScholesProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GeneralizedBlackScholesProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GeneralizedBlackScholesProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GeneralizedBlackScholesProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
