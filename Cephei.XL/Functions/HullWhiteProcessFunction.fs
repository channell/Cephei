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
    [<ExcelFunction(Name="_HullWhiteProcess_a", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).A
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".A") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_alpha", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Alpha
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Alpha") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_diffusion", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Diffusion") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_drift", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Drift") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_expectation", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Expectation") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_HullWhiteProcess", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="h",Description = "YieldTermStructure")>] 
         h : obj)
        ([<ExcelArgument(Name="a",Description = "double")>] 
         a : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let _a = Helper.toCell<double> a "a" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.HullWhiteProcess 
                                                            _h.cell 
                                                            _a.cell 
                                                            _sigma.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhiteProcess>) l

                let source () = Helper.sourceFold "Fun.HullWhiteProcess" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_sigma", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_sigma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Sigma
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Sigma") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_stdDeviation", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".StdDeviation") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_HullWhiteProcess_variance", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Variance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Variance") 

                                               [| _t0.source
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
        StochasticProcess1D interface
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_x0", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".X0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_apply1", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Vector")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Apply1") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhiteProcess> format
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
    [<ExcelFunction(Name="_HullWhiteProcess_apply", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_evolve", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "Vector")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Evolve") 

                                               [| _t0.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhiteProcess> format
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
    [<ExcelFunction(Name="_HullWhiteProcess_evolve1", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
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

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Evolve1") 

                                               [| _t0.source
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
    [<ExcelFunction(Name="_HullWhiteProcess_initialValues", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".InitialValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_size", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_covariance", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Covariance") 

                                               [| _t0.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HullWhiteProcess> format
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
    [<ExcelFunction(Name="_HullWhiteProcess_factors", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_registerWith", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
        ! returns the time value corresponding to the given date in the reference system of the stochastic process.  \note As a number of processes might not need this functionality, a default implementation is given which raises an exception.
    *)
    [<ExcelFunction(Name="_HullWhiteProcess_time", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Time") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_unregisterWith", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_update", Description="Create a HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HullWhiteProcess",Description = "HullWhiteProcess")>] 
         hullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HullWhiteProcess = Helper.toCell<HullWhiteProcess> hullwhiteprocess "HullWhiteProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((HullWhiteProcessModel.Cast _HullWhiteProcess.cell).Update
                                                       ) :> ICell
                let format (o : HullWhiteProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_HullWhiteProcess.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _HullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HullWhiteProcess_Range", Description="Create a range of HullWhiteProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let HullWhiteProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HullWhiteProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<HullWhiteProcess> (c)) :> ICell
                let format (i : Generic.List<ICell<HullWhiteProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<HullWhiteProcess>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
