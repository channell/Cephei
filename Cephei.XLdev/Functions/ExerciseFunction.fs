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
  Base exercise class
  </summary> *)
[<AutoSerializable(true)>]
module ExerciseFunction =

    (*
        inspectors
    *)
    [<ExcelFunction(Name="_Exercise_date", Description="Create a Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Exercise",Description = "Reference to Exercise")>] 
         exercise : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Exercise = Helper.toCell<Exercise> exercise "Exercise" true 
                let _index = Helper.toCell<int> index "index" true
                let builder () = withMnemonic mnemonic ((_Exercise.cell :?> ExerciseModel).Date
                                                            _index.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Exercise.source + ".Date") 
                                               [| _Exercise.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Exercise.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_Exercise_dates", Description="Create a Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Exercise",Description = "Reference to Exercise")>] 
         exercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Exercise = Helper.toCell<Exercise> exercise "Exercise" true 
                let builder () = withMnemonic mnemonic ((_Exercise.cell :?> ExerciseModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Exercise.source + ".Dates") 
                                               [| _Exercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Exercise.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        constructor
    *)
    [<ExcelFunction(Name="_Exercise", Description="Create a Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "Reference to Type")>] 
         Type : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<Type> Type "Type" true
                let builder () = withMnemonic mnemonic (Fun.Exercise 
                                                            _Type.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Exercise>) l

                let source = Helper.sourceFold "Fun.Exercise" 
                                               [| _Type.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Exercise_lastDate", Description="Create a Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_lastDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Exercise",Description = "Reference to Exercise")>] 
         exercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Exercise = Helper.toCell<Exercise> exercise "Exercise" true 
                let builder () = withMnemonic mnemonic ((_Exercise.cell :?> ExerciseModel).LastDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Exercise.source + ".LastDate") 
                                               [| _Exercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Exercise.cell
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
    [<ExcelFunction(Name="_Exercise_type", Description="Create a Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Exercise",Description = "Reference to Exercise")>] 
         exercise : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Exercise = Helper.toCell<Exercise> exercise "Exercise" true 
                let builder () = withMnemonic mnemonic ((_Exercise.cell :?> ExerciseModel).Type
                                                       ) :> ICell
                let format (o : Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Exercise.source + ".TYPE") 
                                               [| _Exercise.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Exercise.cell
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
    [<ExcelFunction(Name="_Exercise_Range", Description="Create a range of Exercise",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Exercise_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Exercise")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Exercise> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Exercise>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Exercise>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Exercise>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
