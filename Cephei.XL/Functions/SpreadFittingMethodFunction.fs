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
Fits a spread curve on top of a discount function according to given parametric method
  </summary> *)
[<AutoSerializable(true)>]
module SpreadFittingMethodFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SpreadFittingMethod_clone", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FittedBondDiscountCurve.FittingMethod>) l

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".Clone") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadFittingMethod> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SpreadFittingMethod_size", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".Size") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
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
    [<ExcelFunction(Name="_SpreadFittingMethod", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Method",Description = "FittedBondDiscountCurve.FittingMethod")>] 
         Method : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "YieldTermStructure")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Method = Helper.toCell<FittedBondDiscountCurve.FittingMethod> Method "Method" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SpreadFittingMethod 
                                                            _Method.cell 
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SpreadFittingMethod>) l

                let source () = Helper.sourceFold "Fun.SpreadFittingMethod" 
                                               [| _Method.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Method.cell
                                ;  _discountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadFittingMethod> format
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
    [<ExcelFunction(Name="_SpreadFittingMethod_constrainAtZero", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_constrainAtZero
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).ConstrainAtZero
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".ConstrainAtZero") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
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
    [<ExcelFunction(Name="_SpreadFittingMethod_discount", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        ([<ExcelArgument(Name="x",Description = "Vector")>] 
         x : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let _x = Helper.toCell<Vector> x "x" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).Discount
                                                            _x.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".Discount") 

                                               [| _x.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
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
    [<ExcelFunction(Name="_SpreadFittingMethod_minimumCostValue", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_minimumCostValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).MinimumCostValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".MinimumCostValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
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
    [<ExcelFunction(Name="_SpreadFittingMethod_numberOfIterations", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_numberOfIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).NumberOfIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".NumberOfIterations") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
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
    [<ExcelFunction(Name="_SpreadFittingMethod_optimizationMethod", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_optimizationMethod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).OptimizationMethod
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<OptimizationMethod>) l

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".OptimizationMethod") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadFittingMethod> format
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
    [<ExcelFunction(Name="_SpreadFittingMethod_solution", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_solution
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).Solution
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".Solution") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadFittingMethod> format
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
    [<ExcelFunction(Name="_SpreadFittingMethod_weights", Description="Create a SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_weights
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SpreadFittingMethod",Description = "SpreadFittingMethod")>] 
         spreadfittingmethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SpreadFittingMethod = Helper.toCell<SpreadFittingMethod> spreadfittingmethod "SpreadFittingMethod"  
                let builder (current : ICell) = withMnemonic mnemonic ((SpreadFittingMethodModel.Cast _SpreadFittingMethod.cell).Weights
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_SpreadFittingMethod.source + ".Weights") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SpreadFittingMethod.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SpreadFittingMethod> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SpreadFittingMethod_Range", Description="Create a range of SpreadFittingMethod",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SpreadFittingMethod_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SpreadFittingMethod> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<SpreadFittingMethod> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<SpreadFittingMethod>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SpreadFittingMethod>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
