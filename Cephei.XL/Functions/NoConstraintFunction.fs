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
  No constraint
  </summary> *)
[<AutoSerializable(true)>]
module NoConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NoConstraint", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.NoConstraint ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NoConstraint>) l

                let source () = Helper.sourceFold "Fun.NoConstraint" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_NoConstraint_empty", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoConstraint",Description = "Reference to NoConstraint")>] 
         noconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoConstraint = Helper.toCell<NoConstraint> noconstraint "NoConstraint"  
                let builder (current : ICell) = withMnemonic mnemonic ((NoConstraintModel.Cast _NoConstraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoConstraint.source + ".Empty") 
                                               [| _NoConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoConstraint.cell
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
    [<ExcelFunction(Name="_NoConstraint_lowerBound", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoConstraint",Description = "Reference to NoConstraint")>] 
         noconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoConstraint = Helper.toCell<NoConstraint> noconstraint "NoConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoConstraintModel.Cast _NoConstraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NoConstraint.source + ".LowerBound") 
                                               [| _NoConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoConstraint> format
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
    [<ExcelFunction(Name="_NoConstraint_test", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoConstraint",Description = "Reference to NoConstraint")>] 
         noconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoConstraint = Helper.toCell<NoConstraint> noconstraint "NoConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoConstraintModel.Cast _NoConstraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_NoConstraint.source + ".Test") 
                                               [| _NoConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoConstraint.cell
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
    [<ExcelFunction(Name="_NoConstraint_update", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoConstraint",Description = "Reference to NoConstraint")>] 
         noconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoConstraint = Helper.toCell<NoConstraint> noconstraint "NoConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoConstraintModel.Cast _NoConstraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_NoConstraint.source + ".Update") 
                                               [| _NoConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoConstraint.cell
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
    [<ExcelFunction(Name="_NoConstraint_upperBound", Description="Create a NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoConstraint",Description = "Reference to NoConstraint")>] 
         noconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoConstraint = Helper.toCell<NoConstraint> noconstraint "NoConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((NoConstraintModel.Cast _NoConstraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_NoConstraint.source + ".UpperBound") 
                                               [| _NoConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NoConstraint_Range", Description="Create a range of NoConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let NoConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NoConstraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NoConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NoConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<NoConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<NoConstraint>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
