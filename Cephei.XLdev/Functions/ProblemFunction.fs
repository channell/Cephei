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
  Constrained optimization problem
  </summary> *)
[<AutoSerializable(true)>]
module ProblemFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Problem_constraint", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_constraint
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).Constraint
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold (_Problem.source + ".CONSTRAINT") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Problem_costFunction", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_costFunction
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).CostFunction
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CostFunction>) l

                let source = Helper.sourceFold (_Problem.source + ".CostFunction") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Problem_currentValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_currentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).CurrentValue
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Problem.source + ".CurrentValue") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Problem_functionEvaluation", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_functionEvaluation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).FunctionEvaluation
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".FunctionEvaluation") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
    [<ExcelFunction(Name="_Problem_functionValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_functionValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).FunctionValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".FunctionValue") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
        ! call cost function gradient computation and increment evaluation counter
    *)
    [<ExcelFunction(Name="_Problem_gradient", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_gradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="grad_f",Description = "Reference to grad_f")>] 
         grad_f : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _grad_f = Helper.toCell<Vector> grad_f "grad_f" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).Gradient
                                                            _grad_f.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : Problem) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Problem.source + ".Gradient") 
                                               [| _Problem.source
                                               ;  _grad_f.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _grad_f.cell
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
    [<ExcelFunction(Name="_Problem_gradientEvaluation", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_gradientEvaluation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).GradientEvaluation
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".GradientEvaluation") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
    [<ExcelFunction(Name="_Problem_gradientNormValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_gradientNormValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).GradientNormValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".GradientNormValue") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
        ! default constructor public Problem(CostFunction costFunction, Constraint constraint, Vector initialValue = Array())
    *)
    [<ExcelFunction(Name="_Problem", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="costFunction",Description = "Reference to costFunction")>] 
         costFunction : obj)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         Constraint : obj)
        ([<ExcelArgument(Name="initialValue",Description = "Reference to initialValue")>] 
         initialValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _costFunction = Helper.toCell<CostFunction> costFunction "costFunction" true
                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" true
                let _initialValue = Helper.toCell<Vector> initialValue "initialValue" true
                let builder () = withMnemonic mnemonic (Fun.Problem 
                                                            _costFunction.cell 
                                                            _Constraint.cell 
                                                            _initialValue.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Problem>) l

                let source = Helper.sourceFold "Fun.Problem" 
                                               [| _costFunction.source
                                               ;  _Constraint.source
                                               ;  _initialValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _costFunction.cell
                                ;  _Constraint.cell
                                ;  _initialValue.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \warning it does not reset the current minumum to any initial value
    *)
    [<ExcelFunction(Name="_Problem_reset", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).Reset
                                                       ) :> ICell
                let format (o : Problem) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Problem.source + ".Reset") 
                                               [| _Problem.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
    [<ExcelFunction(Name="_Problem_setCurrentValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_setCurrentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="currentValue",Description = "Reference to currentValue")>] 
         currentValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _currentValue = Helper.toCell<Vector> currentValue "currentValue" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).SetCurrentValue
                                                            _currentValue.cell 
                                                       ) :> ICell
                let format (o : Problem) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Problem.source + ".SetCurrentValue") 
                                               [| _Problem.source
                                               ;  _currentValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _currentValue.cell
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
    [<ExcelFunction(Name="_Problem_setFunctionValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_setFunctionValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="functionValue",Description = "Reference to functionValue")>] 
         functionValue : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _functionValue = Helper.toCell<double> functionValue "functionValue" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).SetFunctionValue
                                                            _functionValue.cell 
                                                       ) :> ICell
                let format (o : Problem) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Problem.source + ".SetFunctionValue") 
                                               [| _Problem.source
                                               ;  _functionValue.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _functionValue.cell
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
    [<ExcelFunction(Name="_Problem_setGradientNormValue", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_setGradientNormValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="squaredNorm",Description = "Reference to squaredNorm")>] 
         squaredNorm : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _squaredNorm = Helper.toCell<double> squaredNorm "squaredNorm" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).SetGradientNormValue
                                                            _squaredNorm.cell 
                                                       ) :> ICell
                let format (o : Problem) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Problem.source + ".SetGradientNormValue") 
                                               [| _Problem.source
                                               ;  _squaredNorm.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _squaredNorm.cell
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
        ! call cost function computation and increment evaluation counter
    *)
    [<ExcelFunction(Name="_Problem_value", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".Value") 
                                               [| _Problem.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
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
        ! call cost function computation and it gradient
    *)
    [<ExcelFunction(Name="_Problem_valueAndGradient", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_valueAndGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="grad_f",Description = "Reference to grad_f")>] 
         grad_f : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _grad_f = Helper.toCell<Vector> grad_f "grad_f" true
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).ValueAndGradient
                                                            _grad_f.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Problem.source + ".ValueAndGradient") 
                                               [| _Problem.source
                                               ;  _grad_f.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _grad_f.cell
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
        ! call cost values computation and increment evaluation counter
    *)
    [<ExcelFunction(Name="_Problem_values", Description="Create a Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Problem",Description = "Reference to Problem")>] 
         problem : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Problem = Helper.toCell<Problem> problem "Problem" true 
                let _x = Helper.toCell<Vector> x "x" true
                let builder () = withMnemonic mnemonic ((_Problem.cell :?> ProblemModel).Values
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Problem.source + ".Values") 
                                               [| _Problem.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Problem.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Problem_Range", Description="Create a range of Problem",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Problem_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Problem")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Problem> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Problem>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Problem>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Problem>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
