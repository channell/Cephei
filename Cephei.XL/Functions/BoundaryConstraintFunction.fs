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
  %Constraint imposing all arguments to be in [low,high]
  </summary> *)
[<AutoSerializable(true)>]
module BoundaryConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BoundaryConstraint", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="low",Description = "double")>] 
         low : obj)
        ([<ExcelArgument(Name="high",Description = "double")>] 
         high : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _low = Helper.toCell<double> low "low" 
                let _high = Helper.toCell<double> high "high" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BoundaryConstraint 
                                                            _low.cell 
                                                            _high.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BoundaryConstraint>) l

                let source () = Helper.sourceFold "Fun.BoundaryConstraint" 
                                               [| _low.source
                                               ;  _high.source
                                               |]
                let hash = Helper.hashFold 
                                [| _low.cell
                                ;  _high.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BoundaryConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BoundaryConstraint_empty", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConstraint",Description = "BoundaryConstraint")>] 
         boundaryconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConstraint = Helper.toCell<BoundaryConstraint> boundaryconstraint "BoundaryConstraint"  
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConstraintModel.Cast _BoundaryConstraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConstraint.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _BoundaryConstraint.cell
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
    [<ExcelFunction(Name="_BoundaryConstraint_lowerBound", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConstraint",Description = "BoundaryConstraint")>] 
         boundaryconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConstraint = Helper.toCell<BoundaryConstraint> boundaryconstraint "BoundaryConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConstraintModel.Cast _BoundaryConstraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BoundaryConstraint.source + ".LowerBound") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BoundaryConstraint> format
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
    [<ExcelFunction(Name="_BoundaryConstraint_test", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConstraint",Description = "BoundaryConstraint")>] 
         boundaryconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConstraint = Helper.toCell<BoundaryConstraint> boundaryconstraint "BoundaryConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConstraintModel.Cast _BoundaryConstraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConstraint.source + ".Test") 

                                               [| _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConstraint.cell
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
    [<ExcelFunction(Name="_BoundaryConstraint_update", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConstraint",Description = "BoundaryConstraint")>] 
         boundaryconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Vector")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConstraint = Helper.toCell<BoundaryConstraint> boundaryconstraint "BoundaryConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConstraintModel.Cast _BoundaryConstraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BoundaryConstraint.source + ".Update") 

                                               [| _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConstraint.cell
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
    [<ExcelFunction(Name="_BoundaryConstraint_upperBound", Description="Create a BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConstraint",Description = "BoundaryConstraint")>] 
         boundaryconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConstraint = Helper.toCell<BoundaryConstraint> boundaryconstraint "BoundaryConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConstraintModel.Cast _BoundaryConstraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_BoundaryConstraint.source + ".UpperBound") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BoundaryConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BoundaryConstraint_Range", Description="Create a range of BoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BoundaryConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<BoundaryConstraint> (c)) :> ICell
                let format (i : Generic.List<ICell<BoundaryConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<BoundaryConstraint>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
