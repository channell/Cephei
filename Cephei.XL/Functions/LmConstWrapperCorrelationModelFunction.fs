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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_correlation1", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_correlation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Matrix")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).Correlation1
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Correlation1") 

                                               [| _i.source
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_correlation", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Matrix")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).Correlation
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Correlation") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_factors", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "LmConstWrapperCorrelationModel")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_isTimeIndependent", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_isTimeIndependent
        ([<ExcelArgument(Name="Mnemonic",Description = "LmConstWrapperCorrelationModel")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).IsTimeIndependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".IsTimeIndependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "LmConstWrapperCorrelationModel")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="corrModel",Description = "LmCorrelationModel")>] 
         corrModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _corrModel = Helper.toCell<LmCorrelationModel> corrModel "corrModel" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LmConstWrapperCorrelationModel 
                                                            _corrModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmConstWrapperCorrelationModel>) l

                let source () = Helper.sourceFold "Fun.LmConstWrapperCorrelationModel" 
                                               [| _corrModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _corrModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_pseudoSqrt", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_pseudoSqrt
        ([<ExcelArgument(Name="Mnemonic",Description = "Matrix")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Matrix")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).PseudoSqrt
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".PseudoSqrt") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_parameters", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_setParams", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Parameter")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmConstWrapperCorrelationModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".SetParams") 

                                               [| _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
                                ;  _arguments.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_size", Description="Create a LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperCorrelationModel",Description = "LmConstWrapperCorrelationModel")>] 
         lmconstwrappercorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperCorrelationModel = Helper.toCell<LmConstWrapperCorrelationModel> lmconstwrappercorrelationmodel "LmConstWrapperCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmConstWrapperCorrelationModelModel.Cast _LmConstWrapperCorrelationModel.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmConstWrapperCorrelationModel.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperCorrelationModel_Range", Description="Create a range of LmConstWrapperCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmConstWrapperCorrelationModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
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
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmConstWrapperCorrelationModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LmConstWrapperCorrelationModel>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
