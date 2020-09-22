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
  processes
  </summary> *)
[<AutoSerializable(true)>]
module HullWhiteForwardProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HullWhiteForwardProcess_a", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".A") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_alpha", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Alpha
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Alpha") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_B", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_B
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="T2",Description = "Reference to T2")>] 
         T2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _T2 = Helper.toCell<double> T2 "T2" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).B
                                                            _t.cell 
                                                            _T2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".B") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t.source
                                               ;  _T2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
                                ;  _t.cell
                                ;  _T2.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_diffusion", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Diffusion") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_drift", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<double> x "x" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Drift") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_expectation", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Expectation") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_create
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
                let builder () = withMnemonic mnemonic (Fun.HullWhiteForwardProcess 
                                                            _h.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhiteForwardProcess>) l

                let source = Helper.sourceFold "Fun.HullWhiteForwardProcess" 
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_M_T", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_M_T
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="T2",Description = "Reference to T2")>] 
         T2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _s = Helper.toCell<double> s "s" true
                let _t = Helper.toCell<double> t "t" true
                let _T2 = Helper.toCell<double> T2 "T2" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).M_T
                                                            _s.cell 
                                                            _t.cell 
                                                            _T2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".M_T") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _s.source
                                               ;  _t.source
                                               ;  _T2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
                                ;  _s.cell
                                ;  _t.cell
                                ;  _T2.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_sigma", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Sigma") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_stdDeviation", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".StdDeviation") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_variance", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Variance") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_x0", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".X0") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_getForwardMeasureTime", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_getForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).GetForwardMeasureTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".GetForwardMeasureTime") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_setForwardMeasureTime", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_setForwardMeasureTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _T = Helper.toCell<double> T "T" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).SetForwardMeasureTime
                                                            _T.cell 
                                                       ) :> ICell
                let format (o : HullWhiteForwardProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".SetForwardMeasureTime") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
                                ;  _T.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_apply1", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dx = Helper.toCell<Vector> dx "dx" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Apply1") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_apply", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dx = Helper.toCell<double> dx "dx" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Apply") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_evolve", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
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

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<Vector> dw "dw" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Evolve") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_evolve1", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
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

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let _dw = Helper.toCell<double> dw "dw" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Evolve1") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_initialValues", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".InitialValues") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_size", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Size") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_covariance", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Covariance") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_factors", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Factors") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_registerWith", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteForwardProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".RegisterWith") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_time", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _d = Helper.toCell<Date> d "d" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Time") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_unregisterWith", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteForwardProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".UnregisterWith") 
                                               [| _HullWhiteForwardProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_update", Description="Create a HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteForwardProcess",Description = "Reference to HullWhiteForwardProcess")>] 
         hullwhiteforwardprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteForwardProcess = Helper.toCell<HullWhiteForwardProcess> hullwhiteforwardprocess "HullWhiteForwardProcess" true 
                let builder () = withMnemonic mnemonic ((_HullWhiteForwardProcess.cell :?> HullWhiteForwardProcessModel).Update
                                                       ) :> ICell
                let format (o : HullWhiteForwardProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HullWhiteForwardProcess.source + ".Update") 
                                               [| _HullWhiteForwardProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteForwardProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteForwardProcess_Range", Description="Create a range of HullWhiteForwardProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HullWhiteForwardProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HullWhiteForwardProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HullWhiteForwardProcess> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HullWhiteForwardProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HullWhiteForwardProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HullWhiteForwardProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
