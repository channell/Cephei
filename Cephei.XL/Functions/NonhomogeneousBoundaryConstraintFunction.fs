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
  %Constraint imposing i-th argument to be in [low_i,high_i] for all i
  </summary> *)
[<AutoSerializable(true)>]
module NonhomogeneousBoundaryConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="low",Description = "Reference to low")>] 
         low : obj)
        ([<ExcelArgument(Name="high",Description = "Reference to high")>] 
         high : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _low = Helper.toCell<Vector> low "low" 
                let _high = Helper.toCell<Vector> high "high" 
                let builder () = withMnemonic mnemonic (Fun.NonhomogeneousBoundaryConstraint 
                                                            _low.cell 
                                                            _high.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NonhomogeneousBoundaryConstraint>) l

                let source = Helper.sourceFold "Fun.NonhomogeneousBoundaryConstraint" 
                                               [| _low.source
                                               ;  _high.source
                                               |]
                let hash = Helper.hashFold 
                                [| _low.cell
                                ;  _high.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonhomogeneousBoundaryConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_empty", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonhomogeneousBoundaryConstraint",Description = "Reference to NonhomogeneousBoundaryConstraint")>] 
         nonhomogeneousboundaryconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonhomogeneousBoundaryConstraint = Helper.toCell<NonhomogeneousBoundaryConstraint> nonhomogeneousboundaryconstraint "NonhomogeneousBoundaryConstraint"  
                let builder () = withMnemonic mnemonic ((NonhomogeneousBoundaryConstraintModel.Cast _NonhomogeneousBoundaryConstraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NonhomogeneousBoundaryConstraint.source + ".Empty") 
                                               [| _NonhomogeneousBoundaryConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonhomogeneousBoundaryConstraint.cell
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
        ! Returns lower bound for given parameters
    *)
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_lowerBound", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonhomogeneousBoundaryConstraint",Description = "Reference to NonhomogeneousBoundaryConstraint")>] 
         nonhomogeneousboundaryconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonhomogeneousBoundaryConstraint = Helper.toCell<NonhomogeneousBoundaryConstraint> nonhomogeneousboundaryconstraint "NonhomogeneousBoundaryConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((NonhomogeneousBoundaryConstraintModel.Cast _NonhomogeneousBoundaryConstraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NonhomogeneousBoundaryConstraint.source + ".LowerBound") 
                                               [| _NonhomogeneousBoundaryConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonhomogeneousBoundaryConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonhomogeneousBoundaryConstraint> format
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
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_test", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonhomogeneousBoundaryConstraint",Description = "Reference to NonhomogeneousBoundaryConstraint")>] 
         nonhomogeneousboundaryconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonhomogeneousBoundaryConstraint = Helper.toCell<NonhomogeneousBoundaryConstraint> nonhomogeneousboundaryconstraint "NonhomogeneousBoundaryConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((NonhomogeneousBoundaryConstraintModel.Cast _NonhomogeneousBoundaryConstraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NonhomogeneousBoundaryConstraint.source + ".Test") 
                                               [| _NonhomogeneousBoundaryConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonhomogeneousBoundaryConstraint.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_update", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonhomogeneousBoundaryConstraint",Description = "Reference to NonhomogeneousBoundaryConstraint")>] 
         nonhomogeneousboundaryconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonhomogeneousBoundaryConstraint = Helper.toCell<NonhomogeneousBoundaryConstraint> nonhomogeneousboundaryconstraint "NonhomogeneousBoundaryConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic ((NonhomogeneousBoundaryConstraintModel.Cast _NonhomogeneousBoundaryConstraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NonhomogeneousBoundaryConstraint.source + ".Update") 
                                               [| _NonhomogeneousBoundaryConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonhomogeneousBoundaryConstraint.cell
                                ;  _p.cell
                                ;  _direction.cell
                                ;  _beta.cell
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
        ! Returns upper bound for given parameters
    *)
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_upperBound", Description="Create a NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NonhomogeneousBoundaryConstraint",Description = "Reference to NonhomogeneousBoundaryConstraint")>] 
         nonhomogeneousboundaryconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NonhomogeneousBoundaryConstraint = Helper.toCell<NonhomogeneousBoundaryConstraint> nonhomogeneousboundaryconstraint "NonhomogeneousBoundaryConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((NonhomogeneousBoundaryConstraintModel.Cast _NonhomogeneousBoundaryConstraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NonhomogeneousBoundaryConstraint.source + ".UpperBound") 
                                               [| _NonhomogeneousBoundaryConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NonhomogeneousBoundaryConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NonhomogeneousBoundaryConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NonhomogeneousBoundaryConstraint_Range", Description="Create a range of NonhomogeneousBoundaryConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NonhomogeneousBoundaryConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NonhomogeneousBoundaryConstraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NonhomogeneousBoundaryConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NonhomogeneousBoundaryConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NonhomogeneousBoundaryConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NonhomogeneousBoundaryConstraint>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
