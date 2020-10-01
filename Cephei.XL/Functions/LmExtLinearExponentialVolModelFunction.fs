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
  This class describes an extended linear-exponential volatility model   References:  Damiano Brigo, Fabio Mercurio, Massimo Morini, 2003, Different Covariance Parameterizations of Libor Market Model and Joint Caps/Swaptions Calibration, (<http://www.business.uts.edu.au/qfrc/conferences/qmf2001/Brigo_D.pdf>)
  </summary> *)
[<AutoSerializable(true)>]
module LmExtLinearExponentialVolModelFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_integratedVariance", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_integratedVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
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

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let _u = Helper.toCell<double> u "u" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).IntegratedVariance
                                                            _i.cell 
                                                            _j.cell 
                                                            _u.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".IntegratedVariance") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               ;  _i.source
                                               ;  _j.source
                                               ;  _u.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
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
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_create
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
                let builder () = withMnemonic mnemonic (Fun.LmExtLinearExponentialVolModel 
                                                            _fixingTimes.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LmExtLinearExponentialVolModel>) l

                let source = Helper.sourceFold "Fun.LmExtLinearExponentialVolModel" 
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
                    ; subscriber = Helper.subscriberModel<LmExtLinearExponentialVolModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_volatility1", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).Volatility1
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".Volatility1") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LmExtLinearExponentialVolModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_volatility", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let _i = Helper.toCell<int> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).Volatility
                                                            _i.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".Volatility") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               ;  _i.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
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
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_parameters", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_parameters
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).Parameters
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Parameter>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".Parameters") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
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
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_setParams", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_setParams
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
        ([<ExcelArgument(Name="arguments",Description = "Reference to arguments")>] 
         arguments : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let _arguments = Helper.toCell<Generic.List<Parameter>> arguments "arguments" 
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).SetParams
                                                            _arguments.cell 
                                                       ) :> ICell
                let format (o : LmExtLinearExponentialVolModel) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".SetParams") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               ;  _arguments.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
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
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_size", Description="Create a LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LmExtLinearExponentialVolModel",Description = "Reference to LmExtLinearExponentialVolModel")>] 
         lmextlinearexponentialvolmodel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LmExtLinearExponentialVolModel = Helper.toCell<LmExtLinearExponentialVolModel> lmextlinearexponentialvolmodel "LmExtLinearExponentialVolModel"  
                let builder () = withMnemonic mnemonic ((_LmExtLinearExponentialVolModel.cell :?> LmExtLinearExponentialVolModelModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LmExtLinearExponentialVolModel.source + ".Size") 
                                               [| _LmExtLinearExponentialVolModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LmExtLinearExponentialVolModel.cell
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
    [<ExcelFunction(Name="_LmExtLinearExponentialVolModel_Range", Description="Create a range of LmExtLinearExponentialVolModel",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LmExtLinearExponentialVolModel_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LmExtLinearExponentialVolModel")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LmExtLinearExponentialVolModel> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LmExtLinearExponentialVolModel>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LmExtLinearExponentialVolModel>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LmExtLinearExponentialVolModel>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
