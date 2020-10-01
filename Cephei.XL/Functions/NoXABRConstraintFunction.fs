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
module NoXABRConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_NoXABRConstraint", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.NoXABRConstraint ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<NoXABRConstraint>) l

                let source = Helper.sourceFold "Fun.NoXABRConstraint" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoXABRConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! generic
    [<ExcelFunction(Name="_NoXABRConstraint_config", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_config
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        ([<ExcelArgument(Name="costFunction",Description = "Reference to costFunction")>] 
         costFunction : obj)
        ([<ExcelArgument(Name="coeff",Description = "Reference to coeff")>] 
         coeff : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let _costFunction = Helper.toCell<ProjectedCostFunction> costFunction "costFunction" 
                let _coeff = Helper.toCell<XABRCoeffHolder<Model>> coeff "coeff" 
                let _forward = Helper.toCell<double> forward "forward" 
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).Config
                                                            _costFunction.cell 
                                                            _coeff.cell 
                                                            _forward.cell 
                                                       ) :> ICell
                let format (o : NoXABRConstraint) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".Config") 
                                               [| _NoXABRConstraint.source
                                               ;  _costFunction.source
                                               ;  _coeff.source
                                               ;  _forward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
                                ;  _costFunction.cell
                                ;  _coeff.cell
                                ;  _forward.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_NoXABRConstraint_empty", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".Empty") 
                                               [| _NoXABRConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
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
    [<ExcelFunction(Name="_NoXABRConstraint_lowerBound", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".LowerBound") 
                                               [| _NoXABRConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoXABRConstraint> format
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
    [<ExcelFunction(Name="_NoXABRConstraint_test", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".Test") 
                                               [| _NoXABRConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
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
    [<ExcelFunction(Name="_NoXABRConstraint_update", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".Update") 
                                               [| _NoXABRConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
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
    [<ExcelFunction(Name="_NoXABRConstraint_upperBound", Description="Create a NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="NoXABRConstraint",Description = "Reference to NoXABRConstraint")>] 
         noxabrconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _NoXABRConstraint = Helper.toCell<NoXABRConstraint> noxabrconstraint "NoXABRConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((_NoXABRConstraint.cell :?> NoXABRConstraintModel).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_NoXABRConstraint.source + ".UpperBound") 
                                               [| _NoXABRConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _NoXABRConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<NoXABRConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_NoXABRConstraint_Range", Description="Create a range of NoXABRConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let NoXABRConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the NoXABRConstraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<NoXABRConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<NoXABRConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<NoXABRConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<NoXABRConstraint>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
