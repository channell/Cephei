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
module BoundaryConditionSchemeHelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_applyAfterApplying", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_applyAfterApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConditionSchemeHelper",Description = "BoundaryConditionSchemeHelper")>] 
         boundaryconditionschemehelper : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConditionSchemeHelper = Helper.toCell<BoundaryConditionSchemeHelper> boundaryconditionschemehelper "BoundaryConditionSchemeHelper"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConditionSchemeHelperModel.Cast _BoundaryConditionSchemeHelper.cell).ApplyAfterApplying
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : BoundaryConditionSchemeHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConditionSchemeHelper.source + ".ApplyAfterApplying") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConditionSchemeHelper.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_applyAfterSolving", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_applyAfterSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConditionSchemeHelper",Description = "BoundaryConditionSchemeHelper")>] 
         boundaryconditionschemehelper : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConditionSchemeHelper = Helper.toCell<BoundaryConditionSchemeHelper> boundaryconditionschemehelper "BoundaryConditionSchemeHelper"  
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConditionSchemeHelperModel.Cast _BoundaryConditionSchemeHelper.cell).ApplyAfterSolving
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : BoundaryConditionSchemeHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConditionSchemeHelper.source + ".ApplyAfterSolving") 

                                               [| _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConditionSchemeHelper.cell
                                ;  _a.cell
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
        BoundaryCondition inheritance
    *)
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_applyBeforeApplying", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_applyBeforeApplying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConditionSchemeHelper",Description = "BoundaryConditionSchemeHelper")>] 
         boundaryconditionschemehelper : obj)
        ([<ExcelArgument(Name="op",Description = "IOperator")>] 
         op : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConditionSchemeHelper = Helper.toCell<BoundaryConditionSchemeHelper> boundaryconditionschemehelper "BoundaryConditionSchemeHelper"  
                let _op = Helper.toCell<IOperator> op "op" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConditionSchemeHelperModel.Cast _BoundaryConditionSchemeHelper.cell).ApplyBeforeApplying
                                                            _op.cell 
                                                       ) :> ICell
                let format (o : BoundaryConditionSchemeHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConditionSchemeHelper.source + ".ApplyBeforeApplying") 

                                               [| _op.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConditionSchemeHelper.cell
                                ;  _op.cell
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
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_applyBeforeSolving", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_applyBeforeSolving
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConditionSchemeHelper",Description = "BoundaryConditionSchemeHelper")>] 
         boundaryconditionschemehelper : obj)
        ([<ExcelArgument(Name="op",Description = "IOperator")>] 
         op : obj)
        ([<ExcelArgument(Name="a",Description = "Vector")>] 
         a : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConditionSchemeHelper = Helper.toCell<BoundaryConditionSchemeHelper> boundaryconditionschemehelper "BoundaryConditionSchemeHelper"  
                let _op = Helper.toCell<IOperator> op "op" 
                let _a = Helper.toCell<Vector> a "a" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConditionSchemeHelperModel.Cast _BoundaryConditionSchemeHelper.cell).ApplyBeforeSolving
                                                            _op.cell 
                                                            _a.cell 
                                                       ) :> ICell
                let format (o : BoundaryConditionSchemeHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConditionSchemeHelper.source + ".ApplyBeforeSolving") 

                                               [| _op.source
                                               ;  _a.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConditionSchemeHelper.cell
                                ;  _op.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="bcSet",Description = "FdmLinearOp range")>] 
         bcSet : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _bcSet = Helper.toCell<Generic.List<BoundaryCondition<FdmLinearOp>>> bcSet "bcSet" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BoundaryConditionSchemeHelper 
                                                            _bcSet.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BoundaryConditionSchemeHelper>) l

                let source () = Helper.sourceFold "Fun.BoundaryConditionSchemeHelper" 
                                               [| _bcSet.source
                                               |]
                let hash = Helper.hashFold 
                                [| _bcSet.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BoundaryConditionSchemeHelper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_setTime", Description="Create a BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BoundaryConditionSchemeHelper",Description = "BoundaryConditionSchemeHelper")>] 
         boundaryconditionschemehelper : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BoundaryConditionSchemeHelper = Helper.toCell<BoundaryConditionSchemeHelper> boundaryconditionschemehelper "BoundaryConditionSchemeHelper"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((BoundaryConditionSchemeHelperModel.Cast _BoundaryConditionSchemeHelper.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BoundaryConditionSchemeHelper) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_BoundaryConditionSchemeHelper.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BoundaryConditionSchemeHelper.cell
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
    [<ExcelFunction(Name="_BoundaryConditionSchemeHelper_Range", Description="Create a range of BoundaryConditionSchemeHelper",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BoundaryConditionSchemeHelper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BoundaryConditionSchemeHelper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Cephei.Cell.List<BoundaryConditionSchemeHelper> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = l :> ICell
                let format (i : Generic.List<ICell<BoundaryConditionSchemeHelper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BoundaryConditionSchemeHelper>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
