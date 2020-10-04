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
  This class describes a linear-exponential volatility model   References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)
  </summary> *)
[<AutoSerializable(true)>]
module LmLinearExponentialVolatilityModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_integratedVariance", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_integratedVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
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

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _u = Helper.toCell<double> u "u" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).IntegratedVariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _u.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".IntegratedVariance") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _u.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="fixingTimes",Description = "Reference to fixingTimes")>] 
         fixingTimes : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _fixingTimes = Helper.toCell<Generic.List<double>> fixingTimes "fixingTimes" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _c = Helper.toCell<double> c "c" 
                let _d = Helper.toCell<double> d "d" 
                let builder () = withMnemonic mnemonic (Fun.LmLinearExponentialVolatilityModel 
                                                            _fixingTimes.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmLinearExponentialVolatilityModel>) l

                let source = Helper.sourceFold "Fun.LmLinearExponentialVolatilityModel" 
                                               [| _fixingTimes.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _fixingTimes.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmLinearExponentialVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_volatility", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let _i = Helper.toCell<int> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).Volatility
                                                            _i.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".Volatility") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               ;  _i.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_volatility1", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toDefault<Vector> x "x" null
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).Volatility1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".Volatility1") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmLinearExponentialVolatilityModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_parameters", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".Parameters") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_setParams", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmLinearExponentialVolatilityModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".SetParams") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_size", Description="Create a LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmLinearExponentialVolatilityModel",Description = "Reference to LmLinearExponentialVolatilityModel")>] 
         lmlinearexponentialvolatilitymodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmLinearExponentialVolatilityModel = Helper.toCell<LmLinearExponentialVolatilityModel> lmlinearexponentialvolatilitymodel "LmLinearExponentialVolatilityModel"  
                let builder () = withMnemonic mnemonic ((LmLinearExponentialVolatilityModelModel.Cast _LmLinearExponentialVolatilityModel.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmLinearExponentialVolatilityModel.source + ".Size") 
                                               [| _LmLinearExponentialVolatilityModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmLinearExponentialVolatilityModel.cell
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
    [<ExcelFunction(Name="_LmLinearExponentialVolatilityModel_Range", Description="Create a range of LmLinearExponentialVolatilityModel",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LmLinearExponentialVolatilityModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LmLinearExponentialVolatilityModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmLinearExponentialVolatilityModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmLinearExponentialVolatilityModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmLinearExponentialVolatilityModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LmLinearExponentialVolatilityModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
