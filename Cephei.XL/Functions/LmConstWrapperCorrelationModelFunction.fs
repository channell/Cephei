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
module LmConstWrapperCorrelationModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_correlation1", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_correlation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
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

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).Correlation1
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Correlation1") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_correlation", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).Correlation
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Correlation") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmConstWrapperCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_factors", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Factors") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_isTimeIndependent", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_isTimeIndependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).IsTimeIndependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".IsTimeIndependent") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="corrModel",Description = "Reference to corrModel")>] 
         corrModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _corrModel = Helper.toCell<LmCorrelationModel> corrModel "corrModel" 
                let builder () = withMnemonic mnemonic (Fun.LmConstWrapperCorrelationModel 
                                                            _corrModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmConstWrapperCorrelationModel>) l

                let source = Helper.sourceFold "Fun.LmConstWrapperCorrelationModel" 
                                               [| _corrModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _corrModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmConstWrapperCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_pseudoSqrt", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_pseudoSqrt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).PseudoSqrt
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".PseudoSqrt") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmConstWrapperCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_parameters", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Parameters") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_setParams", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmConstWrapperCorrelationModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".SetParams") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _arguments.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_size", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "Reference to LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperCorrelationModel.cell :?> LmConstWrapperCorrelationModelModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Size") 
                                               [| _LmConstWrapperCorrelationModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_Range", Description="Create a range of LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LmConstWrapperCorrelationModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmConstWrapperCorrelationModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmConstWrapperCorrelationModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmConstWrapperCorrelationModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LmConstWrapperCorrelationModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
