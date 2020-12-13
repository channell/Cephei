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
  This class describes the Ornstein-Uhlenbeck process governed by dx = a (r - x_t) dt + dW_t.  processes
  </summary> *)
[<AutoSerializable(true)>]
module OrnsteinUhlenbeckProcessFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_diffusion", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "double")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="UnnamedParameter2",Description = "double")>] 
         UnnamedParameter2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _UnnamedParameter2 = Helper.toCell<double> UnnamedParameter2 "UnnamedParameter2" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Diffusion
                                                            _UnnamedParameter1.cell 
                                                            _UnnamedParameter2.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Diffusion") 

                                               [| _UnnamedParameter1.source
                                               ;  _UnnamedParameter2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _UnnamedParameter1.cell
                                ;  _UnnamedParameter2.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_drift", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "double")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Drift
                                                            _UnnamedParameter1.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Drift") 

                                               [| _UnnamedParameter1.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _UnnamedParameter1.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_expectation", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_expectation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "double")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="x0",Description = "OrnsteinUhlenbeckProcess")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _x0 = Helper.toDefault<double> x0 "x0" 0.0
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Expectation
                                                            _UnnamedParameter1.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Expectation") 

                                               [| _UnnamedParameter1.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _UnnamedParameter1.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_level", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_level
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Level
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Level") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="speed",Description = "double")>] 
         speed : obj)
        ([<ExcelArgument(Name="vol",Description = "double")>] 
         vol : obj)
        ([<ExcelArgument(Name="x0",Description = "double or empty")>] 
         x0 : obj)
        ([<ExcelArgument(Name="level",Description = "double or empty")>] 
         level : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _speed = Helper.toCell<double> speed "speed" 
                let _vol = Helper.toCell<double> vol "vol" 
                let _x0 = Helper.toDefault<double> x0 "x0" 0.0
                let _level = Helper.toDefault<double> level "level" 0.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.OrnsteinUhlenbeckProcess 
                                                            _speed.cell 
                                                            _vol.cell 
                                                            _x0.cell 
                                                            _level.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OrnsteinUhlenbeckProcess>) l

                let source () = Helper.sourceFold "Fun.OrnsteinUhlenbeckProcess" 
                                               [| _speed.source
                                               ;  _vol.source
                                               ;  _x0.source
                                               ;  _level.source
                                               |]
                let hash = Helper.hashFold 
                                [| _speed.cell
                                ;  _vol.cell
                                ;  _x0.cell
                                ;  _level.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OrnsteinUhlenbeckProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_speed", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_speed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Speed
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Speed") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_stdDeviation", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_stdDeviation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x0",Description = "double or empty")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _t = Helper.toCell<double> t "t" 
                let _x0 = Helper.toDefault<double> x0 "x0" 0.0
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).StdDeviation
                                                            _t.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".StdDeviation") 

                                               [| _t.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_variance", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="UnnamedParameter1",Description = "double")>] 
         UnnamedParameter1 : obj)
        ([<ExcelArgument(Name="UnnamedParameter2",Description = "double")>] 
         UnnamedParameter2 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _UnnamedParameter1 = Helper.toCell<double> UnnamedParameter1 "UnnamedParameter1" 
                let _UnnamedParameter2 = Helper.toCell<double> UnnamedParameter2 "UnnamedParameter2" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Variance
                                                            _UnnamedParameter1.cell 
                                                            _UnnamedParameter2.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Variance") 

                                               [| _UnnamedParameter1.source
                                               ;  _UnnamedParameter2.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _UnnamedParameter1.cell
                                ;  _UnnamedParameter2.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_volatility", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Volatility
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
        StochasticProcess interface
    *)
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_x0", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_x0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).X0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".X0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_apply1", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_apply1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "Vector")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dx = Helper.toCell<Vector> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Apply1
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Apply1") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _x0.cell
                                ;  _dx.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OrnsteinUhlenbeckProcess> format
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_apply", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_apply
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="x0",Description = "double or empty")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dx",Description = "double")>] 
         dx : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _x0 = Helper.toDefault<double> x0 "x0" 0.0
                let _dx = Helper.toCell<double> dx "dx" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Apply
                                                            _x0.cell 
                                                            _dx.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Apply") 

                                               [| _x0.source
                                               ;  _dx.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_evolve", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_evolve
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
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

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0"
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<Vector> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Evolve
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Evolve") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                ;  _dw.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OrnsteinUhlenbeckProcess> format
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_evolve1", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_evolve1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double or empty")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        ([<ExcelArgument(Name="dw",Description = "double")>] 
         dw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toDefault<double> x0 "x0" 0.0
                let _dt = Helper.toCell<double> dt "dt" 
                let _dw = Helper.toCell<double> dw "dw" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Evolve1
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                            _dw.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Evolve1") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               ;  _dw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_initialValues", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_initialValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).InitialValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".InitialValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OrnsteinUhlenbeckProcess> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_size", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_covariance", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Covariance
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Covariance") 

                                               [| _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
                                ;  _t0.cell
                                ;  _x0.cell
                                ;  _dt.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<OrnsteinUhlenbeckProcess> format
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_factors", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_registerWith", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OrnsteinUhlenbeckProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_time", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="d",Description = "Date")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _d = Helper.toCell<Date> d "d" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Time
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Time") 

                                               [| _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_unregisterWith", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : OrnsteinUhlenbeckProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_update", Description="Create a OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="OrnsteinUhlenbeckProcess",Description = "OrnsteinUhlenbeckProcess")>] 
         ornsteinuhlenbeckprocess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _OrnsteinUhlenbeckProcess = Helper.toCell<OrnsteinUhlenbeckProcess> ornsteinuhlenbeckprocess "OrnsteinUhlenbeckProcess"  
                let builder (current : ICell) = withMnemonic mnemonic ((OrnsteinUhlenbeckProcessModel.Cast _OrnsteinUhlenbeckProcess.cell).Update
                                                       ) :> ICell
                let format (o : OrnsteinUhlenbeckProcess) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_OrnsteinUhlenbeckProcess.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _OrnsteinUhlenbeckProcess.cell
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
    [<ExcelFunction(Name="_OrnsteinUhlenbeckProcess_Range", Description="Create a range of OrnsteinUhlenbeckProcess",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let OrnsteinUhlenbeckProcess_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<OrnsteinUhlenbeckProcess> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<OrnsteinUhlenbeckProcess> (c)) :> ICell
                let format (i : Cephei.Cell.List<OrnsteinUhlenbeckProcess>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<OrnsteinUhlenbeckProcess>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
