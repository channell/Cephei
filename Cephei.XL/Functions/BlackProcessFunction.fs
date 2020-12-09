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
    [<ExcelFunction(Name="_BlackProcess1", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackProcess1 
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackProcess>) l

                let source () = Helper.sourceFold "Fun.BlackProcess1" 
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
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BlackProcess
                                                            _x0.cell 
                                                            _riskFreeTS.cell 
                                                            _blackVolTS.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackProcess>) l

                let source () = Helper.sourceFold "Fun.BlackProcess" 
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
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess_apply", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_blackVolatility", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_blackVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).BlackVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<BlackVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".BlackVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
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
    [<ExcelFunction(Name="_BlackProcess_diffusion", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Diffusion") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_dividendYield", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_dividendYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).DividendYield
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".DividendYield") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
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
    [<ExcelFunction(Name="_BlackProcess_drift", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Drift") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_evolve", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
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

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Evolve") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_BlackProcess_expectation", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Expectation") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_BlackProcess_localVolatility", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_localVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).LocalVolatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<LocalVolTermStructure>>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".LocalVolatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess_riskFreeRate", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).RiskFreeRate
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".RiskFreeRate") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess_stateVariable", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_stateVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).StateVariable
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<Quote>>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".StateVariable") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess_stdDeviation", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".StdDeviation") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_BlackProcess_time", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Time") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_update", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Update
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_variance", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Variance") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_BlackProcess_x0", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".X0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_initialValues", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".InitialValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackProcess_size", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_covariance", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_BlackProcess.source + ".Covariance") 

                                               [| _t0.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackProcess> format
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
    [<ExcelFunction(Name="_BlackProcess_factors", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_registerWith", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_unregisterWith", Description="Create a BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackProcess",Description = "BlackProcess")>] 
         blackprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackProcess = Helper.toCell<BlackProcess> blackprocess "BlackProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((BlackProcessModel.Cast _BlackProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : BlackProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BlackProcess.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackProcess.cell
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
    [<ExcelFunction(Name="_BlackProcess_Range", Description="Create a range of BlackProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BlackProcess> (c)) :> ICell
                let format (i : Generic.List<ICell<BlackProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BlackProcess>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
