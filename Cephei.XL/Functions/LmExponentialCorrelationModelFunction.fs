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
  This class describes a exponential correlation model  References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)
  </summary> *)
[<AutoSerializable(true)>]
module LmExponentialCorrelationModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_correlation", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_correlation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).Correlation
                                                            _i.cell 
                                                            _j.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".Correlation") 

                                               [| _i.source
                                               ;  _j.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_correlation1", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_correlation1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).Correlation1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".Correlation1") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_isTimeIndependent", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_isTimeIndependent
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).IsTimeIndependent
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".IsTimeIndependent") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _rho = Helper.toCell<double> rho "rho" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LmExponentialCorrelationModel 
                                                            _size.cell 
                                                            _rho.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmExponentialCorrelationModel>) l

                let source () = Helper.sourceFold "Fun.LmExponentialCorrelationModel" 
                                               [| _size.source
                                               ;  _rho.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _rho.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_pseudoSqrt", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_pseudoSqrt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Vector or empty")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).PseudoSqrt
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".PseudoSqrt") 

                                               [| _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmExponentialCorrelationModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_factors", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_factors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).Factors
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".Factors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_parameters", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".Parameters") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_setParams", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Parameter range")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmExponentialCorrelationModel) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".SetParams") 

                                               [| _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_size", Description="Create a LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExponentialCorrelationModel",Description = "LmExponentialCorrelationModel")>] 
         lmexponentialcorrelationmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExponentialCorrelationModel = Helper.toCell<LmExponentialCorrelationModel> lmexponentialcorrelationmodel "LmExponentialCorrelationModel"  
                let builder (current : ICell) = withMnemonic mnemonic ((LmExponentialCorrelationModelModel.Cast _LmExponentialCorrelationModel.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_LmExponentialCorrelationModel.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LmExponentialCorrelationModel.cell
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
    [<ExcelFunction(Name="_LmExponentialCorrelationModel_Range", Description="Create a range of LmExponentialCorrelationModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmExponentialCorrelationModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmExponentialCorrelationModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmExponentialCorrelationModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmExponentialCorrelationModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LmExponentialCorrelationModel>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
