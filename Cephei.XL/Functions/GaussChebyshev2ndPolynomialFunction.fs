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

(* <summary>
  Gauss-Chebyshev polynomial (second kind)
  </summary> *)
[<AutoSerializable(true)>]
module GaussChebyshev2ndPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = (Fun.GaussChebyshev2ndPolynomial 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussChebyshev2ndPolynomial>) l

                let source () = Helper.sourceFold "Fun.GaussChebyshev2ndPolynomial" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussChebyshev2ndPolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_alpha", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".Alpha") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_beta", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".Beta") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_mu_0", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".Mu_0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_w", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".W") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_value", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".Value") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
                                ;  _n.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_weightedValue", Description="Create a GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussChebyshev2ndPolynomial",Description = "GaussChebyshev2ndPolynomial")>] 
         gausschebyshev2ndpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussChebyshev2ndPolynomial = Helper.toModelReference<GaussChebyshev2ndPolynomial> gausschebyshev2ndpolynomial "GaussChebyshev2ndPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussChebyshev2ndPolynomialModel.Cast _GaussChebyshev2ndPolynomial.cell).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussChebyshev2ndPolynomial.source + ".WeightedValue") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussChebyshev2ndPolynomial.cell
                                ;  _n.cell
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
    [<ExcelFunction(Name="_GaussChebyshev2ndPolynomial_Range", Description="Create a range of GaussChebyshev2ndPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussChebyshev2ndPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussChebyshev2ndPolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GaussChebyshev2ndPolynomial> (c)) :> ICell
                let format (i : Cephei.Cell.List<GaussChebyshev2ndPolynomial>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GaussChebyshev2ndPolynomial>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
