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
  Hull-White stochastic process
  </summary> *)
[<AutoSerializable(true)>]
module HullWhiteProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_a", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".A") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_alpha", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Alpha
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Alpha") 
                                               [| _HullWhiteProcess.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_diffusion", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Diffusion") 
                                               [| _HullWhiteProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_drift", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Drift") 
                                               [| _HullWhiteProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_expectation", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Expectation") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _a = Helper.toCell<double> a "a" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let builder () = withMnemonic mnemonic (Fun.HullWhiteProcess 
                                                            _h.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhiteProcess>) l

                let source = Helper.sourceFold "Fun.HullWhiteProcess" 
                                               [| _h.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _h.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_sigma", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Sigma") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_stdDeviation", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".StdDeviation") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_variance", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Variance") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
        StochasticProcess1D interface
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_x0", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".X0") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_apply1", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dx = Helper.toCell<Vector> dx "dx" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Apply1") 
                                               [| _HullWhiteProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_apply", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Apply") 
                                               [| _HullWhiteProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_evolve", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
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

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<Vector> dw "dw" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Evolve") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_evolve1", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
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

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Evolve1") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
        ! returns the initial values of the state variables
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_initialValues", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".InitialValues") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_size", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Size") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_covariance", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Covariance") 
                                               [| _HullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_factors", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Factors") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_registerWith", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".RegisterWith") 
                                               [| _HullWhiteProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_time", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Time") 
                                               [| _HullWhiteProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_unregisterWith", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".UnregisterWith") 
                                               [| _HullWhiteProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_update", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "Reference to HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteProcess.cell :?> HullWhiteProcessModel).Update
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteProcess.source + ".Update") 
                                               [| _HullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_Range", Description="Create a range of HullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HullWhiteProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HullWhiteProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HullWhiteProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HullWhiteProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HullWhiteProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
