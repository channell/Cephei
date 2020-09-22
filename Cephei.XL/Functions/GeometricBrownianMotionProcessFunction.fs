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
  This class describes the stochastic process governed by dS(t, S)= S dt + S dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module GeometricBrownianMotionProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_diffusion", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Diffusion") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_drift", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Drift") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="initialValue",Description = "Reference to initialValue")>] 
         initialValue : obj)
        ([<ExcelArgument(Name="mue",Description = "Reference to mue")>] 
         mue : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _initialValue = Helper.toCell<double> initialValue "initialValue" true
                let _mue = Helper.toCell<double> mue "mue" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.GeometricBrownianMotionProcess 
                                                            _initialValue.cell 
                                                            _mue.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GeometricBrownianMotionProcess>) l

                let source = Helper.sourceFold "Fun.GeometricBrownianMotionProcess" 
                                               [| _initialValue.source
                                               ;  _mue.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _initialValue.cell
                                ;  _mue.cell
                                ;  _sigma.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_x0", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".X0") 
                                               [| _GeometricBrownianMotionProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_apply1", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dx = Helper.toCell<Vector> dx "dx" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Apply1") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        applies a change to the asset value.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_apply", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Apply") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_evolve", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
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

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<Vector> dw "dw" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Evolve") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        returns the asset value after a time interval.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_evolve1", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
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

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Evolve1") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_expectation", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Expectation") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the expectation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_expectation1", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_expectation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Expectation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Expectation1") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the initial values of the state variables
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_initialValues", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".InitialValues") 
                                               [| _GeometricBrownianMotionProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_size", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Size") 
                                               [| _GeometricBrownianMotionProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_stdDeviation", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".StdDeviation") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the standard deviation. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_stdDeviation1", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_stdDeviation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).StdDeviation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".StdDeviation1") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_variance", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Variance") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the variance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_variance1", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_variance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Variance1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Variance1") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the covariance. This method can be overridden in derived classes which want to hard-code a particular discretization.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_covariance", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Covariance") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_factors", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Factors") 
                                               [| _GeometricBrownianMotionProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_registerWith", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GeometricBrownianMotionProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".RegisterWith") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
        ! returns the time value corresponding to the given date in the reference system of the stochastic process.  \note As a number of processes might not need this functionality, a default implementation is given which raises an exception.
    *)
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_time", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Time") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_unregisterWith", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GeometricBrownianMotionProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".UnregisterWith") 
                                               [| _GeometricBrownianMotionProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_update", Description="Create a GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GeometricBrownianMotionProcess",Description = "Reference to GeometricBrownianMotionProcess")>] 
         geometricbrownianmotionprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GeometricBrownianMotionProcess = Helper.toCell<GeometricBrownianMotionProcess> geometricbrownianmotionprocess "GeometricBrownianMotionProcess" true 
                let builder () = withMnemonic mnemonic ((_GeometricBrownianMotionProcess.cell :?> GeometricBrownianMotionProcessModel).Update
                                                       ) :> ICell
                let format (o : GeometricBrownianMotionProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GeometricBrownianMotionProcess.source + ".Update") 
                                               [| _GeometricBrownianMotionProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GeometricBrownianMotionProcess.cell
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
    [<ExcelFunction(Name="_GeometricBrownianMotionProcess_Range", Description="Create a range of GeometricBrownianMotionProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GeometricBrownianMotionProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GeometricBrownianMotionProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GeometricBrownianMotionProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GeometricBrownianMotionProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GeometricBrownianMotionProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GeometricBrownianMotionProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
