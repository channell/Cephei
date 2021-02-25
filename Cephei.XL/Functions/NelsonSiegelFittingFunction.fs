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
  Fits a discount function to the form d(t) = t}, where the zero rate is defined as r c_0 + (c_0 + c_1)*(1 - exp^{ t) - c_2 exp^{ - t}. See: Nelson, C. and A. Siegel (1985): "Parsimonious modeling of yield curves for US Treasury bills." NBER Working Paper Series, no 1594.
  </summary> *)
[<AutoSerializable(true)>]
module NelsonSiegelFittingFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_clone", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NelsonSiegelFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="weights",Description = "Vector or empty")>] 
         weights : obj)
        ([<ExcelArgument(Name="optimizationMethod",Description = "OptimizationMethod or empty")>] 
         optimizationMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _weights = Helper.toDefault<Vector> weights "weights" null
                let _optimizationMethod = Helper.toDefault<OptimizationMethod> optimizationMethod "optimizationMethod" null
                let builder (current : ICell) = (Fun.NelsonSiegelFitting 
                                                            _weights.cell 
                                                            _optimizationMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NelsonSiegelFitting>) l

                let source () = Helper.sourceFold "Fun.NelsonSiegelFitting" 
                                               [| _weights.source
                                               ;  _optimizationMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _weights.cell
                                ;  _optimizationMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NelsonSiegelFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NelsonSiegelFitting_size", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_constrainAtZero", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".ConstrainAtZero") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_discount", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let _x = Helper.toCell<Vector> x "x" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".Discount") 

                                               [| _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_minimumCostValue", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".MinimumCostValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_numberOfIterations", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_optimizationMethod", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".OptimizationMethod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NelsonSiegelFitting> format
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_solution", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".Solution") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NelsonSiegelFitting> format
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
    [<ExcelFunction(Name="_NelsonSiegelFitting_weights", Description="Create a NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NelsonSiegelFitting",Description = "NelsonSiegelFitting")>] 
         nelsonsiegelfitting : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NelsonSiegelFitting = Helper.toModelReference<NelsonSiegelFitting> nelsonsiegelfitting "NelsonSiegelFitting"  
                let builder (current : ICell) = ((NelsonSiegelFittingModel.Cast _NelsonSiegelFitting.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NelsonSiegelFitting.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _NelsonSiegelFitting.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NelsonSiegelFitting> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NelsonSiegelFitting_Range", Description="Create a range of NelsonSiegelFitting",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NelsonSiegelFitting_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NelsonSiegelFitting> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<NelsonSiegelFitting> (c)) :> ICell
                let format (i : Cephei.Cell.List<NelsonSiegelFitting>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<NelsonSiegelFitting>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
