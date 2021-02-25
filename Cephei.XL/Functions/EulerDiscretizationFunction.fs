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
    [<ExcelFunction(Name="_EulerDiscretization_covariance", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Covariance
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Covariance") 

                                               [| _Process.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EulerDiscretization> format
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
    [<ExcelFunction(Name="_EulerDiscretization_diffusion", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Diffusion
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Diffusion") 

                                               [| _Process.source
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
        ! Returns an approximation of the diffusion defined as \f$ \sigma(t_0, \mathbf{x}_0) \sqrt{\Delta t} \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_diffusion1", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Diffusion1
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Diffusion1") 

                                               [| _Process.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EulerDiscretization> format
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
    [<ExcelFunction(Name="_EulerDiscretization_drift1", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_drift1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "Vector")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<Vector> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Drift1
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Drift1") 

                                               [| _Process.source
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EulerDiscretization> format
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
    [<ExcelFunction(Name="_EulerDiscretization_drift", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Drift
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Drift") 

                                               [| _Process.source
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
        ! Returns an approximation of the variance defined as \f$ \sigma(t_0, x_0)^2 \Delta t \f$.
    *)
    [<ExcelFunction(Name="_EulerDiscretization_variance", Description="Create a EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_variance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EulerDiscretization",Description = "EulerDiscretization")>] 
         eulerdiscretization : obj)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="t0",Description = "double")>] 
         t0 : obj)
        ([<ExcelArgument(Name="x0",Description = "double")>] 
         x0 : obj)
        ([<ExcelArgument(Name="dt",Description = "double")>] 
         dt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EulerDiscretization = Helper.toModelReference<EulerDiscretization> eulerdiscretization "EulerDiscretization"  
                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _t0 = Helper.toCell<double> t0 "t0" 
                let _x0 = Helper.toCell<double> x0 "x0" 
                let _dt = Helper.toCell<double> dt "dt" 
                let builder (current : ICell) = ((EulerDiscretizationModel.Cast _EulerDiscretization.cell).Variance
                                                            _Process.cell 
                                                            _t0.cell 
                                                            _x0.cell 
                                                            _dt.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EulerDiscretization.source + ".Variance") 

                                               [| _Process.source
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
    [<ExcelFunction(Name="_EulerDiscretization_Range", Description="Create a range of EulerDiscretization",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EulerDiscretization_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EulerDiscretization> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EulerDiscretization> (c)) :> ICell
                let format (i : Cephei.Cell.List<EulerDiscretization>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EulerDiscretization>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
