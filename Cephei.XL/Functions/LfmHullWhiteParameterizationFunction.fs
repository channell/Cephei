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

  </summary> *)
[<AutoSerializable(true)>]
module LfmHullWhiteParameterizationFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_covariance1", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_covariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Covariance1
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Covariance1") 
                                               [| _LfmHullWhiteParameterization.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_covariance", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Covariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Covariance") 
                                               [| _LfmHullWhiteParameterization.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_diffusion", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Diffusion
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Diffusion") 
                                               [| _LfmHullWhiteParameterization.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_diffusion", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Diffusion1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Diffusion") 
                                               [| _LfmHullWhiteParameterization.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_integratedCovariance", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_integratedCovariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).IntegratedCovariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".IntegratedCovariance") 
                                               [| _LfmHullWhiteParameterization.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
                                ;  _t.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization1", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<LiborForwardModelProcess> Process "Process" true
                let _capletVol = Helper.toCell<OptionletVolatilityStructure> capletVol "capletVol" true
                let builder () = withMnemonic mnemonic (Fun.LfmHullWhiteParameterization1 
                                                            _Process.cell 
                                                            _capletVol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmHullWhiteParameterization>) l

                let source = Helper.sourceFold "Fun.LfmHullWhiteParameterization1" 
                                               [| _Process.source
                                               ;  _capletVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _capletVol.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="capletVol",Description = "Reference to capletVol")>] 
         capletVol : obj)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        ([<ExcelArgument(Name="factors",Description = "Reference to factors")>] 
         factors : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<LiborForwardModelProcess> Process "Process" true
                let _capletVol = Helper.toCell<OptionletVolatilityStructure> capletVol "capletVol" true
                let _correlation = Helper.toCell<Matrix> correlation "correlation" true
                let _factors = Helper.toCell<int> factors "factors" true
                let builder () = withMnemonic mnemonic (Fun.LfmHullWhiteParameterization
                                                            _Process.cell 
                                                            _capletVol.cell 
                                                            _correlation.cell 
                                                            _factors.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmHullWhiteParameterization>) l

                let source = Helper.sourceFold "Fun.LfmHullWhiteParameterization" 
                                               [| _Process.source
                                               ;  _capletVol.source
                                               ;  _correlation.source
                                               ;  _factors.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _capletVol.cell
                                ;  _correlation.cell
                                ;  _factors.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_factors", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Factors") 
                                               [| _LfmHullWhiteParameterization.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_size", Description="Create a LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmHullWhiteParameterization",Description = "Reference to LfmHullWhiteParameterization")>] 
         lfmhullwhiteparameterization : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmHullWhiteParameterization = Helper.toCell<LfmHullWhiteParameterization> lfmhullwhiteparameterization "LfmHullWhiteParameterization" true 
                let builder () = withMnemonic mnemonic ((_LfmHullWhiteParameterization.cell :?> LfmHullWhiteParameterizationModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmHullWhiteParameterization.source + ".Size") 
                                               [| _LfmHullWhiteParameterization.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmHullWhiteParameterization.cell
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
    [<ExcelFunction(Name="_LfmHullWhiteParameterization_Range", Description="Create a range of LfmHullWhiteParameterization",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmHullWhiteParameterization_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LfmHullWhiteParameterization")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LfmHullWhiteParameterization> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LfmHullWhiteParameterization>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LfmHullWhiteParameterization>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LfmHullWhiteParameterization>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
