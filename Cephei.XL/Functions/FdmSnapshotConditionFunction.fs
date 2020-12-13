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
module FdmSnapshotConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmSnapshotCondition_applyTo", Description="Create a FdmSnapshotCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSnapshotCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSnapshotCondition",Description = "FdmSnapshotCondition")>] 
         fdmsnapshotcondition : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSnapshotCondition = Helper.toCell<FdmSnapshotCondition> fdmsnapshotcondition "FdmSnapshotCondition"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSnapshotConditionModel.Cast _FdmSnapshotCondition.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : FdmSnapshotCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmSnapshotCondition.source + ".ApplyTo") 

                                               [| _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSnapshotCondition.cell
                                ;  _o.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSnapshotCondition", Description="Create a FdmSnapshotCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSnapshotCondition_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmSnapshotCondition 
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSnapshotCondition>) l

                let source () = Helper.sourceFold "Fun.FdmSnapshotCondition" 
                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSnapshotCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSnapshotCondition_getTime", Description="Create a FdmSnapshotCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSnapshotCondition_getTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSnapshotCondition",Description = "FdmSnapshotCondition")>] 
         fdmsnapshotcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSnapshotCondition = Helper.toCell<FdmSnapshotCondition> fdmsnapshotcondition "FdmSnapshotCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSnapshotConditionModel.Cast _FdmSnapshotCondition.cell).GetTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmSnapshotCondition.source + ".GetTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSnapshotCondition.cell
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
    [<ExcelFunction(Name="_FdmSnapshotCondition_getValues", Description="Create a FdmSnapshotCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSnapshotCondition_getValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSnapshotCondition",Description = "FdmSnapshotCondition")>] 
         fdmsnapshotcondition : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSnapshotCondition = Helper.toCell<FdmSnapshotCondition> fdmsnapshotcondition "FdmSnapshotCondition"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSnapshotConditionModel.Cast _FdmSnapshotCondition.cell).GetValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmSnapshotCondition.source + ".GetValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSnapshotCondition.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSnapshotCondition> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmSnapshotCondition_Range", Description="Create a range of FdmSnapshotCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSnapshotCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmSnapshotCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FdmSnapshotCondition> (c)) :> ICell
                let format (i : Cephei.Cell.List<FdmSnapshotCondition>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FdmSnapshotCondition>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
