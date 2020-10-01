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
  caplet const volatility model
  </summary> *)
[<AutoSerializable(true)>]
module LmConstWrapperVolatilityModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_integratedVariance", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_integratedVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        ([<ExcelArgument(Name="u",Description = "Reference to u")>] 
         u : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _u = Helper.toCell<double> u "u" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).IntegratedVariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _u.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".IntegratedVariance") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _u.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
                                ;  _i.cell
                                ;  _j.cell
                                ;  _u.cell
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
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="volaModel",Description = "Reference to volaModel")>] 
         volaModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _volaModel = Helper.toCell<LmVolatilityModel> volaModel "volaModel" 
                let builder () = withMnemonic mnemonic (Fun.LmConstWrapperVolatilityModel 
                                                            _volaModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmConstWrapperVolatilityModel>) l

                let source = Helper.sourceFold "Fun.LmConstWrapperVolatilityModel" 
                                               [| _volaModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _volaModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmConstWrapperVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_volatility", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).Volatility
                                                            _i.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".Volatility") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               ;  _i.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_volatility1", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).Volatility1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".Volatility1") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmConstWrapperVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_parameters", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".Parameters") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_setParams", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmConstWrapperVolatilityModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".SetParams") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_size", Description="Create a LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmConstWrapperVolatilityModel",Description = "Reference to LmConstWrapperVolatilityModel")>] 
         lmconstwrappervolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmConstWrapperVolatilityModel = Helper.toCell<LmConstWrapperVolatilityModel> lmconstwrappervolatilitymodel "LmConstWrapperVolatilityModel"  
                let builder () = withMnemonic mnemonic ((_LmConstWrapperVolatilityModel.cell :?> LmConstWrapperVolatilityModelModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmConstWrapperVolatilityModel.source + ".Size") 
                                               [| _LmConstWrapperVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmConstWrapperVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmConstWrapperVolatilityModel_Range", Description="Create a range of LmConstWrapperVolatilityModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmConstWrapperVolatilityModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LmConstWrapperVolatilityModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmConstWrapperVolatilityModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmConstWrapperVolatilityModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmConstWrapperVolatilityModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LmConstWrapperVolatilityModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
