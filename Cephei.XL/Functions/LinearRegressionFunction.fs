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
  linear regression y_i = a_0 + a_1*x_0 +..+a_n*x_{n-1} + eps
  </summary> *)
[<AutoSerializable(true)>]
module LinearRegressionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LinearRegression_coefficients", Description="Create a LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_coefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearRegression",Description = "LinearRegression")>] 
         linearregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearRegression = Helper.toCell<LinearRegression> linearregression "LinearRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearRegressionModel.Cast _LinearRegression.cell).Coefficients
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearRegression.source + ".Coefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! one dimensional linear regression
    *)
    [<ExcelFunction(Name="_LinearRegression1", Description="Create a LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x",Description = "double range")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double range")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x = Helper.toCell<Generic.List<double>> x "x" 
                let _y = Helper.toCell<Generic.List<double>> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LinearRegression1
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LinearRegression>) l

                let source () = Helper.sourceFold "Fun.LinearRegression1" 
                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x.cell
                                ;  _y.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! multi dimensional linear regression
    *)
    [<ExcelFunction(Name="_LinearRegression", Description="Create a LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x",Description = "double range")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double range")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x = Helper.toCell<Generic.List<Generic.List<double>>> x "x" 
                let _y = Helper.toCell<Generic.List<double>> y "y" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LinearRegression
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LinearRegression>) l

                let source () = Helper.sourceFold "Fun.LinearRegression" 
                                               [| _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x.cell
                                ;  _y.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LinearRegression_residuals", Description="Create a LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_residuals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearRegression",Description = "LinearRegression")>] 
         linearregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearRegression = Helper.toCell<LinearRegression> linearregression "LinearRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearRegressionModel.Cast _LinearRegression.cell).Residuals
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearRegression.source + ".Residuals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LinearRegression_standardErrors", Description="Create a LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_standardErrors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearRegression",Description = "LinearRegression")>] 
         linearregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearRegression = Helper.toCell<LinearRegression> linearregression "LinearRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearRegressionModel.Cast _LinearRegression.cell).StandardErrors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearRegression.source + ".StandardErrors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_LinearRegression_Range", Description="Create a range of LinearRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearRegression_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LinearRegression> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LinearRegression>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<LinearRegression>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<LinearRegression>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
