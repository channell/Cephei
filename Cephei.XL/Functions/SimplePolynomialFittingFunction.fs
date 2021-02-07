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
This is a simple/crude, but fast and robust, means of fitting a yield curve.
  </summary> *)
[<AutoSerializable(true)>]
module SimplePolynomialFittingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_clone", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimplePolynomialFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="degree",Description = "int")>] 
         degree : obj)
        ([<ExcelArgument(Name="constrainAtZero",Description = "bool or empty")>] 
         constrainAtZero : obj)
        ([<ExcelArgument(Name="weights",Description = "Vector or empty")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "OptimizationMethod or empty")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _degree = Helper.toCell<int> degree "degree" 
                let _constrainAtZero = Helper.toDefault<bool> constrainAtZero "constrainAtZero" true
                let _weights = Helper.toDefault<Vector> weights "weights" null
                let _optimizationMethod = Helper.toDefault<OptimizationMethod> optimizationMethod "optimizationMethod" null
                let builder (current : ICell) = (Fun.SimplePolynomialFitting 
                                                            _degree.cell 
                                                            _constrainAtZero.cell 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimplePolynomialFitting>) l

                let source () = Helper.sourceFold "Fun.SimplePolynomialFitting" 
                                               [| _degree.source
                                               ;  _constrainAtZero.source
                                               ;  _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _degree.cell
                                ;  _constrainAtZero.cell
                                ;  _weights.cell
                                ;  _optimizationMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimplePolynomialFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_size", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
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
        ! return whether there is a constraint at zero
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_constrainAtZero", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".ConstrainAtZero") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
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
        ! open discountFunction to public
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_discount", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let _x = Helper.toCell<Vector> x "x" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".Discount") 

                                               [| _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
                                ;  _x.cell
                                ;  _t.cell
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
        ! final value of cost function after optimization
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_minimumCostValue", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".MinimumCostValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
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
        ! final number of iterations used in the optimization problem
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_numberOfIterations", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
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
        ! return optimization method being used
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_optimizationMethod", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".OptimizationMethod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimplePolynomialFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! output array of results of optimization problem
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_solution", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".Solution") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimplePolynomialFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! return weights being used
    *)
    [<ExcelFunction(Name="_SimplePolynomialFitting_weights", Description="Create a SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimplePolynomialFitting",Description = "SimplePolynomialFitting")>] 
         simplepolynomialfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimplePolynomialFitting = Helper.toCell<SimplePolynomialFitting> simplepolynomialfitting "SimplePolynomialFitting"  
                let builder (current : ICell) = ((SimplePolynomialFittingModel.Cast _SimplePolynomialFitting.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SimplePolynomialFitting.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SimplePolynomialFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimplePolynomialFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SimplePolynomialFitting_Range", Description="Create a range of SimplePolynomialFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SimplePolynomialFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimplePolynomialFitting> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<SimplePolynomialFitting> (c)) :> ICell
                let format (i : Cephei.Cell.List<SimplePolynomialFitting>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<SimplePolynomialFitting>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
