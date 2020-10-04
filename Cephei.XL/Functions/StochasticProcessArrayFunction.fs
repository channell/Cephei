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
module StochasticProcessArrayFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_apply", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Apply") 
                                               [| _StochasticProcessArray.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_correlation", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Correlation
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Correlation") 
                                               [| _StochasticProcessArray.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_covariance", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Covariance") 
                                               [| _StochasticProcessArray.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_diffusion", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Diffusion") 
                                               [| _StochasticProcessArray.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_drift", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Drift") 
                                               [| _StochasticProcessArray.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_evolve", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
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

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Evolve") 
                                               [| _StochasticProcessArray.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_expectation", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Expectation") 
                                               [| _StochasticProcessArray.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_initialValues", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".InitialValues") 
                                               [| _StochasticProcessArray.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        inspectors
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_process", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_process
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Process
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StochasticProcess1D>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".PROCESS") 
                                               [| _StochasticProcessArray.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        stochastic process interface
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_size", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Size") 
                                               [| _StochasticProcessArray.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
    [<ExcelFunction(Name="_StochasticProcessArray_stdDeviation", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".StdDeviation") 
                                               [| _StochasticProcessArray.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="processes",Description = "Reference to processes")>] 
         processes : obj)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _processes = Helper.toCell<Generic.List<StochasticProcess1D>> processes "processes" 
                let _correlation = Helper.toCell<Matrix> correlation "correlation" 
                let builder () = withMnemonic mnemonic (Fun.StochasticProcessArray 
                                                            _processes.cell 
                                                            _correlation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StochasticProcessArray>) l

                let source = Helper.sourceFold "Fun.StochasticProcessArray" 
                                               [| _processes.source
                                               ;  _correlation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _processes.cell
                                ;  _correlation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StochasticProcessArray> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_time", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Time") 
                                               [| _StochasticProcessArray.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
        ! returns the number of independent factors of the process
    *)
    [<ExcelFunction(Name="_StochasticProcessArray_factors", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Factors") 
                                               [| _StochasticProcessArray.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
    [<ExcelFunction(Name="_StochasticProcessArray_registerWith", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : StochasticProcessArray) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".RegisterWith") 
                                               [| _StochasticProcessArray.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
    [<ExcelFunction(Name="_StochasticProcessArray_unregisterWith", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : StochasticProcessArray) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".UnregisterWith") 
                                               [| _StochasticProcessArray.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
    [<ExcelFunction(Name="_StochasticProcessArray_update", Description="Create a StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StochasticProcessArray",Description = "Reference to StochasticProcessArray")>] 
         stochasticprocessarray : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StochasticProcessArray = Helper.toCell<StochasticProcessArray> stochasticprocessarray "StochasticProcessArray"  
                let builder () = withMnemonic mnemonic ((StochasticProcessArrayModel.Cast _StochasticProcessArray.cell).Update
                                                       ) :> ICell
                let format (o : StochasticProcessArray) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StochasticProcessArray.source + ".Update") 
                                               [| _StochasticProcessArray.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StochasticProcessArray.cell
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
    [<ExcelFunction(Name="_StochasticProcessArray_Range", Description="Create a range of StochasticProcessArray",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let StochasticProcessArray_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the StochasticProcessArray")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<StochasticProcessArray> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<StochasticProcessArray>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<StochasticProcessArray>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<StochasticProcessArray>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
