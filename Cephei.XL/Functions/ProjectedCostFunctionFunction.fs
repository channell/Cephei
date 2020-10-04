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
  Parameterized cost function   This class creates a proxy cost function which can depend on any arbitrary subset of parameters (the other being fixed)
  </summary> *)
[<AutoSerializable(true)>]
module ProjectedCostFunctionFunction =

    (*
        ! returns whole set of parameters corresponding to the set of projected parameters
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_include", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_include
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="projectedParameters",Description = "Reference to projectedParameters")>] 
         projectedParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _projectedParameters = Helper.toCell<Vector> projectedParameters "projectedParameters" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Include
                                                            _projectedParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".INCLUDE") 
                                               [| _ProjectedCostFunction.source
                                               ;  _projectedParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _projectedParameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedCostFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the subset of free parameters corresponding to set of parameters
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_project", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_project
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Project
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".Project") 
                                               [| _ProjectedCostFunction.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedCostFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="costFunction",Description = "Reference to costFunction")>] 
         costFunction : obj)
        ([<ExcelArgument(Name="parametersValues",Description = "Reference to parametersValues")>] 
         parametersValues : obj)
        ([<ExcelArgument(Name="parametersFreedoms",Description = "Reference to parametersFreedoms")>] 
         parametersFreedoms : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _costFunction = Helper.toCell<CostFunction> costFunction "costFunction" 
                let _parametersValues = Helper.toCell<Vector> parametersValues "parametersValues" 
                let _parametersFreedoms = Helper.toCell<Generic.List<bool>> parametersFreedoms "parametersFreedoms" 
                let builder () = withMnemonic mnemonic (Fun.ProjectedCostFunction 
                                                            _costFunction.cell 
                                                            _parametersValues.cell 
                                                            _parametersFreedoms.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ProjectedCostFunction>) l

                let source = Helper.sourceFold "Fun.ProjectedCostFunction" 
                                               [| _costFunction.source
                                               ;  _parametersValues.source
                                               ;  _parametersFreedoms.source
                                               |]
                let hash = Helper.hashFold 
                                [| _costFunction.cell
                                ;  _parametersValues.cell
                                ;  _parametersFreedoms.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedCostFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        CostFunction interface
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_value", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="freeParameters",Description = "Reference to freeParameters")>] 
         freeParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _freeParameters = Helper.toCell<Vector> freeParameters "freeParameters" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Value
                                                            _freeParameters.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".Value") 
                                               [| _ProjectedCostFunction.source
                                               ;  _freeParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _freeParameters.cell
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
    [<ExcelFunction(Name="_ProjectedCostFunction_values", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="freeParameters",Description = "Reference to freeParameters")>] 
         freeParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _freeParameters = Helper.toCell<Vector> freeParameters "freeParameters" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Values
                                                            _freeParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".Values") 
                                               [| _ProjectedCostFunction.source
                                               ;  _freeParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _freeParameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedCostFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Default epsilon for finite difference method :
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_finiteDifferenceEpsilon", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_finiteDifferenceEpsilon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).FiniteDifferenceEpsilon
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".FiniteDifferenceEpsilon") 
                                               [| _ProjectedCostFunction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
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
        ! method to overload to compute grad_f, the first derivative of the cost function with respect to x
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_gradient", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_gradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="grad",Description = "Reference to grad")>] 
         grad : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _grad = Helper.toCell<Vector> grad "grad" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Gradient
                                                            _grad.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : ProjectedCostFunction) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".Gradient") 
                                               [| _ProjectedCostFunction.source
                                               ;  _grad.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _grad.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_jacobian", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_jacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Reference to jac")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).Jacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : ProjectedCostFunction) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".Jacobian") 
                                               [| _ProjectedCostFunction.source
                                               ;  _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _jac.cell
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
        ! method to overload to compute grad_f, the first derivative of the cost function with respect to x and also the cost function
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_valueAndGradient", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_valueAndGradient
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="grad",Description = "Reference to grad")>] 
         grad : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _grad = Helper.toCell<Vector> grad "grad" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).ValueAndGradient
                                                            _grad.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".ValueAndGradient") 
                                               [| _ProjectedCostFunction.source
                                               ;  _grad.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _grad.cell
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
        ! method to overload to compute J_f, the jacobian of the cost function with respect to x and also the cost function
    *)
    [<ExcelFunction(Name="_ProjectedCostFunction_valuesAndJacobian", Description="Create a ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_valuesAndJacobian
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedCostFunction",Description = "Reference to ProjectedCostFunction")>] 
         projectedcostfunction : obj)
        ([<ExcelArgument(Name="jac",Description = "Reference to jac")>] 
         jac : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedCostFunction = Helper.toCell<ProjectedCostFunction> projectedcostfunction "ProjectedCostFunction"  
                let _jac = Helper.toCell<Matrix> jac "jac" 
                let _x = Helper.toCell<Vector> x "x" 
                let builder () = withMnemonic mnemonic ((ProjectedCostFunctionModel.Cast _ProjectedCostFunction.cell).ValuesAndJacobian
                                                            _jac.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_ProjectedCostFunction.source + ".ValuesAndJacobian") 
                                               [| _ProjectedCostFunction.source
                                               ;  _jac.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedCostFunction.cell
                                ;  _jac.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedCostFunction> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ProjectedCostFunction_Range", Description="Create a range of ProjectedCostFunction",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedCostFunction_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ProjectedCostFunction")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ProjectedCostFunction> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ProjectedCostFunction>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ProjectedCostFunction>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ProjectedCostFunction>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
