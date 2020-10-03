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
  This class implements a three factor Heston Hull-White model  This class was not tested enough to guarantee its functionality... work in progress  processes
  </summary> *)
[<AutoSerializable(true)>]
module HybridHestonHullWhiteProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_apply", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Reference to dx")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Apply") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_diffusion", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Diffusion
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Diffusion") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_discretization", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_discretization
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Discretization
                                                       ) :> ICell
                let format (o : HestonProcess.Discretization) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Discretization") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_drift", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Drift
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Drift") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_eta", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_eta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Eta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Eta") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_evolve", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
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

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Evolve") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_hestonProcess", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_hestonProcess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).HestonProcess
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HestonProcess>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".HestonProcess") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_hullWhiteProcess", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_hullWhiteProcess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).HullWhiteProcess
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HullWhiteForwardProcess>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".HullWhiteProcess") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="hestonProcess",Description = "Reference to hestonProcess")>] 
         hestonProcess : obj)
        ([<ExcelArgument(Name="hullWhiteProcess",Description = "Reference to hullWhiteProcess")>] 
         hullWhiteProcess : obj)
        ([<ExcelArgument(Name="corrEquityShortRate",Description = "Reference to corrEquityShortRate")>] 
         corrEquityShortRate : obj)
        ([<ExcelArgument(Name="discretization",Description = "Reference to discretization")>] 
         discretization : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _hestonProcess = Helper.toCell<HestonProcess> hestonProcess "hestonProcess" 
                let _hullWhiteProcess = Helper.toCell<HullWhiteForwardProcess> hullWhiteProcess "hullWhiteProcess" 
                let _corrEquityShortRate = Helper.toCell<double> corrEquityShortRate "corrEquityShortRate" 
                let _discretization = Helper.toDefault<HybridHestonHullWhiteProcess.Discretization> discretization "discretization" HybridHestonHullWhiteProcess.Discretization.BSMHullWhite
                let builder () = withMnemonic mnemonic (Fun.HybridHestonHullWhiteProcess 
                                                            _hestonProcess.cell 
                                                            _hullWhiteProcess.cell 
                                                            _corrEquityShortRate.cell 
                                                            _discretization.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<HybridHestonHullWhiteProcess>) l

                let source = Helper.sourceFold "Fun.HybridHestonHullWhiteProcess" 
                                               [| _hestonProcess.source
                                               ;  _hullWhiteProcess.source
                                               ;  _corrEquityShortRate.source
                                               ;  _discretization.source
                                               |]
                let hash = Helper.hashFold 
                                [| _hestonProcess.cell
                                ;  _hullWhiteProcess.cell
                                ;  _corrEquityShortRate.cell
                                ;  _discretization.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_initialValues", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".InitialValues") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_numeraire", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_numeraire
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Numeraire
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Numeraire") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_size", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Size") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_time", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Time
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Time") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_update", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Update
                                                       ) :> ICell
                let format (o : HybridHestonHullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Update") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_covariance", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Covariance") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_expectation", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Expectation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Expectation") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_factors", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".Factors") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_registerWith", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HybridHestonHullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".RegisterWith") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_stdDeviation", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).StdDeviation
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".StdDeviation") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<HybridHestonHullWhiteProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_unregisterWith", Description="Create a HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="HybridHestonHullWhiteProcess",Description = "Reference to HybridHestonHullWhiteProcess")>] 
         hybridhestonhullwhiteprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _HybridHestonHullWhiteProcess = Helper.toCell<HybridHestonHullWhiteProcess> hybridhestonhullwhiteprocess "HybridHestonHullWhiteProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((HybridHestonHullWhiteProcessModel.Cast _HybridHestonHullWhiteProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : HybridHestonHullWhiteProcess) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_HybridHestonHullWhiteProcess.source + ".UnregisterWith") 
                                               [| _HybridHestonHullWhiteProcess.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _HybridHestonHullWhiteProcess.cell
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
    [<ExcelFunction(Name="_HybridHestonHullWhiteProcess_Range", Description="Create a range of HybridHestonHullWhiteProcess",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let HybridHestonHullWhiteProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the HybridHestonHullWhiteProcess")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<HybridHestonHullWhiteProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<HybridHestonHullWhiteProcess>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<HybridHestonHullWhiteProcess>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<HybridHestonHullWhiteProcess>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
