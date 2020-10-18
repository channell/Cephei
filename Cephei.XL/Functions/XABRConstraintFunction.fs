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
module XABRConstraintFunction =

    (*
        
    *)
    (*!! generic 
    [<ExcelFunction(Name="_XABRConstraint_config", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_config
        ([<ExcelArgument(Name="Mnemonic",Description = "XABRConstraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        ([<ExcelArgument(Name="costFunction",Description = "ProjectedCostFunction")>] 
         costFunction : obj)
        ([<ExcelArgument(Name="coeff",Description = "Model")>] 
         coeff : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let _costFunction = Helper.toCell<ProjectedCostFunction> costFunction "costFunction" 
                let _coeff = Helper.toCell<XABRCoeffHolder<Model>> coeff "coeff" 
                let _forward = Helper.toCell<double> forward "forward" 
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).Config
                                                            _costFunction.cell 
                                                            _coeff.cell 
                                                            _forward.cell 
                                                       ) :> ICell
                let format (o : XABRConstraint) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRConstraint.source + ".Config") 
                                               [| _XABRConstraint.source
                                               ;  _costFunction.source
                                               ;  _coeff.source
                                               ;  _forward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
                                ;  _costFunction.cell
                                ;  _coeff.cell
                                ;  _forward.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_XABRConstraint", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "XABRConstraint")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="impl",Description = "IConstraint")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _impl = Helper.toCell<IConstraint> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.XABRConstraint 
                                                            _impl.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<XABRConstraint>) l

                let source () = Helper.sourceFold "Fun.XABRConstraint" 
                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _impl.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_XABRConstraint1", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "XABRConstraint")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.XABRConstraint1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<XABRConstraint>) l

                let source () = Helper.sourceFold "Fun.XABRConstraint1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_XABRConstraint_empty", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRConstraint.source + ".Empty") 
                                               [| _XABRConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
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
    [<ExcelFunction(Name="_XABRConstraint_lowerBound", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_XABRConstraint.source + ".LowerBound") 
                                               [| _XABRConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRConstraint> format
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
    [<ExcelFunction(Name="_XABRConstraint_test", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRConstraint.source + ".Test") 
                                               [| _XABRConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
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
    [<ExcelFunction(Name="_XABRConstraint_update", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Vector")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Vector")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "double")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_XABRConstraint.source + ".Update") 
                                               [| _XABRConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
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
    [<ExcelFunction(Name="_XABRConstraint_upperBound", Description="Create a XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRConstraint",Description = "XABRConstraint")>] 
         xabrconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRConstraint = Helper.toCell<XABRConstraint> xabrconstraint "XABRConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((XABRConstraintModel.Cast _XABRConstraint.cell).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_XABRConstraint.source + ".UpperBound") 
                                               [| _XABRConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_XABRConstraint_Range", Description="Create a range of XABRConstraint",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<XABRConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<XABRConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<XABRConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<XABRConstraint>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
