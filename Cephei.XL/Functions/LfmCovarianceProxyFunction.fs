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
module LfmCovarianceProxyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_correlationModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_correlationModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).CorrelationModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrelationModel") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_corrModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_corrModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).CorrModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrModel") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_corrModel_", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_corrModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).CorrModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrModel_") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_covariance", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).Covariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".Covariance") 
                                               [| _LfmCovarianceProxy.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_diffusion1", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).Diffusion1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".Diffusion1") 
                                               [| _LfmCovarianceProxy.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_diffusion", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).Diffusion
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".Diffusion") 
                                               [| _LfmCovarianceProxy.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_integratedCovariance1", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_integratedCovariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let _i = Helper.toCell<int> i "i" true
                let _j = Helper.toCell<int> j "j" true
                let _t = Helper.toCell<double> t "t" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).IntegratedCovariance1
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".IntegratedCovariance1") 
                                               [| _LfmCovarianceProxy.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                ;  _i.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_integratedCovariance", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_integratedCovariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let _i = Helper.toCell<int> i "i" true
                let _j = Helper.toCell<int> j "j" true
                let _t = Helper.toCell<double> t "t" true
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).IntegratedCovariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".IntegratedCovariance") 
                                               [| _LfmCovarianceProxy.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                ;  _i.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="volaModel",Description = "Reference to volaModel")>] 
         volaModel : obj)
        ([<ExcelArgument(Name="corrModel",Description = "Reference to corrModel")>] 
         corrModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _volaModel = Helper.toCell<LmVolatilityModel> volaModel "volaModel" true
                let _corrModel = Helper.toCell<LmCorrelationModel> corrModel "corrModel" true
                let builder () = withMnemonic mnemonic (Fun.LfmCovarianceProxy 
                                                            _volaModel.cell 
                                                            _corrModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmCovarianceProxy>) l

                let source = Helper.sourceFold "Fun.LfmCovarianceProxy" 
                                               [| _volaModel.source
                                               ;  _corrModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _volaModel.cell
                                ;  _corrModel.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_volaModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volaModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).VolaModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolaModel") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_volaModel_", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volaModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).VolaModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolaModel_") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_volatilityModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volatilityModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).VolatilityModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolatilityModel") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_factors", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".Factors") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_size", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "Reference to LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toCell<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy" true 
                let builder () = withMnemonic mnemonic ((_LfmCovarianceProxy.cell :?> LfmCovarianceProxyModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LfmCovarianceProxy.source + ".Size") 
                                               [| _LfmCovarianceProxy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_Range", Description="Create a range of LfmCovarianceProxy",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LfmCovarianceProxy")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LfmCovarianceProxy> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LfmCovarianceProxy>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LfmCovarianceProxy>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LfmCovarianceProxy>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
