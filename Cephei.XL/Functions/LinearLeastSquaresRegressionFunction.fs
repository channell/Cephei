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
module LinearLeastSquaresRegressionFunction =

    (*!! ommitted
    (*
        
    *)
    [<ExcelFunction(Name="_LinearLeastSquaresRegression_coefficients", Description="Create a LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_coefficients
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearLeastSquaresRegression",Description = "LinearLeastSquaresRegression")>] 
         linearleastsquaresregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearLeastSquaresRegression = Helper.toCell<LinearLeastSquaresRegression> linearleastsquaresregression "LinearLeastSquaresRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearLeastSquaresRegressionModel.Cast _LinearLeastSquaresRegression.cell).Coefficients
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearLeastSquaresRegression.source + ".Coefficients") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearLeastSquaresRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearLeastSquaresRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        ! modeling uncertainty as definied in Numerical Recipes
    *)
    (*!! ommited 
    [<ExcelFunction(Name="_LinearLeastSquaresRegression_error", Description="Create a LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_error
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearLeastSquaresRegression",Description = "LinearLeastSquaresRegression")>] 
         linearleastsquaresregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearLeastSquaresRegression = Helper.toCell<LinearLeastSquaresRegression> linearleastsquaresregression "LinearLeastSquaresRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearLeastSquaresRegressionModel.Cast _LinearLeastSquaresRegression.cell).Error
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearLeastSquaresRegression.source + ".Error") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearLeastSquaresRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearLeastSquaresRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_LinearLeastSquaresRegression", Description="Create a LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="x",Description = "double range")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "double range")>] 
         y : obj)
        ([<ExcelArgument(Name="v",Description = "double,double range")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _x = Helper.toCell<Generic.List<double>> x "x" 
                let _y = Helper.toCell<Generic.List<double>> y "y" 
                let _v = Helper.toCell<Generic.List<Func<double,double>>> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.LinearLeastSquaresRegression 
                                                            _x.cell 
                                                            _y.cell 
                                                            _v.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LinearLeastSquaresRegression>) l

                let source () = Helper.sourceFold "Fun.LinearLeastSquaresRegression" 
                                               [| _x.source
                                               ;  _y.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _x.cell
                                ;  _y.cell
                                ;  _v.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearLeastSquaresRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! ommited 
    [<ExcelFunction(Name="_LinearLeastSquaresRegression_residuals", Description="Create a LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_residuals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearLeastSquaresRegression",Description = "LinearLeastSquaresRegression")>] 
         linearleastsquaresregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearLeastSquaresRegression = Helper.toCell<LinearLeastSquaresRegression> linearleastsquaresregression "LinearLeastSquaresRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearLeastSquaresRegressionModel.Cast _LinearLeastSquaresRegression.cell).Residuals
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearLeastSquaresRegression.source + ".Residuals") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearLeastSquaresRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearLeastSquaresRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    *)
    (*
        ! standard parameter errors as given by Excel, R etc.
    *)
    (*!! omitted
    [<ExcelFunction(Name="_LinearLeastSquaresRegression_standardErrors", Description="Create a LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_standardErrors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LinearLeastSquaresRegression",Description = "LinearLeastSquaresRegression")>] 
         linearleastsquaresregression : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LinearLeastSquaresRegression = Helper.toCell<LinearLeastSquaresRegression> linearleastsquaresregression "LinearLeastSquaresRegression"  
                let builder (current : ICell) = withMnemonic mnemonic ((LinearLeastSquaresRegressionModel.Cast _LinearLeastSquaresRegression.cell).StandardErrors
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_LinearLeastSquaresRegression.source + ".StandardErrors") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LinearLeastSquaresRegression.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LinearLeastSquaresRegression> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    [<ExcelFunction(Name="_LinearLeastSquaresRegression_Range", Description="Create a range of LinearLeastSquaresRegression",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LinearLeastSquaresRegression_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LinearLeastSquaresRegression> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LinearLeastSquaresRegression> (c)) :> ICell
                let format (i : Cephei.Cell.List<LinearLeastSquaresRegression>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LinearLeastSquaresRegression>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
