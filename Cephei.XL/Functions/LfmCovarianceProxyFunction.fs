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
    [<ExcelFunction(Name="_LfmCovarianceProxy_correlationModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_correlationModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).CorrelationModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrelationModel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_corrModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_corrModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).CorrModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrModel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_corrModel_", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_corrModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).CorrModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmCorrelationModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".CorrModel_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_covariance", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_covariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).Covariance
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".Covariance") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_diffusion1", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_diffusion1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).Diffusion1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".Diffusion1") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_diffusion", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).Diffusion
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".Diffusion") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_integratedCovariance1", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_integratedCovariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).IntegratedCovariance1
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".IntegratedCovariance1") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_integratedCovariance", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_integratedCovariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).IntegratedCovariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".IntegratedCovariance") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_LfmCovarianceProxy", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="volaModel",Description = "LmVolatilityModel")>] 
         volaModel : obj)
        ([<ExcelArgument(Name="corrModel",Description = "LmCorrelationModel")>] 
         corrModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _volaModel = Helper.toCell<LmVolatilityModel> volaModel "volaModel" 
                let _corrModel = Helper.toCell<LmCorrelationModel> corrModel "corrModel" 
                let builder (current : ICell) = (Fun.LfmCovarianceProxy 
                                                            _volaModel.cell 
                                                            _corrModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmCovarianceProxy>) l

                let source () = Helper.sourceFold "Fun.LfmCovarianceProxy" 
                                               [| _volaModel.source
                                               ;  _corrModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _volaModel.cell
                                ;  _corrModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_volaModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volaModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).VolaModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolaModel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_volaModel_", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volaModel_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).VolaModel_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolaModel_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_volatilityModel", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_volatilityModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).VolatilityModel
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmVolatilityModel>) l

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".VolatilityModel") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmCovarianceProxy> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LfmCovarianceProxy_factors", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_size", Description="Create a LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmCovarianceProxy",Description = "LfmCovarianceProxy")>] 
         lfmcovarianceproxy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmCovarianceProxy = Helper.toModelReference<LfmCovarianceProxy> lfmcovarianceproxy "LfmCovarianceProxy"  
                let builder (current : ICell) = ((LfmCovarianceProxyModel.Cast _LfmCovarianceProxy.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LfmCovarianceProxy.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LfmCovarianceProxy.cell
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
    [<ExcelFunction(Name="_LfmCovarianceProxy_Range", Description="Create a range of LfmCovarianceProxy",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LfmCovarianceProxy_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LfmCovarianceProxy> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LfmCovarianceProxy> (c)) :> ICell
                let format (i : Cephei.Cell.List<LfmCovarianceProxy>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LfmCovarianceProxy>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
