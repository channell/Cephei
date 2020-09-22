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
  Euler discretization for stochastic processes
  </summary> *)
[<AutoSerializable(true)>]
module EulerDiscretizationFunction =

    (*
        ! Returns an approximation of the covariance defined as \f$ \sigma(t_0, \mathbf{x}_0)^2 \Delta t \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_covariance", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Covariance
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Covariance") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
        ! Returns an approximation of the diffusion defined as \f$ \sigma(t_0, x_0) \sqrt{\Delta t} \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_diffusion", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Diffusion
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Diffusion") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
        ! Returns an approximation of the diffusion defined as \f$ \sigma(t_0, \mathbf{x}_0) \sqrt{\Delta t} \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_diffusion1", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Diffusion1
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Diffusion1") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
        ! Returns an approximation of the drift defined as \f$ \mu(t_0, \mathbf{x}_0) \Delta t \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_drift1", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_drift1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<Vector> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Drift1
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Drift1") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
        ! Returns an approximation of the drift defined as \f$ \mu(t_0, x_0) \Delta t \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_drift", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Drift
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Drift") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
        ! Returns an approximation of the variance defined as \f$ \sigma(t_0, x_0)^2 \Delta t \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_variance", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "Reference to EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "Reference to t0")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Reference to x0")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "Reference to dt")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toCell<EulerDiscretization> eulerdiscretization "EulerDiscretization" true 
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" true
                let _t0 = Helper.toCell<double> t0 "t0" true
                let _x0 = Helper.toCell<double> x0 "x0" true
                let _dt = Helper.toCell<double> dt "dt" true
                let builder () = withMnemonic mnemonic ((_EulerDiscretization.cell :?> EulerDiscretizationModel).Variance
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EulerDiscretization.source + ".Variance") 
                                               [| _EulerDiscretization.source
                                               ;  _Process.source
                                               ;  _t0.source
                                               ;  _x0.source
                                               ;  _dt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EulerDiscretization.cell
                                ;  _Process.cell
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
    [<ExcelFunction(Name="_EulerDiscretization_Range", Description="Create a range of EulerDiscretization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let EulerDiscretization_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EulerDiscretization")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EulerDiscretization> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EulerDiscretization>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EulerDiscretization>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EulerDiscretization>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
