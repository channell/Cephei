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
  Gauss-Gegenbauer polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussGegenbauerPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lambda",Description = "double")>] 
         lambda : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lambda = Helper.toCell<double> lambda "lambda" 
                let builder (current : ICell) = (Fun.GaussGegenbauerPolynomial 
                                                            _lambda.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussGegenbauerPolynomial>) l

                let source () = Helper.sourceFold "Fun.GaussGegenbauerPolynomial" 
                                               [| _lambda.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lambda.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussGegenbauerPolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_alpha", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".Alpha") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_beta", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".Beta") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_mu_0", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".Mu_0") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_w", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".W") 

                                               [| _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_value", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".Value") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_weightedValue", Description="Create a GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussGegenbauerPolynomial",Description = "GaussGegenbauerPolynomial")>] 
         gaussgegenbauerpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "double")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussGegenbauerPolynomial = Helper.toCell<GaussGegenbauerPolynomial> gaussgegenbauerpolynomial "GaussGegenbauerPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder (current : ICell) = ((GaussGegenbauerPolynomialModel.Cast _GaussGegenbauerPolynomial.cell).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_GaussGegenbauerPolynomial.source + ".WeightedValue") 

                                               [| _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussGegenbauerPolynomial.cell
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
    [<ExcelFunction(Name="_GaussGegenbauerPolynomial_Range", Description="Create a range of GaussGegenbauerPolynomial",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GaussGegenbauerPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussGegenbauerPolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<GaussGegenbauerPolynomial> (c)) :> ICell
                let format (i : Cephei.Cell.List<GaussGegenbauerPolynomial>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<GaussGegenbauerPolynomial>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
