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
module ProjectedConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ProjectedConstraint1", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Constraint")>] 
         Constraint : obj)
        ([<ExcelArgument(Name="parameterValues",Description = "Vector")>] 
         parameterValues : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "bool range")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let _parameterValues = Helper.toCell<Vector> parameterValues "parameterValues" 
                let _fixParameters = Helper.toCell<Generic.List<bool>> fixParameters "fixParameters" 
                let builder (current : ICell) = (Fun.ProjectedConstraint1 
                                                            _Constraint.cell 
                                                            _parameterValues.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ProjectedConstraint>) l

                let source () = Helper.sourceFold "Fun.ProjectedConstraint1" 
                                               [| _Constraint.source
                                               ;  _parameterValues.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
                                ;  _parameterValues.cell
                                ;  _fixParameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ProjectedConstraint", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Constraint")>] 
         Constraint : obj)
        ([<ExcelArgument(Name="projection",Description = "Projection")>] 
         projection : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> Constraint "Constraint" 
                let _projection = Helper.toCell<Projection> projection "projection" 
                let builder (current : ICell) = (Fun.ProjectedConstraint
                                                            _Constraint.cell 
                                                            _projection.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ProjectedConstraint>) l

                let source () = Helper.sourceFold "Fun.ProjectedConstraint" 
                                               [| _Constraint.source
                                               ;  _projection.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
                                ;  _projection.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ProjectedConstraint_empty", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedConstraint",Description = "ProjectedConstraint")>] 
         projectedconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedConstraint = Helper.toCell<ProjectedConstraint> projectedconstraint "ProjectedConstraint"  
                let builder (current : ICell) = ((ProjectedConstraintModel.Cast _ProjectedConstraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ProjectedConstraint.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ProjectedConstraint.cell
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
        ! Returns lower bound for given parameters
    *)
    [<ExcelFunction(Name="_ProjectedConstraint_lowerBound", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedConstraint",Description = "ProjectedConstraint")>] 
         projectedconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedConstraint = Helper.toCell<ProjectedConstraint> projectedconstraint "ProjectedConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = ((ProjectedConstraintModel.Cast _ProjectedConstraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ProjectedConstraint.source + ".LowerBound") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Tests if params satisfy the constraint
    *)
    [<ExcelFunction(Name="_ProjectedConstraint_test", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedConstraint",Description = "ProjectedConstraint")>] 
         projectedconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedConstraint = Helper.toCell<ProjectedConstraint> projectedconstraint "ProjectedConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder (current : ICell) = ((ProjectedConstraintModel.Cast _ProjectedConstraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ProjectedConstraint.source + ".Test") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedConstraint.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_ProjectedConstraint_update", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedConstraint",Description = "ProjectedConstraint")>] 
         projectedconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Vector")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedConstraint = Helper.toCell<ProjectedConstraint> projectedconstraint "ProjectedConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder (current : ICell) = ((ProjectedConstraintModel.Cast _ProjectedConstraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_ProjectedConstraint.source + ".Update") 

                                               [| _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedConstraint.cell
                                ;  _p.cell
                                ;  _direction.cell
                                ;  _beta.cell
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
        ! Returns upper bound for given parameters
    *)
    [<ExcelFunction(Name="_ProjectedConstraint_upperBound", Description="Create a ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ProjectedConstraint",Description = "ProjectedConstraint")>] 
         projectedconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ProjectedConstraint = Helper.toCell<ProjectedConstraint> projectedconstraint "ProjectedConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = ((ProjectedConstraintModel.Cast _ProjectedConstraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_ProjectedConstraint.source + ".UpperBound") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ProjectedConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ProjectedConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_ProjectedConstraint_Range", Description="Create a range of ProjectedConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ProjectedConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ProjectedConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ProjectedConstraint> (c)) :> ICell
                let format (i : Cephei.Cell.List<ProjectedConstraint>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ProjectedConstraint>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
