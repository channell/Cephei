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
module LiborForwardModelProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_accrualEndTimes", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_accrualEndTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).AccrualEndTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".AccrualEndTimes") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_accrualPeriod_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_accrualPeriod_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).AccrualPeriod_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".AccrualPeriod_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_accrualStartTimes", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_accrualStartTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).AccrualStartTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".AccrualStartTimes") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_accrualStartTimes_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_accrualStartTimes_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).AccrualStartTimes_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".AccrualStartTimes_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_apply", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dx = Helper.toCell<Vector> dx "dx" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Apply") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_cashFlows", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_cashFlows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="amount",Description = "Reference to amount")>] 
         amount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _amount = Helper.toCell<double> amount "amount" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).CashFlows
                                                            _amount.cell 
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".CashFlows") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _amount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _amount.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_cashFlows1", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_cashFlows1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).CashFlows1
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".CashFlows1") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_covariance", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Covariance
                                                            _t.cell 
                                                            _x.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Covariance") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_covarParam", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_covarParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).CovarParam
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmCovarianceParameterization>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".CovarParam") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_diffusion", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Diffusion") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_discountBond", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_discountBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="rates",Description = "Reference to rates")>] 
         rates : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _rates = Helper.toCell<Generic.List<double>> rates "rates" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).DiscountBond
                                                            _rates.cell 
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".DiscountBond") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _rates.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _rates.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_drift", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Drift") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_evolve", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
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

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<Vector> dw "dw" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Evolve") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_factors", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Factors") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_fixingDates", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_fixingDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).FixingDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".FixingDates") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_fixingDates_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_fixingDates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).FixingDates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".FixingDates_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_fixingTimes", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_fixingTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).FixingTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".FixingTimes") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_fixingTimes_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_fixingTimes_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).FixingTimes_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".FixingTimes_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_index", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Index") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_index_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_index_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Index_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Index_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_initialValues", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".InitialValues") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_initialValues_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_initialValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).InitialValues_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".InitialValues_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_lfmParam_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_lfmParam_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).LfmParam_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmCovarianceParameterization>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".LfmParam_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess1", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let builder () = withMnemonic mnemonic (Fun.LiborForwardModelProcess1
                                                            _size.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LiborForwardModelProcess>) l

                let source = Helper.sourceFold "Fun.LiborForwardModelProcess1" 
                                               [| _size.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="disc",Description = "Reference to disc")>] 
         disc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" true
                let _index = Helper.toCell<IborIndex> index "index" true
                let _disc = Helper.toCell<IDiscretization> disc "disc" true
                let builder () = withMnemonic mnemonic (Fun.LiborForwardModelProcess
                                                            _size.cell 
                                                            _index.cell 
                                                            _disc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LiborForwardModelProcess>) l

                let source = Helper.sourceFold "Fun.LiborForwardModelProcess" 
                                               [| _size.source
                                               ;  _index.source
                                               ;  _disc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_nextIndexReset", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_nextIndexReset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).NextIndexReset
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".NextIndexReset") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_setCovarParam", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_setCovarParam
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="param",Description = "Reference to param")>] 
         param : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _param = Helper.toCell<LfmCovarianceParameterization> param "param" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).SetCovarParam
                                                            _param.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModelProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".SetCovarParam") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _param.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
                                ;  _param.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_size", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Size") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_size_", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_size_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Size_
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Size_") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
        ! This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_expectation", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Expectation") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
        
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_registerWith", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModelProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".RegisterWith") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
        ! returns the standard deviation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_stdDeviation", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".StdDeviation") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
        ! returns the time value corresponding to the given date in the reference system of the stochastic process.  \note As a number of processes might not need this functionality, a default implementation is given which raises an exception.
    *)
    [<ExcelFunction(Name="_LiborForwardModelProcess_time", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Time") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_unregisterWith", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LiborForwardModelProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".UnregisterWith") 
                                               [| _LiborForwardModelProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_update", Description="Create a LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LiborForwardModelProcess",Description = "Reference to LiborForwardModelProcess")>] 
         liborforwardmodelprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LiborForwardModelProcess = Helper.toCell<LiborForwardModelProcess> liborforwardmodelprocess "LiborForwardModelProcess" true 
                let builder () = withMnemonic mnemonic ((_LiborForwardModelProcess.cell :?> LiborForwardModelProcessModel).Update
                                                       ) :> ICell
                let format (o : LiborForwardModelProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LiborForwardModelProcess.source + ".Update") 
                                               [| _LiborForwardModelProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LiborForwardModelProcess.cell
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
    [<ExcelFunction(Name="_LiborForwardModelProcess_Range", Description="Create a range of LiborForwardModelProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LiborForwardModelProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LiborForwardModelProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LiborForwardModelProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LiborForwardModelProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LiborForwardModelProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LiborForwardModelProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
