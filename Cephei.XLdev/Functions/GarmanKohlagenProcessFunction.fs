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
  This class describes the stochastic process for an exchange rate given by dS(t, S) = (r(t) - r_f(t) - S)^2}{2}) dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module GarmanKohlagenProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GarmanKohlagenProcess", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="foreignRiskFreeTS",Description = "Reference to foreignRiskFreeTS")>] 
         foreignRiskFreeTS : obj)
        ([<ExcelArgument(Name="domesticRiskFreeTS",Description = "Reference to domesticRiskFreeTS")>] 
         domesticRiskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _foreignRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> foreignRiskFreeTS "foreignRiskFreeTS" 
                let _domesticRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> domesticRiskFreeTS "domesticRiskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let builder () = withMnemonic mnemonic (Fun.GarmanKohlagenProcess 
                                                            _x0.cell 
                                                            _foreignRiskFreeTS.cell 
                                                            _domesticRiskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GarmanKohlagenProcess>) l

                let source = Helper.sourceFold "Fun.GarmanKohlagenProcess" 
                                               [| _x0.source
                                               ;  _foreignRiskFreeTS.source
                                               ;  _domesticRiskFreeTS.source
                                               ;  _blackVolTS.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _foreignRiskFreeTS.cell
                                ;  _domesticRiskFreeTS.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess1", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="foreignRiskFreeTS",Description = "Reference to foreignRiskFreeTS")>] 
         foreignRiskFreeTS : obj)
        ([<ExcelArgument(Name="domesticRiskFreeTS",Description = "Reference to domesticRiskFreeTS")>] 
         domesticRiskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _foreignRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> foreignRiskFreeTS "foreignRiskFreeTS" 
                let _domesticRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> domesticRiskFreeTS "domesticRiskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let _d = Helper.toCell<IDiscretization1D> d "d" true
                let builder () = withMnemonic mnemonic (Fun.GarmanKohlagenProcess1 
                                                            _x0.cell 
                                                            _foreignRiskFreeTS.cell 
                                                            _domesticRiskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GarmanKohlagenProcess>) l

                let source = Helper.sourceFold "Fun.GarmanKohlagenProcess1" 
                                               [| _x0.source
                                               ;  _foreignRiskFreeTS.source
                                               ;  _domesticRiskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _foreignRiskFreeTS.cell
                                ;  _domesticRiskFreeTS.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess2", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="foreignRiskFreeTS",Description = "Reference to foreignRiskFreeTS")>] 
         foreignRiskFreeTS : obj)
        ([<ExcelArgument(Name="domesticRiskFreeTS",Description = "Reference to domesticRiskFreeTS")>] 
         domesticRiskFreeTS : obj)
        ([<ExcelArgument(Name="blackVolTS",Description = "Reference to blackVolTS")>] 
         blackVolTS : obj)
        ([<ExcelArgument(Name="localVolTS",Description = "Reference to localVolTS")>] 
         localVolTS : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x0 = Helper.toHandle<Handle<Quote>> x0 "x0" 
                let _foreignRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> foreignRiskFreeTS "foreignRiskFreeTS" 
                let _domesticRiskFreeTS = Helper.toHandle<Handle<YieldTermStructure>> domesticRiskFreeTS "domesticRiskFreeTS" 
                let _blackVolTS = Helper.toHandle<Handle<BlackVolTermStructure>> blackVolTS "blackVolTS" 
                let _localVolTS = Helper.toCell<RelinkableHandle<LocalVolTermStructure>> localVolTS "localVolTS" true
                let _d = Helper.toCell<IDiscretization1D> d "d" true
                let builder () = withMnemonic mnemonic (Fun.GarmanKohlagenProcess2 
                                                            _x0.cell 
                                                            _foreignRiskFreeTS.cell 
                                                            _domesticRiskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _localVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GarmanKohlagenProcess>) l

                let source = Helper.sourceFold "Fun.GarmanKohlagenProcess2" 
                                               [| _x0.source
                                               ;  _foreignRiskFreeTS.source
                                               ;  _domesticRiskFreeTS.source
                                               ;  _blackVolTS.source
                                               ;  _localVolTS.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x0.cell
                                ;  _foreignRiskFreeTS.cell
                                ;  _domesticRiskFreeTS.cell
                                ;  _blackVolTS.cell
                                ;  _localVolTS.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_apply", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Apply") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_blackVolatility", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".BlackVolatility") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_diffusion", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Diffusion") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_dividendYield", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".DividendYield") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_drift", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Drift") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_evolve", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
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

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Evolve") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_expectation", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Expectation") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_localVolatility", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".LocalVolatility") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_riskFreeRate", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".RiskFreeRate") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_stateVariable", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".StateVariable") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_stdDeviation", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".StdDeviation") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_time", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Time") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_update", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Update
                                                       ) :> ICell
                let format (o : GarmanKohlagenProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Update") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_variance", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Variance") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_x0", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".X0") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_initialValues", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".InitialValues") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_size", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Size") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_covariance", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Covariance") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_factors", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".Factors") 
                                               [| _GarmanKohlagenProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_registerWith", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GarmanKohlagenProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".RegisterWith") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_unregisterWith", Description="Create a GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GarmanKohlagenProcess",Description = "Reference to GarmanKohlagenProcess")>] 
         garmankohlagenprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GarmanKohlagenProcess = Helper.toCell<GarmanKohlagenProcess> garmankohlagenprocess "GarmanKohlagenProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GarmanKohlagenProcess.cell :?> GarmanKohlagenProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GarmanKohlagenProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GarmanKohlagenProcess.source + ".UnregisterWith") 
                                               [| _GarmanKohlagenProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GarmanKohlagenProcess.cell
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
    [<ExcelFunction(Name="_GarmanKohlagenProcess_Range", Description="Create a range of GarmanKohlagenProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GarmanKohlagenProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GarmanKohlagenProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GarmanKohlagenProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GarmanKohlagenProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GarmanKohlagenProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GarmanKohlagenProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
