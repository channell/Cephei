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
module LmFixedVolatilityModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmFixedVolatilityModel", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="volatilities",Description = "Reference to volatilities")>] 
         volatilities : obj)
        ([<ExcelArgument(Name="startTimes",Description = "Reference to startTimes")>] 
         startTimes : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _volatilities = Helper.toCell<Vector> volatilities "volatilities" 
                let _startTimes = Helper.toCell<Generic.List<double>> startTimes "startTimes" 
                let builder () = withMnemonic mnemonic (Fun.LmFixedVolatilityModel 
                                                            _volatilities.cell 
                                                            _startTimes.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmFixedVolatilityModel>) l

                let source = Helper.sourceFold "Fun.LmFixedVolatilityModel" 
                                               [| _volatilities.source
                                               ;  _startTimes.source
                                               |]
                let hash = Helper.hashFold 
                                [| _volatilities.cell
                                ;  _startTimes.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmFixedVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmFixedVolatilityModel_volatility", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).Volatility
                                                            _i.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".Volatility") 
                                               [| _LmFixedVolatilityModel.source
                                               ;  _i.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmFixedVolatilityModel_volatility1", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).Volatility1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".Volatility1") 
                                               [| _LmFixedVolatilityModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmFixedVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmFixedVolatilityModel_integratedVariance", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_integratedVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
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

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _u = Helper.toCell<double> u "u" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).IntegratedVariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _u.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".IntegratedVariance") 
                                               [| _LmFixedVolatilityModel.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _u.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmFixedVolatilityModel_parameters", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".Parameters") 
                                               [| _LmFixedVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmFixedVolatilityModel_setParams", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmFixedVolatilityModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".SetParams") 
                                               [| _LmFixedVolatilityModel.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmFixedVolatilityModel_size", Description="Create a LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmFixedVolatilityModel",Description = "Reference to LmFixedVolatilityModel")>] 
         lmfixedvolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmFixedVolatilityModel = Helper.toCell<LmFixedVolatilityModel> lmfixedvolatilitymodel "LmFixedVolatilityModel"  
                let builder () = withMnemonic mnemonic ((LmFixedVolatilityModelModel.Cast _LmFixedVolatilityModel.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmFixedVolatilityModel.source + ".Size") 
                                               [| _LmFixedVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmFixedVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmFixedVolatilityModel_Range", Description="Create a range of LmFixedVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmFixedVolatilityModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LmFixedVolatilityModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmFixedVolatilityModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmFixedVolatilityModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmFixedVolatilityModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LmFixedVolatilityModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
