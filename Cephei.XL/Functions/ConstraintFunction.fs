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
  Base constrainT class
  </summary> *)
[<AutoSerializable(true)>]
module ConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Constraint", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="impl",Description = "Reference to impl")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _impl = Helper.toCell<IConstraint> impl "impl" 
                let builder () = withMnemonic mnemonic (Fun.Constraint 
                                                            _impl.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold "Fun.Constraint" 
                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _impl.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Constraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Constraint1", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Constraint1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Constraint>) l

                let source = Helper.sourceFold "Fun.Constraint1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Constraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Constraint_empty", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         constrainT : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> constrainT "Constraint"  
                let builder () = withMnemonic mnemonic ((ConstraintModel.Cast _Constraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Constraint.source + ".Empty") 
                                               [| _Constraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
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
    [<ExcelFunction(Name="_Constraint_lowerBound", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         constrainT : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> constrainT "Constraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((ConstraintModel.Cast _Constraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Constraint.source + ".LowerBound") 
                                               [| _Constraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Constraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Tests if params satisfy the constrainT
    *)
    [<ExcelFunction(Name="_Constraint_test", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         constrainT : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> constrainT "Constraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((ConstraintModel.Cast _Constraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Constraint.source + ".Test") 
                                               [| _Constraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
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
    [<ExcelFunction(Name="_Constraint_update", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         constrainT : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> constrainT "Constraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic ((ConstraintModel.Cast _Constraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Constraint.source + ".Update") 
                                               [| _Constraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
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
    [<ExcelFunction(Name="_Constraint_upperBound", Description="Create a Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Constraint",Description = "Reference to Constraint")>] 
         constrainT : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Constraint = Helper.toCell<Constraint> constrainT "Constraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((ConstraintModel.Cast _Constraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Constraint.source + ".UpperBound") 
                                               [| _Constraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Constraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Constraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Constraint_Range", Description="Create a range of Constraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Constraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Constraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Constraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Constraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Constraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Constraint>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
