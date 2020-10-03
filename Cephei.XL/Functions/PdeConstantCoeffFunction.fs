﻿(*
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
(*!! generic 
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module PdeConstantCoeffFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PdeConstantCoeff_diffusion", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_diffusion
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeConstantCoeff",Description = "Reference to PdeConstantCoeff")>] 
         pdeconstantcoeff : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeConstantCoeff = Helper.toCell<PdeConstantCoeff> pdeconstantcoeff "PdeConstantCoeff"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((_PdeConstantCoeff.cell :?> PdeConstantCoeffModel).Diffusion
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeConstantCoeff.source + ".Diffusion") 
                                               [| _PdeConstantCoeff.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeConstantCoeff.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_PdeConstantCoeff_discount", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeConstantCoeff",Description = "Reference to PdeConstantCoeff")>] 
         pdeconstantcoeff : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeConstantCoeff = Helper.toCell<PdeConstantCoeff> pdeconstantcoeff "PdeConstantCoeff"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((_PdeConstantCoeff.cell :?> PdeConstantCoeffModel).Discount
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeConstantCoeff.source + ".Discount") 
                                               [| _PdeConstantCoeff.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeConstantCoeff.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_PdeConstantCoeff_drift", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_drift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeConstantCoeff",Description = "Reference to PdeConstantCoeff")>] 
         pdeconstantcoeff : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeConstantCoeff = Helper.toCell<PdeConstantCoeff> pdeconstantcoeff "PdeConstantCoeff"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((_PdeConstantCoeff.cell :?> PdeConstantCoeffModel).Drift
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PdeConstantCoeff.source + ".Drift") 
                                               [| _PdeConstantCoeff.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeConstantCoeff.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_PdeConstantCoeff_factory", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeConstantCoeff",Description = "Reference to PdeConstantCoeff")>] 
         pdeconstantcoeff : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeConstantCoeff = Helper.toCell<PdeConstantCoeff> pdeconstantcoeff "PdeConstantCoeff"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder () = withMnemonic mnemonic ((_PdeConstantCoeff.cell :?> PdeConstantCoeffModel).Factory
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeSecondOrderParabolic>) l

                let source = Helper.sourceFold (_PdeConstantCoeff.source + ".Factory") 
                                               [| _PdeConstantCoeff.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeConstantCoeff.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeConstantCoeff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeConstantCoeff", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _t = Helper.toCell<double> t "t" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic (Fun.PdeConstantCoeff 
                                                            _Process.cell 
                                                            _t.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PdeConstantCoeff>) l

                let source = Helper.sourceFold "Fun.PdeConstantCoeff" 
                                               [| _Process.source
                                               ;  _t.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _t.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PdeConstantCoeff> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PdeConstantCoeff_generateOperator", Description="Create a PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_generateOperator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PdeConstantCoeff",Description = "Reference to PdeConstantCoeff")>] 
         pdeconstantcoeff : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="tg",Description = "Reference to tg")>] 
         tg : obj)
        ([<ExcelArgument(Name="L",Description = "Reference to L")>] 
         L : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PdeConstantCoeff = Helper.toCell<PdeConstantCoeff> pdeconstantcoeff "PdeConstantCoeff"  
                let _t = Helper.toCell<double> t "t" 
                let _tg = Helper.toCell<TransformedGrid> tg "tg" 
                let _L = Helper.toCell<TridiagonalOperator> L "L" 
                let builder () = withMnemonic mnemonic ((_PdeConstantCoeff.cell :?> PdeConstantCoeffModel).GenerateOperator
                                                            _t.cell 
                                                            _tg.cell 
                                                            _L.cell 
                                                       ) :> ICell
                let format (o : PdeConstantCoeff) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PdeConstantCoeff.source + ".GenerateOperator") 
                                               [| _PdeConstantCoeff.source
                                               ;  _t.source
                                               ;  _tg.source
                                               ;  _L.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PdeConstantCoeff.cell
                                ;  _t.cell
                                ;  _tg.cell
                                ;  _L.cell
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
    [<ExcelFunction(Name="_PdeConstantCoeff_Range", Description="Create a range of PdeConstantCoeff",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PdeConstantCoeff_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PdeConstantCoeff")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PdeConstantCoeff> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PdeConstantCoeff>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PdeConstantCoeff>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PdeConstantCoeff>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)