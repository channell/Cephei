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
  Square-root process class   This class describes a square-root process governed by dx = a (b - x_t) dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module SquareRootProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SquareRootProcess_diffusion", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "Reference to UnnamedParameter1")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Diffusion
                                                            _UnnamedParameter1.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Diffusion") 
                                               [| _SquareRootProcess.source
                                               ;  _UnnamedParameter1.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _UnnamedParameter1.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_drift", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "Reference to UnnamedParameter1")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Drift
                                                            _UnnamedParameter1.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Drift") 
                                               [| _SquareRootProcess.source
                                               ;  _UnnamedParameter1.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _UnnamedParameter1.cell
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
    [<ExcelFunction(Name="_SquareRootProcess2", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _b = Helper.toCell<double> b "b" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let builder () = withMnemonic mnemonic (Fun.SquareRootProcess2 
                                                            _b.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                            _x0.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SquareRootProcess>) l

                let source = Helper.sourceFold "Fun.SquareRootProcess2" 
                                               [| _b.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               ;  _x0.source
                                               |]
                let hash = Helper.hashFold 
                                [| _b.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                ;  _x0.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SquareRootProcess", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="disc",Description = "Reference to disc")>] 
         disc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _b = Helper.toCell<double> b "b" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _disc = Helper.toCell<IDiscretization1D> disc "disc" 
                let builder () = withMnemonic mnemonic (Fun.SquareRootProcess
                                                            _b.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                            _x0.cell 
                                                            _disc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SquareRootProcess>) l

                let source = Helper.sourceFold "Fun.SquareRootProcess" 
                                               [| _b.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               ;  _x0.source
                                               ;  _disc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _b.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                ;  _x0.cell
                                ;  _disc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SquareRootProcess1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _b = Helper.toCell<double> b "b" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder () = withMnemonic mnemonic (Fun.SquareRootProcess1
                                                            _b.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SquareRootProcess>) l

                let source = Helper.sourceFold "Fun.SquareRootProcess1" 
                                               [| _b.source
                                               ;  _a.source
                                               ;  _sigma.source
                                               |]
                let hash = Helper.hashFold 
                                [| _b.cell
                                ;  _a.cell
                                ;  _sigma.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        StochasticProcess interface
    *)
    [<ExcelFunction(Name="_SquareRootProcess_x0", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".X0") 
                                               [| _SquareRootProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_apply1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Apply1") 
                                               [| _SquareRootProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_apply", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Apply") 
                                               [| _SquareRootProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_evolve", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
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

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Evolve") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_evolve1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
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

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Evolve1") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_expectation", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Expectation") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_expectation1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_expectation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Expectation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Expectation1") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_initialValues", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".InitialValues") 
                                               [| _SquareRootProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SquareRootProcess_size", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Size") 
                                               [| _SquareRootProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_stdDeviation", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".StdDeviation") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_stdDeviation1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_stdDeviation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).StdDeviation1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".StdDeviation1") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_variance", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Variance") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_variance1", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_variance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Variance1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Variance1") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_covariance", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Covariance") 
                                               [| _SquareRootProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SquareRootProcess> format
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
    [<ExcelFunction(Name="_SquareRootProcess_factors", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Factors") 
                                               [| _SquareRootProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_registerWith", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SquareRootProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".RegisterWith") 
                                               [| _SquareRootProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_time", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Time") 
                                               [| _SquareRootProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_unregisterWith", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : SquareRootProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".UnregisterWith") 
                                               [| _SquareRootProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_update", Description="Create a SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SquareRootProcess",Description = "Reference to SquareRootProcess")>] 
         squarerootprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SquareRootProcess = Helper.toCell<SquareRootProcess> squarerootprocess "SquareRootProcess"  
                let builder () = withMnemonic mnemonic ((SquareRootProcessModel.Cast _SquareRootProcess.cell).Update
                                                       ) :> ICell
                let format (o : SquareRootProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SquareRootProcess.source + ".Update") 
                                               [| _SquareRootProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SquareRootProcess.cell
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
    [<ExcelFunction(Name="_SquareRootProcess_Range", Description="Create a range of SquareRootProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SquareRootProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SquareRootProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SquareRootProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SquareRootProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SquareRootProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SquareRootProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
